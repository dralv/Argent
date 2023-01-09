using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _repository;
        private readonly IMapper _mapper;

        public DespesaService(IDespesaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CadastrarDespesa(DespesaDTO despesaDTO)
        {
            Despesa despesa = _mapper.Map<Despesa>(despesaDTO);
            await _repository.CriarDespesa(despesa);
        }

        public async Task AtualizarDespesa(DespesaDTO despesaDTO)
        {
            Despesa despesa = _mapper.Map<Despesa>(despesaDTO);
            await _repository.AtualizarDespesa(despesa);
        }

        public async Task<IEnumerable<DespesaDTO>> RecuperarDespesas()
        {
            var despesas = await _repository.RecuperarDespesas();
            return _mapper.Map<IEnumerable<DespesaDTO>>(despesas);
        }
        public async Task<DespesaDTO> RecuperarDespesaPorId(int id)
        {
            Despesa despesa = await _repository.RecuperarDespesaPorId(id);
            return  _mapper.Map<DespesaDTO>(despesa);
        }
        public async Task RemoverDespesa(int id)
        {
            var despesa = await _repository.RecuperarDespesaPorId(id);
            await _repository.DeletarDespesa(despesa);
        }
    }
}
