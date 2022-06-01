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
    public partial class REPORTS : UserControl
    {
        public REPORTS()
        {
            InitializeComponent();
        }
        public void Do()
        {
            Helper.conn.Open();
            flowLayoutPanel1.Controls.Clear();
            SqlDataReader reader = new SqlCommand("select * from student", Helper.conn).ExecuteReader();
            PERSON person;
            while (reader.Read())
            {
                person = new School_App.PERSON(reader[1].ToString(), reader[2].ToString());
                flowLayoutPanel1.Controls.Add(person);
                string val1 = reader[0].ToString();
                string val2 = reader[1].ToString();
                string val3 = reader[2].ToString();
                string val4 = reader[3].ToString();
                string val5 = reader[4].ToString();
                string val6 = reader[5].ToString();
                string val7 = reader[6].ToString();
                string val8 = reader[7].ToString();
                person.button1.Click += (s, e) =>
                {
                    new Certificat(val1,
                        val2,
                        val3,
                        val4,
                        val5,
                        val6,
                        val7,
                        val8).ShowDialog();
                };
            }
            Helper.conn.Close();
        }
    }
}