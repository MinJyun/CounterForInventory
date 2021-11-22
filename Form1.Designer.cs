namespace 計數器
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
            this.button1 = new System.Windows.Forms.Button();
            this.ShowLoadingPath = new System.Windows.Forms.TextBox();
            this.OutPutFile = new System.Windows.Forms.Button();
            this.showLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "載入清單";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShowLoadingPath
            // 
            this.ShowLoadingPath.Location = new System.Drawing.Point(12, 19);
            this.ShowLoadingPath.Name = "ShowLoadingPath";
            this.ShowLoadingPath.Size = new System.Drawing.Size(328, 22);
            this.ShowLoadingPath.TabIndex = 2;
            // 
            // OutPutFile
            // 
            this.OutPutFile.Location = new System.Drawing.Point(441, 12);
            this.OutPutFile.Name = "OutPutFile";
            this.OutPutFile.Size = new System.Drawing.Size(89, 33);
            this.OutPutFile.TabIndex = 3;
            this.OutPutFile.Text = "輸出檔案";
            this.OutPutFile.UseVisualStyleBackColor = true;
            this.OutPutFile.Click += new System.EventHandler(this.OutPutFile_Click);
            // 
            // showLabel
            // 
            this.showLabel.AutoSize = true;
            this.showLabel.Location = new System.Drawing.Point(573, 22);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(0, 12);
            this.showLabel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 463);
            this.Controls.Add(this.showLabel);
            this.Controls.Add(this.OutPutFile);
            this.Controls.Add(this.ShowLoadingPath);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "清點單";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ShowLoadingPath;
        private System.Windows.Forms.Button OutPutFile;
        private System.Windows.Forms.Label showLabel;
    }
}

