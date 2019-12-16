﻿using Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Api.DTOs;
using Api.Enums;

namespace Api.Controllers
{
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;
        //TODO: Zwalnia pracownika o podanym numerze ID
        public void FireEmployeeById(int employeeId)
        {
            try
            {
                //TODO: do what's necessary to end this man whole career
                _employeeService.RemoveEmployeeById(employeeId);
            }
            catch(Exception ex)
            {
                
            }
        }

        public EmployeesDTO GetAllEmployees()
        {
            try
            {
                var employeesCollection = _employeeService.GetAllEmployees();

                var result = new EmployeesDTO
                {
                    Employees = employeesCollection,
                    Status = CollectionGetStatus.Success
                };

                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                var result = new EmployeesDTO
                {
                    Status = CollectionGetStatus.Failure
                };

                return result;
            }
        }
    }
}