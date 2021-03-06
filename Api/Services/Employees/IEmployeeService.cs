using System;
using System.Collections.Generic;
using System.Text;
using Api.Managers;
using Model.Models;

namespace Api.Services
{
    public interface IEmployeeService
    {
        public Employee GetEmployeeById(int id);
        public Employee GetEmployeeByLogin(string login);
        public void RemoveEmployeeById(int id);
        public ICollection<Employee> GetAllEmployees();
        public List<Employee> GetEmployeesByPositionId(int positionId);
        public void RemoveEmployee(Employee employee);
        public void AddEmployee(Employee employee, bool detach = false);
        public void UpdateEmployee(Employee employee);
    }
}
