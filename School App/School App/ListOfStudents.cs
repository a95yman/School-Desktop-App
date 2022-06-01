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
    public partial class ListOfStudents : UserControl
    {
        public ListOfStudents()
        {
            InitializeComponent();
        }
        public void Do()
        {
            flowLayoutPanel1.Controls.Clear();
            Helper.conn.Open();
            Panel columns = new Panel();
            columns.Width = flowLayoutPanel1.Width - 20;
            columns.Height = 40;
            SqlDataReader reader = new SqlCommand("select * from student", Helper.conn).ExecuteReader();
            int width = flowLayoutPanel1.Width / (reader.FieldCount+1);
            int left = 0;
            Button column;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                 column = Helper.getButton();
                column.Text = reader.GetName(i);
                column.Width = width - (20 / reader.FieldCount);
                column.Height = 40;
                column.BackColor = Color.Tomato;
                column.ForeColor = Color.White;
                column.Left = left;
                left += width- (20 / reader.FieldCount);
                columns.Controls.Add(column);
            }
            column = Helper.getButton();
            column.Text = "Action";
            column.Width = width - (20 / reader.FieldCount);
            column.Height = 40;
            column.BackColor = Color.Tomato;
            column.ForeColor = Color.White;
            column.Left = left;
            columns.Controls.Add(column);
            flowLayoutPanel1.Controls.Add(columns);
            Color col = Color.White;
            left = 0;
            while (reader.Read())
            {
                Panel row = new Panel();
                row.Width = flowLayoutPanel1.Width - 20;
                row.Height = 40;
                left = 0;
                foreach (string name in new string[] { reader[0].ToString(),
                reader[1].ToString(),reader[2].ToString(),reader[3].ToString(),
                reader[4].ToString(),reader[5].ToString(),reader[6].ToString(),
                reader[7].ToString(),"Supprimer"})
                {
                    Button cell = Helper.getButton();
                    cell.Text = name;
                    cell.Width = width - (20 / reader.FieldCount);
                    cell.Height = 40;
                    if (name == "Supprimer")
                    {
                        cell.BackColor = Color.Tomato;
                        cell.ForeColor = Color.White;
                        string id = reader[0].ToString();
                        Panel r = row;
                        cell.Click += (s, e) =>
                        {
                            try
                            {
                                Helper.conn.Open();
                            }
                            catch { }
                            new SqlCommand("delete from student where id=" + id, Helper.conn).ExecuteNonQuery();
                            MessageBox.Show("Succee!");
                            flowLayoutPanel1.Controls.Remove(r);
                            Helper.conn.Close();
                        };
                    }
                    else
                    {
                        cell.BackColor = col;
                        cell.ForeColor = Color.Black;
                    }
                    cell.Left = left;
                    left += width - (20 / reader.FieldCount);
                    row.Controls.Add(cell);
                }
                col = col == Color.White ? Color.FromArgb(250, 250, 250) : Color.White;
                flowLayoutPanel1.Controls.Add(row);
            }
            Helper.conn.Close();
        }
    }
}
