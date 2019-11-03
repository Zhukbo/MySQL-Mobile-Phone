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
    public partial class Form1 : Form
    {
        string DB = "server=IP; port=3306; database=MobilePhone; user=root; password=12345; charset=utf8";
        //string selectedState;
        public DataRowCollection Genre_List;
        public Form1()
        {
            InitializeComponent();
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                Conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from Category_Phone", DB);
                DataSet ds = new DataSet();
                da.Fill(ds);
                bool checker1 = false;
                bool checker2 = false;
                foreach (DataRow i in ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(i.ItemArray[1]);
                    if (i.ItemArray[1].ToString() == "Смартфон" && i.ItemArray[2].ToString() == "Сенсорний")
                    {
                        checker1 = true;
                    }
                    if (i.ItemArray[1].ToString() == "Кнопочний" && i.ItemArray[2].ToString() == "Кырпіч")
                    {
                        checker2 = true;
                    }
                }
                if (!checker1 || !checker2)
                {
                    MySqlCommand cmd = Conn.CreateCommand();
                    if (!checker1)
                    {
                        cmd.CommandText = "insert Category_Phone (Name,Description) " + " values ('Смартфон', 'Сенсорний')";
                        cmd.ExecuteNonQuery();
                    }
                    if (!checker2)
                    {
                        cmd.CommandText = "insert Category_Phone (Name,Description) " + " values (N'Кнопочний', N'Кырпіч')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            Refresh_ComboBox();
        }


        public void Refresh_ComboBox()
        {
            comboBox1.Items.Clear();
            using (MySqlConnection Conn = new MySqlConnection(DB))
            {
                Conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from Category_Phone", DB);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Genre_List = ds.Tables[0].Rows;
                foreach (DataRow i in Genre_List)
                {
                    comboBox1.Items.Add(i.ItemArray[1].ToString());
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            if (checkBox1.Checked == true) checkBox2.Checked = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            errorProvider2.Clear();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            if (checkBox2.Checked == true) checkBox1.Checked = false;
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            errorProvider1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                if (checkBox1.Checked)
                {
                    string category = null; ;
                    foreach (DataRow i in Genre_List)
                    {
                        if (i.ItemArray[1].ToString() == comboBox1.Text)
                        {
                            category = i.ItemArray[0].ToString();
                            break;
                        }
                    }
                    if (category != null)
                    {
                        using (MySqlConnection Conn = new MySqlConnection(DB))
                        {
                            Conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter("select * " + " from Model_Phone as MP " + " where MP.Category_ID = " + category, DB);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(comboBox1, "Виберіть катeгорію телефона");
                    }
                }
                else if (checkBox2.Checked)
                {
                    int id;
                    if (int.TryParse(textBox1.Text, out id) && id >= 1) errorProvider2.Clear(); else errorProvider2.SetError(textBox1, "Введіть id цифрами більше чим 0");
                    if (errorProvider2.GetError(textBox1) == "")
                    {
                        using (MySqlConnection Conn = new MySqlConnection(DB))
                        {
                            Conn.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter("select * " + " from Model_Phone as MP " + " where MP.ID = " + textBox1.Text, DB);
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
                else
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter("select * from Model_Phone AS MP INNER JOIN Category_Phone AS CP ON MP.Category_ID = CP.ID", DB);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                if (!String.IsNullOrEmpty(textBox2.Text)) errorProvider1.Clear(); else errorProvider1.SetError(textBox2, "Введіть назву телефона");
                if (!String.IsNullOrEmpty(textBox3.Text)) errorProvider2.Clear(); else errorProvider2.SetError(textBox3, "Введіть назву виробника");
                if (!String.IsNullOrEmpty(textBox4.Text)) errorProvider3.Clear(); else errorProvider3.SetError(textBox4, "Введіть назву процесора");
                if (!String.IsNullOrEmpty(textBox5.Text)) errorProvider4.Clear(); else errorProvider4.SetError(textBox5, "Введіть дані про камеру");

                string category = null; ;
                foreach (DataRow i in Genre_List)
                {
                    if (i.ItemArray[1].ToString() == comboBox1.Text)
                    {
                        category = i.ItemArray[0].ToString();
                        break;
                    }
                }
                if (category != null) errorProvider5.Clear(); else errorProvider5.SetError(comboBox1, "Виберіть катeгорію телефона");
                if (errorProvider1.GetError(textBox2) == "" && errorProvider2.GetError(textBox3) == "" && errorProvider3.GetError(textBox4) == "" && errorProvider4.GetError(textBox5) == "" && errorProvider5.GetError(comboBox1) == "")
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "insert into Model_Phone (Name, Manufacturer, Processor, Camera, Category_ID) "+"  values ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "', '" + category + "')";
                        MessageBox.Show("Число доданих записів: " + cmd.ExecuteNonQuery());
                    }
                }
            }
            else if (radioButton3.Checked)
            {
                int id;
                string category = null;
                if (!String.IsNullOrEmpty(textBox2.Text)) errorProvider1.Clear(); else errorProvider1.SetError(textBox2, "Введіть назву телефона");
                if (!String.IsNullOrEmpty(textBox3.Text)) errorProvider2.Clear(); else errorProvider2.SetError(textBox3, "Введіть назву виробника");
                if (!String.IsNullOrEmpty(textBox4.Text)) errorProvider3.Clear(); else errorProvider3.SetError(textBox4, "Введіть назву процесора");
                if (!String.IsNullOrEmpty(textBox5.Text)) errorProvider4.Clear(); else errorProvider4.SetError(textBox5, "Введіть дані про камеру");
                if (int.TryParse(textBox1.Text, out id) && id >= 1) errorProvider5.Clear(); else errorProvider5.SetError(textBox1, "Введіть id цифрами більше чим 0");
                foreach (DataRow i in Genre_List)
                {
                    if (i.ItemArray[1].ToString() == comboBox1.Text)
                    {
                        category = i.ItemArray[0].ToString();
                        break;
                    }
                }
                if (category != null) errorProvider6.Clear(); else errorProvider6.SetError(comboBox1, "Виберіть катeгорію телефона");
                if (errorProvider1.GetError(textBox2) == "" && errorProvider2.GetError(textBox3) == "" && errorProvider3.GetError(textBox4) == "" && errorProvider4.GetError(textBox5) == "" && errorProvider6.GetError(comboBox1) == "" && errorProvider5.GetError(textBox1) == "")
                {
                    using (MySqlConnection Conn = new MySqlConnection(DB))
                    {
                        Conn.Open();
                        MySqlCommand cmd = Conn.CreateCommand();
                        cmd.CommandText = "update Model_Phone " + " set Name = '" + textBox2.Text + "', Manufacturer = '" + textBox3.Text + "', Processor = '" + textBox4.Text + "', Camera = '" + textBox5.Text + "', Category_ID = '" + category + "' where ID = " + textBox1.Text;
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
                        cmd.CommandText = "delete from Model_Phone " + " where ID = " + textBox1.Text;
                        MessageBox.Show("Число вилучених записів: " + cmd.ExecuteNonQuery());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Second qwer = new Second();

            qwer.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
