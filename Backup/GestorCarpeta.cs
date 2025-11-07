using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    public static class GestorCarpeta
    {
        #region "Métodos"

        public static void CrearCarpetaBackup()
        {
            try
            {
                //Obtengo la Dirección de la ruta actual de FordFox V2.0:
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //Conbino la direccion de la ruta anterior con la Carpeta Backup:
                string rutaBackup = Path.Combine(ruta, "Backup");
                //Verifico si no existe la carpeta Backup:
                if(!Directory.Exists(rutaBackup))
                {
                    //Si no existe, la creo:
                    Directory.CreateDirectory(rutaBackup);
                }

            }
            catch (Exception ex) { throw ex; }
        }


        public static void CrearCarpetaBitacora()
        {
            try
            {
                //Obtengo la Dirección de la ruta actual de FordFox V2.0:
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //Conbino la direccion de la ruta anterior con la Carpeta Restore:
                string rutaBitacora = Path.Combine(ruta, "Bitacora");
                //Verifico si no existe la carpeta Restore:
                if (!Directory.Exists(rutaBitacora))
                {
                    //Si no existe, la creo:
                    Directory.CreateDirectory(rutaBitacora);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void CrearCarpetaBD()
        {
            try
            {
                //Obtengo la Dirección de la ruta actual de FordFox V2.0:
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //Conbino la direccion de la ruta anterior con la BD:
                string rutaBD = Path.Combine(ruta, "BaseDatos");
                //Verifico si no existe la carpeta BD:
                if (!Directory.Exists(rutaBD))
                {
                    //Si no existe, la creo:
                    Directory.CreateDirectory(rutaBD);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void CrearCarpetaPDFs(string nombreCarpeta)
        {
            try
            {
                // Obtengo la Dirección de la ruta actual de FordFox V2.0
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                // Combino la direccion de la ruta anterior con la carpeta de PDFs
                string rutaPDF = Path.Combine(ruta, nombreCarpeta);
                // Verifico si no existe la carpeta PDF
                if (!Directory.Exists(rutaPDF))
                {
                    // Si no existe, la creo
                    Directory.CreateDirectory(rutaPDF);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void CrearCarpetaInformes()
        {
            try
            {
                //Obtengo la Dirección de la ruta actual de FordFox V2.0:
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                //Conbino la direccion de la ruta anterior con la BD:
                string rutaInforme = Path.Combine(ruta, "Informes");
                //Verifico si no existe la carpeta Informes:
                if (!Directory.Exists(rutaInforme))
                {
                    Directory.CreateDirectory(rutaInforme);
                }

            }
            catch (Exception ex) { throw ex; }
        }

        public static string UbicacionBD(string nombreXML)
        {
            try
            {
                string baseDatos = "BaseDatos";
                CrearCarpetaBD();
                return Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, baseDatos), nombreXML);

            }
            catch (Exception ex) { throw ex; }
        }


        public static string UbicacionBitacora(string nombreXML)
        {
            try
            {
                string bitacora = "Bitacora";
                CrearCarpetaBD();
                return Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, bitacora), nombreXML);

            }
            catch (Exception ex) { throw ex; }
        }

        public static string UbicacionInformes(string nombreXML)
        {
            try
            {
                string informes = "Informes";
                CrearCarpetaInformes();
                return Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, informes), nombreXML);
            }
            catch (Exception ex) { throw ex; }
        }

        public static string UbicacionPDFs(string nombreArchivo)
        {
            try
            {
                string carpetaPDFs = "PDFs";
                CrearCarpetaPDFs(carpetaPDFs);
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, carpetaPDFs, nombreArchivo);
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion
    }
}
