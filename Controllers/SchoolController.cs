using Gestion_etudiant.Models;
using Gestion_etudiant.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_etudiant.Controllers
{
	
	public class SchoolController : Controller
	{

		readonly ISchoolRepository SchoolRepository;

		public SchoolController(ISchoolRepository schoolRepository)
		{
			SchoolRepository = schoolRepository;
		}

		
		public ActionResult Index()
		{
			return View(SchoolRepository.GetAll());
		}

		// GET: Schoolcs/Details/5
		public ActionResult Details(int id)
		{
			var school = SchoolRepository.GetById(id);
			return View(school);
		}

		// GET: Schoolcs/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Schoolcs/Create
		[HttpPost]
	
		public ActionResult Create(School school)
		{
			try
			{
				
					
					SchoolRepository.Add(school);

				
					return RedirectToAction(nameof(Index));
				
			
			
			}
			catch
			{
				
				return View();
			}
		}

		
		public ActionResult Edit(int id)
		{
            var school = SchoolRepository.GetById(id);
            return View(school);
        }

		// localhost/5000/Edit/3
		[HttpPost]
		public ActionResult Edit(int id, IFormCollection collection, School school)
        {
            try
            {
                SchoolRepository.Edit(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // localhost/5000/School/Delete/5
        public ActionResult Delete(int id)
		{
			var schoolToDelete = SchoolRepository.GetById(id);

			return View(schoolToDelete);
		}

		// POST: Schoolcs/Delete/5
		[HttpPost]
	
		public ActionResult Delete(School s)
		{
			try
			{
				if (s != null)
				{
					// Supprimer l'employé
					SchoolRepository.Delete(s);

					// Rediriger vers la liste des employés après suppression
					return RedirectToAction(nameof(Index));
				}
				else
				{
					return NotFound();
				}
			}
			catch
			{
				// Gérer les erreurs si quelque chose se passe mal
				return View();
			}
		}
	}
}