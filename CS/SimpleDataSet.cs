using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ChartPivotInteractionApproaches
{
    class SimpleDataSet : DataSet 
    {
        public SimpleDataSet()
        {
            DataTable table = new DataTable("table");

            table.Columns.Add("ID", typeof(Int32));
            table.Columns.Add("row1", typeof(string));
            table.Columns.Add("row2", typeof(string));
            table.Columns.Add("row3", typeof(string));
            table.Columns.Add("data1", typeof(double));
            table.Columns.Add("data2", typeof(double));
            table.Columns.Add("data3", typeof(double));
            table.Constraints.Add("IDPK", table.Columns["ID"], true);

            Tables.AddRange(new DataTable[] { table });

            CreateData();
        }

        private void CreateData()
        {
            DataTable table = Tables["table"];

            table.Rows.Add(new object[] { 1, "VINET", "TOMSP", "HANAR", 25, 15, 9 });
            table.Rows.Add(new object[] { 2, "VINET", "TOMSP", "VICTE", 28, 51, 12 });
            table.Rows.Add(new object[] { 3, "VINET", "TOMSP", "SUPRD", 10, 158, 148 });

            table.Rows.Add(new object[] { 4, "VINET", "HANAR", "CHOPS", 52, 24, 83 });
            table.Rows.Add(new object[] { 5, "VINET", "HANAR", "RICSU", 45, 11, 51 });

            table.Rows.Add(new object[] { 6, "WELLI", "HILAA", "CENTC", 13, 32, 23 });
            table.Rows.Add(new object[] { 7, "WELLI", "HILAA", "OTTIK", 56, 67, 26 });
            table.Rows.Add(new object[] { 8, "WELLI", "HILAA", "QUEDE", 171, 120, 14 });

            table.Rows.Add(new object[] { 9, "WELLI", "ERNSH", "RATTC", 81, 62, 8 });
            table.Rows.Add(new object[] { 10, "WELLI", "ERNSH", "ERNSH", 35, 48, 64 });
        }

        #region Disable Serialization for Tables and Relations
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables {
            get { return base.Tables; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations {
            get { return base.Relations; }
        }
        #endregion Disable Serialization for Tables and Relations

    }

}


