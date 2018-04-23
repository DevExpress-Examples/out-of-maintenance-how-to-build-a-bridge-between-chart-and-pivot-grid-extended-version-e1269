namespace ChartPivotInteractionApproaches
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualDataTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartDataVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartDataSourceTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pivotGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pivotSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArgument = new System.Windows.Forms.ComboBox();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.simpleDataSet1 = new ChartPivotInteractionApproaches.SimpleDataSet();
            this.fieldrow1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldrow2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldrow3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fielddata1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fielddata2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fielddata3 = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Range.SideMarginsEnabled = true;
            xyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = true;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Location = new System.Drawing.Point(12, 360);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Chameleon";
            series1.Name = "Series 1";
            sideBySideBarSeriesLabel1.LineVisible = true;
            series1.Label = sideBySideBarSeriesLabel1;
            series2.Name = "Series 2";
            sideBySideBarSeriesLabel2.LineVisible = true;
            series2.Label = sideBySideBarSeriesLabel2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            sideBySideBarSeriesLabel3.LineVisible = true;
            this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel3;
            this.chartControl1.Size = new System.Drawing.Size(628, 234);
            this.chartControl1.TabIndex = 0;
            this.chartControl1.ObjectSelected += new DevExpress.XtraCharts.HotTrackEventHandler(this.chartControl1_ObjectSelected);
            this.chartControl1.ObjectHotTracked += new DevExpress.XtraCharts.HotTrackEventHandler(this.chartControl1_ObjectHotTracked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualDataTableToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // actualDataTableToolStripMenuItem
            // 
            this.actualDataTableToolStripMenuItem.Name = "actualDataTableToolStripMenuItem";
            this.actualDataTableToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.actualDataTableToolStripMenuItem.Text = "Actual DataTable";
            this.actualDataTableToolStripMenuItem.Click += new System.EventHandler(this.actualDataTableToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionOnlyToolStripMenuItem,
            this.chartDataVerticalToolStripMenuItem,
            this.chartDataSourceTypeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // selectionOnlyToolStripMenuItem
            // 
            this.selectionOnlyToolStripMenuItem.CheckOnClick = true;
            this.selectionOnlyToolStripMenuItem.Name = "selectionOnlyToolStripMenuItem";
            this.selectionOnlyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.selectionOnlyToolStripMenuItem.Text = "SelectionOnly";
            this.selectionOnlyToolStripMenuItem.Click += new System.EventHandler(this.selectionOnlyToolStripMenuItem_Click);
            // 
            // chartDataVerticalToolStripMenuItem
            // 
            this.chartDataVerticalToolStripMenuItem.CheckOnClick = true;
            this.chartDataVerticalToolStripMenuItem.Name = "chartDataVerticalToolStripMenuItem";
            this.chartDataVerticalToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.chartDataVerticalToolStripMenuItem.Text = "ChartDataVertical";
            this.chartDataVerticalToolStripMenuItem.Click += new System.EventHandler(this.chartDataVerticalToolStripMenuItem_Click);
            // 
            // chartDataSourceTypeToolStripMenuItem
            // 
            this.chartDataSourceTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pivotGridToolStripMenuItem,
            this.pivotSummaryToolStripMenuItem});
            this.chartDataSourceTypeToolStripMenuItem.Name = "chartDataSourceTypeToolStripMenuItem";
            this.chartDataSourceTypeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.chartDataSourceTypeToolStripMenuItem.Text = "ChartDataSourceType";
            // 
            // pivotGridToolStripMenuItem
            // 
            this.pivotGridToolStripMenuItem.Name = "pivotGridToolStripMenuItem";
            this.pivotGridToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.pivotGridToolStripMenuItem.Text = "PivotGrid";
            this.pivotGridToolStripMenuItem.Click += new System.EventHandler(this.pivotGridToolStripMenuItem_Click);
            // 
            // pivotSummaryToolStripMenuItem
            // 
            this.pivotSummaryToolStripMenuItem.Name = "pivotSummaryToolStripMenuItem";
            this.pivotSummaryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.pivotSummaryToolStripMenuItem.Text = "PivotSummary";
            this.pivotSummaryToolStripMenuItem.Click += new System.EventHandler(this.pivotSummaryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Argument";
            // 
            // cbArgument
            // 
            this.cbArgument.Enabled = false;
            this.cbArgument.FormattingEnabled = true;
            this.cbArgument.Location = new System.Drawing.Point(96, 334);
            this.cbArgument.Name = "cbArgument";
            this.cbArgument.Size = new System.Drawing.Size(121, 21);
            this.cbArgument.TabIndex = 4;
            this.cbArgument.SelectedValueChanged += new System.EventHandler(this.cbArgVal_SelectedValueChanged);
            // 
            // cbValue
            // 
            this.cbValue.Enabled = false;
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(314, 334);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(121, 21);
            this.cbValue.TabIndex = 6;
            this.cbValue.SelectedValueChanged += new System.EventHandler(this.cbArgVal_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Value";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl1.DataMember = "table";
            this.pivotGridControl1.DataSource = this.simpleDataSet1;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldrow1,
            this.fieldrow2,
            this.fieldrow3,
            this.fielddata1,
            this.fielddata2,
            this.fielddata3});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 27);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(628, 300);
            this.pivotGridControl1.TabIndex = 1;
            this.pivotGridControl1.FieldValueCollapsed += new DevExpress.XtraPivotGrid.PivotFieldValueEventHandler(this.pivotGridControl1_FieldValueCollapsed);
            this.pivotGridControl1.FieldValueExpanded += new DevExpress.XtraPivotGrid.PivotFieldValueEventHandler(this.pivotGridControl1_FieldValueExpanded);
            this.pivotGridControl1.CellSelectionChanged += new System.EventHandler(this.pivotGridControl1_CellSelectionChanged);
            this.pivotGridControl1.CellClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl1_CellClick);
            // 
            // simpleDataSet1
            // 
            this.simpleDataSet1.DataSetName = "NewDataSet";
            // 
            // fieldrow1
            // 
            this.fieldrow1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldrow1.AreaIndex = 0;
            this.fieldrow1.Caption = "row1";
            this.fieldrow1.FieldName = "row1";
            this.fieldrow1.Name = "fieldrow1";
            // 
            // fieldrow2
            // 
            this.fieldrow2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldrow2.AreaIndex = 1;
            this.fieldrow2.Caption = "row2";
            this.fieldrow2.FieldName = "row2";
            this.fieldrow2.Name = "fieldrow2";
            // 
            // fieldrow3
            // 
            this.fieldrow3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldrow3.AreaIndex = 2;
            this.fieldrow3.Caption = "row3";
            this.fieldrow3.FieldName = "row3";
            this.fieldrow3.Name = "fieldrow3";
            // 
            // fielddata1
            // 
            this.fielddata1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fielddata1.AreaIndex = 0;
            this.fielddata1.Caption = "data1";
            this.fielddata1.FieldName = "data1";
            this.fielddata1.Name = "fielddata1";
            // 
            // fielddata2
            // 
            this.fielddata2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fielddata2.AreaIndex = 1;
            this.fielddata2.Caption = "data2";
            this.fielddata2.FieldName = "data2";
            this.fielddata2.Name = "fielddata2";
            // 
            // fielddata3
            // 
            this.fielddata3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fielddata3.AreaIndex = 2;
            this.fielddata3.Caption = "data3";
            this.fielddata3.FieldName = "data3";
            this.fielddata3.Name = "fielddata3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 606);
            this.Controls.Add(this.cbValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbArgument);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private SimpleDataSet simpleDataSet1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldrow1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldrow2;
        private DevExpress.XtraPivotGrid.PivotGridField fieldrow3;
        private DevExpress.XtraPivotGrid.PivotGridField fielddata1;
        private DevExpress.XtraPivotGrid.PivotGridField fielddata2;
        private DevExpress.XtraPivotGrid.PivotGridField fielddata3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartDataVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartDataSourceTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pivotGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pivotSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualDataTableToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArgument;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Label label2;
    }
}

