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
    public partial class ViewLeaves : Form
    {
        Functions Con;
        public ViewLeaves()
        {
            InitializeComponent();
            Con = new Functions();
            EmpIdLbl.Text = Loging.EmpId + "";
            EmpNameLbl.Text = Loging.EmpName;
            ShowLeaves(); 
        }
        private void ShowLeaves()
        {
            string Query = "Select * from LeaveTb1 where Employee = {0}";
            Query = string.Format(Query, Loging.EmpId);
            LeaveList.DataSource = Con.GetData(Query);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Loging Obj = new Loging();
            Obj.Show();
            this.Hide();
        }

        private void CloseLbl_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
