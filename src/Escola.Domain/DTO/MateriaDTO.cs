﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.Models;

namespace Escola.Domain.DTO
{
    public class MateriaDTO
    {
        public MateriaDTO()
        {

        }
        public MateriaDTO(Materia materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }       
    }
}
