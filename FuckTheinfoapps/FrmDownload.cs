using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuckTheinfoapps
{
    public partial class FrmDownload : Form
    {
        private string saveFileName;
        private WebClient wc;
        private Uri uri;

        public FrmDownload(string _fileName, string _uri)
        {
            InitializeComponent();

            uri = new Uri(_uri);
            saveFileName = _fileName;

            wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(pChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(fCompleted);
        }

        private void FrmDownload_Load(object sender, EventArgs e)
        {
            Start();
        }

        public void Start()
        {
            status.Text = "進行状況: ダウンロード中..";
            fileName.Text = $"ファイル名: {Path.GetFileNameWithoutExtension(saveFileName)}";
            wc.DownloadFileAsync(uri, saveFileName);
        }

        private void pChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            Console.WriteLine("{0}% ({1}byte 中 {2}byte) ダウンロードが終了しました。", e.ProgressPercentage, e.TotalBytesToReceive, e.BytesReceived);
        }

        private async void fCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Console.WriteLine("キャンセルされました。");
            }
            else if (e.Error != null)
            {
                Console.WriteLine("エラー:{0}", e.Error.Message);
            }
            else
            {
                status.Text = "進行状況: ダウンロード完了";
                await Task.Delay(500);
                Close();
            }
        }
    }
}
