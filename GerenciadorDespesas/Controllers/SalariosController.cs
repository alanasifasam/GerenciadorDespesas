﻿using GerenciadorDespesas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Controllers
{
    public class SalariosController : Controller
    {


        private readonly Contexto _context;
        public SalariosController(Contexto context)
        {
            _context = context;
        }

       [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Salarios.Include(x => x.Meses);
            return View(await contexto.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Index(String txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(await _context.Salarios.Include(x => x.Meses)
                                                    .Where(x=>x.Meses.Nome.ToUpper()
                                                    .Contains(txtProcurar.ToUpper()))
                                                    .ToListAsync());
            }
            return View(await _context.Salarios.Include(x=>x.Meses).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId != x.Salarios.MesId), "MesId", "Nome");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalarioId,MesId,Valor")] Salarios salarios)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = "Salário cadastrado com sucesso.";
                _context.Add(salarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId != x.Salarios.MesId), "MesId", "Nome", salarios.MesId);
            return View(salarios);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarios = await _context.Salarios.FindAsync(id);
            if(salarios == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId == salarios.MesId), "MesId", "Nome", salarios.MesId);
            return View(salarios);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalarioId,MesId,Valor")] Salarios salarios)
        {
            if(id != salarios.SalarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salarios);
                    await _context.SaveChangesAsync();
                    TempData["Confirmacao"] = "Salário atualizado com sucesso.";
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!SalariosExists(salarios.SalarioId))
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
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.MesId == salarios.MesId), "MesId", "Nome", salarios.MesId);
            return View(salarios);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var salarios = await _context.Salarios.FindAsync(id);
            _context.Salarios.Remove(salarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool SalariosExists(int id)
        {
            return _context.Salarios.Any(x => x.SalarioId == id);
        }


    }
}
