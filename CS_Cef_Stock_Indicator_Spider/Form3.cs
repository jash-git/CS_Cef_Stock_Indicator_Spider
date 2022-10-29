using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Cef
{
    public partial class Form3 : Form
    {
        String m_StrStock = "";
        public Form3(String StrStock="")
        {
            InitializeComponent();
            m_StrStock = StrStock;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String StrURL = String.Format("https://www.wantgoo.com/stock/{0}/technical-chart", textBox1.Text);
            textBox2.Text = StrURL;
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser.Load(textBox2.Text);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if(m_StrStock.Length>0)
            {
                textBox1.Text = m_StrStock;
            }
        }
    }
}
