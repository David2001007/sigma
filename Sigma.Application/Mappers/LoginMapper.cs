using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Application.Mappers
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            CreateMap<LoginNovoDto, Login>();
        }
    }
}
