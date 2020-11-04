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
    public class AutorBLL
    {
        private IRepository<Autor> autorRepository = new Repository<Autor>();


        public IEnumerable<Autor> Listar()
        {
            return autorRepository.Listar();
        }

        public void Alta(Autor autor)
        {
            autorRepository.Alta(autor);
        }
    }
}
