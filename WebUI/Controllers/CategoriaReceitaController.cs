using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoriaReceitaController : Controller
    {
        private readonly ICategoriaReceitaService _service;

        public CategoriaReceitaController(ICategoriaReceitaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _service.RecuperarCategoriasReceitas();
            return View(categorias);
        }
        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CategoriaReceitaDTO categoriaReceitaDTO)
        {
            if(categoriaReceitaDTO == null) return NotFound();
            await _service.CadastrarCategoriaReceita(categoriaReceitaDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            if(id==null) return NotFound();
            var categoriaDto = await _service.RecuperarCategoriaReceitaPorId(id);
            if(categoriaDto== null) return NotFound();
            return View(categoriaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CategoriaReceitaDTO categoriaReceitaDTO)
        {
            if(categoriaReceitaDTO== null) return NotFound();
            await _service.AtualizarCateriaReceita(categoriaReceitaDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            if(id==null) return NotFound();
            var categoriaDto = await _service.RecuperarCategoriaReceitaPorId(id);
            if(categoriaDto== null) return NotFound();
            return View(categoriaDto);
        }

        [HttpPost,ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmar(int id)
        {
            await _service.RemoverCategoriaReceita(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detalhar(int id)
        {
            if(id==null) return NotFound(); 
            var categoriaDto = await _service.RecuperarCategoriaReceitaPorId(id);
            if (categoriaDto == null) return NotFound();
            return View(categoriaDto);
        }
    }
}
