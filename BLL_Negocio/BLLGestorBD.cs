using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Negocio
{
    public class BLLGestorBD
    {
        MPPGestorBD oMPPGestorBD;

        #region "Constructor"
        public BLLGestorBD() { oMPPGestorBD = new MPPGestorBD(); }

        #endregion

        #region "Métodos"

        public bool CrearBackup() { return oMPPGestorBD.CrearBackup(); }

        public bool CrearRestore(string nombreBackup) { return oMPPGestorBD.CrearRestore(nombreBackup); }

        public List<string> ListarBackups() { return oMPPGestorBD.ListarBackups(); }

        #endregion
    }
}
