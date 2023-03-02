using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCodeDesktop.VO
{
    public class Aula
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Esboco { get; set; }

        public string Tipo { get; set; }

        public DateTime DataAgendamento { get; set; }
    }
}
