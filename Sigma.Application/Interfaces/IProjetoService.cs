using Sigma.Application.Dtos;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;

namespace Sigma.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<bool> Inserir(ProjetoNovoDto model);
        Task<List<ProjetoDto>> Listar();
        Task<IEnumerable<ProjetoDto>> ConsultarPorFiltro(string? nome, StatusProjeto? status);
        Task Excluir(long id);
        Task Alterar(long id, ProjetoEditarDto dto);
    }
}
