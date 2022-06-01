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
    public partial class PERSON : UserControl
    {
        public PERSON(string str1, string str2)
        {
            InitializeComponent();
            label2.Text = str1;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label3.Text = str2;
            label3.Left = (this.ClientSize.Width - label3.Width) / 2;
        }
    }
}
