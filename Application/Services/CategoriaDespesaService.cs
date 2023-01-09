using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CategoriaDespesaService : ICategoriaDespesaService
    {

        private readonly ICategoriaDespesaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaDespesaService(ICategoriaDespesaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AtualizarCategoriaDespesa(CategoriaDespesaDTO categoriaDespesaDTO)
        {
            var categoriaDespesa = _mapper.Map<CategoriasDespesas>(categoriaDespesaDTO);
            await _repository.AtualizarCategoriaDespesa(categoriaDespesa);
        }

        public async Task CadastraCategoriaDespesa(CategoriaDespesaDTO categoriaDespesaDTO)
        {
            var categoriaDespesa = _mapper.Map<CategoriasDespesas>(categoriaDespesaDTO);
            await _repository.CriarCategoriaDespesa(categoriaDespesa);
        }

        public async Task<IEnumerable<CategoriaDespesaDTO>> RecuperarCategoriasDespesas()
        {
            var cateriasDespesas = await _repository.RecuperarCategoriasDespesas();
            return _mapper.Map<IEnumerable<CategoriaDespesaDTO>>(cateriasDespesas);
        }

        public async Task<CategoriaDespesaDTO> RecuperarCategoriasDespesasPorId(int id)
        {
            var categoriaDespesa = await _repository.RecuperarCategoriaDespesaPorId(id);
            return _mapper.Map<CategoriaDespesaDTO>(categoriaDespesa);
        }

        public async Task RemoverCategoriaDespesa(int id)
        {
            var categoriaDespesa = _repository.RecuperarCategoriaDespesaPorId(id).Result;
            await _repository.DeletarCategoriaDespesa(categoriaDespesa);
        }
    }
}
