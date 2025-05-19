using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickleScore.Web.Models
{
    public class categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Nome da categoria
        public DateTime DataInsercao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}