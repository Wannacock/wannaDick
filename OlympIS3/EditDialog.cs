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
    public partial class EditDialog : Form
    {
        public EditDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = this.Owner as Form1;
            if (Data.User_Edit == "Allow" || Data.UserType == 1)
            {
                using (SqlConnection con = new SqlConnection(Data.Connection))
                {
                    con.Open();
                    switch (F1.tabControl1.SelectedIndex)
                    {
                        case 0:
                            {
                                SqlCommand com = new SqlCommand(@"UPDATE [Данные документов] set Название = '" + F1.Dannie1.Text + "',Год_издательства = '" + F1.Dannie2.Text + "',ID_Издательства = '" + F1.Dannie3.Text + "',ID_Языка = '" + F1.Dannie4.Text + "',Количество_страниц = '" + F1.Dannie5.Text + "' where ID_Документа = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно изменена");
                                break;
                            }
                        case 1:
                            {
                                SqlCommand com = new SqlCommand(@"UPDATE [Авторы] set Инициалы = '" + F1.Autors1.Text + "',Фамилия = '" + F1.Autors2.Text + "',Имя = '" + F1.Autors3.Text + "',Отчество = '" + F1.Autors4.Text + "' where ID_Автора = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно изменена");
                                break;
                            }
                        case 2:
                            {
                                SqlCommand com = new SqlCommand(@"UPDATE [Издательства] set Издательство = '" + F1.Izateli1.Text + "',Адрес = '" + F1.Izateli2.Text + "',Телефон = '" + F1.Izateli3.Text + "' where ID_Издательства = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно изменена");
                                break;
                            }
                        case 3:
                            {
                                SqlCommand com = new SqlCommand(@"UPDATE [Язык] set Язык = '" + F1.Yazik1.Text + "' where ID_Языка = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно изменена");
                                break;
                            }
                        case 4:
                            {
                                SqlCommand com = new SqlCommand(@"UPDATE [Авторы документов] set ID_Документа = '" + F1.AutorDocs1.Text + "',ID_Автора = '" + F1.AutorDocs2.Text + "',Позиция_автора = '" + F1.AutorDocs3.Text + "' where ID_Данных = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно изменена");
                                break;
                            }

                    }
                }
            }
            else MessageBox.Show("У вас не достаточно прав для изменения полей");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 F1 = this.Owner as Form1;
            if (Data.User_Delete == "Allow" || Data.UserType == 1)
            {
                using (SqlConnection con = new SqlConnection(Data.Connection))
                {
                    con.Open();
                    switch (F1.tabControl1.SelectedIndex)
                    {
                        case 0:
                            {
                                SqlCommand com = new SqlCommand(@"DELETE FROM [Данные документов] where ID_Документа = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно удалена");
                                break;
                            }
                        case 1:
                            {
                                SqlCommand com = new SqlCommand(@"DELETE FROM [Авторы] where ID_Автора = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно удалена");
                                break;
                            }
                        case 2:
                            {
                                SqlCommand com = new SqlCommand(@"DELETE FROM [Издательства] where ID_Издательства = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно удалена");
                                break;
                            }
                        case 3:
                            {
                                SqlCommand com = new SqlCommand(@"DELETE FROM [Язык] where ID_Языка = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно удалена");
                                break;
                            }
                        case 4:
                            {
                                SqlCommand com = new SqlCommand(@"DELETE FROM [Авторы документов] where ID_Данных = '" + Dannie1.Text + "'", con);
                                com.ExecuteNonQuery();
                                MessageBox.Show("Запись успешно удалена");
                                break;
                            }

                    }
                }
            }
            else MessageBox.Show("У вас не достаточно прав для удаления полей");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
