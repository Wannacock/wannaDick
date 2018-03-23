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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button4_Click(null, null);

            if (Data.UserType == 1)
            {
                tabControl1.TabPages[5].Parent = tabControl1;
                button4.Visible = true;
            }
            else
            {
                tabControl1.TabPages[5].Parent = null;
                button6.Visible = false;
            }

            using (SqlConnection con = new SqlConnection(Data.Connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand(@"SELECT * FROM Prava where ID_Prav = 1",con);
                SqlDataReader reader = com.ExecuteReader(); ;
                while (reader.Read())
                {
                    Data.User_Add = reader[1].ToString();
                    Data.User_Delete = reader[2].ToString();
                    Data.User_Edit = reader[3].ToString();
                    Data.User_View = reader[4].ToString();
                    Data.User_ViewExport = reader[5].ToString();
                    Data.User_Export = reader[6].ToString();
                }
            }

            string[] address = { "Kostroma", "Moskva", "SPB", "Yaroslavl" };
            comboBox1.Items.AddRange(address);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autorization au = new Autorization();
            au.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elLibraryDataSet.Авторы_документов". При необходимости она может быть перемещена или удалена.
            this.авторы_документовTableAdapter.Fill(this.elLibraryDataSet.Авторы_документов);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elLibraryDataSet.Язык". При необходимости она может быть перемещена или удалена.
            this.языкTableAdapter.Fill(this.elLibraryDataSet.Язык);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elLibraryDataSet.Издательства". При необходимости она может быть перемещена или удалена.
            this.издательстваTableAdapter.Fill(this.elLibraryDataSet.Издательства);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elLibraryDataSet.Авторы". При необходимости она может быть перемещена или удалена.
            this.авторыTableAdapter.Fill(this.elLibraryDataSet.Авторы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elLibraryDataSet.Данные_документов". При необходимости она может быть перемещена или удалена.
            this.данные_документовTableAdapter.Fill(this.elLibraryDataSet.Данные_документов);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Data.Connection))
            {
                if ((Data.User_Add == "Allow") || (Data.UserType == 1))
                {
                    con.Open();
                    switch (tabControl1.SelectedIndex)
                    {
                        case 0:
                            {
                                SqlCommand com = new SqlCommand(@"INSERT INTO [Данные документов](Название,Год_издательства,ID_Издательства,ID_Языка,Количество_страниц) values('" + Dannie1.Text + "','" + Dannie2.Text + "','" + Dannie3.Text + "','" + Dannie4.Text + "','" + Dannie5.Text + "') ", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно добавлена");
                                break;
                            }
                        case 1:
                            {
                                SqlCommand com = new SqlCommand(@"INSERT INTO [Авторы](Инициалы,Фамилия,Имя,Отчество) values('" + Autors1.Text + "','" + Autors2.Text + "','" + Autors3.Text + "','" + Autors4.Text + "') ", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно добавлена");
                                break;
                            }
                        case 2:
                            {
                                SqlCommand com = new SqlCommand(@"INSERT INTO [Издательства](Издательство,Адрес,Телефон) values('" + Izateli1.Text + "','" + Izateli2.Text + "','" + Izateli3.Text + "') ", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно добавлена");
                                break;
                            }
                        case 3:
                            {
                                SqlCommand com = new SqlCommand(@"INSERT INTO [Язык](Язык) values('" + Yazik1.Text + "') ", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно добавлена");
                                break;
                            }
                        case 4:
                            {
                                SqlCommand com = new SqlCommand(@"INSERT INTO [Авторы документов](ID_Документа,ID_Автора,Позиция_автора) values('" + AutorDocs1.Text + "','" + AutorDocs2.Text + "','" + AutorDocs3.Text + "') ", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно добавлена");
                                break;
                            }
                    }
                }
                else MessageBox.Show("У вас не достаточно прав для добавления записей");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminPanel AP = new AdminPanel();
            AP.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditDialog ED = new EditDialog();
            ED.Owner = this;
            ED.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Export ex = new Export();
            ex.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] Kostroma = { "ул.Овражная", "ул.Смоленская", "ул.Свердлова", "прт.Текстильщиков" };
            string[] Moskva = { "прт.Вернадского", "ул.Дубининская", "ул.Люсиновская", "ул.Донская" };
            string[] SPB = { "ул.Рыбинская", "прт.Лиговский", "ул.Днепропетровская", "ул.Седова" };
            string[] Yaroslavl = { "ул.Угличская", "прт.Чкаловка", "прт.Ленина", "ул.Свободы" };


            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.AddRange(Kostroma);
                        break;
                    }
                case 1:
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.AddRange(Moskva);
                        break;
                    }
                case 2:
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.AddRange(SPB);
                        break;
                    }
                case 3:
                    {
                        comboBox2.Items.Clear();
                        comboBox2.Items.AddRange(Yaroslavl);
                        break;
                    }

            }
        }
    }
}
