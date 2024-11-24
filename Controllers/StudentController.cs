using Gestion_etudiant.Models;
using Gestion_etudiant.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gestion_etudiant.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly ISchoolRepository schoolRepository;
        private readonly StudentContext _context;

        public StudentController(IStudentRepository studentRepository, ISchoolRepository schoolRepository, StudentContext context)
        {
            this.studentRepository = studentRepository;
            this.schoolRepository = schoolRepository;
            _context = context;
            _context = context;
        }

        // GET: StudentController
        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.School).ToList();

            // Remplir le ViewBag avec les écoles
            ViewBag.SchoolID = new SelectList(_context.Schools, "SchoolID", "SchoolName");

            return View(students);
        }
        // GET: SchoolController/Details/5
        public IActionResult Details(int id)
        {
            var students = studentRepository.GetById(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            // Remplir la liste déroulante avec les écoles
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }

        
        [HttpPost]
      
        public ActionResult Create(Student student)
        {
            try
            {
                studentRepository.Add(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
                return View(student);
            }
        }

        
        public ActionResult Edit(int id)
        {
            var student = studentRepository.GetById(id);
            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View(student);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Student newStudent)
        {
            try
            {
                studentRepository.Edit(newStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
                return View();
            }
        }

    
        public ActionResult Delete(int id)
        {
            var student = studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student); // Affichage de la vue de confirmation de suppression
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var student = studentRepository.GetById(id);
                if (student != null)
                {
                    studentRepository.Delete(student);
                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }
            catch (Exception)
            {
                return View(); // En cas d'erreur
            }
        }

        // Méthode pour la recherche d'étudiants
        public ActionResult Search(string name, int? schoolid)
        {
            var result = studentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = studentRepository.FindByName(name);
            else if (schoolid != null)
                result = studentRepository.GetStudentsBySchoolID(schoolid);

            ViewBag.SchoolID = new SelectList(schoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
    }
}