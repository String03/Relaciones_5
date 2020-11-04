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
    public class AutorLibroBLL
    {
        private IRepository<AutorLibro> autorLibroRepository = new Repository<AutorLibro>();
        private IRepository<Autor> autorRepository = new Repository<Autor>();
        private AutorLibroRepository repositoryAutorLibro = new AutorLibroRepository();

        public void Baja(AutorLibro autorLibro)
        {
            repositoryAutorLibro.Baja(autorLibro);
        }


        public IEnumerable<AutorLibro> Listar()
        {
            return autorLibroRepository.Listar();
        }

        public void Alta(AutorLibro autorLibro)
        {
            autorLibroRepository.Alta(autorLibro);
        }

        public List<AutorLibroGrilla> BuscarAutorEnLibro(Libro libro)
        {
            var autor = autorRepository.Listar();

            var autorLibro = autorLibroRepository.Listar()
                .Where(l => l.Libro_fk == libro.Id)
                .Select(a => a.Autor_fk);


            return autor.Select(a => new AutorLibroGrilla
            {
                Apellido = a.Apellido,
                Nombres = a.Nombres,
                Id = a.Id,
                PoseeAutor = autorLibro.Contains(a.Id)
            }).ToList();
        }


    }
}
