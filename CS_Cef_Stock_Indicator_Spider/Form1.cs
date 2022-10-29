using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Cef
{
    public partial class Form1 : Form
    {
        public int m_intStocksId = 0;
        public int m_intErrorCount = 0;
        public int m_intTimerState = 0;
        String[] m_ArrayStrStock_codes;
        public string m_StrLastQuoteTime = "";
        public string m_StrRSI5 = "";
        public string m_StrRSI10 = "";
        public string m_StrK9 = "";
        public string m_StrD9 = "";
        public String Get_Html_stock_d(string data)
        {
            //D<i parameter1="">9</i><span data-char="↓" decimals="2" d="">14.23</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" d="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        public String Get_Html_stock_k(string data)
        {
            //K<i parameter1="">9</i><span data-char="↓" decimals="2" k="">8.90</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" k="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        public String Get_Html_stock_rsi2(string data)
        {
            //RSI<i parameter2="">10</i><span data-char="" decimals="2" rsi2="">20.78</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" rsi2="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        public String Get_Html_stock_rsi1(string data)
        {
            //RSI<i parameter1="">5</i><span data-char="↓" decimals="2" rsi1="">13.90</span></li>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"decimals=""2"" rsi1="""">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        public String Get_Html_stock_lastQuoteTime(string data)
        {
            //<time class="last-time ml-5" id="lastQuoteTime">2022-10-14 13:30</time>
            String StrResult = "";
            MatchCollection matches = Regex.Matches(data, @"id=""lastQuoteTime"">(([\s\S])*?)<");


            // 一一取出 MatchCollection 內容
            foreach (Match match in matches)
            {
                StrResult = match.Groups[1].Value;
            }

            return StrResult;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (FileLib.IsFileExists("Stocks.txt"))
            {
                String AllData = FileLib.ReadTxtFile("Stocks.txt", false);
                m_ArrayStrStock_codes = AllData.Split('\n');
            }
            String StrURL = String.Format("https://www.wantgoo.com/stock/{0}/technical-chart", m_ArrayStrStock_codes[0]);
            WebBrowser.Load(StrURL);
        }

        private void WebBrowser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {    
            this.BeginInvoke(new Action(() =>
            {
                String html = WebBrowser.GetSourceAsync().Result;
                richTextBox.Text = html;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String SQL = "DELETE FROM main";
            SQLDataTableModel.SQLiteInsertUpdateDelete(@".\Stock.db", SQL);
            m_intStocksId = 0;
            String StrURL = String.Format("https://www.wantgoo.com/stock/{0}/technical-chart", m_ArrayStrStock_codes[m_intStocksId]);
            WebBrowser.Load(StrURL);
            timer1.Enabled = true;
            m_intTimerState = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool blncheck=false;
            timer1.Enabled = false;
            switch (m_intTimerState)
            {
                case 0://清空變數
                    m_StrLastQuoteTime = "";
                    m_StrRSI5 = "";
                    m_StrRSI10 = "";
                    m_StrK9 = "";
                    m_StrD9 = "";           
                    m_intErrorCount = 0;
                    m_intTimerState = 1;
                    break;
                case 1:
                    for (int i = 0; i < richTextBox.Lines.Length; i++)
                    {
                        String s = richTextBox.Lines[i];

                        string r22 = Get_Html_stock_lastQuoteTime(s);
                        m_StrLastQuoteTime = (r22.Length > 0) ? r22 : m_StrLastQuoteTime;
                        string r33 = Get_Html_stock_rsi1(s);
                        m_StrRSI5 = (r33.Length > 0) ? r33 : m_StrRSI5;
                        string r44 = Get_Html_stock_rsi2(s);
                        m_StrRSI10 = (r44.Length > 0) ? r44 : m_StrRSI10;
                        string r55 = Get_Html_stock_k(s);
                        m_StrK9 = (r55.Length > 0) ? r55 : m_StrK9;
                        string r66 = Get_Html_stock_d(s);
                        m_StrD9 = (r66.Length > 0) ? r66 : m_StrD9;

                        if ((m_StrLastQuoteTime.Length > 0) && (m_StrRSI5.Length > 0) && (m_StrRSI10.Length > 0) && (m_StrK9.Length > 0) && (m_StrD9.Length > 0))
                        {
                            this.Text = m_StrLastQuoteTime + "    " + m_StrRSI5 + "    " + m_StrRSI10 + "    " + m_StrK9 + "    " + m_StrD9 + "    "+ m_intStocksId +"/"+ m_ArrayStrStock_codes.Length;
                            m_intTimerState = 2;
                            blncheck = true;
                        }
                        else
                        {
                            blncheck = false;
                        }
                    }
                    if(!blncheck)
                    {
                        m_intErrorCount++;
                        if (m_intErrorCount > 40)
                        {
                            this.Text = "Stop";
                        }
                        else
                        {
                            this.Text = "Error Count" + m_intErrorCount;
                        }
                    }
                    break;
                case 2:
                    DateTime dateTime = Convert.ToDateTime(m_StrLastQuoteTime);
                    /*
                    int KD_Golden_Cross = ((Convert.ToDouble(m_StrK9) > Convert.ToDouble(m_StrD9)) && (Convert.ToDouble(m_StrK9) < 20))? 1 : 0 ;
                    int KD_Death_Cross = ((Convert.ToDouble(m_StrK9) < Convert.ToDouble(m_StrD9)) && (Convert.ToDouble(m_StrK9) > 80)) ? 1 : 0;
                    int RSI_Golden_Cross = ((Convert.ToDouble(m_StrRSI5) > Convert.ToDouble(m_StrRSI10)) && (Convert.ToDouble(m_StrRSI5) > 50)) ? 1 : 0;
                    int RSI_Death_Cross = ((Convert.ToDouble(m_StrRSI5) < Convert.ToDouble(m_StrRSI10)) && (Convert.ToDouble(m_StrRSI5) < 50)) ? 1 : 0;
                    */
                    int KD_Golden_Cross = ((Convert.ToDouble(m_StrK9) >= Convert.ToDouble(m_StrD9)) && (Convert.ToDouble(m_StrK9) <= 50)) ? (Convert.ToInt32(Convert.ToDouble(m_StrK9)) / 10 * 10) : 0;
                    int KD_Death_Cross = ((Convert.ToDouble(m_StrK9) <= Convert.ToDouble(m_StrD9)) && (Convert.ToDouble(m_StrK9) >= 50)) ? (Convert.ToInt32(Convert.ToDouble(m_StrK9)) / 10 * 10) : 0;
                    int RSI_Golden_Cross = ((Convert.ToDouble(m_StrRSI5) >= Convert.ToDouble(m_StrRSI10)) && (Convert.ToDouble(m_StrRSI5) <= 50)) ? (Convert.ToInt32(Convert.ToDouble(m_StrRSI5)) / 10 * 10) : 0;
                    int RSI_Death_Cross = ((Convert.ToDouble(m_StrRSI5) <= Convert.ToDouble(m_StrRSI10)) && (Convert.ToDouble(m_StrRSI5) >= 50)) ? (Convert.ToInt32(Convert.ToDouble(m_StrRSI5)) / 10 * 10) : 0;

                    String SQL = String.Format("INSERT INTO main (Time,Stock_code,K9,D9,RSI5,RSI10,KD_Golden_Cross,KD_Death_Cross,RSI_Golden_Cross,RSI_Death_Cross) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                                                                  dateTime.ToString("yyyyMMdd"), m_ArrayStrStock_codes[m_intStocksId], m_StrK9, m_StrD9, m_StrRSI5, m_StrRSI10, KD_Golden_Cross, KD_Death_Cross, RSI_Golden_Cross, RSI_Death_Cross);
                    SQLDataTableModel.SQLiteInsertUpdateDelete(@".\Stock.db", SQL);
                    richTextBox.Text = "";
                    Thread.Sleep(5000);
                    if (m_intStocksId < (m_ArrayStrStock_codes.Length - 1))
                    {
                        m_intTimerState = 0;
                        m_intStocksId++;
                        String StrURL = String.Format("https://www.wantgoo.com/stock/{0}/technical-chart", m_ArrayStrStock_codes[m_intStocksId]);
                        WebBrowser.Load(StrURL);
                    }
                    else
                    {
                        m_intTimerState = 101;
                    }
                    break;
            }

            if ((!(m_intErrorCount > 40)) && (m_intTimerState<100))
            {
                timer1.Enabled = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                if (m_intErrorCount > 40)
                {
                    m_intErrorCount = 0;
                    MessageBox.Show("ERROR");
                    timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("FINISH");
                }
            }
        }
    }
}
