using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

namespace Escola.Domain.Services
{
    public class MateriaServico : IMateriaServico
    {
        private readonly IMateriaRepositorio _materiaRepositorio;

        public MateriaServico(IMateriaRepositorio materiaRepositorio)
        {
            _materiaRepositorio = materiaRepositorio;
        }
        public void Inserir(MateriaDTO materia)
        {
            _materiaRepositorio.Inserir(new Materia(materia));
        }
        public void Atualizar(MateriaDTO materia)
        {
            var materiaDB = _materiaRepositorio.ObterPorId(materia.Id);
            materiaDB.Update(materia);
            _materiaRepositorio.Atualizar(materiaDB);
        }


        public void Excluir(int id)
        {
            var materia = _materiaRepositorio.ObterPorId(id);
            _materiaRepositorio.Excluir(materia);
        }


        public IList<MateriaDTO> ObterPorNome(string nome)
        {
            return (IList<MateriaDTO>)_materiaRepositorio.ObterPorNome(nome).Select(x => new MateriaDTO(x));
        }

        public IList<MateriaDTO> ObterTodos()
        {
            return _materiaRepositorio.ObterTodos()
                           .Select(x => new MateriaDTO(x))
                           .ToList();
        }
        public MateriaDTO ObterPorId(int id)
        {
            return new MateriaDTO(_materiaRepositorio.ObterPorId(id));
        }

        List<MateriaDTO> IMateriaServico.ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        void IMateriaServico.Excluir(Materia materia)
        {
            throw new NotImplementedException();
        }

        void IMateriaServico.Atualizar(Materia materia)
        {
            throw new NotImplementedException();
        }
    }
}
