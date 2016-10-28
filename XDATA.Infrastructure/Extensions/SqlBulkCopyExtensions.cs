﻿using System.Data;
using System.Data.SqlClient;

namespace XDATA
{
    public static class SqlBulkCopyExtensions
    {
        public static void MapColumns(this SqlBulkCopy bulk, DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                bulk.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
        }
    }
}
