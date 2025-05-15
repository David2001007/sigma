using Sigma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        Task<bool> Inserir(Projeto entidade);
        Task<List<Projeto>> Listar();
    }
}
