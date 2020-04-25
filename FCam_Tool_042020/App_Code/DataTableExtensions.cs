using System.Collections.Generic;
using System.Data;

namespace MapOpennet.App_Code
{
    public static class DataTableExtensions
    {
        public static void SetColumnsName(this DataTable table, List<ModelExportExcel> columnNames)
        {
            int columnIndex = 0;
            foreach (var column in columnNames)
            {
                table.Columns[column.key].SetOrdinal(columnIndex);
                table.Columns[column.key].ColumnName = column.value;
                columnIndex++;
            }
            for (int i = table.Columns.Count - 1; i >= columnNames.Count; i--)
            {
                table.Columns.RemoveAt(i);
            }
        }
    }
}