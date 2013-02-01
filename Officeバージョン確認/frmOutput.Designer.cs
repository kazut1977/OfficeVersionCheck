namespace Officeバージョン確認
{
    partial class frmOutput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grOutput = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // grOutput
            // 
            this.grOutput.AllowUserToAddRows = false;
            this.grOutput.AllowUserToDeleteRows = false;
            this.grOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Version});
            this.grOutput.Location = new System.Drawing.Point(8, 12);
            this.grOutput.Name = "grOutput";
            this.grOutput.ReadOnly = true;
            this.grOutput.RowTemplate.Height = 21;
            this.grOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grOutput.Size = new System.Drawing.Size(475, 230);
            this.grOutput.TabIndex = 0;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "ファイル名";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FileName.Width = 265;
            // 
            // Version
            // 
            this.Version.HeaderText = "バージョン";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Version.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(199, 248);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 277);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grOutput);
            this.MaximizeBox = false;
            this.Name = "frmOutput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "バージョン確認結果";
            this.Load += new System.EventHandler(this.frmOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grOutput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
    }
}