/**********************************************
* Author       : Rambabu Sapa PCCTG 
* Date         :06/09/2015
* Description  : Data Sales Data Helper 
**********************************************/

namespace NHSalesScheduler
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DataHelper
    {
        static bool _writeConsole = ConfigurationManager.AppSettings["WriteToConsole"].ToBoolean();
        static string _MessageWriter = ConfigurationManager.AppSettings["MessageWriter"].ToStr();
        public static bool IsDebug = System.Configuration.ConfigurationManager.AppSettings["IsDebug"].ToBoolean();

        public static DataSet dsliendetails = new DataSet();
        public static DataSet dsfilingdetails = new DataSet();
        public static DataSet dsdebtor = new DataSet();
        public static DataSet dsFilingAmendments = new DataSet();
        public static DataSet dssecuredparty = new DataSet();
        public static DataSet dscollaterals = new DataSet();
        public static DataSet dsFSAProducts = new DataSet();
        public static DataSet dsfederaljudgment = new DataSet();
        public static DataSet dsfederaltaxserialno = new DataSet();
        public static DataSet dsmslinfo = new DataSet();
        public static DataSet dsucccorrection = new DataSet();
        public static DataSet dsasl1collaterals = new DataSet();
        public static DataSet dsasl2collaterals = new DataSet();
        public static DataSet dsasl3collaterals = new DataSet();
        public static DataSet dsasl5collaterals = new DataSet();
        public static DataSet dsstatetaxcollateral = new DataSet();

        #region Data Sale StartUp Report

        public static void GenerateDataSaleStartUpRepots(DateTime fromdate, DateTime todate, bool _writetoDatabase)
        {

            //string LienTypeId = ((int)LookUpConsts.LienType.UCCLien).ToStr() + ',' + ((int)LookUpConsts.LienType.UCCTransamittingUtility).ToStr() + ',' + ((int)LookUpConsts.LienType.UCCCNSLien).ToStr();
            //string IndexTypeId = ((int)LookUpConsts.UCCIndexType.UCCLienIndex).ToStr();

            List<string> files = new List<string>();
            int filingcount = 0;
            string filesize = "";
            string DataFilePath = string.Empty;

            try
            {      

                //Filings

                if (_writeConsole)
                {
                    Console.WriteLine("Generating Filing Details for Data Sale Start Up Filing Data Reports");
                }

                DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.FilingDetail;

                filingcount = DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCFILING, ref  files);
                

                if (_writeConsole)
                {
                    Console.WriteLine("Generated Filing Details for Data Sale Start Up Filing Data Reports");
                }

                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("Generated Filing Details for Data Sale Start Up Filing Data Reports");
                }


                //Filing Amendments


                if (_writeConsole)
                {
                    Console.WriteLine("Generating Filing Details for Data Sale Start Up Filing Amendments Reports");
                }

                DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.FilingAmendments;

                filingcount = DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCFILING_AMEDNMENTS, ref  files);


                if (_writeConsole)
                {
                    Console.WriteLine("Generated Filing Details for Data Sale Start Up Filing Amendments Reports");
                }

                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("Generated Filing Details for Data Sale Start Up Filing Amendments Reports");
                }


                //Debtors

                if (_writeConsole)
                {
                    Console.WriteLine("Generating Filing Details for Data Sale Start Up Debtor Reports");
                }

                DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.Debtors;

                filingcount = DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_DEBTORS, ref  files);


                if (_writeConsole)
                {
                    Console.WriteLine("Generated Filing Details for Data Sale Start Up Debtor Reports");
                }

                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("Generated Filing Details for Data Sale Start Up Debtor Reports");
                }


                //Secured Parties

                if (_writeConsole)
                {
                    Console.WriteLine("Generating Filing Details for Data Sale Start Up Secured Party Reports");
                }

                DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.SecuredParty;

                filingcount = DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_SECUREDPARTIES, ref  files);


                if (_writeConsole)
                {
                    Console.WriteLine("Generated Filing Details for Data Sale Start Up Secured Party Reports");
                }

                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("Generated Filing Details for Data Sale Start Up Secured Party Reports");
                }

                if (IsDebug)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Environment.NewLine);
                    sb.Append("Generated Filing Details for Data Sale Start Up Filing Data Reports");
                    sb.Append("*****************************");
                    ExceptionLog.Write(new Exception(), sb.ToStr());
                }


                string ContentTypes = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.ContentType;
                byte[] array = File.ReadAllBytes(ConfigurationManager.AppSettings["ContentType"].ToStr(true));
                System.IO.File.WriteAllBytes(ContentTypes, array);
                files.Add(ContentTypes);

                string UCCDataExport = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.UCCDataExport;
                byte[] dataExportArray = File.ReadAllBytes(ConfigurationManager.AppSettings["UCCDataExport"].ToStr(true));
                System.IO.File.WriteAllBytes(UCCDataExport, dataExportArray);
                files.Add(UCCDataExport);

                string SqlScripts = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.SqlScripts;
                byte[] arraySqlScripts = File.ReadAllBytes(ConfigurationManager.AppSettings["SqlScripts"].ToStr(true));
                System.IO.File.WriteAllBytes(SqlScripts, arraySqlScripts);
                files.Add(SqlScripts);


                filesize = Helper.CreateArchive(WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleStartUpFilingDataZipFile, WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate), files);
                if (_writetoDatabase)
                {//Insert DataSale - UCCDatabaseRefresh
                    DataSalesContext.InsertDataSalesScheduler(DateTime.Now.Month, DateTime.Now.Year, Path.Combine(WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleStartUpFilingDataZipFile), (int)LookUpConsts.DataSalesType.UCCDataSaleStartUp, filingcount, fromdate, todate, filesize, true, false);
                }


                // For Image Data 
                //DateTime lastdbrundate = "11/30/2015".ToDateTime();
                List<ImageFiles> FilingImagesList = DataSalesContext.GetFilingImagesList(fromdate, todate);
                List<string> ImageFiles = new List<string>();

                foreach (var filepath in FilingImagesList)
                {
                    Copy(filepath.FileLocation, WebDirectoryHelper.DataSales.DataSalesStartUpPathImageData(fromdate), filepath.FilingNo, ref ImageFiles);
                }

                if (ImageFiles.Count > 0)
                {
                    filesize = Helper.CreateArchive(WebDirectoryHelper.DataSales.DataSalesStartUpPathImageData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleStartUpImageDataZipFile, WebDirectoryHelper.DataSales.DataSalesStartUpPathImageData(fromdate), ImageFiles);
                    if (_writetoDatabase)
                    {//Insert DataSale - ImageData Report Type
                        DataSalesContext.InsertDataSalesScheduler(DateTime.Now.Month, DateTime.Now.Year, Path.Combine(WebDirectoryHelper.DataSales.DataSalesStartUpPathImageData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleStartUpImageDataZipFile), (int)LookUpConsts.DataSalesType.UCCDataSaleStartUp, ImageFiles.Count, fromdate, todate, filesize, false, true);
                    }
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated Data Sale Start Up Imaga Data Reports");
                    }
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated Data Sale Start Up Imaga Data Reports");
                    }
                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Data Sale Start Up Imaga Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }
                else
                {
                    if (_writeConsole)
                    {
                        Console.WriteLine("Not able to generate  Data Sale Start Up Imaga Data Reports");
                    }
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Not able to generate  Data Sale Start Up Imaga Data Reports");
                    }
                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Not able to generate Data Sale Start Up Imaga Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }



            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
        }

        #endregion

        #region Data Sales Weekly Update Report

        public static void GenerateDataSaleWeeklyUpdateReport(DateTime fromdate, DateTime todate, bool _writetoDatabase)
        {
            //Debtor
            if (_writeConsole)
            {
                Console.WriteLine("Getting Debtor Details for Data Sale Weekly Update Filing Data Reports");
            }

            dsdebtor = DataSalesContext.GetUCCDebtors(fromdate, todate);// debtor 

            ClearLine();

            //Filing Amendments
            if (_writeConsole)
            {
                Console.WriteLine("Getting Filing Amendment Details For a week");
            }

            dsFilingAmendments = DataSalesContext.GetUCCFilingAmendments(fromdate, todate);// debtor 
            ClearLine();

            // UCC Filing Details
            if (_writeConsole)
            {
                Console.WriteLine("Getting Filing Details for Data Sale Weekly Update Filing Data Reports");
            }

            dsfilingdetails = DataSalesContext.GetUCCFilingDetails(fromdate, todate);// Filing 
            ClearLine();

            // Secured Party
            if (_writeConsole)
            {
                Console.WriteLine("Getting SecuredParty Details for Data Sale Weekly Update Filing Data Reports");
            }

            dssecuredparty = DataSalesContext.GetUCCSecuredParty(fromdate, todate);//SecuredParty
            ClearLine();


            /*
            if (_writeConsole)
            {
                Console.WriteLine("Getting FSA Product Details for Data Sale Weekly Update Filing Data Reports");
            }
            dsFSAProducts = DataSalesContext.GetFSAProducts(fromdate, todate);//FSAProducts

            ClearLine();
         
            if (_writeConsole)
            {
                Console.WriteLine("Getting Lien Details for Data Sale Weekly Update Filing Data Reports");
            }
            dsliendetails = DataSalesContext.GetUCCLienDetail(fromdate, todate);// Lien Details 
            ClearLine();
            */

            List<string> files = new List<string>();
            int filingcount = dsfilingdetails.Tables[0].Rows.Count;
            string filesize = "";
            try
            {

                if (dsdebtor != null && dsdebtor.Tables.Count > 0)
                {
                    // debtor 
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating Debtor Details for Data Sale Weekly Update Filing Data Reports");
                    }

                    string DataFilePath = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.Debtors;
                    System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsdebtor.Tables[0]));
                    files.Add(DataFilePath);
                    ClearLine();

                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated Debtor Details for Data Sale Weekly Update Filing Data Reports");
                    }

                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated Debtor Details for Data Sale Weekly Update Filing Data Reports");
                    }

                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Debtor Details for Data Sale Weekly Update Filing Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }

                if (dsFilingAmendments != null && dsFilingAmendments.Tables.Count > 0)
                {
                    // Amendments 
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating Filing Amendment Details for a week");
                    }

                    string DataFilePath = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.FilingAmendments;
                    System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsFilingAmendments.Tables[0]));
                    files.Add(DataFilePath);

                    ClearLine();

                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating Filing Amendment Details for a week");
                    }

                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generating Filing Amendment Details for a week");
                    }

                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Filing Amendment Details  for Data Sale Weekly Update Filing Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }


                if (dsfilingdetails != null && dsfilingdetails.Tables.Count > 0)
                {// Filings 
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating Filing Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    string DataFilePath = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.FilingDetail;
                    System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsfilingdetails.Tables[0]));
                    files.Add(DataFilePath);
                    ClearLine();
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated Filing Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated Filing Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Filing Details for Data Sale Weekly Update  Filing Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }

                if (dssecuredparty != null && dssecuredparty.Tables.Count > 0)
                {
                    // SecuredParty 
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating Secured Party Details for  Sale Weekly Update Filing Data Reports");
                    }

                    string DataFilePath = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.SecuredParty;

                    System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dssecuredparty.Tables[0]));

                    files.Add(DataFilePath);

                    ClearLine();

                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated Secured Party Details for Data Sale Weekly Update Filing Data Reports");
                    }

                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated Secured Party Details for Data Sale Weekly Update Filing Data Reports");
                    }

                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Secured Party Details for Data Sale Weekly Update Filing Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }


                #region Un Used Code
                /*
                if (dsliendetails != null && dsliendetails.Tables.Count > 0)
                {
                    // Lien 
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating Lien Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    string DataFilePath = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.LienDetail;
                    System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsliendetails.Tables[0]));
                    files.Add(DataFilePath);
                    ClearLine();
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated Lien Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated Lien Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Lien Details for Data Sale Weekly Update Filing Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }

                if (dscollaterals != null && dscollaterals.Tables.Count > 0)
                {//Collaterals
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating UCC Collateral Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    string DataFilePath = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.UCCCollateral;
                    System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dscollaterals.Tables[0]));
                    files.Add(DataFilePath);
                    ClearLine();
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated UCC Collateral Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated UCC Collateral Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated UCC Collateral Details for UCC Data Sale Weekly Update Filing Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }


                if (dsFSAProducts != null && dsFSAProducts.Tables.Count > 0)
                {//Collaterals
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating  FSAProducts Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    string DataFilePath = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.FSAProducts;
                    System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsFSAProducts.Tables[0]));
                    files.Add(DataFilePath);
                    ClearLine();
                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated FSAProducts Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated FSAProducts Details for Data Sale Weekly Update Filing Data Reports");
                    }
                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated FSAProducts Details for UCC Data Sale Start Up Filing Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }
                */


                #endregion

                string ContentTypes = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.ContentType;
                byte[] array = File.ReadAllBytes(ConfigurationManager.AppSettings["ContentType"].ToStr(true));
                System.IO.File.WriteAllBytes(ContentTypes, array);
                files.Add(ContentTypes);

                string UCCDataExport = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.UCCDataExport;
                byte[] dataExportArray = File.ReadAllBytes(ConfigurationManager.AppSettings["UCCDataExport"].ToStr(true));
                System.IO.File.WriteAllBytes(UCCDataExport, dataExportArray);
                files.Add(UCCDataExport);

                string SqlScripts = WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate) + WebDirectoryHelper.DataFileNames.SqlScripts;
                byte[] arraySqlScripts = File.ReadAllBytes(ConfigurationManager.AppSettings["SqlScripts"].ToStr(true));
                System.IO.File.WriteAllBytes(SqlScripts, arraySqlScripts);
                files.Add(SqlScripts);

                filesize = Helper.CreateArchive(WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleWeeklyUpdateFilingDataZipFile, WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate), files);

                if (_writetoDatabase)
                {
                    //Insert DataSale - UCCDatabaseRefresh
                    DataSalesContext.InsertDataSalesScheduler(DateTime.Now.Month, DateTime.Now.Year, Path.Combine(WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateFilingData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleWeeklyUpdateFilingDataZipFile), (int)LookUpConsts.DataSalesType.UCCWeeklyUpdateFiles, filingcount, fromdate, todate, filesize, true, false);
                }

                // For Image Data 
                //DataSet dsFilingImages = DataSalesContext.GetFilingImages(fromdate, todate);

                List<ImageFiles> FilingImagesList = DataSalesContext.GetFilingImagesList(fromdate, todate).ToList();

                //List<string> FilingImagesList = new List<string>();
                //FilingImagesList = dsFilingImages.Tables[0].AsEnumerable().Select(r => r.Field<string>("FileLocation")).ToList();
                List<string> ImageFiles = new List<string>();
                foreach (var item in FilingImagesList)
                {
                    Copy(item.FileLocation, WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateImageData(fromdate), item.FilingNo, ref ImageFiles);

                }
                if (ImageFiles.Count > 0)
                {

                    if (_writeConsole)
                    {
                        Console.WriteLine("Generating Data Sale Weekly Update Imaga Data Reports");
                    }

                    filesize = Helper.CreateArchive(WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateImageData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleWeeklyUpdateImageDataZipFile, WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateImageData(fromdate), ImageFiles);

                    if (_writetoDatabase)
                    {//Insert DataSale - ImageData Report Type
                        DataSalesContext.InsertDataSalesScheduler(DateTime.Now.Month, DateTime.Now.Year, Path.Combine(WebDirectoryHelper.DataSales.DataSaleWeeklyUpdateImageData(fromdate), WebDirectoryHelper.ArchiveFileName.DataSaleWeeklyUpdateImageDataZipFile), (int)LookUpConsts.DataSalesType.UCCWeeklyUpdateFiles, ImageFiles.Count, fromdate, todate, filesize, false, true);
                    }

                    if (_writeConsole)
                    {
                        Console.WriteLine("Generated Data Sale Weekly Update Image Data Reports");
                    }

                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Generated Data Sale Weekly Update Imaga Data Reports");
                    }

                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Generated Data Sale Weekly Update Imaga Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }
                else
                {
                    if (_writeConsole)
                    {
                        Console.WriteLine("Not able to generate  Data Sale Weekly Update Imaga Data Reports");
                    }

                    using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                    {
                        writer.WriteLine("Not able to generate  Data Sale Weekly Update Imaga Data Reports");
                    }

                    if (IsDebug)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Environment.NewLine);
                        sb.Append("Not able to generate Data Sale Weekly Update Imaga Data Reports");
                        sb.Append("*****************************");
                        ExceptionLog.Write(new Exception(), sb.ToStr());
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
        }

        #endregion

        public static void Copy(string src, string dest, string FilingNo, ref List<string> ImagePaths)  //Copying OrignalFiles To Reports Path
        {
            try
            {
                if (src.ToStr(true) != string.Empty)
                {
                    String OriginalPath = Path.GetDirectoryName(src);
                    DirectoryInfo ReportsPath = new DirectoryInfo(dest);

                    if (System.IO.File.Exists(src))
                    {
                        if (!System.IO.File.Exists(Path.Combine(dest, Path.GetFileName(src))))  //Copying Filing Images
                        {
                            System.IO.File.Copy(src, Path.Combine(dest, FilingNo.ToStr(true).ToUpper() + Path.GetExtension(src)));
                            ImagePaths.Add(Path.Combine(dest, FilingNo.ToStr(true).ToUpper() + Path.GetExtension(src)));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
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


#region Unnecessary COde

/*
 
 *  // debtor 
                if (_writeConsole)
                {
                    Console.WriteLine("Generating Debtors Details for Data Sale Start Up Filing Data Reports");
                }
                DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.Debtors;

                DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_DEBTORS, ref  files);
                //System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsdebtor.Tables[0]));
                //files.Add(DataFilePath);

                if (_writeConsole)
                {
                    Console.WriteLine("Generated Debtors Details for Data Sale Start Up Filing Data Reports");
                }
                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("Generated Debtors Details for Data Sale Start Up Filing Data Reports");
                }
                if (IsDebug)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Environment.NewLine);
                    sb.Append("Generated Debtors Details for Data Sale Start Up Filing Data Reports");
                    sb.Append("*****************************");
                    ExceptionLog.Write(new Exception(), sb.ToStr());
                }

                // SecuredParty 
                if (_writeConsole)
                {
                    Console.WriteLine("Generating Secured Party Details for UCC Database Refresh Reports...");
                }
                DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.SecuredParty;

                DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_SECUREDPARTIES, ref  files);
                //System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dssecuredparty.Tables[0]));
                //files.Add(DataFilePath);

                if (_writeConsole)
                {
                    Console.WriteLine("Generated Secured Party Details for Data Sale Start Up Filing Data Reports");
                }
                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("Generated Secured Party Details for Data Sale Start Up Filing Data Reports");
                }
                if (IsDebug)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Environment.NewLine);
                    sb.Append("Generated Secured Party Details for Data Sale Start Up Filing Data Reports");
                    sb.Append("*****************************");
                    ExceptionLog.Write(new Exception(), sb.ToStr());
                }

                //Collaterals
                //if (_writeConsole)
                //{
                //    Console.WriteLine("Generating UCC Collateral Details for Data Sale Start Up Filing Data Reports");
                //}
                // DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.UCCCollateral;
                //System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dscollaterals.Tables[0]));
                //files.Add(DataFilePath);

                //if (_writeConsole)
                //{
                //    Console.WriteLine("Generated UCC Collateral Details for Data Sale Start Up Filing Data Reports");
                //}
                //using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                //{
                //    writer.WriteLine("Generated UCC Collateral Details for Data Sale Start Up Filing Data Reports");
                //}
                //if (IsDebug)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    sb.Append(Environment.NewLine);
                //    sb.Append("Generated UCC Collateral Details for UCC Data Sale Start Up Filing Data Reports");
                //    sb.Append("*****************************");
                //    ExceptionLog.Write(new Exception(), sb.ToStr());
                //}


                //FSA products
                if (_writeConsole)
                {
                    Console.WriteLine("Generating  FSAProducts Details for Data Sale Start Up Filing Data Reports");
                }
                DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.FSAProducts;
                //System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsFSAProducts.Tables[0]));
                //files.Add(DataFilePath);
                DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_CNSPRODUCTS, ref  files);
                ClearLine();
                if (_writeConsole)
                {
                    Console.WriteLine("Generated FSAProducts Details for Data Sale Start Up Filing Data Reports");
                }
                using (StreamWriter writer = new StreamWriter(_MessageWriter, true))
                {
                    writer.WriteLine("Generated FSAProducts Details for Data Sale Start Up Filing Data Reports");
                }
                if (IsDebug)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Environment.NewLine);
                    sb.Append("Generated FSAProducts Details for UCC Data Sale Start Up Filing Data Reports");
                    sb.Append("*****************************");
                    ExceptionLog.Write(new Exception(), sb.ToStr());
                }


 */
/*
 
 
 
 * 
                if (_writeConsole)
                {
                    Console.WriteLine("Generating Lien Details for Data Sale Start Up Filing Data Reports");
                }
                string DataFilePath = WebDirectoryHelper.DataSales.DataSalesStartUpPathFilingData(fromdate) + WebDirectoryHelper.DataFileNames.LienDetail;

                DataSalesContext.ConvertDatabaseStartUpsToCSV(fromdate, todate, DataFilePath, DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCLIEN, ref  files);
                // System.IO.File.WriteAllBytes(DataFilePath, CSVConvertor.Convert(dsliendetails.Tables[0]));
                // files.Add(DataFilePath);
 */

#endregion