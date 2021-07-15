using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Diagnostics;
namespace Helper
{
    public class ExcelConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="dsinput"></param>
        public static void ConvExcel(string Name, DataSet dsinput)
        {
            Application ExcelApp = new Application();
            Workbook ExcelWorkBook = null;
            Worksheet ExcelWorkSheet = null;

            ExcelApp.Visible = false;
            ExcelWorkBook = ExcelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            try
            {
                for (int i = 1; i < dsinput.Tables.Count; i++)
                    ExcelWorkBook.Worksheets.Add(); //Adding New sheet in Excel Workbook

                for (int i = 0; i < dsinput.Tables.Count; i++)
                {
                    int r = 1; // Initialize Excel Row Start Position  = 1

                    ExcelWorkSheet = ExcelWorkBook.Worksheets[i + 1];

                    //Writing Columns Name in Excel Sheet

                    for (int col = 1; col <= dsinput.Tables[i].Columns.Count; col++)
                        ExcelWorkSheet.Cells[r, col] = dsinput.Tables[i].Columns[col - 1].ColumnName;
                    r++;

                    //Writing Rows into Excel Sheet
                    for (int row = 0; row <dsinput.Tables[i].Rows.Count; row++) //r stands for ExcelRow and col for ExcelColumn
                    {
                        // Excel row and column start positions for writing Row=1 and Col=1
                        for (int col = 1; col <= dsinput.Tables[i].Columns.Count; col++)
                            ExcelWorkSheet.Cells[r, col] = dsinput.Tables[i].Rows[row][col - 1].ToString();
                        r++;
                    }
                    ExcelWorkSheet.Name = dsinput.Tables[i].TableName;//Renaming the ExcelSheets
                }

                ExcelWorkBook.SaveAs(Name);
                ExcelWorkBook.Close();
                ExcelApp.Quit();
                Marshal.ReleaseComObject(ExcelWorkSheet);
                Marshal.ReleaseComObject(ExcelWorkBook);
                Marshal.ReleaseComObject(ExcelApp);


            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
            }
            finally
            {

                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
        }

    }// End if the class 
}
