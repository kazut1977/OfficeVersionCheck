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
    public partial class frmOutput : Form
    {
        internal CVersion VersionInfo
        {
            get;
            set;
        }

        public frmOutput()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOutput_Load(object sender, EventArgs e)
        {
            bool HasRecord = true;
            string FileName = "";
            string Version = "";

            // 表示する前にプロパティVersionInfoにsetする必要があります。
            VersionInfo.Reset();

            while (HasRecord)
            {
                VersionInfo.GetItem(out FileName, out Version);

                grOutput.Rows.Add(Path.GetFileName(FileName), Version);

                HasRecord = VersionInfo.MoveNext();
            }

        }






    }
}
