using Api.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public partial class EmployeeListForm : Form
    {
        private readonly EmployeeController _employeeController;
        private readonly EmploymentController _employmentController;
        private readonly EmployeeAddEditForm _employeeAddEditFOrm;
        private readonly EmploymentForm _employmentForm;

        private Api.DTOs.EmployeesDTO _employeesDTO;
        public EmployeeListForm(EmployeeController employeeController, EmploymentController employmentController, EmployeeAddEditForm employeeAddEditFOrm, EmploymentForm employmentForm)
        {
            _employeeController = employeeController;
            _employmentController = employmentController;
            _employeeAddEditFOrm = employeeAddEditFOrm;
            _employeeAddEditFOrm.FormClosed += delegate { SynchronizeEmployees(); };
            _employmentForm = employmentForm;
            _employmentForm.FormClosed += delegate { SynchronizeEmployees(); };
            InitializeComponent();
        }

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            SynchronizeEmployees();
        }

        private void SynchronizeEmployees()
        {
            _employeesDTO = _employeeController.GetAllEmployees();

            listView1.Items.Clear();
            if (_employeesDTO.Employees != null)
            {
                foreach (var e in _employeesDTO.Employees)
                {
                    string[] lv = { e.Id.ToString(), e.Name, e.Surname, e.Pesel, e.Birthday.ToString(), (e.ActiveEmployments != null && e.ActiveEmployments.Count > 0) ? "Tak" : "Nie" };
                    listView1.Items.Add(new ListViewItem(lv));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wybrane rekordy?", "Potwierdzenie", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (ListViewItem s in listView1.SelectedItems)
                {
                    _employeeController.RemoveEmployee(((List<Model.Models.Employee>)_employeesDTO.Employees)[listView1.Items.IndexOf(s)]);
                }
                SynchronizeEmployees();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _employeeAddEditFOrm.employee = new Model.Models.Employee();
            _employeeAddEditFOrm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ustaw employment jako nowy lub aktywny istniejący
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedEmployee = ((List<Model.Models.Employee>)_employeesDTO.Employees)[listView1.Items.IndexOf(listView1.SelectedItems[0])];
                if (selectedEmployee.ActiveEmployments != null && selectedEmployee.ActiveEmployments.Count > 0)
                {
                    _employmentForm.Employment = _employmentController.GetEmploymentById(selectedEmployee.ActiveEmployments[0].Id);
                } else
                {
                    _employmentForm.Employment = new Model.Models.Employment();
                }
                _employmentForm.Employee = selectedEmployee;// _employeeController.GetEmployeeById(selectedEmployee.Id);
                _employmentForm.ShowDialog();
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            button4.Enabled = listView1.SelectedItems.Count > 0;
            button2.Enabled = listView1.SelectedItems.Count > 0;
            button3.Enabled = listView1.SelectedItems.Count > 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var employeeId = ((List<Model.Models.Employee>)_employeesDTO.Employees)[listView1.Items.IndexOf(listView1.SelectedItems[0])].Id;
            _employeeAddEditFOrm.employee = _employeeController.GetEmployeeById(employeeId);
            _employeeAddEditFOrm.ShowDialog();
        }
    }
}
