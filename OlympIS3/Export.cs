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
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace OlympIS3
{
    public partial class Export : Form
    {

        public Export()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Data.Connection))
            {
                con.Open();
                System.Data.DataTable dt = new System.Data.DataTable();
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT Название FROM [Данные документов] where Количество_страниц > 200", con);
                            SqlDataAdapter da = new SqlDataAdapter(com);
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            break;
                        }
                    case 1:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT SUM(Количество_страниц) FROM [Данные документов]", con);
                            SqlDataAdapter da = new SqlDataAdapter(com);
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            break;
                        }
                    case 2:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT [Данные документов].Название,[Авторы].Имя,[Авторы].Фамилия,[Авторы].Отчество FROM [Данные документов],[Авторы],[Авторы документов] where ([Данные документов].ID_Документа = [Авторы документов].ID_Документа) and ([Авторы].ID_Автора = [Авторы документов].ID_Автора and ([Авторы документов].Позиция_автора = 3))",con);
                            SqlDataAdapter da = new SqlDataAdapter(com);
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            break;
                        }
                    case 3:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT DISTINCT [Издательства].Издательство FROM [Издательства],[Данные документов],[Авторы документов] where (([Авторы документов].ID_Автора = 3) and ([Данные документов].ID_Документа = [Авторы документов].ID_Документа) and ([Издательства].ID_Издательства = [Данные документов].ID_Издательства))", con);
                            SqlDataAdapter da = new SqlDataAdapter(com);
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            break;
                        }
                    case 4:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT DISTINCT [Данные документов].Название, [Авторы].Инициалы FROM[Авторы],[Издательства],[Данные документов],[Авторы документов] where(([Авторы документов].ID_Автора = [Авторы].ID_Автора) and([Данные документов].ID_Документа = [Авторы документов].ID_Документа) and ([Издательства].ID_Издательства = [Данные документов].ID_Издательства) and[Данные документов].Год_издательства >= '2009.01.01' and[Данные документов].Год_издательства <= '2015.12.31')", con);
                            SqlDataAdapter da = new SqlDataAdapter(com);
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            break;
                        }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Data.Connection))
            {
                con.Open();
                Excel.Application exApp = new Excel.Application();
                exApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)exApp.ActiveSheet;

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            worksheet.Cells[3, "A"] = "ID_документа";
                            worksheet.Cells[3, "B"] = "Название";
                            SqlCommand com = new SqlCommand(@"SELECT ID_документа,Название FROM [Данные документов] where Количество_страниц > 200", con);
                            SqlDataReader reader = com.ExecuteReader();
                            int ket = 4;
                            while (reader.Read())
                            {
                                worksheet.Cells[ket, "A"] = reader.GetInt32(0);
                                worksheet.Cells[ket, "B"] = reader.GetInt32(0);
                                ket++;
                            }
                            worksheet.SaveAs(Environment.CurrentDirectory + "\\" + "repor.xls");
                            exApp.Quit();
                            MessageBox.Show("Отчет успешно создан");
                            break;
                        }
                    case 1:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT SUM(Количество_страниц) FROM [Данные документов]", con);
                            break;
                        }
                    case 2:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT [Данные документов].Название,[Авторы].Имя,[Авторы].Фамилия,[Авторы].Отчество FROM [Данные документов],[Авторы],[Авторы документов] where ([Данные документов].ID_Документа = [Авторы документов].ID_Документа) and ([Авторы].ID_Автора = [Авторы документов].ID_Автора and ([Авторы документов].Позиция_автора = 3))", con);
                            break;
                        }
                    case 3:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT DISTINCT [Издательства].Издательство FROM [Издательства],[Данные документов],[Авторы документов] where (([Авторы документов].ID_Автора = 3) and ([Данные документов].ID_Документа = [Авторы документов].ID_Документа) and ([Издательства].ID_Издательства = [Данные документов].ID_Издательства))", con);
                            break;
                        }
                    case 4:
                        {
                            SqlCommand com = new SqlCommand(@"SELECT DISTINCT [Данные документов].Название, [Авторы].Инициалы FROM[Авторы],[Издательства],[Данные документов],[Авторы документов] where(([Авторы документов].ID_Автора = [Авторы].ID_Автора) and([Данные документов].ID_Документа = [Авторы документов].ID_Документа) and ([Издательства].ID_Издательства = [Данные документов].ID_Издательства) and[Данные документов].Год_издательства >= '2009.01.01' and[Данные документов].Год_издательства <= '2015.12.31')", con);
                            break;
                        }

                }
            }
        }
    }
}
