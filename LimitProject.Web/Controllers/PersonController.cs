using LimitProject.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace LimitProject.Web.Controllers
{
    public class PersonController : Controller
    {
        private static List<PersonDto> _persons = null;
        
        public PersonController() 
        {
            if (_persons == null)
            LoadPersons();  
        }

        private void LoadPersons()
        {
            _persons = new List<PersonDto>();

            PersonDto person1 = new PersonDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Morgana Larissa",
                Document = "12234567",
                Limit = 10000,
                CurrentLimit = 0
            };
            _persons.Add(person1);

            PersonDto person2 = new PersonDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Maria Alice",
                Document = "12234567",
                Limit = 10000,
                CurrentLimit = 0
            };
            _persons.Add(person2);

            PersonDto person3 = new PersonDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Maria Flor",
                Document = "12234567",
                Limit = 10000,
                CurrentLimit = 0
            };
            _persons.Add(person3);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(_persons);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Document, Limit")] PersonDto person)
        {
            try
            {
                person.Id = Guid.NewGuid().ToString();
                _persons.Add(person);

                return RedirectToAction("List");
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Delete(string Id) 
        {
            PersonDto person = _persons.FirstOrDefault(p => p.Id.Equals(Id));
            return View(person);
        }

        [HttpPost]
        public IActionResult Delete2(string Id)
        {
            PersonDto person = _persons.FirstOrDefault(p => p.Id.Equals(Id));
            if (person != null)
                _persons.Remove(person);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            PersonDto person = _persons.FirstOrDefault(p => p.Id.Equals(Id));
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Name, Document, Limit, CurrentLimit")] PersonDto person)
        {
            PersonDto personSearch = _persons.FirstOrDefault(p => p.Id.Equals(person.Id));
            if(personSearch != null)
            {
                _persons.Remove(personSearch);
                _persons.Add(person);
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Details(string Id) 
        {
            PersonDto person = _persons.FirstOrDefault(p => p.Id.Equals(Id));
            return View(person); 
        }
    }
}
