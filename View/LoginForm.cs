using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Api.Controllers;

namespace View
{
    public partial class LoginForm : Form
    {
        private readonly ModuleChoiceForm _moduleChoiceForm;
        private readonly EmployeeController _employeeController;

        public bool isClosed = false;
        public LoginForm(ModuleChoiceForm moduleChoiceForm, EmployeeController employeeController)
        {
            _moduleChoiceForm = moduleChoiceForm;
            _employeeController = employeeController;
            InitializeComponent();
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
        }

        private void LoginTry()
        {
            try
            {
                if (!(textBoxUsername.Text == ""))
                {

                    if (!(textBoxPassword.Text == ""))
                    {
                        if(_employeeController.Login(textBoxUsername.Text, textBoxPassword.Text))
                        {
                            this.Hide();
                            _moduleChoiceForm._loginForm = this;
                            _moduleChoiceForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowe hasło lub login", "Błąd logowania", 0, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nie podano hasła", "Błąd logowania", 0, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nie podano loginu", "Błąd logowania", 0, MessageBoxIcon.Error);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void ButtonLogin_Click(object sender, EventArgs e) // TO DO
        {
            LoginTry();
        }

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide(); 
            isClosed = true;
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                LoginTry();
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                LoginTry();
            }
        }
    }
}
