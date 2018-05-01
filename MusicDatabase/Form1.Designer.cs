namespace MusicDatabase
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.joinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandsAndMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreAndSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreAndArtistsAndSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songsAndReviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandsAndBreakupsAndSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistsAndSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bandsAndSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Tables";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "DeleteTable";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "Fill SQL List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 123);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Fill Database";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(11, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 24);
            this.button5.TabIndex = 5;
            this.button5.Text = "Complete Setup";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(204, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(653, 338);
            this.dataGridView1.TabIndex = 6;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(11, 214);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(166, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Add Data";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 352);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(166, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Reload";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 325);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // joinsToolStripMenuItem
            // 
            this.joinsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artistsAndSongsToolStripMenuItem,
            this.bandsAndMembersToolStripMenuItem,
            this.genreAndSongsToolStripMenuItem,
            this.genreAndArtistsAndSongsToolStripMenuItem,
            this.bandsAndBreakupsAndSongsToolStripMenuItem,
            this.songsAndReviewsToolStripMenuItem,
            this.bandsAndSongsToolStripMenuItem});
            this.joinsToolStripMenuItem.Name = "joinsToolStripMenuItem";
            this.joinsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.joinsToolStripMenuItem.Text = "Joins";
            // 
            // bandsAndMembersToolStripMenuItem
            // 
            this.bandsAndMembersToolStripMenuItem.Name = "bandsAndMembersToolStripMenuItem";
            this.bandsAndMembersToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.bandsAndMembersToolStripMenuItem.Text = "Bands and Members";
            this.bandsAndMembersToolStripMenuItem.Click += new System.EventHandler(this.bandsAndMembersToolStripMenuItem_Click);
            // 
            // genreAndSongsToolStripMenuItem
            // 
            this.genreAndSongsToolStripMenuItem.Name = "genreAndSongsToolStripMenuItem";
            this.genreAndSongsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.genreAndSongsToolStripMenuItem.Text = "Genre and Songs";
            this.genreAndSongsToolStripMenuItem.Click += new System.EventHandler(this.genreAndSongsToolStripMenuItem_Click);
            // 
            // genreAndArtistsAndSongsToolStripMenuItem
            // 
            this.genreAndArtistsAndSongsToolStripMenuItem.Name = "genreAndArtistsAndSongsToolStripMenuItem";
            this.genreAndArtistsAndSongsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.genreAndArtistsAndSongsToolStripMenuItem.Text = "Genre and Artists and Songs";
            this.genreAndArtistsAndSongsToolStripMenuItem.Click += new System.EventHandler(this.genreAndArtistsAndSongsToolStripMenuItem_Click);
            // 
            // songsAndReviewsToolStripMenuItem
            // 
            this.songsAndReviewsToolStripMenuItem.Name = "songsAndReviewsToolStripMenuItem";
            this.songsAndReviewsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.songsAndReviewsToolStripMenuItem.Text = "Songs and Reviews";
            this.songsAndReviewsToolStripMenuItem.Click += new System.EventHandler(this.songsAndReviewsToolStripMenuItem_Click);
            // 
            // bandsAndBreakupsAndSongsToolStripMenuItem
            // 
            this.bandsAndBreakupsAndSongsToolStripMenuItem.Name = "bandsAndBreakupsAndSongsToolStripMenuItem";
            this.bandsAndBreakupsAndSongsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.bandsAndBreakupsAndSongsToolStripMenuItem.Text = "Bands and Breakups and Songs";
            this.bandsAndBreakupsAndSongsToolStripMenuItem.Click += new System.EventHandler(this.bandsAndBreakupsAndSongsToolStripMenuItem_Click);
            // 
            // artistsAndSongsToolStripMenuItem
            // 
            this.artistsAndSongsToolStripMenuItem.Name = "artistsAndSongsToolStripMenuItem";
            this.artistsAndSongsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.artistsAndSongsToolStripMenuItem.Text = "Artists and Songs";
            this.artistsAndSongsToolStripMenuItem.Click += new System.EventHandler(this.artistsAndSongsToolStripMenuItem_Click);
            // 
            // bandsAndSongsToolStripMenuItem
            // 
            this.bandsAndSongsToolStripMenuItem.Name = "bandsAndSongsToolStripMenuItem";
            this.bandsAndSongsToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.bandsAndSongsToolStripMenuItem.Text = "Bands and Songs";
            this.bandsAndSongsToolStripMenuItem.Click += new System.EventHandler(this.bandsAndSongsToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 387);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem joinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bandsAndMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genreAndSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genreAndArtistsAndSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songsAndReviewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bandsAndBreakupsAndSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artistsAndSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bandsAndSongsToolStripMenuItem;
    }
}

