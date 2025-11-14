using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.BEComposite
{
    public abstract class BEComposite: BEEntidad
    {
        public string Nombre { get; set; }
        public BEComposite(long pId, string pNombre)
        {
            Id = pId;
            Nombre = pNombre;
        }
        public abstract void Agregar(BEComposite oBEComposite);
        public abstract IList<BEComposite> ObtenerHijos();

  

    }
}
