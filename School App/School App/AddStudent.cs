using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School_App
{
    public partial class AddStudent : UserControl
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nom.Text.Trim().Length<=0 || lieu.Text.Trim().Length <= 0 ||
                date.Text.Trim().Length <= 0 ||
                numero_inscription.Text.Trim().Length <= 0 ||
                numero_national.Text.Trim().Length <= 0 || niveau.Text.Trim().Length <= 0 ||
                branche.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Veuillez remplir tous les chanps!");
                return;
            }
            Helper.conn.Open();
            string query = "insert into student values('"+nom.Text+"', '"+lieu.Text+
                "','"+date.Text+"', '"+numero_inscription.Text+
                "','"+numero_national.Text+"','"+niveau.Text+"','"+branche.Text+"')";
            new SqlCommand(query, Helper.conn).ExecuteNonQuery();
            MessageBox.Show("Succee!");
            nom.Text = lieu.Text = date.Text = numero_inscription.Text = numero_national.Text
                = niveau.Text = branche.Text = "";
            nom.Focus();
            Helper.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nom.Text = lieu.Text = date.Text = numero_inscription.Text = numero_national.Text
                = niveau.Text = branche.Text = "";
            nom.Focus();
        }
    }
}
