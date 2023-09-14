using EmployeePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Controllers
{
    public class EmployeeController : Controller
    {
        DetailsDbContext dbcontext;
        public EmployeeController(DetailsDbContext context)
        {
            dbcontext = context;
        }

        public IActionResult Index()
        {
            return View(dbcontext.Employees.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            dbcontext.Employees.Add(obj);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            Employee obj = dbcontext.Employees.Find(id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult DepartmentDetails()
        {
            List<string> departmentList = dbcontext.Employees.Select(x =>x.EmployeeDep).Distinct().ToList();
            ViewBag.dep= departmentList;    
            return View();
        }


        [HttpGet]
        public IActionResult Dept(string id)
        {
            List<Employee> dep = dbcontext.Employees.Where(opt => opt.EmployeeDep == id).ToList();



            if (dep == null)
            {
                return NotFound(new { result = "Not available" });
            }
            else
            {
                return View(dep);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = dbcontext.Employees.Find(id);
            return View(obj);
        }



        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            dbcontext.Entry(obj).State = EntityState.Modified;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = dbcontext.Employees.Find(id);
            return View(obj);
        }



        [HttpPost]
        public IActionResult Delete(string id)
        {
            Employee obj = dbcontext.Employees.Find(int.Parse(id));
            dbcontext.Employees.Remove(obj);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }



}
