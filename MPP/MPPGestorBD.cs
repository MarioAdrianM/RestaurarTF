using Backup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            finally { }
        }

        public bool CrearRestore(string nombreBackup)
        {
            try
            {
                gestorBD.CrearRestore(nombreBackup);
                return true;
            }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public List<string> ListarBackups()
        {
            try
            {
                List<string> listaNombreBackups = new List<string>();
                listaNombreBackups = gestorBD.ListarBackups();
                if (listaNombreBackups != null) { return listaNombreBackups; }
                else { return listaNombreBackups = null; }
            }
            catch (Exception ex) { throw ex; }
            finally { }
        }
    }
}
