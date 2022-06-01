using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_App
{
    public partial class Certificat : Form
    {
        public Certificat(string id, string nom, string lieu,
            string date, string numIns, string CIN,
            string niveau, string branche)
        {
            InitializeComponent();
            label2.Text = "ID : " + id;
            label3.Text = "NOM COMPLET : " + nom;
            label4.Text = "LIEU DE NAISSANCE : " + lieu;
            label4.Left = (this.Width - label4.Width) / 2;
            label5.Text = "DATE DE NAISSANCE : " + date;
            label5.Left = (this.Width - label5.Width) / 2;
            label6.Text = "NUM D'INSCRIPTION : " + numIns;
            label6.Left = (this.Width - label6.Width) / 2;
            label7.Text = "CIN : " + date;
            label7.Left = (this.Width - label7.Width) / 2;
            label8.Text = "NIVEAU SCOLAIRE : " + numIns;
            label8.Left = (this.Width - label8.Width) / 2;
            label9.Text = "BRANCHE : " + date;
            label9.Left = (this.Width - label9.Width) / 2;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }
        void Save()
        {

            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save("certificat.jpg", ImageFormat.Jpeg);
                System.Diagnostics.Process.Start("certificat.jpg");
            }
        }
    }
}
