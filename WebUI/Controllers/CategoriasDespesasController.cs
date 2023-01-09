using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoriasDespesasController : Controller
    {
        private readonly ICategoriaDespesaService _service;

        public CategoriasDespesasController(ICategoriaDespesaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoriasDespesas = await _service.RecuperarCategoriasDespesas();
            return View(categoriasDespesas);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CategoriaDespesaDTO categoriaDespesaDTO)
        {
            if(ModelState.IsValid)
            {
                await _service.CadastraCategoriaDespesa(categoriaDespesaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDespesaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            if (id == null) return NotFound();
            var categoriaDto = await _service.RecuperarCategoriasDespesasPorId(id);
            if(categoriaDto== null) return NotFound();  
            return View(categoriaDto);
        }

        [HttpPost]
        public async Task<IActionResult>Editar(CategoriaDespesaDTO categoriaDespesaDTO)
        {
            if (ModelState.IsValid)
            {
                await _service.AtualizarCategoriaDespesa(categoriaDespesaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDespesaDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Deletar(int id)
        {
            if(id==null) return NotFound();
            var categoriaDto = await _service.RecuperarCategoriasDespesasPorId(id);
            if(categoriaDto== null) return NotFound();
            return View(categoriaDto);
        }
        [HttpPost(),ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmar(int id)
        {
            await _service.RemoverCategoriaDespesa(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Detalhar(int id)
        {
            if (id == null) return NotFound();
            var categoriaDto = await _service.RecuperarCategoriasDespesasPorId(id);
            if(categoriaDto== null) return NotFound();
            return View(categoriaDto);
        }
    }
}
