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
    public partial class Form1 : Form
    {
        public static HtmlDocument doc;

        public Form1()
        {
            InitializeComponent();
        }
        public void generateEarnings()
        {
            string output;
            string StartDate = txtDateStart.Value.ToString("yyyy-MM-dd");
            string EndDate = txtDateEnd.Value.ToString("yyyy-MM-dd");
            DateTime day = Convert.ToDateTime(StartDate);
            DateTime Endday = Convert.ToDateTime(EndDate);
            int TimeDiff = Convert.ToInt32(Endday.Subtract(day).Days.ToString());
            progressBar1.Maximum = TimeDiff + 1;
            progressBar1.Value = 0;

            List<Earnings> lstEarning = new List<Earnings>();

            while (day <= Convert.ToDateTime(EndDate))
            {
                string dateExtension = day.ToString("yyyy-MM-dd");
                WebClient webClient = new WebClient();
                string page = webClient.DownloadString("https://finance.yahoo.com/calendar/earnings?day=" + dateExtension);

                //HtmlDocument doc = new HtmlDocument();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);
                if (doc.DocumentNode.SelectNodes("//table[contains(@class, 'data-table W(100%) Bdcl(c) Pos(r) BdB Bdc($c-fuji-grey-c)')]") == null)
                {
                    txtLogActivity.Text += day.ToString("yyyy-MM-dd") + "   no data \r\n\n";
                }
                else
                {
                    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[contains(@class, 'data-table W(100%) Bdcl(c) Pos(r) BdB Bdc($c-fuji-grey-c)')]"))
                    {
                        foreach (HtmlNode tableBody in table.SelectNodes("tbody"))
                        {
                            txtLogActivity.Text += "No. of Earnings: " + tableBody.SelectNodes("tr").Count();
                            txtLogActivity.Text += "\r\n\n";

                            foreach (HtmlNode tableRow in tableBody.SelectNodes("tr"))
                            {
                                HtmlNodeCollection tableRows = tableRow.SelectNodes("td");
                                if (tableRows.Any())
                                {
                                    txtLogActivity.Text += "Symbol: " + tableRows[1].InnerText + "\r\n";
                                    txtLogActivity.Text += "Company: " + tableRows[2].InnerText + "\r\n";
                                    txtLogActivity.Text += "Earnings Call Time: " + tableRows[3].InnerText + "\r\n";
                                    txtLogActivity.Text += "EPS Estimate: " + tableRows[4].InnerText + "\r\n";
                                    txtLogActivity.Text += "Reported EPS: " + tableRows[5].InnerText + "\r\n";
                                    txtLogActivity.Text += "Surprise (%): " + tableRows[6].InnerText + "\r\n";
                                    txtLogActivity.Text += "\r\n\n";
                                    //txtLogActivity.Text();
                                }
                                lstEarning.Add(new Earnings()
                                {
                                    Symbol = tableRows[1].InnerText,
                                    Company = tableRows[2].InnerText,
                                    EarningsCallTime = tableRows[3].InnerText,
                                    EPSEstimate = tableRows[4].InnerText,
                                    ReportedEPS = tableRows[5].InnerText,
                                    SurprisePercentage = tableRows[6].InnerText
                                });
                            }
                        }
                    }
                    //Console.ReadKey();
                }
                day = day.AddDays(1);
                progressBar1.Value += 1;
            }

            output = JsonConvert.SerializeObject(lstEarning);
            System.IO.File.AppendAllText(txtFileLocation.Text + @"jsonFile.json", output);

            MessageBox.Show("Completed  ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        class Earnings
        {
            public String Symbol { get; set; }
            public String Company { get; set; }
            public String EarningsCallTime { get; set; }
            public String EPSEstimate { get; set; }
            public String ReportedEPS { get; set; }
            public String SurprisePercentage { get; set; }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            generateEarnings();

        }
    }
}
