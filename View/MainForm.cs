using Api.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Enums;

namespace View
{
    public partial class MainForm : Form
    {
        private readonly LoginForm _loginForm;
        private readonly ParcelController _parcelController;
        private readonly CourierForm _courierForm;

        public MainForm(LoginForm loginForm, ParcelController parcelController, CourierForm courierForm)
        {
            _parcelController = parcelController;
            _loginForm = loginForm;
            _courierForm = courierForm;
            InitializeComponent();
        }

        private void ButtonOpenLoginWindow_Click(object sender, EventArgs e)
        {
            this.Hide();
            _loginForm.ShowDialog();
            
            if(_loginForm.isClosed == true)
            {
                textBoxInsertNumber.Text = "";
                TextBoxInsertNumber_Leave(sender, e);
                this.Show();
            }
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            TextBoxInsertNumber_Leave(sender, e);
            labelStatus.Text = "";

            if(_courierForm.isClosed == true)
            {
                this.Show();
            }
        }

        private void TextBoxInsertNumber_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxInsertNumber.Text))
            {
                textBoxInsertNumber.ForeColor = Color.Gray;
                textBoxInsertNumber.Text = "Wpisz numer przesyłki";
            }
            else
            {
                textBoxInsertNumber.ForeColor = Color.Black;
            }
        }

        private void TextBoxInsertNumber_Enter(object sender, EventArgs e)
        {
            if (textBoxInsertNumber.Text == "Wpisz numer przesyłki")
            {
                textBoxInsertNumber.Text = "";
                textBoxInsertNumber.ForeColor = Color.Black;
            }
        }

        private int ConvertStringToInt(string intString)
        {
            int i = 0;
            if (!Int32.TryParse(intString, out i))
            {
                i = -1;
            }
            return i;
        }

        private void ButtonCheckStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(textBoxInsertNumber.Text == "") && !(textBoxInsertNumber.Text == "Wpisz numer przesyłki"))
                {
                    ParcelStatus theStatus = _parcelController.GetParcelStatusById(ConvertStringToInt(textBoxInsertNumber.Text));

                    switch (theStatus)
                    {
                        case ParcelStatus.AtPostingPoint:
                            {
                                labelStatus.Text = "Przesyłka w punkcie nadania";
                                break;
                            }                            
                        case ParcelStatus.OnWayToWarehouse:
                            {
                                labelStatus.Text = "Przeyłka w drodze do magazynu";
                                break;
                            }
                        case ParcelStatus.InWarehouse:
                            {
                                labelStatus.Text = "Przesyłka w magazynie";
                                break;
                            }
                        case ParcelStatus.OnWayToTheCustomer:
                            {
                                labelStatus.Text = "Przesyłka w drodze do odbiorcy";
                                break;
                            }
                        case ParcelStatus.Returned:
                            {
                                labelStatus.Text = "Przesyłka zwrócona";
                                break;
                            }
                        case ParcelStatus.Delivered:
                            {
                                labelStatus.Text = "Przesyłka dostarczona";
                                break;
                            }
                        default:
                            {
                                labelStatus.Text = "Brak przesyłki o podanym numerze";
                                break;
                            }

                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }        
        }

        private void textBoxInsertNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }     
}
