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
    }
}