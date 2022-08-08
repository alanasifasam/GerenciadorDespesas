using GerenciadorDespesas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Controllers
{
    public class TipoDespesasController : Controller
    {

        private readonly Contexto _context;
        public TipoDespesasController(Contexto context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDespesas.ToListAsync());
        }


        public async Task<JsonResult> TipoDespesaExiste(string Nome) 
        { 
            if(await _context.TipoDespesas.AnyAsync(x=>x.Nome.ToUpper()== Nome.ToUpper()))
            
                return Json("Esse tipo de despesa já existe!");

            return Json(true);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDespesaId,Nome")] TipoDespesas tipoDespesas)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = tipoDespesas.Nome + "Foi cadastrado com sucesso.";


                _context.Add(tipoDespesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesas);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var tipoDespesas = await _context.TipoDespesas.FindAsync(id);
            if(tipoDespesas == null)
            {
                return NotFound();
            }
            return View(tipoDespesas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , [Bind("TipoDespesaId,Nome")] TipoDespesas tipoDespesas)
        {
            if(id != tipoDespesas.TipoDespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    TempData["Confirmacao"] = tipoDespesas.Nome + " foi atualizado com sucesso.";
                    _context.Update(tipoDespesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDespesasExists(tipoDespesas.TipoDespesaId))
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
            return View(tipoDespesas);
        }



      
        [HttpPost]
        
        public async Task<JsonResult> Delete(int id)
        {
            var tipoDespesas = await _context.TipoDespesas.FindAsync(id);
            TempData["Confirmacao"] = tipoDespesas.Nome + " foi excluido com sucesso.";

            _context.TipoDespesas.Remove(tipoDespesas);
            await _context.SaveChangesAsync();
            return Json(tipoDespesas.Nome + "excluído com sucesso.");
        }

        private bool TipoDespesasExists(int id)
        {
            return _context.TipoDespesas.Any(x => x.TipoDespesaId == id);
        }

    }
}
