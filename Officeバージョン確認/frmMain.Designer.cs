namespace Officeバージョン確認
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFile = new System.Windows.Forms.Label();
            this.btnRef = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.lstTarget = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(5, 13);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(45, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "ファイル：";
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(46, 7);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(55, 24);
            this.btnRef.TabIndex = 1;
            this.btnRef.Text = "参照";
            this.btnRef.UseVisualStyleBackColor = true;
            this.btnRef.Click += new System.EventHandler(this.btnRef_Click);
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(171, 336);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(93, 23);
            this.btnExec.TabIndex = 4;
            this.btnExec.Text = "実行";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(270, 336);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(93, 23);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text = "終了";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // lstTarget
            // 
            this.lstTarget.AllowDrop = true;
            this.lstTarget.FormattingEnabled = true;
            this.lstTarget.HorizontalScrollbar = true;
            this.lstTarget.ItemHeight = 12;
            this.lstTarget.Location = new System.Drawing.Point(7, 38);
            this.lstTarget.Name = "lstTarget";
            this.lstTarget.Size = new System.Drawing.Size(516, 292);
            this.lstTarget.TabIndex = 6;
            this.lstTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstTarget_DragDrop);
            this.lstTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstTarget_DragEnter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(107, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(55, 24);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Officeファイル(*.docx;*.xlsx;*.pptx)|*.docx;*.xlsx;*.pptx";
            this.dlgOpen.Multiselect = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 363);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstTarget);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.btnRef);
            this.Controls.Add(this.lblFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Officeファイルバージョン確認";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnRef;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.ListBox lstTarget;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}

