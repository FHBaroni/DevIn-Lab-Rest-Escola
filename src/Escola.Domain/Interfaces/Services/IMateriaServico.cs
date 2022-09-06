using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.DTO;
using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Services
{
    public interface IMateriaServico
    {
        IList<MateriaDTO> ObterTodos();
        MateriaDTO ObterPorId(int id);
        void Inserir(MateriaDTO materia);
        void Excluir(int id);
        void Atualizar(MateriaDTO materia);
        IList<MateriaDTO> ObterPorNome(string nome);
    }
}
