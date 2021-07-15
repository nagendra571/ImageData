﻿/**********************************************
* Author       : Rambabu Sapa PCCTG 
* Date         :06/09/2015
* Description  : Data Context 
**********************************************/

namespace Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.IO;

    public class DataSalesContext
    {

        public static int ConvertDatabaseStartUpsToCSV(DateTime FromDate, DateTime ToDate, string filepath, string proc, ref List<string> files)
        {
            //  Stopwatch swra = new Stopwatch();

            string NewconnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            StreamWriter CsvfileWriter = new StreamWriter(filepath);
            string sqlselectQuery = proc;
            SqlCommand sqlcmd = new SqlCommand();

            SqlConnection spContentConn = new SqlConnection(NewconnectionString);
            sqlcmd.Connection = spContentConn;
            sqlcmd.CommandTimeout = 24000;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = sqlselectQuery;
            sqlcmd.Parameters.AddWithValue("@FromDate", FromDate);
            sqlcmd.Parameters.AddWithValue("@ToDate", ToDate);

            spContentConn.Open();
            int count = 0;
            using (spContentConn)
            {
                using (SqlDataReader sdr = sqlcmd.ExecuteReader())
                using (CsvfileWriter)
                {
                    //For getting the Table Headers
                    //DataTable Tablecolumns = new DataTable();

                    //for (int i = 0; i < sdr.FieldCount; i++)
                    //{
                    //    Tablecolumns.Columns.Add(sdr.GetName(i));
                    //}

                    // CsvfileWriter.WriteLine(string.Join("|", Tablecolumns.Columns.Cast<DataColumn>().Select(csvfile => csvfile.ColumnName)));
                    //For table headers

                    while (sdr.Read())
                    {
                        if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.Debtors)
                        {
                            CsvfileWriter.WriteLine(sdr[0].ToStr(true)
                                + sdr[1].ToStr(true)
                                + sdr[2].ToStr(true)
                                + sdr[3].ToStr(true)
                                + sdr[4].ToStr(true)
                                + sdr[5].ToStr(true)
                                + sdr[6].ToStr(true)
                                + sdr[7].ToStr(true)
                                + sdr[8].ToStr(true)
                                + sdr[9].ToStr(true)
                                + sdr[10].ToStr(true)
                                + sdr[11].ToStr(true)
                                + sdr[12].ToStr(true)
                                + sdr[13].ToStr(true)
                                + sdr[14].ToStr(true)
                                + sdr[15].ToStr(true)
                                + sdr[16].ToStr(true)
                                + sdr[17].ToStr(true)
                                //+ sdr[18].ToStr(true)
                                 
                                );
                        }
                        else if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.FilingAmendments)
                        {
                            CsvfileWriter.WriteLine(sdr[0].ToStr(true)
                               + sdr[1].ToStr(true)
                               
                               );
                        }
                        else if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.FilingDetail)
                        {
                            CsvfileWriter.WriteLine(sdr[0].ToStr(true)
                                + sdr[1].ToStr(true)
                                + sdr[2].ToStr(true)
                                + sdr[3].ToStr(true)
                                + sdr[4].ToStr(true)
                                + sdr[5].ToStr(true)
                                + sdr[6].ToStr(true)
                                 
                                );
                        }
                        else if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.SecuredParty)
                        {
                            CsvfileWriter.WriteLine(sdr[0].ToStr(true)
                                + sdr[1].ToStr(true)
                                + sdr[2].ToStr(true)
                                + sdr[3].ToStr(true)
                                + sdr[4].ToStr(true)
                                + sdr[5].ToStr(true)
                                + sdr[6].ToStr(true)
                                + sdr[7].ToStr(true)
                                + sdr[8].ToStr(true)
                                + sdr[9].ToStr(true)
                                + sdr[10].ToStr(true)
                                + sdr[11].ToStr(true)
                                + sdr[12].ToStr(true)
                                + sdr[13].ToStr(true)
                                + sdr[14].ToStr(true)
                                + sdr[15].ToStr(true)
                                + sdr[16].ToStr(true)
                                + sdr[17].ToStr(true)
                                + sdr[18].ToStr(true)
                                 
                                );
                        }

                        //if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.LienDetail)
                        //{
                        //    CsvfileWriter.WriteLine(sdr[0].ToStr(true) + "|" + sdr[1].ToStr(true) + "|" + sdr[2].ToStr(true) + "|" + sdr[3].ToStr(true) + "|" + sdr[4].ToStr(true) + "|" + sdr[5].ToStr(true) + "|");
                        //}
                        //else if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.FilingDetail)
                        //{
                        //    CsvfileWriter.WriteLine(sdr[0].ToStr(true) + "|" + sdr[1].ToStr(true) + "|" + sdr[2].ToStr(true) + "|" + sdr[3].ToStr(true) + "|" + sdr[4].ToStr(true) + "|" + sdr[5].ToStr(true) + "|");
                        //}
                        //else if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.Debtors)
                        //{
                        //    CsvfileWriter.WriteLine(sdr[0].ToStr(true) + "|" + sdr[1].ToStr(true) + "|" + sdr[2].ToStr(true) + "|" + sdr[3].ToStr(true) + "|" + sdr[4].ToStr(true) + "|" + sdr[5].ToStr(true) + "|" + sdr[6].ToStr(true) + "|" + sdr[7].ToStr(true) + "|" + sdr[8].ToStr(true) + "|"
                        //        + sdr[9].ToStr(true) + "|" + sdr[10].ToStr(true) + "|" + sdr[11].ToStr(true) + "|" + sdr[12].ToStr(true) + "|" + sdr[13].ToStr(true) + "|" + sdr[14].ToStr(true) + "|" + sdr[15].ToStr(true) + "|" + sdr[16].ToStr(true) + "|"
                        //        );
                        //}
                        //else if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.SecuredParty)
                        //{
                        //    CsvfileWriter.WriteLine(sdr[0].ToStr(true) + "|" + sdr[1].ToStr(true) + "|" + sdr[2].ToStr(true) + "|" + sdr[3].ToStr(true) + "|" + sdr[4].ToStr(true) + "|" + sdr[5].ToStr(true) + "|" + sdr[6].ToStr(true) + "|" + sdr[7].ToStr(true) + "|" + sdr[8].ToStr(true) + "|"
                        //        + sdr[9].ToStr(true) + "|" + sdr[10].ToStr(true) + "|" + sdr[11].ToStr(true) + "|" + sdr[12].ToStr(true) + "|" + sdr[13].ToStr(true) + "|" + sdr[14].ToStr(true) + "|" + sdr[15].ToStr(true) + "|" + sdr[16].ToStr(true) + "|" + sdr[17].ToStr(true) + "|"
                        //        );
                        //}
                        //else if (Path.GetFileName(filepath) == WebDirectoryHelper.DataFileNames.FSAProducts)
                        //{
                        //    CsvfileWriter.WriteLine(sdr[0].ToStr(true) + "|" + sdr[1].ToStr(true) + "|" + sdr[2].ToStr(true) + "|" + sdr[3].ToStr(true) + "|" + sdr[4].ToStr(true) + "|" + sdr[5].ToStr(true) + "|" + sdr[6].ToStr(true) + "|");
                        //}

                        count++;

                    }
                }

            }
            files.Add(filepath);
            //  swra.Stop();
            // Console.WriteLine(count);
            return count;
        }


        /// <summary>
        /// UCC Lien Details 
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public static DataSet GetUCCLienDetail(DateTime FromDate, DateTime ToDate)
        {
            var dsliendetails = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                //if (LienTypeId != null)
                //    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                //if (IndexTypeId != null)
                //    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsliendetails = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCLIEN, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsliendetails;
        }

        //UCC Collateral
        public static DataSet GetUCCCollaterals(DateTime FromDate, DateTime ToDate)
        {
            var dscollaterals = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                //if (LienTypeId != null)
                //    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                //if (IndexTypeId != null)
                //    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dscollaterals = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCCOLLATERALTEXT, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dscollaterals;
        }

        //FSAProducts
        public static DataSet GetFSAProducts(DateTime FromDate, DateTime ToDate)
        {
            var dscollaterals = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                //if (LienTypeId != null)
                //    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                //if (IndexTypeId != null)
                //    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dscollaterals = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_CNSPRODUCTS, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dscollaterals;
        }



        //CNS Collateral
        public static DataSet GetCNSCollateral(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dscnscollaterals = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dscnscollaterals = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_CNSPRODUCTS, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dscnscollaterals;
        }

        //ASL1 Collateral
        public static DataSet GetASL1Collateral(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsaslcollaterals = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsaslcollaterals = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_ASL1COLLATERAL, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsaslcollaterals;
        }
        //ASL2 Collateral
        public static DataSet GetASL2Collateral(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsaslcollaterals = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsaslcollaterals = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_ASL2COLLATERAL, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsaslcollaterals;
        }
        //ASL3 Collateral
        public static DataSet GetASL3Collateral(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsaslcollaterals = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsaslcollaterals = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_ASL3COLLATERAL, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsaslcollaterals;
        }
        //ASL5 Collateral
        public static DataSet GetASL5Collateral(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsaslcollaterals = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsaslcollaterals = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_ASL5COLLATERAL, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsaslcollaterals;
        }
        //FederalJudgment Info
        public static DataSet GetFederalJudgmentInfo(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsfederaljudgment = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsfederaljudgment = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_FEDERALJUDGMENTINFO, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsfederaljudgment;
        }
        //FederalTaxSerial Info
        public static DataSet GetFederalTaxSerialInfo(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsfederaltax = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsfederaltax = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_FEDERALTAXSERIALNOINFO, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsfederaltax;
        }
        //MSL Collateral
        public static DataSet GetMSLCollateral(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsmsl = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsmsl = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_MSL, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsmsl;
        }
        //State Tax Collaterals
        public static DataSet GetStateTaxCollateral(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dsstatetaxcollateral = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsstatetaxcollateral = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_STATETAXFILINGINFO, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsstatetaxcollateral;
        }

        //UCC5 Correction
        public static DataSet GetUCCCorrection(DateTime FromDate, DateTime ToDate, string LienTypeId, string IndexTypeId)
        {
            var dscorrection = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                if (LienTypeId != null)
                    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                if (IndexTypeId != null)
                    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dscorrection = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCCORRECTION, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dscorrection;
        }

        //Insert Data Sales Scheduler
        public static bool InsertDataSalesScheduler(int month, int year, string datapath, int datasaletypeid, int filingcount, DateTime fromdate, DateTime todate, string filesize, bool IsFilingData, bool IsImageData)
        {
            try
            {
                SqlParameter[] parm = new SqlParameter[12];
                parm[0] = new SqlParameter("@Year", year);
                parm[1] = new SqlParameter("@DataPath", datapath);
                parm[2] = new SqlParameter("@Month", month);
                parm[3] = new SqlParameter("@DataSalesTypeId", datasaletypeid);
                parm[4] = new SqlParameter("@FilingsCount", filingcount);
                parm[5] = new SqlParameter("@FromDateTime", fromdate);
                parm[6] = new SqlParameter("@ToDateTime", todate);
                parm[7] = new SqlParameter("@FileSize", filesize);//Helper.GetFileSizeInMB(datapath));
                parm[8] = new SqlParameter("@IsFilingData", IsFilingData);
                parm[9] = new SqlParameter("@IsImageData", IsImageData);
                parm[10] = new SqlParameter("@Action", "C");

                return DbActivity.ExecuteNonQuery(DBCommands.USP_UCC_DATASALES_SCHEDULER, parm).ToInt() > 0 ? true : false;
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }

        }

        #region Data Sales Filing Details


        //Filing Details 
        public static DataSet GetUCCFilingDetails(DateTime FromDate, DateTime ToDate)
        {
            var dsfilingdetails = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                //if (LienTypeId != null)
                //    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                //if (IndexTypeId != null)
                //    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsfilingdetails = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCFILING, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsfilingdetails;
        }

        // UCC Debtor 
        public static DataSet GetUCCDebtors(DateTime FromDate, DateTime ToDate)
        {
            var dsdebtor = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                dsdebtor = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_DEBTORS, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsdebtor;
        }


        //UCC Filing Amendments
        public static DataSet GetUCCFilingAmendments(DateTime FromDate, DateTime ToDate)
        {
            var dssecuredparty = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                dssecuredparty = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_UCCFILING_AMEDNMENTS, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dssecuredparty;
        }


        //UCC Secured Parties 
        public static DataSet GetUCCSecuredParty(DateTime FromDate, DateTime ToDate)
        {
            var dssecuredparty = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                //parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                //parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dssecuredparty = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_SECUREDPARTIES, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dssecuredparty;
        }



        #endregion

        #region Data Sales Image Filing Details


        //UCC Collateral
        public static DataSet GetFilingImages(DateTime FromDate, DateTime ToDate)
        {
            var dsFilingPaths = new DataSet();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);
                //if (LienTypeId != null)
                //    parm[2] = new SqlParameter("@LienTypeId", LienTypeId);
                //if (IndexTypeId != null)
                //    parm[3] = new SqlParameter("@IndexTypeId", IndexTypeId);
                dsFilingPaths = DbActivity.ExecuteDataset(DBCommands.USP_UCC_DATASALES_SCHEDULER_FILINGIMAGEPATHS, parm);
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsFilingPaths;
        }

        //UCC Collateral
        public static List<ImageFiles> GetFilingImagesList(DateTime FromDate, DateTime ToDate)
        {
            List<ImageFiles> dsFilingPaths = new List<ImageFiles>();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@FromDate", FromDate);
                parm[1] = new SqlParameter("@ToDate", ToDate);

                SqlDataReader dr = DbActivity.ExecuteReader(DBCommands.USP_UCC_DATASALES_SCHEDULER_FILINGIMAGEPATHS, parm);

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ImageFiles data = new ImageFiles()
                        {
                            FileLocation = dr["FileLocation"].ToStr(true),
                            FilingNo = dr["FilingNo"].ToStr(true)
                        };

                        dsFilingPaths.Add(data);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
                throw;
            }
            return dsFilingPaths;
        }

        #endregion

    }// End of the class 
}
