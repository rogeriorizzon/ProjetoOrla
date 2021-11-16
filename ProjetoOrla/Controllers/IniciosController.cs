using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOrla.Models;

namespace ProjetoOrla.Controllers
{
    public class IniciosController : Controller
    {
        private readonly Contexto _context;
        private readonly IHostingEnvironment _hostingEnvironment;


        public IniciosController(Contexto context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Inicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inicio.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            return View(await _context.Inicio.ToListAsync());
        }
        // GET: Inicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicio = await _context.Inicio
                .FirstOrDefaultAsync(m => m.InicioId == id);
            if (inicio == null)
            {
                return NotFound();
            }

            return View(inicio);
        }

        // GET: Inicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InicioId,Titulo_1,Titulo_2,BotaoInicio,FotoInicio")] Inicio inicio, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {

                var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Imagens");

                if(arquivo != null)
                {
                    using(var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                    {
                        await arquivo.CopyToAsync(fileStream);
                        inicio.FotoInicio = "~/img/slider/" + arquivo.FileName;
                    }
                }
                _context.Add(inicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inicio);
        }

        // GET: Inicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicio = await _context.Inicio.FindAsync(id);
            if (inicio == null)
            {
                return NotFound();
            }
            return View(inicio);

            TempData["FotoInicio"] = inicio.FotoInicio;
        }

        // POST: Inicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InicioId,Titulo_1,Titulo_2,BotaoInicio,FotoInicio")] Inicio inicio, IFormFile arquivo)
        {
            if (id != inicio.InicioId)
            {
                return NotFound();
            }

            if (String.IsNullOrEmpty(inicio.FotoInicio))
                inicio.FotoInicio = TempData["FotoTopo"].ToString();

            if (ModelState.IsValid)
            {
                try
                {
                    var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Imagens");

                    if(arquivo != null)
                    {
                        using(var fileStream = new FileStream(Path.Combine(linkUpload, arquivo.FileName), FileMode.Create))
                        {
                            await arquivo.CopyToAsync(fileStream);
                            inicio.FotoInicio = "~/img/slider/" + arquivo.FileName;
                        }
                    }
                    _context.Update(inicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InicioExists(inicio.InicioId))
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
            return View(inicio);
        }

        // GET: Inicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inicio = await _context.Inicio
                .FirstOrDefaultAsync(m => m.InicioId == id);
            if (inicio == null)
            {
                return NotFound();
            }

            return View(inicio);
        }

        // POST: Inicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inicio = await _context.Inicio.FindAsync(id);
            _context.Inicio.Remove(inicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InicioExists(int id)
        {
            return _context.Inicio.Any(e => e.InicioId == id);
        }
    }
}
