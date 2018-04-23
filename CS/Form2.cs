using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChartPivotInteractionApproaches
{
    public partial class Form2 : Form
    {
        private DataTable browsableTable;

        public DataTable BrowsableTable
        {
            get { return browsableTable; }
            set
            {
                browsableTable = value;
                dataGridView1.DataSource = value;
                RecalculateActualWidth();
            }
        }
        
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            RecalculateActualWidth();
        }

        private void dataGridView1_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            RecalculateActualWidth();
        }

        private void RecalculateActualWidth()
        {
            int totalWidth = 0;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                totalWidth += col.Width;

            totalWidth += dataGridView1.RowHeadersWidth;

            Width = totalWidth + 60;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //base.OnClosing(e);
            e.Cancel = true;
            Hide();
        }

    }
}