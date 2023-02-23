using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pets_R_Us.Contracts;
using Pets_R_Us.Data;
using Pets_R_Us.Models;

namespace Pets_R_Us.Controllers
{
    public class PlayDateController : Controller
    {
        private readonly IPlayDateRepository playDateRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<Users> _userManager;

        public PlayDateController(IWebHostEnvironment webHostEnvironment, IPlayDateRepository playDateRepository,
            IMapper mapper, UserManager<Users> userManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.playDateRepository = playDateRepository;
            this.mapper = mapper;
            _userManager = userManager;
        }



        // GET: PlayDateController
        public async Task<IActionResult> Index()
        {
            var playDate = mapper.Map<List<PlayDateVM>>(await playDateRepository.GetAllAsync());

            return View(playDate);
        }

        public IActionResult Create()
        {
            return View();
        }

        // GET: PlayDateController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var playDate = await playDateRepository.GetAsync(id);
            if (playDate == null)
            {
                return NotFound();
            }

            var playDateVM = mapper.Map<PlayDateVM>(playDate);
            return View(playDate);
        }


        // POST: PlayDateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayDateVM playDateVM)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                playDateVM.Users = user.Id;

                if (ModelState.IsValid)
                {
                    var playDate = mapper.Map<PlayDate>(playDateVM);

                    await playDateRepository.AddAsync(playDate);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(playDateVM);
        }





        // GET: PlayDateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlayDateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayDateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayDateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
