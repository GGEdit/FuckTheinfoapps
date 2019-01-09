namespace FuckTheinfoapps
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.scanButton = new System.Windows.Forms.Button();
            this.songName = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.再生PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ダウンロードDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.データDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アプリケーション終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本体設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.リピート再生RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ダウンロード回数改竄HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ホームページHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.playList = new System.Windows.Forms.ComboBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // scanButton
            // 
            this.scanButton.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.scanButton.Location = new System.Drawing.Point(135, 30);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(86, 24);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "First Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // songName
            // 
            this.songName.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.songName.Location = new System.Drawing.Point(10, 30);
            this.songName.Name = "songName";
            this.songName.Size = new System.Drawing.Size(120, 24);
            this.songName.TabIndex = 1;
            this.songName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.songName_KeyPress);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(284, 329);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "曲タイトル";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "アーティスト";
            this.columnHeader2.Width = 99;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "URL";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.再生PToolStripMenuItem,
            this.ダウンロードDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            // 
            // 再生PToolStripMenuItem
            // 
            this.再生PToolStripMenuItem.Name = "再生PToolStripMenuItem";
            this.再生PToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.再生PToolStripMenuItem.Text = "再生(&P)";
            this.再生PToolStripMenuItem.Click += new System.EventHandler(this.再生PToolStripMenuItem_Click);
            // 
            // ダウンロードDToolStripMenuItem
            // 
            this.ダウンロードDToolStripMenuItem.Name = "ダウンロードDToolStripMenuItem";
            this.ダウンロードDToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ダウンロードDToolStripMenuItem.Text = "ダウンロード(&D)";
            this.ダウンロードDToolStripMenuItem.Click += new System.EventHandler(this.ダウンロードDToolStripMenuItem_Click);
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nextButton.Location = new System.Drawing.Point(222, 30);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(60, 24);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "・ 曲名、アーティスト名 検索";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.データDToolStripMenuItem,
            this.設定SToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(297, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // データDToolStripMenuItem
            // 
            this.データDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アプリケーション終了XToolStripMenuItem});
            this.データDToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.データDToolStripMenuItem.Name = "データDToolStripMenuItem";
            this.データDToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.データDToolStripMenuItem.Text = "データ(&D)";
            // 
            // アプリケーション終了XToolStripMenuItem
            // 
            this.アプリケーション終了XToolStripMenuItem.Name = "アプリケーション終了XToolStripMenuItem";
            this.アプリケーション終了XToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.アプリケーション終了XToolStripMenuItem.Text = "アプリケーション終了(&X)";
            this.アプリケーション終了XToolStripMenuItem.Click += new System.EventHandler(this.アプリケーション終了XToolStripMenuItem_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.本体設定SToolStripMenuItem,
            this.リピート再生RToolStripMenuItem,
            this.ダウンロード回数改竄HToolStripMenuItem});
            this.設定SToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.設定SToolStripMenuItem.Text = "ツール(&T)";
            // 
            // 本体設定SToolStripMenuItem
            // 
            this.本体設定SToolStripMenuItem.Name = "本体設定SToolStripMenuItem";
            this.本体設定SToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.本体設定SToolStripMenuItem.Text = "本体設定(&S)";
            // 
            // リピート再生RToolStripMenuItem
            // 
            this.リピート再生RToolStripMenuItem.Name = "リピート再生RToolStripMenuItem";
            this.リピート再生RToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.リピート再生RToolStripMenuItem.Text = "リピート再生(&R)";
            this.リピート再生RToolStripMenuItem.Click += new System.EventHandler(this.リピート再生RToolStripMenuItem_Click);
            // 
            // ダウンロード回数改竄HToolStripMenuItem
            // 
            this.ダウンロード回数改竄HToolStripMenuItem.Name = "ダウンロード回数改竄HToolStripMenuItem";
            this.ダウンロード回数改竄HToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ダウンロード回数改竄HToolStripMenuItem.Text = "ダウンロード回数改竄(&H)";
            this.ダウンロード回数改竄HToolStripMenuItem.Click += new System.EventHandler(this.ダウンロード回数改竄HToolStripMenuItem_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ホームページHToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // ホームページHToolStripMenuItem
            // 
            this.ホームページHToolStripMenuItem.Name = "ホームページHToolStripMenuItem";
            this.ホームページHToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ホームページHToolStripMenuItem.Text = "ホームページ(&H)";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 419);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.playList);
            this.tabPage1.Controls.Add(this.listView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "My Music";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 25);
            this.button2.TabIndex = 14;
            this.button2.Text = "同期";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "・ プレイリスト";
            // 
            // playList
            // 
            this.playList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playList.FormattingEnabled = true;
            this.playList.Location = new System.Drawing.Point(10, 30);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(214, 25);
            this.playList.TabIndex = 12;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.playList_SelectedIndexChanged);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listView2.ForeColor = System.Drawing.Color.White;
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(0, 60);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(284, 329);
            this.listView2.TabIndex = 10;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "曲タイトル";
            this.columnHeader4.Width = 98;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "アーティスト";
            this.columnHeader5.Width = 99;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "URL";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.scanButton);
            this.tabPage2.Controls.Add(this.songName);
            this.tabPage2.Controls.Add(this.nextButton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(292, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "検索";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(292, 389);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "アカウント";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MPlayer
            // 
            this.MPlayer.Enabled = true;
            this.MPlayer.Location = new System.Drawing.Point(0, 442);
            this.MPlayer.Name = "MPlayer";
            this.MPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MPlayer.OcxState")));
            this.MPlayer.Size = new System.Drawing.Size(300, 45);
            this.MPlayer.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 487);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.MPlayer);
            this.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FuckTheinfoapps";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.TextBox songName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 再生PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ダウンロードDToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer MPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem データDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アプリケーション終了XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 本体設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ホームページHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem リピート再生RToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ComboBox playList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem ダウンロード回数改竄HToolStripMenuItem;
    }
}

