using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace App2
{
    public partial class Second : Form
    {
        public Second()
        {
            InitializeComponent();
        }
        string DB = "server=IP; port=3306; database=MobilePhone; user=root; password=12345; charset=utf8";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                using (MySqlConnection Conn = new MySqlConnection(DB))
                {
                    Conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("select * " + " from Category_Phone", DB);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else if (radioButton2.Checked)
            {
                if (!String.IsNullOrEmpty(textBox2.Text)) errorProvider1.Clear(); else errorProvider1.SetError(textBox2, "Введіть назву категорії");
                if (!String.IsNullOrEmpty(textBox3.Text)) errorProvider2.Clear(); else errorProvider2.SetError(textBox3, "Напишіть якийсь опис");
                if (errorProvider1.GetError(textBox2) == "" && (errorProvider2.GetError(textBox3) == ""))
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "insert Category_Phone (Name,Description)"+" values ('" + textBox2.Text + "', '" + textBox3.Text + "')";
                        MessageBox.Show("Число доданих записів: " + cmd.ExecuteNonQuery());
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                int id;
                if (int.TryParse(textBox1.Text, out id) && id >= 1) errorProvider1.Clear(); else errorProvider1.SetError(textBox1, "Введіть id цифрами більше чим 0");
                if (!String.IsNullOrEmpty(textBox2.Text)) errorProvider2.Clear(); else errorProvider2.SetError(textBox2, "Введіть назву категорії");
                if (!String.IsNullOrEmpty(textBox3.Text)) errorProvider3.Clear(); else errorProvider3.SetError(textBox3, "Напишіть якийсь опис");

                if (errorProvider2.GetError(textBox2) == "" && errorProvider3.GetError(textBox3) == "" && errorProvider1.GetError(textBox1) == "")
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "update Category_Phone " + " set Name = '" + textBox2.Text + "', Description = '" + textBox3.Text + "' where ID = " + textBox1.Text;
                        MessageBox.Show("Число оновлених записів: " + cmd.ExecuteNonQuery());
                    }
                }

            }
            else
            {
                int id;
                if (int.TryParse(textBox1.Text, out id) && id >= 1) errorProvider1.Clear(); else errorProvider1.SetError(textBox1, "Введіть id цифрами більше чим 0");
                if (errorProvider1.GetError(textBox1) == "")
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "delete from Category_Phone " + " where ID = " + textBox1.Text;
                        MessageBox.Show("Число вилучених записів: " + cmd.ExecuteNonQuery());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 firma = new Form1();
            firma.Show();
            this.Hide();
        }

        private void Second_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
