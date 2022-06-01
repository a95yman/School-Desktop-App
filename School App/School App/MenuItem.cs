using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_App
{
    public partial class MenuItem : UserControl
    {
        public bool isCliecked = false;
        public Color ClickedColor;
        public MenuItem(Bitmap bmp, string text)
        {
            InitializeComponent();
            pictureBox2.Image = bmp;
            label3.Text = text;
            label3.Left = (this.Width- label3.Width) / 2;
            label3.ForeColor = Color.FromArgb(30, 30, 30);
            this.BackColor = Color.FromArgb(247, 247, 247);
            ClickedColor = Color.FromArgb(220,220,220);
            this.Click+= (s, e) =>
            {
                Do();
            };
            this.MouseEnter += (s, e) =>
            {
                if (isCliecked == false)
                    this.BackColor = Color.FromArgb(230, 230, 230);
            };
            this.MouseLeave+= (s, e) =>
            {
                if (isCliecked == false)
                    this.BackColor = Color.FromArgb(247, 247, 247);
            };
            foreach(Control con in new Control[] { pictureBox2, label3 })
            {
                con.MouseEnter += (s, e) =>
                {
                    if (isCliecked == false)
                        this.BackColor = Color.FromArgb(230, 230, 230);
                };
                con.MouseLeave += (s, e) =>
                {
                    if (isCliecked == false)
                        this.BackColor = Color.FromArgb(247, 247, 247);
                };
                con.Click += (s, e) =>
                {
                    Do();
                };
            }
        }
        void Do()
        {
            foreach(MenuItem item in Form1.window.lst)
            {
                item.isCliecked = false;
                item.BackColor = Color.FromArgb(247, 247, 247);
                //item.label3.ForeColor = Color.FromArgb(30, 30, 30);
            }
            isCliecked = true;
            this.BackColor = ClickedColor;
            if(act!=null)
            act.Invoke();
            //label3.ForeColor = Color.White;
        }
        public Action act;
        public MenuItem()
        {
            InitializeComponent();
        }
    }
}
