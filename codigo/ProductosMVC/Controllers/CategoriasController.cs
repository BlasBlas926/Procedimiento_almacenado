using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductosMVC.Data;
using ProductosMVC.Models;

namespace ProductosMVC.Controllers
{

    public class CategoriasController : Controller
    {
        private readonly CategoriasDbContext _context;

        public CategoriasController(CategoriasDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Categorias.FromSqlRaw("SELECT * FROM schemasye.obtener_productos()").ToListAsync();
            return View(productos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Categorias producto)
        {
            await _context.Database.ExecuteSqlRawAsync("SELECT * FROM schemasye.insertar_producto({0}, {1}, {2}, {3}, {4})",
            producto.Nombre,
            producto.Precio,
            producto.Cantidad,
            producto.Fecha_Registro,
            producto.Estado);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _context.Categorias
              .FromSqlRaw("SELECT * FROM schemasye.obtener_producto_por_id({0})", id)
                .FirstOrDefaultAsync();
            return View(producto);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _context.Categorias
                .FromSqlRaw("SELECT * FROM schemasye.obtener_producto_por_id({0})", id)
                .FirstOrDefaultAsync(); ;
            return View(producto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Categorias producto)
        {
            await _context.Database.ExecuteSqlRawAsync("SELECT * FROM schemasye.actualizar_producto({0}, {1}, {2}, {3}, {4}, {5})",
            producto.Id,
            producto.Nombre,
            producto.Precio,
            producto.Cantidad,
            producto.Fecha_Registro,
            producto.Estado);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Categorias
                .FromSqlRaw("SELECT * FROM schemasye.obtener_producto_por_id({0})", id)
                .FirstOrDefaultAsync();
            return View(producto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Categorias producto)
        {
            await _context.Database.ExecuteSqlRawAsync("SELECT * FROM schemasye.eliminar_producto({0})", producto.Id);
            return RedirectToAction("Index");
        }
    }
}