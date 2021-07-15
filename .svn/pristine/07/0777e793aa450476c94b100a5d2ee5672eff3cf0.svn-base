/**********************************************
* Author       : Rambabu Sapa PCCTG 
* Date         :06/09/2015
* Description  : WebDirectoryHelper
**********************************************/

namespace Helper
{
    using System;
    using System.Configuration;
    using System.IO;

    public class WebDirectoryHelper
    {

        /// <summary>
        /// UCC Data Sales File Path 
        /// </summary>
        /// <param name="weekno"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static string UCCDataSalesPath(int weekno, int month, int year)
        {
            DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["DataSalesPath"].ToStr() + year + @"\" + month + @"\WEEK" + weekno.ToInt() + @"\");
            if (!di.Exists)
                di.Create();
            return di.ToStr();
        }

        /// <summary>
        /// UCC Data Sales ZIP Path 
        /// </summary>
        /// <param name="WeekOfYear"></param>
        /// <param name="Year"></param>
        /// <returns></returns>
        public static string UCCDataSalesZipPath(int WeekOfYear, int Year)
        {
            DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["DataSalesPath"].ToStr() + Year + @"\WEEK" + WeekOfYear.ToInt() + @"\");
            if (!di.Exists)
                di.Create();
            return di.ToStr();
        }

        public static class DataFileNames
        {
            public const string Debtors = "Debtors.csv";
            public const string FilingAmendments = "FilingAmendments.csv";
            public const string FilingDetail = "Filings.csv";//FilingDetail
            public const string SecuredParty = "SecuredParties.csv";
            public const string LienDetail = "LienDetail.csv";
            public const string UCCCollateral = "UCCCollateral.csv";
            public const string FSAProducts = "FSAProducts.csv";
            public const string FederaljudgmentInfo = "FederaljudgmentInfo.csv";
            public const string FederalTaxSerialNo = "FederalTaxCollaterals.csv";
            public const string MSLInfo = "MSLInfo.csv";
            public const string UCC5Correction = "UCC5Correction.csv";
            public const string ASL1Collaterals = "ASL1Collaterals.csv";
            public const string ASL2Collaterals = "ASL2Collaterals.csv";
            public const string ASL3Collaterals = "ASL3Collaterals.csv";
            public const string ASL5Collaterals = "ASL5Collaterals.csv";
            public const string StateTaxCollaterals = "StateTaxInfo.csv";

            public const string ContentType = "[Content Type].xml";//
            public const string UCCDataExport = "UCC_Data_Export.txt";//
            public const string SqlScripts = "UCC_Data_Export_Create_SQL_Scripts.txt";//
        }

        public static class ReportFileNames
        {
            public const string LienDetail = "LienDetail.csv";
            public const string FilingDetail = "FilingDetail.csv";
            public const string Debtors = "Debtors.csv";
            public const string SecuredParty = "SecuredParty.csv";
            public const string UCCCollateral = "UCCCollateral.csv";
            public const string CNSCollateral = "CNSCollateral.csv";
            public const string FederaljudgmentInfo = "FederaljudgmentInfo.csv";
            public const string FederalTaxSerialNo = "FederalTaxCollaterals.csv";
            public const string MSLInfo = "MSLInfo.csv";
            public const string UCC5Correction = "UCC5Correction.csv";
            public const string ASL1Collaterals = "ASL1Collaterals.csv";
            public const string ASL2Collaterals = "ASL2Collaterals.csv";
            public const string ASL3Collaterals = "ASL3Collaterals.csv";
            public const string ASL5Collaterals = "ASL5Collaterals.csv";
            public const string StateTaxCollaterals = "StateTaxInfo.csv";

            public const string StateTaxMonthly = "StateTaxMonthlyReport.xlsx";
            public const string StateTaxDaily = "StateTaxDailyReport.xlsx";
            public const string FederalTaxmonthly = "FederalTaxMonthlyReport.xlsx";
            public const string CreditBureauWeekly = "CreditBureauWeeklyReport.xlsx";

        }



        public static class ArchiveFileName
        {

            //Data
            public const string DataSaleStartUpFilingDataZipFile = "DataSaleStartUpFilingData.zip";

            public const string DataSaleStartUpImageDataZipFile = "DataSaleStartUpImageData.zip";

            public const string DataSaleWeeklyUpdateFilingDataZipFile = "DataSaleWeeklyUpdateFilingData.zip";

            public const string DataSaleWeeklyUpdateImageDataZipFile = "DataSaleWeeklyUpdateImageData.zip";
        }

        /// <summary>
        /// Data Sales Path 
        /// </summary>
        public static class DataSales
        {
            public static string DataSalesStartUpPathFilingData(DateTime date)
            {
                DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["DataSaleStartUppath"].ToStr() + date.Year + @"\" + date.Month.ToInt() + @"\" + date.Day + @"\Filing Data\");
                if (!di.Exists)
                    di.Create();
                return di.ToStr();
            }

            public static string DataSalesStartUpPathImageData(DateTime date)
            {
                DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["DataSaleStartUppath"].ToStr() + date.Year + @"\" + date.Month.ToInt() + @"\" + date.Day + @"\Image Data\");
                if (!di.Exists)
                    di.Create();
                return di.ToStr();
            }
            public static string DataSaleWeeklyUpdateFilingData(DateTime date)
            {
                DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["WeeklyDataSalesUpdatePath"].ToStr() + date.Year + @"\" + date.Month.ToInt() + @"\" + date.Day + @"\DataSale Weekly Update FilingData\");
                if (!di.Exists)
                    di.Create();
                return di.ToStr();
            }
            public static string DataSaleWeeklyUpdateImageData(DateTime date)
            {
                DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["WeeklyDataSalesUpdatePath"].ToStr() + date.Year + @"\" + date.Month.ToInt() + @"\" + date.Day + @"\DataSale Weekly Update ImageData\");
                if (!di.Exists)
                    di.Create();
                return di.ToStr();
            }


        }// end Of Data Sales 


    }
}
