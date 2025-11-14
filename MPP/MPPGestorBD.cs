using Backup;
using System;
using System.Collections.Generic;

namespace MPP
{
    public class MPPGestorBD
    {
        GestorBD gestorBD = new GestorBD();

        public bool CrearBackup()
        {
            try
            {
                gestorBD.CrearBackUp();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool CrearRestore(string nombreBackup)
        {
            try
            {
                gestorBD.CrearRestore(nombreBackup);

                return true;    
            }
            catch (Exception ex) { throw ex; }
        }

        public List<string> ListarBackups()
        {
            try
            {
                GestorCarpeta.CrearCarpetaBackup();

                List<string> listaNombreBackups = gestorBD.ListarBackups();

                return listaNombreBackups ?? new List<string>();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
