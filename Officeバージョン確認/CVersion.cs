using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Packaging;
using System.Xml;

namespace Officeバージョン確認
{
    struct StVersion
    {
        internal string FilePath;
        internal string Version;
    }

    class CVersion
    {
        // バージョン情報管理
        private const string WORK_FOLDER = "work";
        private const string APP_PATH = "\\docProps\\app.xml";
        private const string XPATH_VERSION = "/ns:Properties/ns:AppVersion";
        
        // バージョン情報リスト（パス、バージョン文字列）
        //private Dictionary<string, string> VersionInfo;
        private List<StVersion> VersionInfo;

        // MoveNextを使う時のカレントインデックス
        private int CurIdx;        

        public CVersion()
        {
            VersionInfo = new List<StVersion>();
        }

        ~CVersion()
        {
            VersionInfo = null;
        }

        public void AddFile(string FilePath)
        {
            // FilePathのバージョンを調べ、Dictionaryへ追加

            // Zip作成
            string ZipFile = this.MakeZip(FilePath);

            // Zipファイルの展開
            string DecompPath = this.DecompressZip(ZipFile);

            // docProps\app.xmlを開く
            string AppVersion = this.GetAppVersion(DecompPath + APP_PATH);
            
            // AppVersionのValueを取得
            StVersion sVersion = new StVersion();
            sVersion.FilePath = FilePath;
            sVersion.Version = this.ConvertVersionString(AppVersion);
            VersionInfo.Add(sVersion);

            // workフォルダを消す
            Directory.Delete(Path.GetDirectoryName(FilePath) + "\\" + WORK_FOLDER, true);

        }

        private string ConvertVersionString(string VersionNo)
        {
            string VersionStr = "その他のバージョン";

            if (VersionNo.StartsWith("12"))
            {
                VersionStr = "Office 2007(Ver12)";
            }
            else if (VersionNo.StartsWith("14"))
            {
                VersionStr = "Office 2010(Ver14)";
            }

            return (VersionStr);
        }

        private string GetAppVersion(string XmlPath)
        {
            string AppVersion;

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(XmlPath);

            // AppVersionのValueを取得
            XmlNamespaceManager xmlNs = new XmlNamespaceManager(xDoc.NameTable);
            xmlNs.AddNamespace("ns", "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
            //xmlNs.AddNamespace(String.Empty, "http://schemas.openxmlformats.org/officeDocument/2006/extended-properties");
            //xmlNs.AddNamespace("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            XmlNode NodeVersion = xDoc.SelectSingleNode(XPATH_VERSION, xmlNs);
            AppVersion = NodeVersion.InnerText;
            
            NodeVersion = null;
            xmlNs = null;
            xDoc = null;

            return (AppVersion);

        }

        // Zip作成
        private string MakeZip(string FilePath)
        {
            string ZipFile = "";

            string WorkPath = Path.GetDirectoryName(FilePath) + "\\" + WORK_FOLDER;
            
            Directory.CreateDirectory(WorkPath);
            ZipFile = WorkPath + "\\" + Path.GetFileName(FilePath) + ".zip";
            File.Copy(FilePath, ZipFile, true);

            return (ZipFile);
        }

        private string DecompressZip(string ZipFile)
        {
            string targetPath = ZipFile + ".uz";

            using (Package package = Package.Open(ZipFile, FileMode.Open, FileAccess.ReadWrite))
            {
                PackageRelationshipCollection collection = package.GetRelationships();

                // 先にディレクトリを作成
                foreach (PackageRelationship ship in collection)
                {
                    Uri uri = PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative), ship.TargetUri);
                    string dirPath = Path.GetDirectoryName(uri.OriginalString);
                    string[] splitData = dirPath.Split(new char[]{'\\'}, StringSplitOptions.RemoveEmptyEntries);
                    string url = string.Empty;
                    for (int iLoop = 0; iLoop < splitData.Length; iLoop++)
                    {
                        url += "\\";
                        url += splitData[iLoop];
                    }

                    // ディレクトリが存在しない時
                    if (!Directory.Exists(targetPath + url))
                    {
                        Directory.CreateDirectory(targetPath + url);
                    }

                    PackagePart packagePartResource = package.GetPart(uri);
                    using (FileStream fileStream = File.Create(targetPath + url + "\\" + Path.GetFileName(uri.OriginalString)))
                    {
                        CopyStream(packagePartResource.GetStream(), fileStream);
                    }

                }
            }

            return (targetPath);

        }

        /// <summary>
        /// コピー用ストリーム
        /// </summary>
        /// <param name="source">元ストリーム</param>
        /// <param name="target">先ストリーム</param>
        private static void CopyStream(Stream source, Stream target)
        {
            const int bufSize = 0x1000;
            byte[] buf = new byte[bufSize];
            int bytesRead = 0;
            while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)
                target.Write(buf, 0, bytesRead);
        }

        public void Reset()
        {
            // Dictionary<string,string>のカレントを最初に設定
            CurIdx = 0;
        }

        public bool MoveNext()
        {
            bool HasNext = false;

            CurIdx++;
            if (CurIdx < VersionInfo.Count)
            {
                HasNext = true;
            }

            return (HasNext);
        }

        public void GetItem(out string FilePath, out string Version)
        {

            //VersionInfo[CurIdx];
            FilePath = VersionInfo[CurIdx].FilePath;
            Version = VersionInfo[CurIdx].Version;

        }

    }
}
