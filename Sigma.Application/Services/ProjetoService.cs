using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using Sigma.Domain.Interfaces.Repositories;

namespace Sigma.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;
        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
        }

        public async Task<bool> Alterar(long id, ProjetoEditarDto dto)
        {
            var projeto = await _projetoRepository.GetByIdAsync(id);

            if (projeto == null)
                throw new KeyNotFoundException("Projeto não encontrado.");
            
            projeto.Nome = dto.Nome;
            projeto.Descricao = dto.Descricao;
            projeto.DataInicio = (DateTime)dto.DataInicio;
            projeto.PrevisaoTermino = (DateTime)dto.PrevisaoTermino;
            projeto.OrcamentoTotal = (decimal)dto.OrcamentoTotal;
            projeto.Risco = (Risco)dto.Risco;
            projeto.Status = (StatusProjeto)dto.Status;

            await _projetoRepository.UpdateAsync(projeto);
            return true;
        }


        public async Task<IEnumerable<ProjetoDto>> ConsultarPorFiltro(string? nome, StatusProjeto? status)
        {
            var projetos = await _projetoRepository.GetByFiltroAsync(nome, status);

            var projetosDto = _mapper.Map<IEnumerable<ProjetoDto>>(projetos);

            return projetosDto;
        }

        public async Task<bool> Excluir(long id)
        {
            var projeto = await _projetoRepository.GetByIdAsync(id);

            if (projeto == null)
                throw new KeyNotFoundException("Projeto não encontrado.");

            if (projeto.Status == StatusProjeto.Iniciado ||
                projeto.Status == StatusProjeto.Planejado ||
                projeto.Status == StatusProjeto.EmAndamento ||
                projeto.Status == StatusProjeto.Encerrado)
            {
                throw new InvalidOperationException("Não é possível excluir projetos com esse status.");
            }

            await _projetoRepository.DeleteAsync(id);
            return true;
        }


        public async Task<bool> Inserir(ProjetoNovoDto model)
        {
            return await _projetoRepository.Inserir(_mapper.Map<Projeto>(model));
        }
        public async Task<List<ProjetoDto>> Listar()
        {
            var projetos = await _projetoRepository.Listar();
            return _mapper.Map<List<ProjetoDto>>(projetos);
        }


        Task IProjetoService.Alterar(long id, ProjetoEditarDto dto)
        {
            return Alterar(id, dto);
        }

        Task IProjetoService.Excluir(long id)
        {
            return Excluir(id);
        }
    }
}
