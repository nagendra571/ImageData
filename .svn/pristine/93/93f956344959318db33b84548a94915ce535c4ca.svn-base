/**********************************************
* Author       : rsapa PCCTG 
* Date         :04/31/2015
* Description  : Reporting Helper 
**********************************************/
namespace Helper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Drawing;
    using System.Configuration;
    using System.Reflection;
    using System.Threading;
    using WebSupergoo.ABCpdf8;
    public class ReportingHelper
    {
        /// <summary>
        /// Appending Header and Footer for Report 
        /// </summary>
        /// <param name="html">Main report html </param>
        /// <param name="filepath">Full File Path</param>
        /// <param name="header">header Html</param>
        /// <param name="footer">Footer Html</param>
        public static void AppendHeaderFooter(string html, string filepath, string header = "", string footer = "")
        {
            try
            {
                var theDoc = new Doc();
                theDoc.TextStyle.Size = 30;
                theDoc.Rect.Height = 690;
                theDoc.Rect.Inset(50, 50);
                theDoc.Rect.Bottom = 60;
                theDoc.Color.String = "255 255 255";
                int theId = theDoc.AddImageHtml(html);

                while (true)
                {
                    theDoc.FrameRect();
                    if (!theDoc.Chainable(theId))
                        break;
                    theDoc.Page = theDoc.AddPage();
                    theId = theDoc.AddImageToChain(theId);
                }
                theDoc.Rect.String = "35 25 580 50";
                theDoc.Font = theDoc.AddFont("Times New Roman");
                theDoc.FontSize = 11;
                int pagenumber = 1;

                for (int i = 1; i <= theDoc.PageCount; i++)
                {
                    theDoc.PageNumber = i;
                    if (header.ToStr(true).Trim().Length >= 1)
                    {
                        theDoc.Rect.String = "35 770 560 650";// L B W H
                        theDoc.HPos = 0.0;
                        theDoc.VPos = 0.0;
                        theDoc.Color.String = "0 0 0";
                        theDoc.AddImageHtml(header);
                    }
                    if (footer.ToStr(true).Trim().Length >= 1)
                    {
                        theDoc.Rect.String = "35, 58, 580, 1";// L B W H    21, 38, 580, 1
                        theDoc.HPos = 0.0;
                        theDoc.VPos = 0.0;
                        theDoc.Color.String = "0 0 0";
                        theDoc.AddImageHtml(footer);
                        theDoc.AddLine(42, 56, 550, 56);
                    }
                    theDoc.Flatten();

                    pagenumber++;

                }

                theDoc.HtmlOptions.LinkPages();
                byte[] theData = theDoc.GetData();
                System.IO.File.WriteAllBytes(filepath, theData);
                theDoc.Clear();
                theDoc.Dispose();
            }
            catch (Exception exception)
            {
                ExceptionLog.Write(exception, exception.Message);
            }
        }// End of Append header and footer 

        /// <summary>
        /// Adding Page Numbers for Report 
        /// </summary>
        /// <param name="path"></param>
        public static void AddPageNumbers(string path)
        {
            if (System.IO.File.Exists(path.ToStr()))
            {
                string _localfilepath;
                var collpathss = System.IO.Path.GetDirectoryName(path);
                _localfilepath = collpathss + "\\Copy_" + System.IO.Path.GetFileName(path);
                WebSupergoo.ABCpdf8.Doc pdf = new WebSupergoo.ABCpdf8.Doc();
                if (System.IO.File.Exists(path.ToStr()))
                {
                    WebSupergoo.ABCpdf8.Doc pdfsubpage = new WebSupergoo.ABCpdf8.Doc();
                    pdfsubpage.Read(path);
                    pdf.Append(pdfsubpage);
                    pdfsubpage.Clear();
                    pdfsubpage.Dispose();
                }
                int pages = pdf.PageCount;
                for (int i = 1; i <= pages; i++)
                {
                    pdf.PageNumber = i;
                    pdf.Rect.Magnify(0.5, 0.5);
                    pdf.VPos = 0.7;
                    pdf.Rect.String = "500, 18, 585, 4";//L B W H 
                    // pdf.Rect.String = "100 38 585 13";
                    pdf.Font = pdf.AddFont("Trebuchet");
                    pdf.Color.String = "0 0 0";
                    pdf.AddText("- Page " + i.ToString() + " of " + pages.ToString() + " -");
                }
                System.IO.File.WriteAllBytes(_localfilepath, pdf.GetData());
                pdf.Clear();
                // pdf.Dispose();
                if (System.IO.File.Exists(_localfilepath.ToStr()))
                {
                    WebSupergoo.ABCpdf8.Doc pdfFinalPage = new WebSupergoo.ABCpdf8.Doc();
                    pdfFinalPage.Read(_localfilepath);
                    pdf.Append(pdfFinalPage);
                    pdfFinalPage.Clear();
                    pdfFinalPage.Dispose();
                }
                System.IO.File.WriteAllBytes(path, pdf.GetData());
                pdf.Clear();
                pdf.Dispose();
                System.IO.File.Delete(path);
                System.IO.File.Move(_localfilepath, path);
            }
        }// End Of Add Page 

    }// End Of The Class 
}
