using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exo_WebApi.Context;
using Exo_WebApi.Models;

namespace Exo_WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;
        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }
        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }
        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }
        public Projeto BuscarporId(int id)
        {
            return _context.Projetos.Find(id);
        }
        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);
            if (projetoBuscado != null)
            {
                projetoBuscado.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoBuscado.Status = projeto.Status;
                projetoBuscado.Area = projeto.Area;
            }
            _context.Projetos.Update(projetoBuscado);
            _context.SaveChanges();
        }
        public void Deletar(int id)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);
            _context.Projetos.Remove(projetoBuscado);
            _context.SaveChanges();
        }
    }
}