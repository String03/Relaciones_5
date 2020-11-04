using Relaciones_5.DAL;
using Relaciones_5.DAL.IRepositorios;
using Relaciones_5.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.BLL
{
    public class LibroBLL
    {
        private IRepository<Libro> libroRepository = new Repository<Libro>();


        public IEnumerable<Libro> Listar()
        {
            return libroRepository.Listar();
        }

        public void Alta(Libro libro)
        {
            libroRepository.Alta(libro);
        }

        public void Baja(Libro libro)
        {
            libroRepository.Baja(libro);
        }

        public void Modificacion(Libro libro)
        {
            libroRepository.Modificacion(libro);
        }
    }
}
