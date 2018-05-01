using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MusicDatabase
{
    public partial class Form1 : Form
    {
        public List<string> SQLstrings = new List<string>();
        private DataGridView mainDataGridView;
        private SqlDataAdapter DA = new SqlDataAdapter();
        private BindingSource mainbindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            mainDataGridView = this.dataGridView1;

            this.comboBox1.Items.Add("Songs");
            this.comboBox1.Items.Add("Artists");
            this.comboBox1.Items.Add("Bands");
            this.comboBox1.Items.Add("Reviews");
            this.comboBox1.Items.Add("Band Breakup");
            this.comboBox1.Items.Add("Band Memebers");
        }

        //Create tables
        private void button1_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            if (System.IO.File.Exists("MusicDB.mdf"))
            {
                System.IO.File.Delete("MusicDB.mdf");
                System.IO.File.Delete("MusicDB_log.ldf");
            }

            System.IO.File.Copy("Empty.mdf", "MusicDB.mdf");

            string filename, version, connectionInfo;
            SqlConnection db;
            version = "MSSQLLocalDB";
            filename = "MusicDB.mdf";

            connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);

            db = new SqlConnection(connectionInfo);

            db.Open();

            string sql, msg;
            SqlCommand cmd;

            //sql = String.Format(@"
            //CREATE TABLE Songs (
            //SID INT IDENTITY(1,1) PRIMARY KEY,
            //Genre NVARCHAR(128) NOT NULL,
            //SongTitle NVARCHAR(128) NOT NULL,
            //ReleaseDate SMALLINT
            //);
            //");

            //MessageBox.Show(sql);

            int rowsModified = 0;

            foreach (string S in SQLstrings)
            {
                cmd = new SqlCommand();
                cmd.Connection = db;
                cmd.CommandText = S;
                rowsModified = cmd.ExecuteNonQuery();
            }

           // MessageBox.Show(rowsModified.ToString());

            db.Close();

            this.Cursor = Cursors.Default;

            if (rowsModified == 0)
                MessageBox.Show("Table Creation Failed");
            else
                MessageBox.Show("Table Creation Succeeded");
        }

        //Delete table
        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("MusicDB.mdf"))
            {
                System.IO.File.Delete("MusicDB.mdf");
                System.IO.File.Delete("MusicDB_log.ldf");
            }

            System.IO.File.Copy("Empty.mdf", "MusicDB.mdf");

            MessageBox.Show("Database Cleared");
        }

        //Fill SQL List
        private void button3_Click(object sender, EventArgs e)
        {
            string sql;

            //Songs Table
            sql = String.Format(@"
            CREATE TABLE Songs (
            SID INT PRIMARY KEY,
            Genre NVARCHAR(128) NOT NULL,
            SongTitle NVARCHAR(128) NOT NULL,
            ReleaseYear SMALLINT
            );
            ");

            SQLstrings.Add(sql);

            //Artists Table
            sql = String.Format(@"
            CREATE TABLE Artists (
            AID INT PRIMARY KEY,
            Name NVARCHAR(128) NOT NULL,
            YOB SMALLINT NOT NULL,
            Gender NVARCHAR(1) NOT NULL
            );
            ");

            SQLstrings.Add(sql);

            //Bands Table
            sql = String.Format(@"
            CREATE TABLE Bands (
            BID INT PRIMARY KEY,
            Name NVARCHAR(128) NOT NULL,
            YOB SMALLINT NOT NULL
            );
            ");

            SQLstrings.Add(sql);

            //Reviews Table
            sql = String.Format(@"
            CREATE TABLE Reviews (
            RID INT IDENTITY(1,1) PRIMARY KEY,
            SID INT NOT NULL FOREIGN KEY REFERENCES Songs(SID),
            Review SMALLINT NOT NULL
            );
            ");

            SQLstrings.Add(sql);

            //Artists Songs Table
            sql = String.Format(@"
            CREATE TABLE ArtistsSongs (
            AID INT NOT NULL FOREIGN KEY REFERENCES Artists(AID),
            SID INT NOT NULL FOREIGN KEY REFERENCES Songs(SID)
            );
            ");

            SQLstrings.Add(sql);

            //Band Breakup Table
            sql = String.Format(@"
            CREATE TABLE BandBreakups (
            FID INT PRIMARY KEY,
            BID INT NOT NULL FOREIGN KEY REFERENCES Bands(BID),
            Form SMALLINT NOT NULL,
            BreakUp SMALLINT NOT NULL
            );
            ");

            SQLstrings.Add(sql);

            //Band Members
            sql = String.Format(@"
            CREATE TABLE BandMembers (
            FID INT NOT NULL FOREIGN KEY REFERENCES BandBreakups(FID),
            BID INT NOT NULL FOREIGN KEY REFERENCES Bands(BID),
            Member NVARCHAR(128) NOT NULL
            );
            ");

            SQLstrings.Add(sql);

            MessageBox.Show("List Filled");

        }

        // Fill Database
        private void button4_Click(object sender, EventArgs e)
        {
            string filename;
            string[] data;

            filename = this.textBox1.Text;

            if (System.IO.File.Exists(filename))
            {
                 data = System.IO.File.ReadAllLines(filename);
                //MessageBox.Show("File found");
            }
            else { data = null;
                MessageBox.Show("Error No File ");
                return;
            }

            string version, connectionInfo;
            SqlConnection db;
            version = "MSSQLLocalDB";
            filename = "MusicDB.mdf";

            connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);

            db = new SqlConnection(connectionInfo);

            db.Open();

            string sql, msg;
            SqlCommand cmd;

            string table = null, col1 = null, col2 = null, col3 = null, col4 = null;
            string val1 = null, val2 = null, val3 = null, val4 = null;

            bool isFirstLine = true;

            foreach (string S in data)
            {

                if (isFirstLine == true)
                {
                    string[] cuttings = S.Split(',');
                    table = cuttings[0];
                    col1 = cuttings[1] + ", ";
                    col2 = cuttings[2];
                    if (cuttings.GetLength(0) == 4)
                    {
                        col2 += ", ";
                        col3 = cuttings[3];
                    }
                    if (cuttings.GetLength(0) == 5)
                    {
                        col2 += ", ";
                        col3 = cuttings[3] + ", ";
                        col4 = cuttings[4];
                    }

                    isFirstLine = false;
                }

                else
                {
                    string newS = S;

                    newS.Replace("'", "''");

                    string[] cuttings = new string[4];
                    
                    cuttings = newS.Split(',');

                    for(int i = 0; i < cuttings.GetLength(0); i++)
                    {
                        string tmp = "'";
                        tmp += cuttings[i];
                        tmp += "'";
                        cuttings[i] = tmp;
                    }

                    for(int i = 0; i < cuttings.GetLength(0)-1; i++)
                    {
                        if (cuttings[i+1] != "")
                        {
                            cuttings[i] += ", ";
                        }

                    }

                    val1 = cuttings[0];
                    val2 = cuttings[1];
                    if (cuttings.GetLength(0) == 3)
                    {
                        val3 = cuttings[2];
                    }

                    if (cuttings.GetLength(0) == 4)
                    {
                        val3 = cuttings[2];
                        val4 = cuttings[3];
                    }

                    cmd = new SqlCommand();
                    cmd.Connection = db;
                    cmd.CommandText =
                    String.Format(@"
                    INSERT INTO
                    {0}({1}{2}{3}{4})
                    Values({5}{6}{7}{8});
                    ", table, col1, col2, col3, col4, val1, val2, val3, val4);
                    //MessageBox.Show(cmd.CommandText);
                    cmd.ExecuteNonQuery();

                    
                }
                
            }

            MessageBox.Show(String.Format(@"{0} File Entered", this.textBox1.Text));
            db.Close();

        }

        // Complete Setup
        private void button5_Click(object sender, EventArgs e)
        {
            //Fill list with SQL table creation commands
            button3.PerformClick();

            //Run thru list performing all create table commands
            button1.PerformClick();

            //Loop thru adding all data
            string[] filenames = new string[] { "Songs.txt", "Artists.txt", "Bands.txt", "Reviews.txt", "ArtistsSongs.txt", "BandBreakups.txt","BandMembers.txt" };
            string[] data;

            foreach (var filename in filenames)
            {
                this.textBox1.Text = filename;

                button4.PerformClick();
            }

        }

        //get specific data from database for display
        private void GetData(string command)
        {
            string version = "MSSQLLocalDB";
            string filename = "MusicDB.mdf";

            string connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);

            DA = new SqlDataAdapter(command, connectionInfo);

            SqlCommandBuilder builder = new SqlCommandBuilder(DA);

            DataTable table = new DataTable();

            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            DA.Fill(table);
            mainbindingSource.DataSource = table;

            mainDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        
        //tmp
        //private void button6_Click(object sender, EventArgs e)
        //{
        //    mainDataGridView.DataSource = mainbindingSource;
        //    GetData("select * from Artists"); 
        //}

        //Add data
        private void button6_Click_1(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
        }

        //display data
        private void button7_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                mainDataGridView.DataSource = mainbindingSource;
                GetData("select * from Songs");
            }

            else if (this.comboBox1.SelectedIndex == 1)
            {
                mainDataGridView.DataSource = mainbindingSource;
                GetData("select * from Artists");
            }

            else if (this.comboBox1.SelectedIndex == 2)
            {
                mainDataGridView.DataSource = mainbindingSource;
                GetData("select * from Bands");
            }

            else if (this.comboBox1.SelectedIndex == 3)
            {
                mainDataGridView.DataSource = mainbindingSource;
                GetData("select * from Reviews");
            }

            else if (this.comboBox1.SelectedIndex == 4)
            {
                mainDataGridView.DataSource = mainbindingSource;
                GetData("select * from BandBreakups");
            }

            else if (this.comboBox1.SelectedIndex == 5)
            {
                mainDataGridView.DataSource = mainbindingSource;
                GetData("select * from BandMembers");
            }


        }

        //tmp work with joins
        /*
        private void button9_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = mainbindingSource;
            GetData(String.Format(@"
                    SELECT Bands.Name, BandBreakups.Form, BandBreakups.Breakup
                    FROM BandBreakups
                    INNER JOIN Bands
                    ON BandBreakups.BID = Bands.BID
                    WHERE Bands.Name = 'Span';"));

        }
        */

        // Joins Menu

        private void artistsAndSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = mainbindingSource;
            //GetData(String.Format(@"
            //        SELECT Artists.Name, tmp.SongTitle
            //        FROM ( SELECT ArtistsSongs.AID, Songs.SongTitle
            //                FROM Songs
            //                INNER JOIN ArtistsSongs
            //                ON ArtistsSongs.SID = Songs.SID
            //                ) As tmp
            //        INNER JOIN Artists
            //        ON tmp.AID = Artists.AID;"));

            GetData(String.Format(@"
                    SELECT Artists.Name, Songs.SongTitle
                    FROM Artists
                    INNER JOIN ArtistsSongs ON ArtistsSongs.AID = Artists.AID
                    INNER JOIN Songs on ArtistsSongs.SID = Songs.SID
                    ORDER BY Artists.Name ASC, Songs.SongTitle ASC;"));

        }

        private void bandsAndSongsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


        }

        private void bandsAndMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = mainbindingSource;
            GetData(String.Format(@"
                    SELECT Bands.Name, BandMembers.Member
                    FROM BandMembers
                    INNER JOIN Bands
                    ON BandMembers.BID = Bands.BID"));
        }

        private void genreAndSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = mainbindingSource;
            GetData(String.Format(@"
                    SELECT Songs.Genre, Songs.SongTitle
                    FROM Songs"));

        }

        private void genreAndArtistsAndSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bandsAndBreakupsAndSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = mainbindingSource;
            GetData(String.Format(@"
                    SELECT Bands.Name, BandBreakups.Form, BandBreakups.Breakup
                    FROM BandBreakups
                    INNER JOIN Bands
                    ON BandBreakups.BID = Bands.BID;"));
        }

        private void songsAndReviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainDataGridView.DataSource = mainbindingSource;
            GetData(String.Format(@"
                    SELECT Songs.SongTitle, Reviews.Review
                    FROM Reviews
                    INNER JOIN Songs
                    ON Songs.SID = Reviews.SID;"));
        }



    }
}
