namespace CS_Cef
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WebBrowser
            // 
            this.WebBrowser.ActivateBrowserOnCreation = false;
            this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Top;
            this.WebBrowser.Location = new System.Drawing.Point(0, 0);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(963, 382);
            this.WebBrowser.TabIndex = 0;
            this.WebBrowser.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.WebBrowser_FrameLoadEnd);
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox.Location = new System.Drawing.Point(0, 439);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(963, 352);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start_Spider";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(194, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Start_Form2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(381, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 45);
            this.button3.TabIndex = 4;
            this.button3.Text = "Start_Form3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 791);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.WebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser WebBrowser;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

