using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraCharts;
using DevExpress.XtraPivotGrid;


namespace ChartPivotInteractionApproaches {
    public partial class Form1 : Form {
        private DataTable intermidiateTable;
        private ChartDataSourceType currentChartDataSourceType;
        private Form2 actualDataTableForm;

        public Form1() {
            InitializeComponent();

            intermidiateTable = new DataTable();
            currentChartDataSourceType = ChartDataSourceType.PivotGrid;
        }

        private void Form1_Load(object sender, EventArgs e) {
            pivotGridControl1.CollapseAll();
            chartControl1.Series.Clear();
            InitializeMenuItemsState();

            TransferData(currentChartDataSourceType);

            actualDataTableForm = new Form2();

            actualDataTableForm.BrowsableTable = intermidiateTable;
            actualDataTableForm.Owner = this;
            actualDataTableForm.Show();

            this.Location = new Point(0, 0);
            actualDataTableForm.Location = new Point(this.Width, 0);
        }

        private void InitializeMenuItemsState() {
            chartDataVerticalToolStripMenuItem.Checked = 
                pivotGridControl1.OptionsChartDataSource.ProvideDataByColumns;
            selectionOnlyToolStripMenuItem.Checked = 
                pivotGridControl1.OptionsChartDataSource.SelectionOnly;

            if (currentChartDataSourceType == ChartDataSourceType.PivotGrid) {
                pivotGridToolStripMenuItem.Checked = true;
                pivotSummaryToolStripMenuItem.Checked = false;
                chartDataVerticalToolStripMenuItem.Enabled = true;
                selectionOnlyToolStripMenuItem.Enabled = true;
            } else if (currentChartDataSourceType == ChartDataSourceType.PivotSummary) {
                pivotGridToolStripMenuItem.Checked = false;
                pivotSummaryToolStripMenuItem.Checked = true;
                chartDataVerticalToolStripMenuItem.Enabled = false;
                selectionOnlyToolStripMenuItem.Enabled = false;
            }
        }

        private void pivotGridControl1_CellSelectionChanged(object sender, EventArgs e) {
            TransferData(currentChartDataSourceType);
        }

        private void pivotGridControl1_CellClick(object sender, PivotCellEventArgs e) {
            TransferData(currentChartDataSourceType);
        }

        private void pivotGridControl1_FieldValueExpanded(object sender, PivotFieldValueEventArgs e) {
            TransferData(currentChartDataSourceType);
        }

        private void pivotGridControl1_FieldValueCollapsed(object sender, PivotFieldValueEventArgs e) {
            TransferData(currentChartDataSourceType);
        }

        private void cbArgVal_SelectedValueChanged(object sender, EventArgs e) {
            BindChartToIntermidiateTable(currentChartDataSourceType);
        }

        #region CoreFunctionality
        public void TransferData(ChartDataSourceType chartDataSourceType) {
            CreateIntermidiateTableSchema(chartDataSourceType);
            FillArgValComboBoxes();
            FillIntermidiateTable(chartDataSourceType);
            BindChartToIntermidiateTable(chartDataSourceType);
        }

        private void CreateIntermidiateTableSchema(ChartDataSourceType chartDataSourceType) {
            PropertyDescriptorCollection columnsInfo = null;

            if (chartDataSourceType == ChartDataSourceType.PivotGrid)
                columnsInfo = ((ITypedList)pivotGridControl1).GetItemProperties(null);
            else if (chartDataSourceType == ChartDataSourceType.PivotSummary)
                columnsInfo = ((ITypedList)pivotGridControl1.CreateSummaryDataSource()).GetItemProperties(null);

            intermidiateTable.Columns.Clear();
            foreach (PropertyDescriptor propertyDescriptor in columnsInfo)
                intermidiateTable.Columns.Add(propertyDescriptor.Name, propertyDescriptor.PropertyType);
        }

        private void FillIntermidiateTable(ChartDataSourceType chartDataSourceType) {
            object realDataSource = null;

            if (chartDataSourceType == ChartDataSourceType.PivotGrid)
                realDataSource = pivotGridControl1;
            else if (chartDataSourceType == ChartDataSourceType.PivotSummary)
                realDataSource = pivotGridControl1.CreateSummaryDataSource();

            intermidiateTable.Rows.Clear();
            for (int i = 0; i < ((IList)pivotGridControl1).Count; i++) {
                DataRow row = intermidiateTable.NewRow();

                foreach (PropertyDescriptor d in ((ITypedList)realDataSource).GetItemProperties(null)) {
                    object value = d.GetValue(((IList)realDataSource)[i]);
                    row[d.Name] = (value != null ? value : DBNull.Value);
                }

                intermidiateTable.Rows.Add(row);
            }
        }

