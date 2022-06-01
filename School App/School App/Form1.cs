using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_App
{
    public partial class Form1 : Form
    {
        public static Form1 window;
        public List<MenuItem> lst;
        public Form1()
        {
            InitializeComponent();
            lst = new List<School_App.MenuItem>();
            window = this;
            dashboard = new MenuItem(Properties.Resources.dashboard, "Dashboard");
            add_student = new MenuItem(Properties.Resources.add, "Add Student");
            list_of_student = new MenuItem(Properties.Resources.list, "List Of\nStudents");
            report = new MenuItem(Properties.Resources.report, "Certificat\nScolaire");
            settings = new MenuItem(Properties.Resources.settings, "Settings");
            logout = new MenuItem(Properties.Resources.logout, "Logout");
            empty = new MenuItem(null, "");
            empty.BackColor = panel1.BackColor;
            empty.Height = 20;
            foreach (MenuItem item in new MenuItem[] { dashboard, add_student, list_of_student ,
            report, settings, logout, empty})
            {
                panel1.Controls.Add(item);
                lst.Add(item);
            }
            this.Shown += (s, e) =>
            {
                Init();
            };
            t = new Timer() { Interval = 1000, Enabled = true };
            int hour = 0, min = 0, sec = 0;
            string hour_text="", min_text="", sec_text="";
            t.Tick += (s, e) =>
            {
                if (hour.ToString().Length == 1)
                    hour_text = "0" + hour;
                else hour_text = hour.ToString();
                if (min.ToString().Length == 1)
                    min_text = "0" + min;
                else min_text = min.ToString();
                if (sec.ToString().Length == 1)
                    sec_text = "0" + sec;
                else sec_text = sec.ToString();
                sec++;
                if (sec == 59) {
                    sec = 0;
                    min++;
                }
                if (min == 59)
                {
                    min = 0;
                    hour++;
                }
                minutes.Text = hour_text + ":" + min_text + ":" + sec_text;
            };
        }
        MenuItem dashboard, add_student, list_of_student, report, settings, logout, empty;
        void Init()
        {
            int left_margin = 10;
            int top = label8.Top + label8.Height + 20;
            int left = (panel1.Width - (new MenuItem().Width * 2 + left_margin)) / 2;
            int c = 0;
            foreach (MenuItem item in new MenuItem[] { dashboard, add_student,
            list_of_student, report, settings, logout, empty})
            {
                item.Top = top;
                item.Left = left;
                left += item.Width + left_margin;
                c++;
                if (c == 2)
                {
                    c = 0;
                    top += item.Height + left_margin;
                    left = (panel1.Width - (new MenuItem().Width * 2 + left_margin)) / 2;
                }
            }
            ADDSTUDENT = new School_App.AddStudent();
            LISTOFSTUDENT = new School_App.ListOfStudents();
            DASHBOARD = new School_App.Dashboard();
            REPORT = new School_App.REPORTS();
            container.Controls.Add(DASHBOARD);
            dashboard.act = new Action(() =>
            {
                container.Controls.Clear();
                container.Controls.Add(DASHBOARD);
            });
            add_student.act = new Action(() =>
            {
                container.Controls.Clear();
                container.Controls.Add(ADDSTUDENT);
            });
            list_of_student.act = new Action(() =>
            {
                LIST();
            });
            report.act = new Action(() =>
            {
                LIST2();
            });
            settings.act = new Action(() =>
            {
                new Settings().ShowDialog();
            });
            logout.act = new Action(() =>
            {
                Application.Exit();
            });
        }
        public void LIST()
        {
            container.Controls.Clear();
            LISTOFSTUDENT.Do();
            container.Controls.Add(LISTOFSTUDENT);
        }
        public void LIST2()
        {
            container.Controls.Clear();
            REPORT.Do();
            container.Controls.Add(REPORT);
        }
        AddStudent ADDSTUDENT;
        ListOfStudents LISTOFSTUDENT;
        Dashboard DASHBOARD;
        REPORTS REPORT;
        Timer t;
    }
    public class Helper
    {
        public static System.Data.SqlClient.SqlConnection conn
            = new System.Data.SqlClient.SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=school;AttachDbFilename=|DataDirectory|school.mdf;Integrated Security=True");
        public static Button getButton()
        {
            Button b = new Button();
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
    }
}
