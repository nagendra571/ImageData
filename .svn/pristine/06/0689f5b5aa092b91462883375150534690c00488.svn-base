/**********************************************
* Author       : Rambabu Sapa PCCTG 
* Date         :06/09/2015
* Description  : Helpers 
**********************************************/
namespace Helper
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Data.SqlClient;
    using System.IO.Compression;
    using System.Data;
    using System.Text;
    public class Helper
    {
        #region Get Week Number Of The Year
        /// <summary>
        ///  Get The Week Number of The Year 
        /// </summary>
        /// <param name="DatePassed"></param>
        /// <returns></returns>
        public static int GetWeekNumberOfYear(DateTime DatePassed)
        {
            int WeekNumber = 0;
            try
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                WeekNumber = ciCurr.Calendar.GetWeekOfYear(DatePassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, " Get Week Number of The Year ");
            }
            return WeekNumber;
        }
        #endregion Get Week Number Of The Year

        #region GetWeek Number In Month

        /// <summary>
        /// Get Week Number of The Month 
        /// </summary>
        /// <param name="capturedDate"></param>
        /// <returns></returns>
        public static int GetWeekNumberOfMonth(DateTime capturedDate)
        {
            DateTime today = DateTime.Today;
            DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            int day = endOfMonth.Day;

            int mycapturedDay = capturedDate.Day;

            DateTime now = DateTime.Now;
            int count = 0;
            for (int i = 0; i < day; ++i)
            {
                DateTime d = new DateTime(now.Year, now.Month, i + 1);
                //Compare date with sunday
                if (d.DayOfWeek == DayOfWeek.Sunday)
                {
                    count++;
                    if (mycapturedDay == i + 1)
                        break;
                }
            }
            return count;
        }

        #endregion get Week Number in Month

        #region Create ZIP File


        // Returns the human-readable file size for an arbitrary, 64-bit file size
        //  The default format is "0.### XB", e.g. "4.2 KB" or "1.434 GB"
        public static string GetFileSize(long i)
        {
            string sign = (i < 0 ? "-" : "");
            double readable = (i < 0 ? -i : i);
            string suffix;
            if (i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (double)(i >> 50);
            }
            else if (i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (double)(i >> 40);
            }
            else if (i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (double)(i >> 30);
            }
            else if (i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (double)(i >> 20);
            }
            else if (i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (double)(i >> 10);
            }
            else if (i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = (double)i;
            }
            else
            {
                return i.ToString(sign + "0 B"); // Byte
            }
            readable = readable / 1024;

            return sign + readable.ToString("0.### ") + suffix;
        }

        /// <summary>
        /// Creating ZIP Files 
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="_lstDocuments"></param>
        /// <param name="archiveName"></param>
        /// <param name="archivePath"></param>
        /// <returns></returns>
        public static string CreateArchive(string folder,
                string archiveName, string archivePath, IEnumerable<string> files)
        {
            string fileSizeinKBs = "";
            string folderFullPath = Path.GetFullPath(folder);
            archivePath = Path.Combine(archivePath, archiveName);
            if (File.Exists(archivePath))
            {
                File.Delete(archivePath);
            }
            //IEnumerable<string> files = Directory.EnumerateFiles(folder,
            //        "*.*", SearchOption.TopDirectoryOnly);
            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Create))
            {
                foreach (string file in files)
                {

                    try
                    {
                        var addFile = Path.GetFullPath(file);
                        if (addFile != archivePath)
                        {
                            addFile = addFile.Substring(folderFullPath.Length);
                            // Adding File 
                            archive.CreateEntryFromFile(file, addFile);

                        }
                    }
                    catch (IOException exception)
                    {
                        ExceptionLog.Write(exception, "Adding File to ZipArchive ");

                    }

                }
                long fileSize = new System.IO.FileInfo(archivePath).Length;
                fileSizeinKBs = GetFileSize(fileSize);
                DeleteFiles(files);

            }
            return fileSizeinKBs;
        }

        #endregion End Of  Creating Zip File

        #region Insert Scheduler Items
        /// <summary>
        /// Insert The Record After Processing 
        /// </summary>
        /// <param name="WeekOfYear"></param>
        /// <param name="Year"></param>
        /// <param name="DataPath"></param>
        /// <param name="ImagesPath"></param>
        /// <returns></returns>
        public static bool InsertUCCDataSalesScheduler(int WeekOfYear, int Year, string DataPath, string ImagesPath, int FilingsCount, int ImagesCount, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlParameter[] Parm = new SqlParameter[8];
                Parm[0] = new SqlParameter("@WeekOfYear", WeekOfYear);
                Parm[1] = new SqlParameter("Year", Year);
                Parm[2] = new SqlParameter("DataPath", DataPath);
                Parm[3] = new SqlParameter("ImagePath", ImagesPath);
                Parm[4] = new SqlParameter("FilingsCount", FilingsCount);
                Parm[5] = new SqlParameter("ImagesCount", ImagesCount);
                Parm[6] = new SqlParameter("FromDate", FromDate);
                Parm[7] = new SqlParameter("ToDate", ToDate);
                // DbActivity.ExecuteScalar(DBCommands.USP_INSERTUCCDATASALESSCHEDULER, Parm);
                return true;
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, "Insert Data Sales Seheduler ");
                return false;
            }

        } // End of The Inserting 

        #endregion End of Insert Scheduler Items

        /// <summary>
        /// Get  Html string By Data Table 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetHtml(DataTable dt)
        {
            StringBuilder html = new StringBuilder("<table style=\"width:100%;\" border=\"1\" cellpadding=\"3\" cellspacing=\"0\" ><tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                html.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            html.Append("</th></tr>");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                html.Append("<tr style=\"page-break-inside:avoid;\">");
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    string columndata = dt.Rows[j][k].ToStr(true);
                    //if (dt.Rows[j][k].ToString() != null && dt.Rows[j][k].ToString() != "" && !string.IsNullOrEmpty(dt.Rows[j][k].ToStr(true)) && dt.Rows[j][k].ToString() != "  " && dt.Rows[j][k].ToString() != " ")
                    if (columndata != null && columndata != "" && !string.IsNullOrEmpty(columndata) && columndata != "  " && columndata != " " && columndata.Length > 0)
                    {
                        html.Append("<td>" + columndata + "&nbsp;</td>");
                    }
                    else
                    {
                        html.Append("<td>&nbsp;-&nbsp;</td>");
                    }
                }
                html.Append("</tr>");
            }
            html.Append("</table>");

            return html.ToString();
        }

        /// <summary>
        /// Delete Files 
        /// </summary>
        /// <param name="files"></param>
        public static void DeleteFiles(IEnumerable<string> files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
        }

        /// <summary>
        /// returns  File Size in MB by FilePath 
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static double GetFileSizeInMB(string filepath)
        {

            double len = new FileInfo(filepath).Length;
            len = (len / 1024f) / 1024f;
            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            return String.Format("{0:0.##}", len).ToDouble();

        }

    } //  End Of The Class 
}
