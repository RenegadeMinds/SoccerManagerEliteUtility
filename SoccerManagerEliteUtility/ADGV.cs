using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zuby.ADGV;

namespace SMElite
{
    public class AdgvColumn
    {
        public AdgvColumn(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public AdgvColumn()
        {
            Name = string.Empty;
            Type = null;
        }

        public string Name { get; set; }
        public Type Type { get; set; }
    }


    public class AdgvRow
    {
        public AdgvRow(List<AdgvColumn> columns, List<object> data)
        {
            Columns = columns;
            Data = data;
        }

        public List<AdgvColumn> Columns { get; set; }
        public List<object> Data { get; set; }

        public object[] GetRow()
        {
            return Data.Cast<object>().ToArray(); // new object[Data.Count];            
        }
    }


    public partial class Utilities
    {
        // Here object[rows,columns] should have a string (0) then a type (1)
        public static bool SetGridData(List<AdgvColumn> cols, 
            string name, 
            ref DataTable _dataTable, 
            ref DataSet _dataSet, 
            ref BindingSource bsBinder, 
            ref AdvancedDataGridViewSearchToolBar adgvSearch, 
            ref AdvancedDataGridView adgvReport)
        {
            _dataTable = _dataSet.Tables.Add(name);

            // 
            foreach (var col in cols)
            {
                _dataTable.Columns.Add(col.Name, col.Type);
            }

            bsBinder.DataMember = _dataTable.TableName;
            adgvSearch.SetColumns(adgvReport.Columns);

            return true;
        }

        public static void AddGridData(List<AdgvRow> rows, ref DataTable _dataTable)
        {
            int rowNum = rows.Count;

            // Add rows
            for (int i = 0; i < rowNum; i++)
            {
                _dataTable.Rows.Add(rows[i].GetRow()); // add the row to the datatable
            }
        }


    }
}
