using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Somativa.Data;
using Somativa.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Immutable;

namespace Somativa.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly SprintContext _context;
        private string _caminho;

        public ProdutosController(SprintContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _caminho = hostingEnvironment.WebRootPath;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var sprintContext = _context.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor);
            return View(await sprintContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome");
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Estoque,Preco,CategoriaId,FornecedorId,Imagem")] Produto produto, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                produto.ProdutoId = Guid.NewGuid();

                // Verifica se uma imagem foi enviada
                if (imgUp != null && imgUp.Length > 0)
                {
                    // Especifica a pasta onde a imagem será salva
                    string uploadsFolder = Path.Combine(_caminho, "uploads");

                    // Verifica se a pasta existe, se não, a cria
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Gera um nome único para a imagem
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgUp.FileName;

                    // Combina o caminho da pasta com o nome da imagem
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Salva a imagem no caminho especificado
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imgUp.CopyToAsync(fileStream);
                    }

                    // Define o caminho da imagem no modelo de produto
                    produto.Imagem = uniqueFileName;
                }


                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorId", produto.FornecedorId);
            return View(produto);
        }


        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", produto.CategoriaId);
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "Nome", produto.FornecedorId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProdutoId,Nome,Estoque,Preco,CategoriaId,FornecedorId,Imagem")] Produto produto, IFormFile? imgUp)
        {


            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            // Verifica se uma imagem foi enviada
            if (imgUp != null && imgUp.Length > 0)
            {
                // Especifica a pasta onde a imagem será salva
                string uploadsFolder = Path.Combine(_caminho, "uploads");

                // Verifica se a pasta existe, se não, a cria
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Gera um nome único para a imagem
                string uniqueFileName = produto.ProdutoId.ToString() + "_" + imgUp.FileName;

                // Combina o caminho da pasta com o nome da imagem
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Salva a imagem no caminho especificado
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imgUp.CopyToAsync(fileStream);
                }

                // Define o caminho da imagem no modelo de produto
                produto.Imagem = uniqueFileName;
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorId", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'SprintContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
            return (_context.Produtos?.Any(e => e.ProdutoId == id)).GetValueOrDefault();
        }
    }
}