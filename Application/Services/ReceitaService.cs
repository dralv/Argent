using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _repository;
        private readonly IMapper _mapper;

        public ReceitaService(IReceitaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CadastrarReceita(ReceitaDTO receitaDTO)
        {
            var receita = _mapper.Map<Receita>(receitaDTO);
            await _repository.CriarReceita(receita);
        }

        public async Task<IEnumerable<ReceitaDTO>> RecuperarReceitas()
        {
            var receitas = await _repository.RecuperarReceita();
            return _mapper.Map<IEnumerable<ReceitaDTO>>(receitas);
        }
        public async Task<ReceitaDTO> RecuperarReceitaPorId(int id)
        {
            var receita = await _repository.RecuperarReceitaPorId(id);
            return _mapper.Map<ReceitaDTO>(receita);
        }

        public async Task AtualizarReceita(ReceitaDTO receitaDTO)
        {
            var receita = _mapper.Map<Receita>(receitaDTO);

            await _repository.AtualizarReceita(receita);
        }

        public async Task DeletarReceita(int id)
        {
            var receita = await _repository.RecuperarReceitaPorId(id);
            await _repository.DeletarReceita(receita);
        }
    }
}
