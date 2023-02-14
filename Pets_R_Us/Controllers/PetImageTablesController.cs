using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets_R_Us.Contracts;
using Pets_R_Us.Data;
using Pets_R_Us.Models;

namespace Pets_R_Us.Controllers
{
    public class PetImageTablesController : Controller
    {
        private readonly IPetImageRepository petImageRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PetImageTablesController(IPetImageRepository petImageRepository, IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            this.petImageRepository = petImageRepository;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: PetImageTables
        public async Task<IActionResult> Index()
        {
            var petImagesTables = mapper.Map<List<PetImageTablesVM>>(await petImageRepository.GetAllAsync());

            return View(petImagesTables);
        }

        // GET: PetImageTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var petImageTable = await petImageRepository.GetAsync(id);
            if (petImageTable == null)
            {
                return NotFound();
            }

            var petImageTableVM = mapper.Map<PetImageTablesVM>(petImageTable);
            return View(petImageTable);
        }

        // GET: PetImageTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetImageTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetImageTablesVM petImageTablesVM)
        {
            if (ModelState.IsValid)
            {
                if (petImageTablesVM.PetImage != null)
                {
                    string folder = "./UploadedFiles/Images/";
                    folder += Guid.NewGuid().ToString() + petImageTablesVM.PetImage.FileName;

                    petImageTablesVM.PetImageUrl = folder;

                    string serverFolder = Path.Combine(this.webHostEnvironment.WebRootPath, folder);

                    await petImageTablesVM.PetImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                var petImageTables = mapper.Map<PetImageTable>(petImageTablesVM);
                await petImageRepository.AddAsync(petImageTables);
                return RedirectToAction(nameof(Index));
            }
            return View(petImageTablesVM);
        }


        // GET: PetImageTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var petImageTable = await petImageRepository.GetAsync(id);
            if (petImageTable == null)
            {
                return NotFound();
            }

            var petImageTableVM = mapper.Map<PetImageTablesVM>(petImageTable);
            return View(petImageTableVM);
        }

        // POST: PetImageTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetImageTablesVM petImageTablesVM)
        {
            if (id != petImageTablesVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var petImageTables = mapper.Map<PetImageTable>(petImageTablesVM);
                    await petImageRepository.UpdateAsync(petImageTables);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await petImageRepository.Exists(petImageTablesVM.Id))
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
            return View(petImageTablesVM);
        }


        // POST: PetImageTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await petImageRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
