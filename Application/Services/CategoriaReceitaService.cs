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
    public class CategoriaReceitaService : ICategoriaReceitaService
    {
        private readonly ICategoriaReceitaRepository _repository;
        private readonly IMapper _mapper;

        public CategoriaReceitaService(ICategoriaReceitaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AtualizarCateriaReceita(CategoriaReceitaDTO categoriaReceitaDTO)
        {
            var categoriaReceita = _mapper.Map<CategoriasReceitas>(categoriaReceitaDTO);
            await _repository.AtualizarCategoriaReceita(categoriaReceita);

        }

        public async Task CadastrarCategoriaReceita(CategoriaReceitaDTO categoriaReceitaDTO)
        {
            var categoriaReceita = _mapper.Map<CategoriasReceitas>(categoriaReceitaDTO);
            await _repository.CriarCategoriaReceita(categoriaReceita);
        }

        public async Task<CategoriaReceitaDTO> RecuperarCategoriaReceitaPorId(int id)
        {
            var categoriaReceita = await _repository.RecuperarCategoriaReceitaPorId(id);
            return _mapper.Map<CategoriaReceitaDTO>(categoriaReceita); 
        }

        public async Task<IEnumerable<CategoriaReceitaDTO>> RecuperarCategoriasReceitas()
        {
            var categoriasReceitas = await _repository.RecuperarCategoriasReceitas();
            return _mapper.Map<IEnumerable<CategoriaReceitaDTO>>(categoriasReceitas);
        }

        public async Task RemoverCategoriaReceita(int id)
        {
            var categoriaReceita = await _repository.RecuperarCategoriaReceitaPorId(id);
            await _repository.DeletarCategoriaReceita(categoriaReceita);
        }
    }
}
