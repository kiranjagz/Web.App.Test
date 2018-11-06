using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.App.Test.Models;
using Web.App.Test.RabbitBroker.Publisher;
using Web.App.Test.Repository.SQL;

namespace Web.App.Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayer _player;
        private readonly IPublisher _publisher;

        public HomeController(IPlayer player,
            IPublisher publisher)
        {
            _player = player;
            _publisher = publisher;
        }

        public IActionResult Index()
        {
            var players = _player.Get();
            return View(players);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlayerModel model)
        {
            try
            {
                var player = model;
                _publisher.PublishMessage(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
