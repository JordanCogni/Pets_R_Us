using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var user = await _userManager.GetUserAsync(User);
            var playDates = await playDateRepository.GetAllAsync();
            var filteredPlayDates = playDates.Where(p => p.Users.Contains(user.Id));
            var playDateVMs = mapper.Map<List<PlayDateVM>>(filteredPlayDates);

            if (playDateVMs.Any())
            {
                return View(playDateVMs);
            }

            return View();
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

                var playDate = mapper.Map<PlayDate>(playDateVM);

                await playDateRepository.AddAsync(playDate);
                return RedirectToAction(nameof(Index));
            }
            return View(playDateVM);
        }





        // GET: PlayDateController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var playDate = await playDateRepository.GetAsync(id);
            if (playDate == null)
            {
                return NotFound();
            }

            var playDateVM = mapper.Map<PlayDateVM>(playDate);
            return View(playDateVM);
        }

        // POST: PlayDateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PlayDateVM playDateVM)
        {
            if (id != playDateVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var playDate = mapper.Map<PlayDate>(playDateVM);
                    await playDateRepository.UpdateAsync(playDate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await playDateRepository.Exists(playDateVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(playDateVM);
        }


        // POST: PlayDateController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await playDateRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
