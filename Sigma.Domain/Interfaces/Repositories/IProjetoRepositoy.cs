﻿using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task DeleteAsync(long id);
        Task<Projeto> GetByIdAsync(long id);
        Task<bool> Inserir(Projeto entidade);
        Task UpdateAsync(Projeto projeto);
        Task<List<Projeto>> Listar();
        Task<IEnumerable<Projeto>> GetByFiltroAsync(string? nome, StatusProjeto? status);
        Task<bool> InserirLogin(Login login);
        Task<Login> GetByUsuarioAsync(string usuario);        
    }
}
