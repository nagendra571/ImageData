﻿/**********************************************
* Author       : 
* Date         :06/09/2015
* Description  : NHCDataSalesScheduler
**********************************************/
namespace NHDataSalesScheduler
{
    using Helper;
    using NHSalesScheduler;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Text;

    public class Program
    {
        static bool _writeConsole = ConfigurationManager.AppSettings["WriteToConsole"].ToBoolean();
        static bool _writetoDatabase = ConfigurationManager.AppSettings["WriteToDatBase"].ToBoolean();
        static string _MessageWriter = ConfigurationManager.AppSettings["MessageWriter"].ToStr();
        public static bool IsDebug = System.Configuration.ConfigurationManager.AppSettings["IsDebug"].ToBoolean();

        static void Main(string[] args)
        {
            if (!File.Exists(_MessageWriter))
            {
                var directoryName = Path.GetDirectoryName(_MessageWriter);
                DirectoryInfo di = new DirectoryInfo(directoryName);
                if (!di.Exists)
                {
                    di.Create();
                }
                System.IO.StreamWriter sw = null;
                System.IO.FileStream fs;
                fs = new System.IO.FileStream(_MessageWriter, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                sw = new System.IO.StreamWriter(fs);
                sw.Close();
            }

            RunDataSalesReports();

            if (_writeConsole)
            {
                //Console.ReadKey();
                Environment.Exit(0);
            }

            //Environment.Exit(0);
        }

        public static bool IsEndOfMonth(DateTime date)
        {
            return date.AddDays(1).Day == 1;
        }

        public static void RunDataSalesReports()
        {
            try
            {
                int DaysBack = ConfigurationManager.AppSettings["Daysback"].ToInt();
                DateTime fromdate = DateTime.Now.AddDays(-DaysBack);  //                 
                DateTime todate = new DateTime();// = DateTime.Now.AddDays(-DaysBack).AddDays(30);// Only Add 30 Days           
                //int FilingsCount = 0; int ImagesCount = 0;


                //if (DateTime.Now.Day == ConfigurationManager.AppSettings["MonthlyGeneratedDate"].ToInt())
                //{
                #region Data Sales Start Up Reports

                if (ConfigurationManager.AppSettings["GenerateDataSaleStartUp"].ToBoolean() == true)
                {
                    DateTime Startdate = ConfigurationManager.AppSettings["FromDate"].ToDateTime();
                    todate = DateTime.Now.GetWeekStartDate();
                    DataHelper.GenerateDataSaleStartUpRepots(Startdate, todate, _writetoDatabase);
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated Data Sale StartUp Data from " + Startdate.ToShortDateString() + " to " + todate.ToShortDateString());
                        writer.WriteLine("*****************************");
                    }

                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated Data Sale StartUp  Data from " + Startdate.ToShortDateString() + " to " + todate.ToShortDateString());
                        Console.WriteLine("*****************************");
                    }
                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Data Sale StartUp  Data from " + Startdate.ToShortDateString() + " to " + todate.ToShortDateString());
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }

                }
                #endregion

                #region  DataSale Weekly Update

                if (ConfigurationManager.AppSettings["GenerateDataSaleWeeklyUpdate"].ToBoolean() == true)
                {
                    while (fromdate.AddDays(6) <= DateTime.Now.GetWeekStartDate())
                    {
                        todate = fromdate.AddDays(6);

                        DataHelper.GenerateDataSaleWeeklyUpdateReport(fromdate, fromdate.AddDays(6), _writetoDatabase);

                        using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                        {
                            writer.WriteLine("Generated Data Sale Weekly Update from " + fromdate.ToShortDateString() + " to " + todate.ToShortDateString());
                            writer.WriteLine("*****************************");
                        }

                        if (_writeConsole)
                        {
                            Console.WriteLine("Generated Data Sale Weekly Update from " + fromdate.ToShortDateString() + " to " + todate.ToShortDateString());
                            Console.WriteLine("*****************************");
                        }

                        if (IsDebug)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(Environment.NewLine);
                            sb.Append("Generated Data Sale Weekly Update from " + fromdate.ToShortDateString() + " to " + todate.ToShortDateString());
                            sb.Append("*****************************");
                            ExceptionLog.Write(new Exception(), sb.ToStr());
                        }

                        fromdate = fromdate.AddDays(7);
                    }
                }

                //  }

                #endregion

                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("*****************************");
                    writer.WriteLine("No Data Imported");
                    writer.WriteLine("From Date: " + fromdate.ToShortDateString());
                    writer.WriteLine("To Date: " + todate.ToShortDateString());

                    writer.WriteLine("*****************************");
                    writer.Close();
                }

                if (_writeConsole)
                {
                    Console.WriteLine("No Data Imported " + DateTime.Now.ToLongTimeString());
                    Console.WriteLine("From Date: " + fromdate.ToShortDateString());
                    Console.WriteLine("To Date: " + todate.ToShortDateString());
                }

                /* Database Insert of Filing Count and Image Count , Week Number and FileLocation */
                if (ConfigurationManager.AppSettings["WriteToDatBase"].ToBoolean())
                {
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        //DataSalesContext.InsertDataSalesScheduler(DateTime.Now.Month,DateTime.Now.Year,WebDirectoryHelper.ReportSales.UCCMonthly(fromdate)+"",0,dsfilingdetails.Tables[0].Rows.Count,fromdate,toDate);
                        //Helper.InsertUCCDataSalesScheduler(Helper.GetWeekNumberOfYear(fromdate), fromdate.Year, ZipDataPath + "Data.zip", ZipImagesPath + "Images.zip", FilingsCount, ImagesCount, fromdate, toDate);
                        writer.WriteLine("No Data Imported " + DateTime.Now.ToLongTimeString());
                        writer.WriteLine("*****************************");
                    }

                    if (_writeConsole)
                    {
                        Console.WriteLine("DataBase Insert Successful On " + DateTime.Now.ToLongTimeString());
                        Console.WriteLine("*****************************");
                    }

                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("DataBase Insert Successful On " + DateTime.Now.ToLongTimeString());
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
                ExceptionLog.Write(exception, "UCC Data Sales Generation");
            }
        }

        public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
