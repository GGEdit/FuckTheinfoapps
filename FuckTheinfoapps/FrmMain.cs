using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuckTheinfoapps
{
    public partial class FrmMain : Form
    {
        Theinfoapps tApps;
        ListViewItem itemx;
        int pNumber = 0;
        dynamic obj;

        public FrmMain()
        {
            InitializeComponent();
            listView1.Columns.RemoveAt(2);
            listView2.Columns.RemoveAt(2);
            tApps = new Theinfoapps();
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            await LoadPlayList();
        }

        private void 再生PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count >= 0 && listView1.SelectedIndices.Count == 1)
            {
                MPlayer.URL = listView1.SelectedItems[0].SubItems[2].Text;
                MPlayer.Ctlcontrols.play();
            }
            else if (listView2.Items.Count >= 0 && listView2.SelectedIndices.Count == 1)
            {
                MPlayer.URL = listView2.SelectedItems[0].SubItems[2].Text;
                MPlayer.Ctlcontrols.play();
            }
        }

        private void ダウンロードDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd;
            FrmDownload frmDownload;
            if (listView1.Items.Count >= 0 && listView1.SelectedIndices.Count == 1)
            {
                sfd = SaveFileHelper.Create($"{listView1.SelectedItems[0].Text}.mp3");
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    frmDownload = new FrmDownload(sfd.FileName, listView1.SelectedItems[0].SubItems[2].Text);
                    frmDownload.Show();
                }
            }
            else if (listView2.Items.Count >= 0 && listView2.SelectedIndices.Count == 1)
            {
                sfd = SaveFileHelper.Create($"{listView2.SelectedItems[0].Text}.mp3");
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    frmDownload = new FrmDownload(sfd.FileName, listView2.SelectedItems[0].SubItems[2].Text);
                    frmDownload.Show();
                }
            }
        }

        private void リピート再生RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (リピート再生RToolStripMenuItem.CheckState == CheckState.Checked)
            {
                MPlayer.settings.setMode("loop", false);
                リピート再生RToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else if (リピート再生RToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                MPlayer.settings.setMode("loop", true);
                リピート再生RToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }

        private void ダウンロード回数改竄HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDLCnt frmDLCnt = new FrmDLCnt();
            frmDLCnt.Show();
        }

        private void アプリケーション終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.Items.Count <= 0)
                return;

            MPlayer.URL = listView1.SelectedItems[0].SubItems[2].Text;
            MPlayer.Ctlcontrols.play();
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.Items.Count <= 0)
                return;

            MPlayer.URL = listView2.SelectedItems[0].SubItems[2].Text;
            MPlayer.Ctlcontrols.play();
        }

        private void songName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Scan();
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            Scan();
        }

        private async void nextButton_Click(object sender, EventArgs e)
        {
            await Next();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadPlayList();
        }

        private async void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadSongByPlayList();
        }

        private async void Scan()
        {
            if (scanButton.Text == "New Scan")
            {
                pNumber = 0;
                listView1.Items.Clear();
                nextButton.Enabled = false;
                scanButton.Text = "First Scan";
            }
            else if (scanButton.Text == "First Scan")
            {
                if (pNumber != 0)
                {
                    pNumber = 0;
                    MessageBox.Show("初期化に失敗しました。", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!await ScanMusicList(pNumber))
                {
                    MessageBox.Show("お探しの曲は存在しません。", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pNumber++;
                await ScanMusicList(pNumber);

                scanButton.Text = "New Scan";
                nextButton.Enabled = true;
                pNumber++;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private async Task Next()
        {
            if (!await ScanMusicList(pNumber))
            {
                MessageBox.Show("これ以上は存在しません。", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pNumber++;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private async Task<bool> ScanMusicList(int _sCount)
        {
            obj = await tApps.GetSongObj(songName.Text, _sCount);
            if (obj == null)
                return false;

            foreach (var data in obj.data.items)
            {
                itemx = listView1.Items.Add(data.title);
                itemx.SubItems.Add(data.artist);
                itemx.SubItems.Add(data.url);
            }
            return true;
        }

        private async Task LoadPlayList()
        {
            playList.DataSource = null;
            playList.Items.Clear();

            obj = await tApps.GetPlaylistObj("u3859021544345334070001472");
            if (obj == null)
                return;

            List<Playlist> playListItem = new List<Playlist>();
            foreach (var data in obj.data.song_lists)
            {
                Playlist pList = new Playlist(data.song_list_name, data.song_list_id);
                playListItem.Add(pList);
            }
            playList.DisplayMember = "Name";
            playList.ValueMember = "Url";
            playList.DataSource = playListItem;
        }

        private async Task LoadSongByPlayList()
        {
            listView2.Items.Clear();

            string songId = ((Playlist)playList.SelectedItem).Url;
            obj = await tApps.GetSongObjByPlayList(songId);
            if (obj == null)
                return;

            foreach (var data in obj.data.songs)
            {
                itemx = listView2.Items.Add(data.title);
                itemx.SubItems.Add(data.artist);
                itemx.SubItems.Add(data.url);
            }
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
