using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Models
{
    public class NotasMateria
    {
        public int Id { get; set; }
        public virtual Materia materia { get; set; }
        public int MateriaId { get; set; }
        public virtual Boletim boletim { get; set; }
        public int BoletimId { get; set; }
        public double Nota { get; set; }
    }
}
