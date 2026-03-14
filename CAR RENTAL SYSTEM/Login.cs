using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
        public Boolean vaidateValues()
        {    Boolean isValid = true;
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Enter Username");
                isValid=false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Enter Password");
                isValid=false;
            }
            return isValid;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!vaidateValues())
            {
                return;
            }
            membersTableAdapter1.GetDataBy(txtUserName.Text, txtPassword.Text);
            if (membersTableAdapter1.GetDataBy(txtUserName.Text, txtPassword.Text).Count > 0)
            {
              frmMenu main = new frmMenu();
              main.Show();
              this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();
            }
        }
    }
}
