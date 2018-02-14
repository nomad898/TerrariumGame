using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TerrariumGame.WebApi.Controllers
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }

    public class ValueController : ApiController
    {
        Employee[] employees = new Employee[]
      {
            new Employee{Id=0,Name="111",Salary="151110"},
            new Employee{Id=1,Name="John", Salary="120000"},
            new Employee{Id=2,Name="Chris",Salary="140000"},
            new Employee{Id=3,Name="Siraj", Salary="90000"}
      };

        public IEnumerable<Employee> Get()
        {
            return employees.ToList();
        }

        public Employee Get(int Id)
        {
            try
            {
                return employees[Id];
            }
            catch (Exception)
            {
                return new Employee();
            }
        }
    }
}
