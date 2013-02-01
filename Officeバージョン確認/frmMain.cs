using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Officeバージョン確認
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {

            lstTarget.BeginUpdate();
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in dlgOpen.FileNames)
                {
                    lstTarget.Items.Add(file);
                }
            }
            lstTarget.EndUpdate();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstTarget.BeginUpdate();
            lstTarget.Items.Clear();
            lstTarget.EndUpdate();
        }

        private void lstTarget_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lstTarget_DragDrop(object sender, DragEventArgs e)
        {

            lstTarget.BeginUpdate();
            string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);

            lstTarget.Items.AddRange(Files);
            lstTarget.EndUpdate();
        }

        private void btnExec_Click(object sender, EventArgs e)
        {

            if (lstTarget.Items.Count <= 0)
            {
                MessageBox.Show("Officeファイルをドラッグするか、参照ボタンからファイルを選んでください。");
                return;
            }

            CVersion oVer = new CVersion();
            string sExtention = "";

            for (int i = 0; i < lstTarget.Items.Count; i++)
            {
                sExtention = Path.GetExtension(lstTarget.Items[i].ToString());
                sExtention = sExtention.ToLower();

                // 1ファイルずつバージョンを検査
                switch (sExtention)
                {
                    case ".docx":
                    case ".xlsx":
                    case ".pptx":
                        oVer.AddFile(lstTarget.Items[i].ToString());
                        break;

                    default:
                        // Word、Excel、PowerPointの2007以上のファイルでなければ、処理しない
                        break;
                }

            }

            // 出力
            frmOutput fOutput = new frmOutput();
            fOutput.VersionInfo = oVer;
            fOutput.ShowDialog();

            oVer = null;
        }


    }
}
