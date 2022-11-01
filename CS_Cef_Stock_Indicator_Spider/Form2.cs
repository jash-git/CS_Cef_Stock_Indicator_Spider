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
    public partial class Form2 : Form
    {
        void dataGridView1Clean()
        {
            try
            {
                //--
                //dataGridView1.ReadOnly = true;//唯讀 不可更改
                dataGridView1.RowHeadersVisible = false;//DataGridView 最前面指示選取列所在位置的箭頭欄位
                dataGridView1.Rows[0].Selected = false;//取消DataGridView的默認選取(選中)Cell 使其不反藍
                dataGridView1.AllowUserToAddRows = false;//是否允許使用者新增資料
                dataGridView1.AllowUserToDeleteRows = false;//是否允許使用者刪除資料
                dataGridView1.AllowUserToOrderColumns = false;//是否允許使用者調整欄位位置
                dataGridView1.AllowUserToResizeRows = false;//是否允許使用者改變行高
                dataGridView1.AllowUserToResizeColumns = false;//是否允許使用者改變欄寬
                dataGridView1.MultiSelect = false;//不允許多選;只能單選

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;//單一欄位禁止編輯
                    dataGridView1.Columns[i].DefaultCellStyle.NullValue = null;//允許單一圖片放空，不顯示X圖
                }

                //設置所有行背景色
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);

                //設置奇數行背景色（下標從零開始）
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 223, 229);

                //選擇顏色指定
                dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 208, 192);

                //設定文字顏色
                dataGridView1.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
                dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 0, 0);


                //將行高調整到適合螢幕上當前顯示的行中所有單元格（包括標頭單元格）的內容。
                //dgvmain001.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                //dgvmain001.RowTemplate.Height = 300;//全部調整固定行高


                //允許換行屬性設定，透過換行符號換行
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView1.AllowUserToAddRows = false;//刪除空白列
                dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;//整列選取


                do
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewRow r1 = dataGridView1.Rows[i];//取得DataGridView整列資料
                        dataGridView1.Rows.Remove(r1);//DataGridView刪除整列
                    }
                } while (dataGridView1.Rows.Count > 0);

            }
            catch
            {
            }
        }

        void dataGridView2Clean()
        {
            try
            {
                //--
                //dataGridView2.ReadOnly = true;//唯讀 不可更改
                dataGridView2.RowHeadersVisible = false;//DataGridView 最前面指示選取列所在位置的箭頭欄位
                dataGridView2.Rows[0].Selected = false;//取消DataGridView的默認選取(選中)Cell 使其不反藍
                dataGridView2.AllowUserToAddRows = false;//是否允許使用者新增資料
                dataGridView2.AllowUserToDeleteRows = false;//是否允許使用者刪除資料
                dataGridView2.AllowUserToOrderColumns = false;//是否允許使用者調整欄位位置
                dataGridView2.AllowUserToResizeRows = false;//是否允許使用者改變行高
                dataGridView2.AllowUserToResizeColumns = false;//是否允許使用者改變欄寬
                dataGridView2.MultiSelect = false;//不允許多選;只能單選

                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    dataGridView2.Columns[i].ReadOnly = true;//單一欄位禁止編輯
                    dataGridView2.Columns[i].DefaultCellStyle.NullValue = null;//允許單一圖片放空，不顯示X圖
                }

                //設置所有行背景色
                dataGridView2.RowsDefaultCellStyle.BackColor = Color.FromArgb(227, 227, 227);

                //設置奇數行背景色（下標從零開始）
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 223, 229);

                //選擇顏色指定
                dataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 208, 192);

                //設定文字顏色
                dataGridView2.RowsDefaultCellStyle.ForeColor = Color.FromArgb(0, 0, 0);
                dataGridView2.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 0, 0);


                //將行高調整到適合螢幕上當前顯示的行中所有單元格（包括標頭單元格）的內容。
                //dgvmain001.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                //dgvmain001.RowTemplate.Height = 300;//全部調整固定行高


                //允許換行屬性設定，透過換行符號換行
                dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView2.AllowUserToAddRows = false;//刪除空白列
                dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;//整列選取


                do
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        DataGridViewRow r1 = dataGridView2.Rows[i];//取得DataGridView整列資料
                        dataGridView2.Rows.Remove(r1);//DataGridView刪除整列
                    }
                } while (dataGridView2.Rows.Count > 0);

            }
            catch
            {
            }
        }


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1Clean();
            dataGridView2Clean();

            String SQL = "SELECT * FROM main WHERE RSI_Golden_Cross>0 OR KD_Golden_Cross>0 ORDER BY RSI_Golden_Cross DESC,KD_Golden_Cross DESC";
            DataTable dataTable = SQLDataTableModel.GetDataTable(@".\Stock.db", SQL);
            for(int i=0; i < dataTable.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dataTable.Rows[i][0].ToString(), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), dataTable.Rows[i][3].ToString(), dataTable.Rows[i][4].ToString(), dataTable.Rows[i][5].ToString(), dataTable.Rows[i][6].ToString(), dataTable.Rows[i][7].ToString(), dataTable.Rows[i][8].ToString(), dataTable.Rows[i][9].ToString());
            }

            SQL = "SELECT * FROM main WHERE RSI_Death_Cross>0 OR KD_Death_Cross>0 ORDER BY RSI_Death_Cross DESC,KD_Death_Cross DESC";
            dataTable = SQLDataTableModel.GetDataTable(@".\Stock.db", SQL);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataGridView2.Rows.Add(dataTable.Rows[i][0].ToString(), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), dataTable.Rows[i][3].ToString(), dataTable.Rows[i][4].ToString(), dataTable.Rows[i][5].ToString(), dataTable.Rows[i][6].ToString(), dataTable.Rows[i][7].ToString(), dataTable.Rows[i][8].ToString(), dataTable.Rows[i][9].ToString());
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;//取得被選取的第一列旗標位置
            String StrBuf = dataGridView1.Rows[index].Cells[1].Value.ToString();
            Form3 form3 = new Form3(StrBuf);
            form3.ShowDialog();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridView2.SelectedRows[0].Index;//取得被選取的第一列旗標位置
            String StrBuf = dataGridView2.Rows[index].Cells[1].Value.ToString();
            Form3 form3 = new Form3(StrBuf);
            form3.ShowDialog();
        }
    }
}
