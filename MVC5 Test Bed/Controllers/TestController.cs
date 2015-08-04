using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5TestBed.Models;

namespace MVC5TestBed.Controllers
{
	public class TestController : Controller
	{
		public ActionResult Index()
		{
			// create list of employee models
			List<EmployeeView> employees = new List<EmployeeView>();
			employees.Add(new EmployeeView((Employee)new Employee() { FirstName = "Colin", LastName = "Jaggs", Salary = 44000 }));
			employees.Add(new EmployeeView((Employee)new Employee() { FirstName = "Adam", LastName = "Greenfield", Salary = 38000 }));
			employees.Add(new EmployeeView((Employee)new Employee() { FirstName = "Dan", LastName = "Hutchinson", Salary = 34000 }));
			employees.Add(new EmployeeView((Employee)new Employee() { FirstName = "Arek", LastName = "Gadecki", Salary = 27000 }));
			employees.Add(new EmployeeView((Employee)new Employee() { FirstName = "Tony", LastName = "Cartridge", Salary = 8500 }));

			// create new employee list view for the page
			EmployeeListView vmEmpList = new EmployeeListView
			{
				Employees = employees.OrderBy(e => e.EmployeeName).ThenBy(e => e.Employee.Salary).ToList(),
				UserName = "Admin"
			};

			ViewBag.TestVal = "Testing...";

			return View(vmEmpList);
		}

		public ActionResult Page1()
		{
			return View();
		}

		public ActionResult Page2()
		{
			if (Session["RunOnce"] != null)
			{
				return View();
			}
			else
			{
				Session.Add("RunOnce", true);
				return Content("You can only view this after your first visit.  Hit refresh to try again.");
			}
		}

		public string GetString()
		{
			return "Hello World!  How many times have you seen this before?";
		}
	}
}