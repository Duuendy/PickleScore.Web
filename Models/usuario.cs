using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickleScore.Web.Models
{
    public class usuario
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public int PerfilId { get; set; }
        public DateTime  DataInsercao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}