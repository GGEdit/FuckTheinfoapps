using System.IO;
using System.Windows.Forms;

namespace FuckTheinfoapps
{
    class SaveFileHelper
    {
        public static SaveFileDialog Create(string fileName)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = fileName;
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            sfd.Filter = "MP3ファイル(*.mp3;*.MP3)|*.mp3;*.MP3|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;

            return sfd;
        }
    }
}
