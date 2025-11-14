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
                //carpeta BD:
                GestorCarpeta.CrearCarpetaBD();
                //Backup:
                GestorCarpeta.CrearCarpetaBackup();
               
                string rutaBD = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseDatos", "BD.Xml");
                
                string nombreBackup = $"BD_Backup_{DateTime.Now:dd-MM-yyyy HH-mm-ss}.xml";
                
                string rutaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup", nombreBackup);
                
                if (File.Exists(rutaBD))
                {
                    
                    if (!File.Exists(rutaBackup))
                    {
                        
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
                
                GestorCarpeta.CrearCarpetaBD();
              
                GestorCarpeta.CrearCarpetaBackup();
             
                string rutaBD = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseDatos", "BD.Xml");
                
                string rutaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup", nombreBackup);
                
                if (File.Exists(rutaBD))
                {
                    
                    if (File.Exists(rutaBackup))
                    {
                        
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
               
                string rutaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backup");
                
                if (Directory.Exists(rutaBackup))
                {
                    
                    string[] backups = Directory.GetFiles(rutaBackup, "*.xml");
                    
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
