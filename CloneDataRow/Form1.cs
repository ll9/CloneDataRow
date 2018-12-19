using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloneDataRow
{
    public partial class Form1 : Form
    {
        private DataTable table;

        public Form1()
        {
            InitializeComponent();

            InitializeTable();
            dataGridView1.DataSource = table;
        }

        private void InitializeTable()
        {
            table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name");

            var row = table.NewRow();
            row[0] = 1;
            row[1] = "Peter";
            table.Rows.Add(row);

            var row2 = table.NewRow();
            row2[0] = 2;
            row2[1] = "Hans";
            table.Rows.Add(row2);

            var row3 = table.NewRow();
            row3[0] = 3;
            row3[1] = "Jens";
            table.Rows.Add(row3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var row = table.Rows[1];
            var newRow = table.NewRow();

            foreach (var columnName in row.Table.Columns.Cast<DataColumn>().Select(col => col.ColumnName))
            {
                // if columnName == idcolumn create new guid...
                newRow[columnName] = row[columnName];
            }

            table.Rows.InsertAt(newRow, table.Rows.IndexOf(row));
        }
    }
}
