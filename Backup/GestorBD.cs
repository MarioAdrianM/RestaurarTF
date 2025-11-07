using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Backup
{
    public class GestorBD
    {
        #region "Métodos"

        public void CrearBackUp()
        {
            try
            {
                //Verifico que exista la carpeta BD:
                GestorCarpeta.CrearCarpetaBD();
                //Verifico que exista la carpeta Backup:
                GestorCarpeta.CrearCarpetaBackup();
                //Obtengo la ruta de la BD:
                string rutaBD = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseDatos", "BD.Xml");
                //Nombre del Backup:
                string nombreBackup = $"BD_Backup_{DateTime.Now:dd-MM-yyyy HH-mm-ss}.xml";
                //Ruta Destino del Backup:
                string rutaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup", nombreBackup);
                //Verifico que exista la BD:
                if (File.Exists(rutaBD))
                {
                    //Verifico que no exista el nombre del Backup que se intenta guardar:
                    if (!File.Exists(rutaBackup))
                    {
                        //Copiamos la BD para que quede como un Backup:
                        File.Copy(rutaBD, rutaBackup);
                    }
                    else { throw new Exception("Error: El Backup que intenta guardar ya existe!"); }
                }
                else { throw new Exception("Error: No se pudo recuperar la dirección de la Base de Datos!"); }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public void CrearRestore(string nombreBackup)
        {
            try
            {
                //Verifico que exista la carpeta BD:
                GestorCarpeta.CrearCarpetaBD();
                //Verifico que exista la carpeta Backup:
                GestorCarpeta.CrearCarpetaBackup();
                //Obtengo la ruta de la BD:
                string rutaBD = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseDatos", "BD.Xml");
                //Especifico la dirección de los Backups y del nombre del backup seleccionado:
                string rutaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup", nombreBackup);
                //Verifico que la rutaBD no sea nula:
                if (File.Exists(rutaBD))
                {
                    //Verifico que la rutaBackup no sea nula:
                    if (File.Exists(rutaBackup))
                    {
                        //Copio el Backup seleccionado a la carpeta de la BD, y se pone true en el 3° parámetro para sobreescribir el archivo BD.xml existente:
                        File.Copy(rutaBackup, rutaBD, true);
                    }
                    else { throw new Exception("Error: No se pudo recuperar la dirección de los Backups para realizar el Restore!"); }
                }
                else { throw new Exception("Error: No se pudo recuperar la dirección de la Base de Datos!"); }


            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public List<string> ListarBackups()
        {
            try
            {
                //Obtengo la ruta de los Backups:
                string rutaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
                //Verifico que exista la Carpeta:
                if (Directory.Exists(rutaBackup))
                {
                    //Recupeto todos los archivos XML Backups:
                    string[] backups = Directory.GetFiles(rutaBackup, "*.xml");
                    //FALTA VERIFICAR QUE PASA SI NO EXISTEN BACKUPS:

                    //Devuevlo los Backups:
                    return backups.Select(Path.GetFileName).ToList();
                }
                else { throw new Exception("Error: No se pudo recuperar la dirección de los Backups!"); }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        #endregion
    }
}
