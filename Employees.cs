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
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmployees();
        }

        private void ShowEmployees()
        {
            string Query = "Select * from EmployeeTb1";
            EmployeesList.DataSource = Con.GetData(Query);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {
           
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpMobileTb.Text == "" || PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1 )
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = EmpGenCb.Text;
                    string Mobile = EmpMobileTb.Text;
                    string Pass = PasswordTb.Text;
                    string Add = AddTb.Text;
                    string Query = "insert into EmployeeTb1 values('{0}', '{1}', '{2}', '{3}', '{4}')";
                    Query = string.Format(Query, Name,Gender,Mobile,Pass,Add);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Added !!!");
                    EmpNameTb.Text = "";
                    EmpMobileTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int Key = 0;
        private void EmployeesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeesList.SelectedRows[0].Cells[1].Value.ToString();
            EmpGenCb.Text = EmployeesList.SelectedRows[0].Cells[2].Value.ToString();
            EmpMobileTb.Text = EmployeesList.SelectedRows[0].Cells[3].Value.ToString();
            PasswordTb.Text = EmployeesList.SelectedRows[0].Cells[4].Value.ToString();
            AddTb.Text = EmployeesList.SelectedRows[0].Cells[5].Value.ToString();

            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpMobileTb.Text == "" || PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = EmpGenCb.Text;
                    string Mobile = EmpMobileTb.Text;
                    string Pass = PasswordTb.Text;
                    string Add = AddTb.Text;
                    string Query = "Update EmployeeTb1 set EmpName = '{0}', EmpGen = '{1}', EmpMobile = '{2}', EmpPass = '{3}', EmAdd = '{4}' Where EmpId = {5}";
                    Query = string.Format(Query, Name, Gender, Mobile, Pass, Add,Key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Updated !!!");
                    EmpNameTb.Text = "";
                    EmpMobileTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpMobileTb.Text == "" || PasswordTb.Text == "" || EmpGenCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                   
                    string Query = "delete from EmployeeTb1 where EmpId = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Deleted !!!");
                    EmpNameTb.Text = "";
                    EmpMobileTb.Text = "";
                    PasswordTb.Text = "";
                    AddTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CategoryLbl_Click(object sender, EventArgs e)
        {
            Categories Obj = new Categories();
            Obj.Show();
            this.Hide();
        }

        private void LeaveLbl_Click(object sender, EventArgs e)
        {
            Leaves Obj = new Leaves();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
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
