
namespace Helper
{
    using System;
    using System.IO;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    public static class ExceptionLog
    {
        #region Properties

        private static string ErrorLogFilePath
        {
            get
            {
              
                return ConfigurationManager.AppSettings["ErrorLogPath"].ToString();
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Log SQLClient Exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="paramsCollection"></param>
        public static void Write(SqlException exception, SqlCommand sqlCmd)
        {
            string additionalInfo = "";

            additionalInfo += "\n~~~~~~~~~~~~~~~~~~~~~~~\nSql Command Information";
            additionalInfo += "\n~~~~~~~~~~~~~~~~~~~~~~~";
            additionalInfo += "\n\tCommandText : " + sqlCmd.CommandText;
            additionalInfo += "\n\tCommandType : " + sqlCmd.CommandType.ToString();

            if (sqlCmd.Parameters.Count != 0)
                additionalInfo += "\n----------------\nParameters\n----------------";

            foreach (SqlParameter param in sqlCmd.Parameters)
            {
                if (param.Direction != ParameterDirection.Output && param.Direction != ParameterDirection.InputOutput && param.Direction != ParameterDirection.ReturnValue)
                {
                    if (param.Value != null && param.Value != DBNull.Value)
                        additionalInfo += "\n\t" + param.ParameterName + " = " + param.Value.ToString();
                    else
                        additionalInfo += "\n\t" + param.ParameterName + " = NULL ";
                }
            }

            LogException(exception, additionalInfo, ErrorLogFilePath);
        }

        /// <summary>
        /// Log Exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="additionalInfo"></param>
        public static void Write(Exception exception, string additionalInfo)
        {
            try
            {
                if (additionalInfo == null) additionalInfo = "";
                LogException(exception, additionalInfo, ErrorLogFilePath);
            }
            catch { }
        }
        #endregion

        #region Private Methods

        private static void LogException(Exception exception, string additionalInfo, string errorLogPath)
        {


            System.IO.StreamWriter sw = null;
            try
            {
                DirectoryInfo dirErrorLog = new DirectoryInfo(errorLogPath);
                if (!dirErrorLog.Exists)
                {
                    dirErrorLog.Create();
                }

                System.IO.FileStream fs;
                fs = new System.IO.FileStream(errorLogPath + "\\" + DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "") + ".log", System.IO.FileMode.Append, System.IO.FileAccess.Write);
                sw = new System.IO.StreamWriter(fs);

                if (exception is SqlException)
                    WriteSqlException((SqlException)exception, sw, additionalInfo);
                else
                    WriteException((Exception)exception, sw, additionalInfo);

                sw.Close();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        private static void WriteException(Exception myError, StreamWriter sw, string additionalInfo)
        {
            sw.Write("\n");
            sw.WriteLine("DateTime    : " + DateTime.Now.ToString());
            sw.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            sw.WriteLine(additionalInfo);
            sw.Write("\n");
            sw.WriteLine("Source      : " + myError.Source);
            sw.WriteLine("Exception   : " + myError.ToString());
            sw.Write("\n");
            sw.WriteLine("   StackTrace: " + Convert.ToString(myError.StackTrace));
            sw.Write("\n");
            if (myError.InnerException != null)
            {
                sw.WriteLine("Inner Exception : ");
                sw.Write(myError.InnerException);
            }
            sw.Write("\n\n===============================================================================================\n\n");

        }
        private static void WriteSqlException(SqlException myError, StreamWriter sw, string additionalInfo)
        {
            sw.Write("\n");
            sw.WriteLine("DateTime    : " + DateTime.Now.ToString());
            sw.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            sw.WriteLine(additionalInfo);
            sw.Write("\n");
            sw.WriteLine("\tServer      : " + myError.Server);
            sw.WriteLine("\tSource      : " + myError.Source);
            sw.WriteLine("\tLine Number : " + myError.LineNumber);
            sw.WriteLine("\tMessage     : " + myError.Message);
            sw.Write("\n");
            sw.WriteLine("Exception   : " + myError.ToString());
            sw.Write("\n");
            sw.WriteLine("  StackTrace : " + Convert.ToString(myError.StackTrace));
            sw.Write("\n");
            if (myError.InnerException != null)
            {
                sw.WriteLine("Inner Exception : ");
                sw.Write(myError.InnerException);
            }

            sw.Write("\n\n===============================================================================================\n\n");

        }
        private static string GetTodayDate()
        {
            return DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString();

        }
        /// <summary>
        /// Based on File size generate file Name
        /// </summary>
        /// <param name="dirPath">directory path</param>
        /// <param name="type">typeoflog</param>
        /// <returns>fileName</returns>
        private static string LogFileName(string dirPath)
        {
            string fileName = "";
            string filePath = "";
            long len = 0;
            string[] files = Directory.GetFiles(dirPath, "*.log");

            int count = files.Length;
            if (count > 0)
            {
                filePath = files[count - 1];
                FileInfo fi = new FileInfo(filePath);

                len = fi.Length;
            }
            else
                count = 1;

            return fileName;
        }

        #endregion
    } // End of ExceptionLog 
}
