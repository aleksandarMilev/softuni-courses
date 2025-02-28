﻿using DetailPrinter.Models;
using System;
using System.Collections.Generic;
namespace DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                Console.WriteLine(employee.GetEmployeeInfo());
            }
        }
    }
}
 