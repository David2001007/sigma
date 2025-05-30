using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Domain.Entities
{
    public class Login
    {
        public long Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
