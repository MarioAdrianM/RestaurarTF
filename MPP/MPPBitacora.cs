using Abstraccion;
using Backup;
using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MPP
{
    public class MPPBitacora : IGestor<BEBitacora>
    {
        //readonly string ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        readonly string ruta = GestorCarpeta.UbicacionBitacora("Bitacora.Xml");
        XDocument BDXML;

        #region "Métodos"

        public bool CrearXML()
        {
            try
            {
                Backup.GestorCarpeta.CrearCarpetaBitacora();
                if (!File.Exists(ruta))
                {
                    BDXML = new XDocument(new XElement("Root",
                    new XElement("Bitacoras")));
                    BDXML.Save(ruta);
                    return true;
                }
                else
                {
                    BDXML = XDocument.Load(ruta);
                    if (BDXML != null)
                    {
                        XElement bitacoras = BDXML.Root.Element("Bitacoras");

                        if (bitacoras != null) { return true; }

                        else
                        {
                            bitacoras = new XElement("Bitacoras");
                            BDXML.Root.Add(bitacoras);
                            BDXML.Save(ruta);
                            return true;
                        }
                    }
                    else { throw new XmlException("Error: No se pudo recuperar el XML!"); }
                }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public bool Eliminar(BEBitacora objeto) { throw new NotImplementedException(); }

        public bool Guardar(BEBitacora oBEBitacora)
        {
            try
            {
                if (CrearXML() == true)
                {
                    BDXML = XDocument.Load(ruta);
                    if (BDXML != null)
                    {
                        if (oBEBitacora != null)
                        {
                            if (oBEBitacora.Id == 0)
                            {
                                if (VerificarExistenciaObjeto(oBEBitacora) == false)
                                {
                                    long pId = ObtenerUltimoId() + 1;
                                    oBEBitacora.Id = pId;
                                    BDXML.Root.Element("Bitacoras").Add(new XElement("bitacora",
                                        new XAttribute("Id", oBEBitacora.Id.ToString().Trim()),
                                        new XElement("Detalle", oBEBitacora.Detalle.Trim()),
                                        new XElement("Fecha_Registro", oBEBitacora.FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss").Trim()),
                                        new XElement("usuario",
                                        new XAttribute("Id", oBEBitacora.oBEUsuario.Id.ToString().Trim()))));
                                    BDXML.Save(ruta);
                                    return true;
                                }
                                else { throw new Exception("Eror: No se puede dar el alta a una Bitacora que ya existe!"); }
                            }
                            else { throw new Exception("Error: Ya existe la Bitacora!"); }
                        }
                        else { throw new Exception("Error: No se pudo obtener la información de la Bitacora!"); }
                    }
                    else { throw new XmlException("Error: No se pudo recuperar la información del XML!"); }
                }
                else { throw new XmlException("Error: No se pudo recuperar el XML!"); }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public BEBitacora ListarObjeto(BEBitacora objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEBitacora> ListarTodo()
        {
            try
            {
                if (CrearXML() == true)
                {
                    BDXML = XDocument.Load(ruta);
                    if (BDXML != null)
                    {
                        List<BEBitacora> listaBitacoras = new List<BEBitacora>();
                        var buscarBitacorias = from bitacora in BDXML.Root.Element("Bitacoras").Descendants("bitacora")
                                               select new BEBitacora
                                               {
                                                   Id = long.Parse(bitacora.Attribute("Id").Value.Trim()),
                                                   FechaRegistro = DateTime.Parse(bitacora.Element("Fecha_Registro").Value.Trim()),
                                                   Detalle = bitacora.Element("Detalle").Value.Trim(),
                                                   oBEUsuario = new BEUsuario
                                                   {
                                                       Id = long.Parse(bitacora.Element("usuario").Attribute("Id").Value.Trim()),
                                                   }
                                               };
                        if (buscarBitacorias != null)
                        {
                            listaBitacoras = buscarBitacorias.ToList();
                            return listaBitacoras;
                        }
                        else { return listaBitacoras = null; }
                    }
                    else { throw new XmlException("Error: No se pudo recuperar la información del XML!"); }
                }
                else { throw new Exception("Error: No se pudo recuperar la información del XML!"); }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public List<BEBitacora> ListarTodoPorTipo(bool pTipo)
        {
            try
            {
                if (CrearXML() == true)
                {
                    BDXML = XDocument.Load(ruta);
                    if (BDXML != null)
                    {
                        if (pTipo == true)
                        {
                            List<BEBitacora> listaBitacoras = new List<BEBitacora>();
                            var buscarBitacoriasBackups = from bitacora in BDXML.Root.Element("Bitacoras").Descendants("bitacora")
                                                          where bitacora.Element("Detalle").Value == "backup"
                                                          select new BEBitacora
                                                          {
                                                              Id = long.Parse(bitacora.Attribute("Id").Value.Trim()),
                                                              FechaRegistro = DateTime.Parse(bitacora.Element("Fecha_Registro").Value.Trim()),
                                                              Detalle = bitacora.Element("Detalle").Value.Trim(),
                                                              oBEUsuario = new BEUsuario
                                                              {
                                                                  Id = long.Parse(bitacora.Element("usuario").Attribute("Id").Value.Trim()),
                                                              }
                                                          };
                       
                            if (buscarBitacoriasBackups != null)
                            {
                                listaBitacoras = buscarBitacoriasBackups.ToList();
                                return listaBitacoras;
                            }
                          
                            else { return listaBitacoras = null; }
                        }
                       
                        else
                        {
                            List<BEBitacora> listaBitacoras = new List<BEBitacora>();
                            var buscarBitacoriasRestores = from bitacora in BDXML.Root.Element("Bitacoras").Descendants("bitacora")
                                                           where bitacora.Element("Detalle").Value == "restore"
                                                           select new BEBitacora
                                                           {
                                                               Id = long.Parse(bitacora.Attribute("Id").Value.Trim()),
                                                               FechaRegistro = DateTime.Parse(bitacora.Element("Fecha_Registro").Value.Trim()),
                                                               Detalle = bitacora.Element("Detalle").Value.Trim(),
                                                               oBEUsuario = new BEUsuario
                                                               {
                                                                   Id = long.Parse(bitacora.Element("usuario").Attribute("Id").Value.Trim()),
                                                               }
                                                           };
                            
                            if (buscarBitacoriasRestores != null)
                            {
                                listaBitacoras = buscarBitacoriasRestores.ToList();
                                return listaBitacoras;
                            }
                           
                            else { return listaBitacoras = null; }
                        }
                    }
                    else { throw new XmlException("Error: No se pudo recuperar la información del XML!"); }
                }
                else { throw new Exception("Error: No se pudo recuperar la información del XML!"); }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public long ObtenerUltimoId()
        {
            try
            {
        
                if (CrearXML() == true)
                {
            
                    BDXML = XDocument.Load(ruta);
                    if (BDXML != null)
                    {
                 
                        var pId = from bitacora in BDXML.Root.Element("Bitacoras").Descendants("bitacora")
                                  select long.Parse(bitacora.Attribute("Id").Value.Trim());
                   
                        if (pId.Any())
                        {
                            
                            long ultimoId = pId.Max();
                            return ultimoId;
                        }
                        
                        else { return 0; }
                    }
                    else { throw new XmlException("Error: No se pudo recuperar la información del XML!"); }
                }
                else { throw new XmlException("Error: No se pudo recuperar el XML!"); }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        public bool VerificarExistenciaObjeto(BEBitacora oBEBitacora)
        {
            try
            {
                
                if (CrearXML() == true)
                {
                    
                    BDXML = XDocument.Load(ruta);
                    if (BDXML != null)
                    {
                    
                        if (oBEBitacora != null)
                        {
                            var buscarBitacora = from bitacora in BDXML.Root.Element("Bitacoras").Descendants("bitacora")
                                                 where bitacora.Element("Fecha_Registro").Value.Trim() == oBEBitacora.FechaRegistro.ToString().Trim()
                                                 select bitacora;
                          
                            if (buscarBitacora.Count() > 0) { return true; }
                          
                            else { return false; }
                        }
                        else { throw new Exception("Error: No se pudo recuperar la información de la Bitacora brindada!"); }
                    }
                    else { throw new XmlException("Error: No se pudo recuperar la información del XML!"); }
                }
                else { throw new XmlException("Error: No se pudo recuperar el XML!"); }
            }
            catch (XmlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }

        #endregion
    }
}
