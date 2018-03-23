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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elLibraryDataSet.Prava". При необходимости она может быть перемещена или удалена.
            this.pravaTableAdapter.Fill(this.elLibraryDataSet.Prava);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Data.Connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand(@"UPDATE Prava set User_Add = '"+ Dannie3.Text + "',User_Delete = '" + comboBox1.Text + "',User_Edit = '" + comboBox2.Text + "',User_View = '" + comboBox3.Text + "',User_ViewExport = '" + comboBox4.Text + "',User_Export = '" + comboBox5.Text + "'",con);
                com.ExecuteNonQuery();
                MessageBox.Show("Права успешно изенены");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form F1 = new Form1();
            F1.Show();
            this.Close();
        }
    }
}
