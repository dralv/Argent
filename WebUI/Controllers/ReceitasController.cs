using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly IReceitaService _service;
        private readonly ICategoriaReceitaService _serviceCategoria;

        public ReceitasController(IReceitaService service, ICategoriaReceitaService serviceCategoria)
        {
            _service = service;
            _serviceCategoria = serviceCategoria;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var receitasDto = await _service.RecuperarReceitas();
            return View(receitasDto);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.CategoriaId = new SelectList(await _serviceCategoria.RecuperarCategoriasReceitas(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ReceitaDTO receitaDTO)
        {
            await _service.CadastrarReceita(receitaDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            if (id == null) return NotFound();
            var receitasDto = await _service.RecuperarReceitaPorId(id);
            if(receitasDto == null) return NotFound();
            ViewBag.CategoriaId = new SelectList(await _serviceCategoria.RecuperarCategoriasReceitas(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ReceitaDTO receitaDTO)
        {
            await _service.AtualizarReceita(receitaDTO);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            if (id == null) return NotFound();
            var receitasDto = await _service.RecuperarReceitaPorId(id);
            if (receitasDto == null) return NotFound();
            return View(receitasDto);
        }
        [HttpPost,ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmar(int id)
        {
            await _service.DeletarReceita(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhar(int id)
        {
            if(id==null) return NotFound();
            var receitaDto = await _service.RecuperarReceitaPorId(id);
            if (receitaDto == null) return NotFound();
            return View(receitaDto);
        }
    }
}
    