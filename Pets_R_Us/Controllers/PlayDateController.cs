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
        private readonly ApplicationDbContext _context;

        public PlayDateController(IWebHostEnvironment webHostEnvironment, IPlayDateRepository playDateRepository,
            IMapper mapper, UserManager<Users> userManager, ApplicationDbContext _context)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.playDateRepository = playDateRepository;
            this.mapper = mapper;
            _userManager = userManager;
            this._context = _context;
        }


        // GET: PlayDateController
        public async Task<IActionResult> Index(PlayDateWithUsers playDateWithUsers)
        {
            var user = await _userManager.GetUserAsync(User);

            var playDates = await playDateRepository.GetAllAsync();
            var filteredPlayDates = playDates.Where(p => p.Users.Contains(user.Id) ||
            p.ReceivingUserId.Contains(user.Id));
            var playDateVMs = mapper.Map<List<PlayDateWithUsers>>(filteredPlayDates);

            if (playDateVMs.Any())
            {
                return View(playDateVMs);
            }

            return View();
        }



        public async Task<IActionResult> Create()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersPetBreeds = new List<string>();
            foreach (var person in users)
            {
                usersPetBreeds.Add($"{person.PetBreed}|{person.Id}");

            }
            ViewData["PetBreed"] = usersPetBreeds;

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
        public async Task<IActionResult> Create(PlayDateWithUsers playDateWithUsers)
        {


            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                playDateWithUsers.Users = user.Id;

                var playDate = mapper.Map<PlayDate>(playDateWithUsers);

                await playDateRepository.AddAsync(playDate);
                return RedirectToAction(nameof(Index));
            }

            return View(playDateWithUsers);
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


        public IActionResult Search(int id)
        {
            var playDateWithUsers = from pd in _context.playDates
                                    join u in _context.Users on pd.ReceivingUserId equals u.Id
                                    select new PlayDateWithUsers
                                    {
                                        Id = pd.Id,
                                        ReceivingUserId = pd.ReceivingUserId
                                    };
            return View(playDateWithUsers);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Json(users);
        }

        [HttpPost]
        public IActionResult UpdateAttending(int id, bool attending)
        {
            var playDate = _context.playDates.Find(id);
            if (playDate == null)
            {
                return NotFound();
            }

            playDate.Attending = attending;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



    }
}
