using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.DTO;
using Escola.Domain.Exceptions;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;

namespace Escola.Domain.Services
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoServico(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public void Atualizar(AlunoDTO aluno)
        {
            var alunoDb = _alunoRepositorio.ObterPorId(aluno.Id);
            alunoDb.Update(aluno);
            //alunoDb.Update(new Aluno(aluno));
            _alunoRepositorio.Atualizar(alunoDb);
        }

        public void Excluir(Guid id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);
            _alunoRepositorio.Excluir(aluno);
        }

        public void Inserir(AlunoDTO aluno)
        {
            if (ObterIdade(aluno.DataNascimento) < 18)
                throw new EhMenorIdadeException("O aluno precisa ser maior de Idade");

            else if (_alunoRepositorio.ExisteMatricula(aluno.Matricula))
                throw new DuplicadoException("Matricula já existente");

            _alunoRepositorio.Inserir(new Aluno(aluno));
        }

        public int ObterIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (dataNascimento.Month > DateTime.Now.Month &&
                dataNascimento.Date > DateTime.Now.Date)
                idade++;
            return idade;
        }

        public AlunoDTO ObterPorId(Guid id)
        {
            return new AlunoDTO(_alunoRepositorio.ObterPorId(id));
        }

        public IList<AlunoDTO> ObterTodos(Paginacao paginacao)
        {
      
            return _alunoRepositorio.ObterTodos(paginacao)
                                    .Select(x => new AlunoDTO(x)).ToList();
        }

        public int ObterTotal()
        {
            return _alunoRepositorio.ObterTotal();
        }
    }
}