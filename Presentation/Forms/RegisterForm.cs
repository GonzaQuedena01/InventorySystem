using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entity;
using Business;

namespace Presentation.Forms
{
    public partial class RegisterForm : Form
    {
        UserService _UserService;

        public RegisterForm()
        {
            InitializeComponent();

            _UserService = new UserService();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = TbxUsername.Text;
            string password = TbxPassword.Text;

            string resp = _UserService.RegisterUser(new User(username, password));

            if (resp != "")
            {
                MessageBox.Show(resp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Registration Successful!", "Completed" ,MessageBoxButtons.OK);
            }
        }
    }
}
