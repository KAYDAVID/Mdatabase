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
using System.Threading;

namespace MusicDatabase
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.comboBox1.Items.Add("Songs");
            this.comboBox1.Items.Add("Artists");
            this.comboBox1.Items.Add("Bands");
            this.comboBox1.Items.Add("Reviews");
            this.comboBox1.Items.Add("Band Breakup");
            this.comboBox1.Items.Add("Band Memebers");

            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;

            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlTransaction Tx = null;
            string filename;
            string[] data;

            string version, connectionInfo;
            SqlConnection db = null;
            version = "MSSQLLocalDB";
            filename = "MusicDB.mdf";

            connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;", version, filename);

            int count = 0;

            while (count <= 3)
            {
                try
                {
                    db = new SqlConnection(connectionInfo);

                    db.Open();

                    Tx = db.BeginTransaction(IsolationLevel.Serializable);

                    string sql, msg;
                    SqlCommand cmd;

                    string table = null, col1 = null, col2 = null, col3 = null, col4 = null;
                    string val1 = null, val2 = null, val3 = null, val4 = null;

                    Thread.Sleep(Convert.ToInt32(this.textBox4.Text));

                    if (this.comboBox1.SelectedIndex == 0)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = db;
                        cmd.Transaction = Tx;
                        cmd.CommandText =
                        String.Format(@"
                    SELECT MAX(SID)
                    FROM Songs;
                    ");
                        //MessageBox.Show(cmd.CommandText);
                        object result = cmd.ExecuteScalar();

                        int max = (int)result + 1;


                        table = "Songs";
                        col1 = "SID, ";
                        col2 = "Genre, ";
                        col3 = "SongTitle, ";
                        col4 = "ReleaseYear";

                        val1 = "'" + max.ToString() + "', ";
                        val2 = "'" + this.textBox1.Text + "', ";
                        val3 = "'" + this.textBox2.Text + "', ";
                        val4 = "'" + this.textBox3.Text + "'";
                    }

                    else if (this.comboBox1.SelectedIndex == 1)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = db;
                        cmd.Transaction = Tx;
                        cmd.CommandText =
                        String.Format(@"
                    SELECT MAX(AID)
                    FROM Artists;
                    ");
                        //MessageBox.Show(cmd.CommandText);
                        object result = cmd.ExecuteScalar();

                        int max = (int)result + 1;

                        table = "Artists";
                        col1 = "AID, ";
                        col2 = "Name, ";
                        col3 = "YOB, ";
                        col4 = "Gender";

                        val1 = "'" + max.ToString() + "', ";
                        val2 = "'" + this.textBox1.Text + "', ";
                        val3 = "'" + this.textBox2.Text + "', ";
                        val4 = "'" + this.textBox3.Text + "'";
                    }

                    else if (this.comboBox1.SelectedIndex == 2)
                    {
                        cmd = new SqlCommand();
                        cmd.Connection = db;
                        cmd.Transaction = Tx;
                        cmd.CommandText =
                        String.Format(@"
                    SELECT MAX(BID)
                    FROM Bands;
                    ");
                        //MessageBox.Show(cmd.CommandText);
                        object result = cmd.ExecuteScalar();

                        int max = (int)result + 1;

                        table = "Bands";
                        col1 = "BID, ";
                        col2 = "Name, ";
                        col3 = "YOB";
                        //col4 = "Gender";

                        val1 = "'" + max.ToString() + "', ";
                        val2 = "'" + this.textBox1.Text + "', ";
                        val3 = "'" + this.textBox2.Text + "'";
                        //val4 = "'" + this.textBox3.Text + "'";
                    }

                    else if (this.comboBox1.SelectedIndex == 3)
                    {
                        string title = "'" + this.textBox1.Text + "'";

                        cmd = new SqlCommand();
                        cmd.Connection = db;
                        cmd.Transaction = Tx;
                        cmd.CommandText =
                        String.Format(@"
                    SELECT SID
                    FROM Songs WHERE SongTitle = {0};
                    ", title);
                        //MessageBox.Show(cmd.CommandText);
                        object result2 = cmd.ExecuteScalar();

                        table = "Reviews";
                        //col1 = "RID, ";
                        col2 = "SID, ";
                        col3 = "Review";
                        //col4 = "Gender";

                        //val1 = "'" + max.ToString() + "', ";
                        val1 = "'" + result2.ToString() + "', ";
                        val2 = "'" + this.textBox2.Text + "'";
                        //val4 = "'" + this.textBox3.Text + "'";
                    }

                    else if (this.comboBox1.SelectedIndex == 4)
                    {

                        cmd = new SqlCommand();
                        cmd.Connection = db;
                        cmd.Transaction = Tx;
                        cmd.CommandText =
                        String.Format(@"
                    SELECT MAX(FID)
                    FROM BandBreakups;
                    ");
                        //MessageBox.Show(cmd.CommandText);
                        object result = cmd.ExecuteScalar();

                        int max = (int)result + 1;

                        string title = "'" + this.textBox1.Text + "'";

                        cmd = new SqlCommand();
                        cmd.Connection = db;
                        cmd.CommandText =
                        String.Format(@"
                    SELECT BID
                    FROM Bands WHERE Name = {0};
                    ", title);
                        //MessageBox.Show(cmd.CommandText);
                        object result2 = cmd.ExecuteScalar();

                        table = "BandBreakups";
                        col1 = "FID, ";
                        col2 = "BID, ";
                        col3 = "Form, ";
                        col4 = "Breakup";

                        val1 = "'" + max.ToString() + "', ";
                        val2 = "'" + result2.ToString() + "', ";
                        val3 = "'" + this.textBox2.Text + "', ";
                        val4 = "'" + this.textBox3.Text + "'";
                    }

                    //else if (this.comboBox1.SelectedIndex == 5)
                    //{

                    //    cmd = new SqlCommand();
                    //    cmd.Connection = db;
                    //    cmd.CommandText =
                    //    String.Format(@"
                    //        SELECT FID
                    //        FROM BandBreakups WHERE ;
                    //        ");
                    //    //MessageBox.Show(cmd.CommandText);
                    //    object result = cmd.ExecuteScalar();

                    //    int max = (int)result + 1;

                    //    string title = "'" + this.textBox1.Text + "'";

                    //    cmd = new SqlCommand();
                    //    cmd.Connection = db;
                    //    cmd.CommandText =
                    //    String.Format(@"
                    //        SELECT BID
                    //        FROM Bands WHERE Name = {0};
                    //        ", title);
                    //    //MessageBox.Show(cmd.CommandText);
                    //    object result2 = cmd.ExecuteScalar();

                    //    table = "Band Breakup";
                    //    col1 = "FID, ";
                    //    col2 = "BID, ";
                    //    col3 = "Form";
                    //    col4 = "Breakup";

                    //    val1 = "'" + max.ToString() + "', ";
                    //    val1 = "'" + result2.ToString() + "', ";
                    //    val2 = "'" + this.textBox2.Text + "', ";
                    //    val4 = "'" + this.textBox3.Text + "'";
                    //}

                    cmd = new SqlCommand();
                    cmd.Connection = db;
                    cmd.Transaction = Tx;
                    cmd.CommandText =
                            String.Format(@"
                    INSERT INTO
                    {0}({1}{2}{3}{4})
                    Values({5}{6}{7}{8});
                    ", table, col1, col2, col3, col4, val1, val2, val3, val4);
                    // MessageBox.Show(cmd.CommandText);

                    cmd.ExecuteNonQuery();

                    Tx.Commit();
                }

                catch (Exception ex)
                {
                    if (Tx != null)
                        Tx.Rollback();

                    count++;
                    MessageBox.Show(ex.Message);
                }


                finally
                {
                    if (db != null)
                        db.Close();
                    count = 3;
                    this.Close();
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                this.label2.Text = "Song Title";
                this.label2.Visible = true;
                this.textBox1.Enabled = true;

                this.label3.Text = "Genre";
                this.label3.Visible = true;
                this.textBox2.Enabled = true;

                this.label4.Text = "Release Year";
                this.label4.Visible = true;
                this.textBox3.Enabled = true;
            }

            else if (this.comboBox1.SelectedIndex == 1)
            {
                this.label2.Text = "Name";
                this.label2.Visible = true;
                this.textBox1.Enabled = true;

                this.label3.Text = "Year of Birth";
                this.label3.Visible = true;
                this.textBox2.Enabled = true;

                this.label4.Text = "Gender";
                this.label4.Visible = true;
                this.textBox3.Enabled = true;
            }

            else if (this.comboBox1.SelectedIndex == 2)
            {
                this.label2.Text = "Name";
                this.label2.Visible = true;
                this.textBox1.Enabled = true;

                this.label3.Text = "Year of Formation";
                this.label3.Visible = true;
                this.textBox2.Enabled = true;

                this.label4.Text = " ";
                this.label4.Visible = false;
                this.textBox3.Enabled = false;
            }

            else if (this.comboBox1.SelectedIndex == 3)
            {
                this.label2.Text = "Song Title";
                this.label2.Visible = true;
                this.textBox1.Enabled = true;

                this.label3.Text = "Review";
                this.label3.Visible = true;
                this.textBox2.Enabled = true;

                this.label4.Text = "";
                this.label4.Visible = false;
                this.textBox3.Enabled = false;
            }

            else if (this.comboBox1.SelectedIndex == 4)
            {
                this.label2.Text = "Band Name";
                this.label2.Visible = true;
                this.textBox1.Enabled = true;

                this.label3.Text = "Form Date";
                this.label3.Visible = true;
                this.textBox2.Enabled = true;

                this.label4.Text = "End Data";
                this.label4.Visible = true;
                this.textBox3.Enabled = true;
            }

            else if (this.comboBox1.SelectedIndex == 5)
            {
                this.label2.Text = "Band Name";
                this.label2.Visible = true;
                this.textBox1.Enabled = true;

                this.label3.Text = "Member Name";
                this.label3.Visible = true;
                this.textBox2.Enabled = true;

                this.label4.Text = "";
                this.label4.Visible = false;
                this.textBox3.Enabled = false;
            }




        }
    }
}
