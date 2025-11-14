using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEntidad : IEntidad
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
