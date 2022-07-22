using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stored_Procedure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Stored_Procedure.Controllers
{
    public class StudentsController : Controller
    {
        StudentDataAccessLayer DAL = new StudentDataAccessLayer();
        // GET: StudentsController
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            students = DAL.GetAllStudent().ToList();
            return View(students);
        }

        // GET: StudentsController/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = DAL.DetailsOfStudent(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // GET: StudentsController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Student std)
        {
            if (ModelState.IsValid)
            {
                DAL.AddStudent(std);
                return RedirectToAction("Index");
            }
            return View(std);
        }

        // GET: StudentsController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = DAL.DetailsOfStudent(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Student std)
        {
            if (id != std.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                DAL.UpdateStudent(std);
                return RedirectToAction("Index");
            }
            return View(DAL);
        }

        // GET: StudentsController/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = DAL.DetailsOfStudent(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            DAL.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
