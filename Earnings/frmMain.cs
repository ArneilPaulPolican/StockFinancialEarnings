using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using HtmlDocument = System.Windows.Forms.HtmlDocument;

namespace Earnings
{
    public partial class frmMain : Form
    {
        public static HtmlDocument doc;

        public frmMain()
        {
            InitializeComponent();
        }

        public void generateEarnings()
        {
            List<Earnings> lstEarning = new List<Earnings>();

            WebClient webClient = new WebClient();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            magentadbDataContext dbProd = new magentadbDataContext();

            DateTime currentDate = Convert.ToDateTime(txtDateStart.Value.ToString("yyyy-MM-dd"));
            DateTime endDate = Convert.ToDateTime(txtDateEnd.Value.ToString("yyyy-MM-dd"));

            int dateDiff = Convert.ToInt32(endDate.Subtract(currentDate).Days.ToString());
            int offset = 0;

            progressBar1.Maximum = dateDiff + 1;
            progressBar1.Value = 0;

            while (currentDate <= endDate)
            {
                string urlDateString = currentDate.ToString("yyyy-MM-dd");
                string url = webClient.DownloadString("https://finance.yahoo.com/calendar/earnings?day=" + urlDateString + "&offset=" + offset);

                doc.LoadHtml(url);

                if (doc.DocumentNode.SelectNodes("//table[contains(@class, 'data-table W(100%) Bdcl(c) Pos(r) BdB Bdc($c-fuji-grey-c)')]") == null)
                {
                    txtLogActivity.Text += urlDateString + ": No data. \r\n";
                }
                else
                {
                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@class, 'data-table W(100%) Bdcl(c) Pos(r) BdB Bdc($c-fuji-grey-c)')]"))
                    {
                        
                        foreach (HtmlNode tableBody in table.SelectNodes("tbody"))
                        {

                            txtLogActivity.Text += urlDateString + ": " + tableBody.SelectNodes("tr").Count() + " symbols \r\n";

                            if (tableBody.SelectNodes("tr").Count() == 100)
                            {
                                offset = offset + 100;
                            }
                            else
                            {
                                offset = 0;
                            }
                            
                            foreach (HtmlNode tableRow in tableBody.SelectNodes("tr"))
                            {

                                HtmlNodeCollection tableRows = tableRow.SelectNodes("td");

                                if (tableRows.Any())
                                {
                                    try
                                    {
                                        txtLogActivity.Text += tableRows[1].InnerText + "\r\n";
                                        txtLogActivity.SelectionStart = txtLogActivity.Text.Length;
                                        txtLogActivity.ScrollToCaret();
                                        //txtLogActivity.Text = "Symbol: " + tableRows[1].InnerText + "\r\n" + txtLogActivity.Text;
                                        //txtLogActivity.Text = "Company: " + tableRows[2].InnerText + "\r\n" + txtLogActivity.Text;
                                        //txtLogActivity.Text = "Earnings Call Time: " + tableRows[3].InnerText + "\r\n" + txtLogActivity.Text;
                                        //txtLogActivity.Text = "EPS Estimate: " + tableRows[4].InnerText + "\r\n" + txtLogActivity.Text;
                                        //txtLogActivity.Text = "Reported EPS: " + tableRows[5].InnerText + "\r\n" + txtLogActivity.Text;
                                        //txtLogActivity.Text = "Surprise (%): " + tableRows[6].InnerText + "\r\n" + txtLogActivity.Text;
                                        //txtLogActivity.Text = "\r\n\n" + txtLogActivity.Text;

                                        
                                        TrnStockEarning newTrnStockEarning = new TrnStockEarning();

                                        string earningSymbol = tableRows[1].InnerText.ToUpper();
                                        string earningPosition = "Before Market Open";

                                        if (tableRows[3].InnerText.Equals("After Market Close")) earningPosition = "After Market Close";

                                        if (dbProd.TrnStockEarnings.Where(e => e.Symbol == earningSymbol && e.EarningDate.Date == currentDate.Date).Count() == 0)
                                        {
                                            var MstSymbol = from s in dbProd.MstSymbols
                                                            where s.Symbol == earningSymbol && 
                                                                  (s.Exchange == "NASDAQ" || s.Exchange == "NYSE" || s.Exchange == "AMEX")
                                                            select new
                                                            {
                                                                Id = s.Id,
                                                            };

                                            if (MstSymbol.Any())
                                            {
                                                newTrnStockEarning.Symbol = earningSymbol;
                                                newTrnStockEarning.SymbolId = MstSymbol.FirstOrDefault().Id;
                                                newTrnStockEarning.EarningDate = currentDate.Date;
                                                newTrnStockEarning.EarningTime = earningPosition;

                                                dbProd.TrnStockEarnings.InsertOnSubmit(newTrnStockEarning);
                                                dbProd.SubmitChanges();
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        txtLogActivity.Text += "Error saving. \r\n";
                                    }
                                }
                            }
                        }
                    }

                }

                if (offset == 0)
                {
                    currentDate = currentDate.AddDays(1);
                    progressBar1.Value += 1;
                }

            }

            MessageBox.Show("Completed  ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            generateEarnings();

        }
    }

    public class Earnings
    {
        public String Symbol { get; set; }
        public String Company { get; set; }
        public String EarningsCallTime { get; set; }
        public String EPSEstimate { get; set; }
        public String ReportedEPS { get; set; }
        public String SurprisePercentage { get; set; }
    }
}