        private void BindChartToIntermidiateTable(ChartDataSourceType chartDataSourceType) {
            chartControl1.DataSource = intermidiateTable;

            if (chartDataSourceType == ChartDataSourceType.PivotGrid) {
                chartControl1.SeriesDataMember = "Series";
                chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments";
                chartControl1.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
            } else if (chartDataSourceType == ChartDataSourceType.PivotSummary) {
                if (cbArgument.Text != null && cbValue.Text != null) {
                    try {
                        chartControl1.Series.Clear();
                        chartControl1.Series.Add(new Series("Series", ViewType.Bar));
                        chartControl1.Series[0].ArgumentDataMember = cbArgument.Text;
                        chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { cbValue.Text });
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            chartControl1.RefreshData();
        }

        private void FillArgValComboBoxes() {
            cbArgument.Items.Clear();
            cbValue.Items.Clear();
            for (int i = 0; i < intermidiateTable.Columns.Count; i++) {
                cbArgument.Items.Add(intermidiateTable.Columns[i].ColumnName);
                cbValue.Items.Add(intermidiateTable.Columns[i].ColumnName);
            }
        }
        #endregion CoreFunctionality

        #region DrillDownFeature
        private void chartControl1_ObjectHotTracked(object sender, HotTrackEventArgs e) {
            if (e.HitInfo.SeriesPoint != null)
                Cursor = System.Windows.Forms.Cursors.Hand;
            else
                Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void chartControl1_ObjectSelected(object sender, HotTrackEventArgs e) {
            SeriesPoint seriesPoint = e.HitInfo.SeriesPoint;

            if (seriesPoint != null) {
                string[] values = seriesPoint.Argument.ToString().Split(new string[] { " | " }, StringSplitOptions.None);
                List<PivotGridField> fields = new List<PivotGridField>();

                pivotGridControl1.CollapseAll();
                //return;
                foreach (PivotGridField pivotGridField in pivotGridControl1.Fields) {
                    if (pivotGridField.Area == PivotArea.RowArea || pivotGridField.Area == PivotArea.ColumnArea) {
                        fields.Add(pivotGridField);
                    }
                }

                // Expand field values
                for (int i = 0; i < values.Length; i++) {
                    PivotGridField fieldToExpand = GetFieldByAreaIndex(fields, i);

                    if (fieldToExpand == null)
                        continue;

                    if (Microsoft.VisualBasic.Information.IsNumeric(values[i])) {
                        if (fieldToExpand.DataType == typeof(Int32)) {
                            fieldToExpand.ExpandValue(Int32.Parse(values[i]));
                        } else if (fieldToExpand.DataType == typeof(Double)) {
                            fieldToExpand.ExpandValue(Double.Parse(values[i]));
                        }
                    } else if (Microsoft.VisualBasic.Information.IsDate(values[i])) {
                        fieldToExpand.ExpandValue(DateTime.Parse(values[i]));
                    } else {
                        fieldToExpand.ExpandValue(values[i].ToString());
                    }
                }
                //return;
                // Make cells selection
                List<Point> selectedCells = new List<Point>();
                int lastIndex = values.Length - 1;

                System.Threading.Thread.Sleep(100);
                for (int i = 0; i < pivotGridControl1.Cells.RowCount; i++) {
                    bool skipFlag = false;
                    for (int j = 0; j < values.Length; j++) {
                        object value = pivotGridControl1.GetFieldValue(GetFieldByAreaIndex(fields, j), i);

                        if (!object.Equals(value, values[j]))
                            skipFlag = true;
                    }

                    if (skipFlag) continue;

                    for (int j = 0; j < pivotGridControl1.Cells.ColumnCount; j++) {
                        selectedCells.Add(new Point(j, i));
                    }
                }

                if (selectedCells.Count != 0) {
                    pivotGridControl1.Cells.FocusedCell = selectedCells[0];
                    pivotGridControl1.Cells.MultiSelection.SetSelection(selectedCells.ToArray());
                }
            }
        }

        private PivotGridField GetFieldByAreaIndex(List<PivotGridField> fields, int areaIndex) {
            foreach (PivotGridField f in fields) {
                if (f.AreaIndex == areaIndex)
                    return f;
            }

            return null;
        }
        #endregion DrillDownFeature

        #region MenuItemsHandling
        private void actualDataTableToolStripMenuItem_Click(object sender, EventArgs e) {
            actualDataTableForm.Show();
        }

        private void selectionOnlyToolStripMenuItem_Click(object sender, EventArgs e) {
            pivotGridControl1.OptionsChartDataSource.SelectionOnly = 
                !pivotGridControl1.OptionsChartDataSource.SelectionOnly;
            TransferData(currentChartDataSourceType);
        }

        private void chartDataVerticalToolStripMenuItem_Click(object sender, EventArgs e) {
            pivotGridControl1.OptionsChartDataSource.ProvideDataByColumns = 
                !pivotGridControl1.OptionsChartDataSource.ProvideDataByColumns;
            TransferData(currentChartDataSourceType);
        }

        private void pivotGridToolStripMenuItem_Click(object sender, EventArgs e) {
            pivotGridToolStripMenuItem.Checked = true;
            pivotSummaryToolStripMenuItem.Checked = false;
            chartDataVerticalToolStripMenuItem.Enabled = true;
            selectionOnlyToolStripMenuItem.Enabled = true;
            cbArgument.Enabled = false;
            cbValue.Enabled = false;
            currentChartDataSourceType = ChartDataSourceType.PivotGrid;
            TransferData(currentChartDataSourceType);
        }

        private void pivotSummaryToolStripMenuItem_Click(object sender, EventArgs e) {
            pivotSummaryToolStripMenuItem.Checked = true;
            pivotGridToolStripMenuItem.Checked = false;
            chartDataVerticalToolStripMenuItem.Enabled = false;
            selectionOnlyToolStripMenuItem.Enabled = false;
            cbArgument.Enabled = true;
            cbValue.Enabled = true;
            currentChartDataSourceType = ChartDataSourceType.PivotSummary;
            TransferData(currentChartDataSourceType);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        #endregion MenuItemsHandling
    }

    public enum ChartDataSourceType {
        PivotGrid = 0,
        PivotSummary = 1
    }

}