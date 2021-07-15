﻿/**********************************************
* Author       : Rambabu Sapa PCCTG 
* Date         :06/09/2015
* Description  : CSVConvertor
**********************************************/
namespace Helper
{
    using System.Data;
    using System.Text;
    public static class CSVConvertor
    {
        /// <summary>
        /// To Get Export CSV File
        /// </summary>
        /// <param name="oDataTable"></param>
        /// <returns></returns>
        public static byte[] Convert(DataTable oDataTable)
        {
            StringBuilder oStringBuilder = new StringBuilder();

            /*******************************************************************
             * Start, Creating column header
             * *****************************************************************/

            //foreach (DataColumn oDataColumn in oDataTable.Columns)
            //{
            //    var ColumnHeading = "\"" + oDataColumn.ColumnName.ToString() + "\"";
            //    oStringBuilder.Append(ColumnHeading + "|");
            //}

            //oStringBuilder.AppendLine();

            /*******************************************************************
             * End, Creating column header
             * *****************************************************************/

            /*******************************************************************
             * Start, Creating rows
             * *****************************************************************/

            foreach (DataRow oDataRow in oDataTable.Rows)
            {
                foreach (DataColumn oDataColumn in oDataTable.Columns)
                {
                    if (oDataRow[oDataColumn.ColumnName] != null && oDataRow[oDataColumn.ColumnName].ToStr(true) != "")
                    {
                        //var ColumnData = "\"" + oDataRow[oDataColumn.ColumnName].ToString() + "\"";
                        var ColumnData = oDataRow[oDataColumn.ColumnName].ToString();
                        oStringBuilder.Append(ColumnData);
                    }
                    else
                    {
                        var ColumnData = "\"\"";
                        oStringBuilder.Append(ColumnData + "|");
                    }
                }

                oStringBuilder.AppendLine();
            }

            /*******************************************************************
             * End, Creating rows
             * *****************************************************************/

            return System.Text.Encoding.UTF8.GetBytes(oStringBuilder.ToStr());
        }

    } // End of Csv Converter  
}
