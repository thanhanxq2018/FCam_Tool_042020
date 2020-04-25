// ===============================================================================
// <copyright file="ExportExcelHelper.cs" version="4.0" company="FPT Telecom">
// Copyright © 2015-2016 FPT Telecom.
// All rights reserved.
// <author>XuanLT7</author>
// <date>8/4/2016</date>
// </copyright>
// ===============================================================================
using Microsoft.ApplicationBlocks.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace MapOpennet.App_Code
{
    public class ExportExcelHelper
    {
        private static string INFMapConnString = INFMapConnect.sqlConnectString;

        public static byte[] exportDataTableToExcel(string commandText, SqlParameter[] par, List<ModelExportExcel> lstColumn, string sheetName = "Sheet1")
        {
            DataSet ds = SqlHelper.ExecuteDataset(INFMapConnString, CommandType.StoredProcedure, commandText, par);
            DataTable tb = ds.Tables[0];
            tb.SetColumnsName(lstColumn);
            List<int> lstColumnDel = new List<int>();
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetName);

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 2
                ws.Cells[1, 2].LoadFromDataTable(tb, true);
                // Set font size for table
                ws.Cells.Style.Font.Size = 10;

                for (int i = 0; i < lstColumn.Count; i++)
                {
                    switch (lstColumn[i].type)
                    {
                        case "datetime":
                            for (int j = 0; j < tb.Columns.Count; j++)
                            {
                                if (ws.Cells[1, i + 2].Text == lstColumn[i].value)
                                {
                                    ws.Column(i + 2).Style.Numberformat.Format = "dd/MM/yyyy";
                                    ws.Cells[1, i + 2].Worksheet.DefaultColWidth = 20;
                                }
                            }
                            break;

                        case "select":
                            for (int j = 0; j < tb.Rows.Count; j++)
                            {
                                ws.Cells[j + 2, i + 2].Value = lstColumn[i].selectSource[ws.Cells[j + 2, i + 2].Value.ToString()];
                            }
                            break;

                        default:
                            break;
                    }
                }

                // Set Header first column is STT
                ws.Cells[1, 1].Value = "STT";

                // Set Number order
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    ws.Cells[i + 2, 1].Value = i + 1;
                }

                // Set style for header
                using (ExcelRange rng = ws.Cells[1, 1, 1, lstColumn.Count + 1])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.Font.Size = 11;
                }

                // Create border for data in file
                using (ExcelRange rng = ws.Cells[1, 1, tb.Rows.Count + 1, lstColumn.Count + 1])
                {
                    // Assign borders
                    rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                // Auto fit width column
                ws.Cells.AutoFitColumns();

                return pck.GetAsByteArray();
            }
        }

        public static byte[] exportMultiTableToExcel(List<TableExportModel> tables)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet

                foreach (TableExportModel t in tables)
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(t.name);
                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    ws.Cells[1, 1].LoadFromDataTable(t.table, t.printHeader);

                    // Set font size for table
                    ws.Cells.Style.Font.Size = 11;

                    // Set style for header
                    if (t.printHeader)
                    {
                        using (ExcelRange rng = ws.Cells[1, 1, 1, t.table.Columns.Count])
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                            rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                            rng.Style.Font.Color.SetColor(Color.White);
                            rng.Style.Font.Size = 12;
                        }
                    }

                    ws.Cells.AutoFitColumns();
                }
                return pck.GetAsByteArray();
            }
        }
    }

    public class ModelExportExcel
    {
        public string key { get; set; }
        public string value { get; set; }
        public string type { get; set; }

        public Dictionary<string, string> selectSource { get; set; }
    }

    public class TableExportModel
    {
        public string name { get; set; }

        public DataTable table { get; set; }

        public bool printHeader { get; set; }
    }
}