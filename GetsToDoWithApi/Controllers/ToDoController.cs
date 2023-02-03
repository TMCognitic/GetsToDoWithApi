using GetsToDoWithApi.Models.Entities;
using GetsToDoWithApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GetsToDoWithApi.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<ToDo>? data = _repository.Get();

            if(data is null)
            {
                throw new Exception("Erreur dans le call de l'api, vérifie l'url...");
            }

            return View(data);
        }
    }
}
