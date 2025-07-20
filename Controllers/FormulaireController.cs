using Microsoft.AspNetCore.Mvc;
using PromamecIntranet.Models;
using PromamecIntranet.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PromamecIntranet.Controllers
{
    public class FormulaireController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FormulaireController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: /Formulaire
        public async Task<IActionResult> Index(string clientNom, bool? amssnur, DateTime? dateDebut, DateTime? dateFin)
        {
            var formulaires = _context.Formulaires.AsQueryable();

            if (!string.IsNullOrEmpty(clientNom))
                formulaires = formulaires.Where(f => f.NomClient.Contains(clientNom));

            if (amssnur.HasValue)
                formulaires = formulaires.Where(f => f.DossierAMSSNUR == amssnur.Value);

            if (dateDebut.HasValue)
                formulaires = formulaires.Where(f => f.DateCreation >= dateDebut.Value);

            if (dateFin.HasValue)
                formulaires = formulaires.Where(f => f.DateCreation <= dateFin.Value);

            var result = await formulaires.ToListAsync();
            return View(result);
        }

        // GET: /Formulaire/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Formulaire/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormulaireProjet model, IFormFile excelFile)
        {
            if (ModelState.IsValid)
            {
                if (excelFile != null && excelFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);
                    var fileName = Guid.NewGuid() + Path.GetExtension(excelFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await excelFile.CopyToAsync(stream);
                    }

                    model.NomFichierExcel = excelFile.FileName;
                    model.CheminFichierExcel = "/uploads/" + fileName;
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: /Formulaire/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var formulaire = await _context.Formulaires.FirstOrDefaultAsync(f => f.Id == id);
            if (formulaire == null) return NotFound();

            return View(formulaire);
        }

        // GET: /Formulaire/Print/5
        public async Task<IActionResult> Print(int id)
        {
            var formulaire = await _context.Formulaires.FindAsync(id);
            if (formulaire == null) return NotFound();

            return View("Print", formulaire);
        }
    }
}
