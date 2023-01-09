using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers
{
    public class DespesasController : Controller
    {
        private readonly IDespesaService _service;
        private readonly ICategoriaDespesaService _serviceCategoria;

        public DespesasController(IDespesaService service, ICategoriaDespesaService serviceCategoria)
        {
            _service = service;
            _serviceCategoria= serviceCategoria;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var despesas = await _service.RecuperarDespesas();
            return View(despesas);
        }
        [HttpGet()]
        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.CategoriaId = new SelectList(await _serviceCategoria.RecuperarCategoriasDespesas(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(DespesaDTO despesaDTO)
        {

            await _service.CadastrarDespesa(despesaDTO);
            return RedirectToAction(nameof(Index));
            //if (ModelState.IsValid)
            //{
                
            //}
            //return View(despesaDTO);
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            if(id==null) return NotFound();
            var despesasDto = await _service.RecuperarDespesaPorId(id);
            if(despesasDto == null) return NotFound();
            ViewBag.CategoriaId = new SelectList(await _serviceCategoria.RecuperarCategoriasDespesas(), "Id", "Nome");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Editar(DespesaDTO despesaDTO)
        {
            await _service.AtualizarDespesa(despesaDTO);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Deletar (int id)
        {
            if (id == null) return NotFound();
            var despesaDto = await _service.RecuperarDespesaPorId(id);
            if(despesaDto== null) return NotFound();
            return View(despesaDto);
        }
        [HttpPost(),ActionName("Deletar")]
        public async Task<IActionResult> DeletarConfirmar (int id)
        {
            await _service.RemoverDespesa(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhar(int id)
        {
            if (id == null) return NotFound();
            var despesaDto = await _service.RecuperarDespesaPorId(id);
            if (despesaDto == null) return NotFound();
            return View(despesaDto);
        }
    }
}
