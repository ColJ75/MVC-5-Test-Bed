using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5TestBed.Models
{
	#region Model

	public class Employee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Salary { get; set; }
	}

	#endregion

	#region ModelView

	public class EmployeeView
	{
		public Employee Employee { get; set; }
		public string EmployeeName { get; }
		public string Salary { get; }
		public string SalaryColor { get; }

		public EmployeeView(Employee emp)
		{
			this.Employee = emp;
			this.EmployeeName = string.Format("{0} {1}", this.Employee.FirstName, this.Employee.LastName).Trim();
			this.Salary = this.Employee.Salary.ToString("C");
			this.SalaryColor = this.Employee.Salary >= 35000 ? "#ff0" : this.Employee.Salary <= 10000 ? "#f99" : "#0c0";
		}
	}

	public class EmployeeListView
	{
		public List<EmployeeView> Employees { get; set; }
		public string UserName { get; set; }
	}

	#endregion
}