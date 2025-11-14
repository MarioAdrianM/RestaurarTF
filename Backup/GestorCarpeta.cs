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
                
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
               
                string rutaBackup = Path.Combine(ruta, "Backup");
                
                if(!Directory.Exists(rutaBackup))
                {
                    
                    Directory.CreateDirectory(rutaBackup);
                }

            }
            catch (Exception ex) { throw ex; }
        }


        public static void CrearCarpetaBitacora()
        {
            try
            {
                
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                
                string rutaBitacora = Path.Combine(ruta, "Bitacora");
                
                if (!Directory.Exists(rutaBitacora))
                {
                   
                    Directory.CreateDirectory(rutaBitacora);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void CrearCarpetaBD()
        {
            try
            {
                
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                
                string rutaBD = Path.Combine(ruta, "BaseDatos");
                
                if (!Directory.Exists(rutaBD))
                {
                    
                    Directory.CreateDirectory(rutaBD);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void CrearCarpetaPDFs(string nombreCarpeta)
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                string rutaPDF = Path.Combine(ruta, nombreCarpeta);
                if (!Directory.Exists(rutaPDF))
                {
                    Directory.CreateDirectory(rutaPDF);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void CrearCarpetaInformes()
        {
            try
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;
                string rutaInforme = Path.Combine(ruta, "Informes");
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
