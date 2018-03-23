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

namespace OlympIS3
{
    public partial class Autorization : Form
    {
        
        
        public Autorization()
        {
            InitializeComponent();
        }

        private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(SqlConnection con = new SqlConnection(Data.Connection))
            {
                try
                {
                    con.Open();
                    if ((textBox1.Text != "") && (textBox2.Text != ""))
                    {
                        try
                        {
                            SqlCommand com = new SqlCommand(@"SELECT Type From Users where login = '"+ textBox1.Text +"' and password = '"+ textBox2.Text +"'",con);
                            int Type = (int)com.ExecuteScalar();
                            Data.UserType = Type;
                            Form1 F1 = new Form1();
                            F1.Show();
                            this.Hide();
                        }
                        catch
                        {
                            MessageBox.Show("Неправильно введен логин или пароль");
                        }

                    }
                    else MessageBox.Show("Заполните поля логина и пароля");
                }
                catch
                {
                    MessageBox.Show("Отсутствует соединение с сервером");
                }
            }
        }
    }
}
