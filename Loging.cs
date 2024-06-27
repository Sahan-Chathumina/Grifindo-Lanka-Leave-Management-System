using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Lanka_Leave_Management_System_1._0
{
    public partial class Loging : Form
    {
        Functions Con;
        public Loging()
        {
            InitializeComponent();
            Con = new Functions();
            PasswordTb.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public static int EmpId;
        public static string EmpName = "";
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Infomation");
            }
            else
            {
                if (UNameTb.Text == "Admin" && PasswordTb.Text == "Admin123")
                {
                    Employees Obj = new Employees();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    try
                    {
                        string Query = "Select * from EmployeeTb1 where EmpName = '{0}' and EmpPass = '{1}'";
                        Query = string.Format(Query, UNameTb.Text, PasswordTb.Text);
                        DataTable dt = Con.GetData(Query);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Incorrect Password !!!");
                            UNameTb.Text = "";
                            PasswordTb.Text = "";
                        }
                        else
                        {
                            EmpId = Convert.ToInt32(dt.Rows[0][0].ToString());
                            EmpName = dt.Rows[0][1].ToString();
                            ViewLeaves Obj = new ViewLeaves();
                            Obj.Show();
                            this.Hide();
                        }
                    }
                    catch (Exception Ex) 
                    {
                        MessageBox.Show(Ex.Message);
                    }
                
                    
                }
            }
        }

        private void CloseLbl_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
