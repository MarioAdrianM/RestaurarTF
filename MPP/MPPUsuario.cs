using Abstraccion;
using Backup;
using BE;
using BE.BEComposite;
using Seguridad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;  

namespace MPP
{
    public class MPPUsuario : IGestor<BEUsuario>
    {
        private readonly string ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        private XDocument BDXML;

        #region IGestor básicos

        public bool CrearXML()
        {
            try
            {
                if (!File.Exists(ruta))
                {
                    BDXML = new XDocument(
                        new XElement("Root",
                            new XElement("Usuarios"),
                            new XElement("Usuario_Roles"),
                            new XElement("Usuario_Permisos"),
                            new XElement("Roles"),
                            new XElement("Permisos"),
                            new XElement("Rol_Permisos")
                        )
                    );
                    BDXML.Save(ruta);
                    return true;
                }
                else
                {
                    BDXML = XDocument.Load(ruta);

                    if (BDXML.Root.Element("Usuarios") == null)
                        BDXML.Root.Add(new XElement("Usuarios"));
                    if (BDXML.Root.Element("Usuario_Roles") == null)
                        BDXML.Root.Add(new XElement("Usuario_Roles"));
                    if (BDXML.Root.Element("Usuario_Permisos") == null)
                        BDXML.Root.Add(new XElement("Usuario_Permisos"));
                    if (BDXML.Root.Element("Roles") == null)
                        BDXML.Root.Add(new XElement("Roles"));
                    if (BDXML.Root.Element("Permisos") == null)
                        BDXML.Root.Add(new XElement("Permisos"));
                    if (BDXML.Root.Element("Rol_Permisos") == null)
                        BDXML.Root.Add(new XElement("Rol_Permisos"));

                    BDXML.Save(ruta);
                    return true;
                }
            }
            catch { throw; }
        }

        public bool Guardar(BEUsuario oBEUsuario)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo crear/cargar el XML.");
                BDXML = XDocument.Load(ruta);

                if (oBEUsuario == null)
                    throw new Exception("Usuario nulo.");

                if (oBEUsuario.Id == 0)
                {
                    if (VerificarExistenciaObjeto(oBEUsuario))
                        throw new Exception("Ya existe un usuario con ese nombre.");

                    long nuevoId = ObtenerUltimoId() + 1;
                    oBEUsuario.Id = nuevoId;

                    string passwordEncriptado = Encriptacion.EncriptarPassword(oBEUsuario.Password);

                    BDXML.Root.Element("Usuarios").Add(
                        new XElement("usuario",
                            new XAttribute("Id", oBEUsuario.Id.ToString().Trim()),
                            new XElement("Usuario", oBEUsuario.Usuario.Trim()),
                            new XElement("Password", passwordEncriptado),
                            new XElement("Activo", oBEUsuario.Activo.ToString()),
                            new XElement("Bloqueado", oBEUsuario.Bloqueado.ToString())
                        )
                    );

                    BDXML.Save(ruta);
                    return true;
                }
                else
                {
                    var usuarioXML = BDXML.Root.Element("Usuarios")
                        .Descendants("usuario")
                        .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == oBEUsuario.Id.ToString().Trim());

                    if (usuarioXML == null)
                        throw new Exception("No se encontró el usuario a modificar.");

                    string passwordEncriptado = Encriptacion.EncriptarPassword(oBEUsuario.Password);

                    usuarioXML.Element("Password").Value = passwordEncriptado;
                    usuarioXML.Element("Activo").Value = oBEUsuario.Activo.ToString();
                    usuarioXML.Element("Bloqueado").Value = oBEUsuario.Bloqueado.ToString();

                    BDXML.Save(ruta);
                    return true;
                }
            }
            catch { throw; }
        }

        public bool Eliminar(BEUsuario oBEUsuario)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                var usuario = BDXML.Root.Element("Usuarios")
                    .Descendants("usuario")
                    .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == oBEUsuario.Id.ToString().Trim());

                if (usuario == null)
                    throw new Exception("No se encontró el usuario.");

                bool tieneRoles = BDXML.Root.Element("Usuario_Roles")
                    .Descendants("usuario_rol")
                    .Any(x => x.Element("Id_Usuario").Value.Trim() == oBEUsuario.Id.ToString().Trim());

                bool tienePermisos = BDXML.Root.Element("Usuario_Permisos")
                    .Descendants("usuario_permiso")
                    .Any(x => x.Element("Id_Usuario").Value.Trim() == oBEUsuario.Id.ToString().Trim());

                if (tieneRoles || tienePermisos)
                    throw new Exception("No se puede eliminar un usuario con roles o permisos asociados.");

                usuario.Remove();
                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }

        public List<BEUsuario> ListarTodo()
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                var lista = from u in BDXML.Root.Element("Usuarios").Elements("usuario")
                            select new BEUsuario
                            {
                                Id = long.Parse(u.Attribute("Id").Value.Trim()),
                                Usuario = u.Element("Usuario").Value.Trim(),
                                Password = u.Element("Password").Value.Trim(),
                                Activo = bool.Parse(u.Element("Activo").Value.Trim()),
                                Bloqueado = bool.Parse(u.Element("Bloqueado").Value.Trim())
                            };

                return lista.ToList();
            }
            catch { throw; }
        }

        public BEUsuario ListarObjeto(BEUsuario oBEUsuario)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                var usuarioXML = BDXML.Root.Element("Usuarios")
                    .Descendants("usuario")
                    .FirstOrDefault(x => x.Element("Usuario").Value.Trim() == oBEUsuario.Usuario.Trim());

                if (usuarioXML == null)
                    return null;

                return new BEUsuario
                {
                    Id = long.Parse(usuarioXML.Attribute("Id").Value.Trim()),
                    Usuario = usuarioXML.Element("Usuario").Value.Trim(),
                    Password = usuarioXML.Element("Password").Value.Trim(),
                    Activo = bool.Parse(usuarioXML.Element("Activo").Value.Trim()),
                    Bloqueado = bool.Parse(usuarioXML.Element("Bloqueado").Value.Trim())
                };
            }
            catch { throw; }
        }

        public BEUsuario ListarObjetoPorId(BEUsuario oBEUsuario)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                var usuarioXML = BDXML.Root.Element("Usuarios")
                    .Descendants("usuario")
                    .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == oBEUsuario.Id.ToString().Trim());

                if (usuarioXML == null)
                    return null;

                return new BEUsuario
                {
                    Id = long.Parse(usuarioXML.Attribute("Id").Value.Trim()),
                    Usuario = usuarioXML.Element("Usuario").Value.Trim(),
                    Password = usuarioXML.Element("Password").Value.Trim(),
                    Activo = bool.Parse(usuarioXML.Element("Activo").Value.Trim()),
                    Bloqueado = bool.Parse(usuarioXML.Element("Bloqueado").Value.Trim())
                };
            }
            catch { throw; }
        }

        public long ObtenerUltimoId()
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                var ids = BDXML.Root.Element("Usuarios")
                    .Descendants("usuario")
                    .Select(x => long.Parse(x.Attribute("Id").Value.Trim()));

                return ids.Any() ? ids.Max() : 0;
            }
            catch { throw; }
        }

        public bool VerificarExistenciaObjeto(BEUsuario oBEUsuario)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                return BDXML.Root.Element("Usuarios")
                    .Descendants("usuario")
                    .Any(x => x.Element("Usuario").Value.Trim() == oBEUsuario.Usuario.Trim());
            }
            catch { throw; }
        }

        #endregion

        #region Encriptado y login

        public string EncriptarPassword(string pPassword)
        {
            if (string.IsNullOrEmpty(pPassword))
                throw new Exception("La contraseña no puede ser vacía.");

            return Encriptacion.EncriptarPassword(pPassword);
        }

        public string DesencriptarPassword(string pPassword)
        {
            if (string.IsNullOrEmpty(pPassword))
                throw new Exception("La contraseña no puede ser vacía.");

            return Encriptacion.DesencriptarPassword(pPassword);
        }

        public bool Login(BEUsuario oBEUsuario)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML.");
                BDXML = XDocument.Load(ruta);

                string passCifrada = EncriptarPassword(oBEUsuario.Password.Trim());

                var usuarioXML = BDXML.Root.Element("Usuarios")
                    .Descendants("usuario")
                    .FirstOrDefault(x =>
                        x.Element("Usuario").Value.Trim() == oBEUsuario.Usuario.Trim() &&
                        x.Element("Password").Value.Trim() == passCifrada
                    );

                if (usuarioXML == null)
                    throw new Exception("Usuario o contraseña incorrectos.");

                if (usuarioXML.Element("Activo").Value != "True")
                    throw new Exception("El usuario no está activo.");

                if (usuarioXML.Element("Bloqueado").Value != "False")
                    throw new Exception("El usuario está bloqueado.");

                return true;
            }
            catch { throw; }
        }

        #endregion

        #region Usuario – Permisos

        private bool CrearXMLUsuarioPermiso()
        {
            if (!CrearXML()) return false;
            BDXML = XDocument.Load(ruta);

            if (BDXML.Root.Element("Usuario_Permisos") == null)
            {
                BDXML.Root.Add(new XElement("Usuario_Permisos"));
                BDXML.Save(ruta);
            }

            return true;
        }

        private bool VerificarUsuarioPermiso(BEUsuario u, BEPermiso p)
        {
            if (!CrearXMLUsuarioPermiso()) return false;
            BDXML = XDocument.Load(ruta);

            return BDXML.Root.Element("Usuario_Permisos")
                .Descendants("usuario_permiso")
                .Any(x =>
                    x.Element("Id_Usuario").Value.Trim() == u.Id.ToString().Trim() &&
                    x.Element("Id_Permiso").Value.Trim() == p.Id.ToString().Trim()
                );
        }

        public bool AsociarPermisoAUsuario(BEUsuario u, BEPermiso p)
        {
            try
            {
                if (!CrearXMLUsuarioPermiso())
                    throw new Exception("No se pudo cargar el XML.");

                BDXML = XDocument.Load(ruta);

                if (VerificarUsuarioPermiso(u, p))
                    throw new Exception("El permiso ya está asociado al usuario.");

                BDXML.Root.Element("Usuario_Permisos").Add(
                    new XElement("usuario_permiso",
                        new XElement("Id_Usuario", u.Id.ToString().Trim()),
                        new XElement("Id_Permiso", p.Id.ToString().Trim())
                    )
                );

                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }

        public bool DesasociarPermisoAUsuario(BEUsuario u, BEPermiso p)
        {
            try
            {
                if (!CrearXMLUsuarioPermiso())
                    throw new Exception("No se pudo cargar el XML.");

                BDXML = XDocument.Load(ruta);

                var nodo = BDXML.Root.Element("Usuario_Permisos")
                    .Descendants("usuario_permiso")
                    .FirstOrDefault(x =>
                        x.Element("Id_Usuario").Value.Trim() == u.Id.ToString().Trim() &&
                        x.Element("Id_Permiso").Value.Trim() == p.Id.ToString().Trim()
                    );

                if (nodo == null)
                    throw new Exception("Ese permiso no estaba asociado al usuario.");

                nodo.Remove();
                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }

        #endregion

        #region Usuario – Roles

        private bool CrearXMLUsuarioRol()
        {
            if (!CrearXML()) return false;
            BDXML = XDocument.Load(ruta);

            if (BDXML.Root.Element("Usuario_Roles") == null)
            {
                BDXML.Root.Add(new XElement("Usuario_Roles"));
                BDXML.Save(ruta);
            }

            return true;
        }

        private bool VerificarUsuarioRol(BEUsuario u, BERol r)
        {
            if (!CrearXMLUsuarioRol()) return false;
            BDXML = XDocument.Load(ruta);

            return BDXML.Root.Element("Usuario_Roles")
                .Descendants("usuario_rol")
                .Any(x =>
                    x.Element("Id_Usuario").Value.Trim() == u.Id.ToString().Trim() &&
                    x.Element("Id_Rol_Padre").Value.Trim() == r.Id.ToString().Trim()
                );
        }

        public bool AsociarUsuarioARol(BEUsuario u, BERol r)
        {
            try
            {
                if (!CrearXMLUsuarioRol())
                    throw new Exception("No se pudo cargar el XML.");

                BDXML = XDocument.Load(ruta);

                if (VerificarUsuarioRol(u, r))
                    throw new Exception("El usuario ya tiene ese rol.");

                BDXML.Root.Element("Usuario_Roles").Add(
                    new XElement("usuario_rol",
                        new XElement("Id_Usuario", u.Id.ToString().Trim()),
                        new XElement("Id_Rol_Padre", r.Id.ToString().Trim())
                    )
                );

                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }

        public bool DesasociarUsuarioARol(BEUsuario u, BERol r)
        {
            try
            {
                if (!CrearXMLUsuarioRol())
                    throw new Exception("No se pudo cargar el XML.");

                BDXML = XDocument.Load(ruta);

                var nodo = BDXML.Root.Element("Usuario_Roles")
                    .Descendants("usuario_rol")
                    .FirstOrDefault(x =>
                        x.Element("Id_Usuario").Value.Trim() == u.Id.ToString().Trim() &&
                        x.Element("Id_Rol_Padre").Value.Trim() == r.Id.ToString().Trim()
                    );

                if (nodo == null)
                    throw new Exception("No se encontró ese rol para ese usuario.");

                nodo.Remove();
                BDXML.Save(ruta);
                return true;
            }
            catch { throw; }
        }
        public List<BERol> ListarRolesDelUsuario(BEUsuario oBEUsuario)
        {
            try
            {
                if (!CrearXML()) throw new Exception("No se pudo cargar el XML");
                BDXML = XDocument.Load(ruta);

                List<BERol> lista = new List<BERol>();

                var nodosUsuarioRol = BDXML.Root.Element("Usuario_Roles")
                    .Descendants("usuario_rol")
                    .Where(x => x.Element("Id_Usuario").Value.Trim() == oBEUsuario.Id.ToString().Trim())
                    .ToList();

                foreach (var nodo in nodosUsuarioRol)
                {
                    string idRol = nodo.Element("Id_Rol_Padre").Value.Trim();

                    var rolXml = BDXML.Root.Element("Roles")
                        .Descendants("rol")
                        .FirstOrDefault(r => r.Attribute("Id").Value.Trim() == idRol);

                    if (rolXml != null)
                    {
                        BERol rol = new BERol(
                            long.Parse(idRol),
                            rolXml.Element("Nombre").Value.Trim()
                        );
                        lista.Add(rol);
                    }
                }

                return lista;
            }
            catch { throw; }
        }

        public List<BERol> ListarRolesDeUsuario(BEUsuario u)
        {
            if (!CrearXMLUsuarioRol()) return new List<BERol>();
            BDXML = XDocument.Load(ruta);

            var lista = new List<BERol>();

            var nodos = BDXML.Root.Element("Usuario_Roles")
                .Descendants("usuario_rol")
                .Where(x => x.Element("Id_Usuario").Value.Trim() == u.Id.ToString().Trim())
                .ToList();

            foreach (var ur in nodos)
            {
                string idRol = ur.Element("Id_Rol_Padre").Value.Trim();
                var nodoRol = BDXML.Root.Element("Roles")
                    .Descendants("rol")
                    .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == idRol);

                if (nodoRol != null)
                {
                    lista.Add(new BERol(long.Parse(idRol), nodoRol.Element("Nombre").Value.Trim()));
                }
            }

            return lista;
        }


        #endregion

        #region Permisos efectivos del usuario (directos + por rol)

        public List<BEPermiso> ListarPermisosDirectosDelUsuario(BEUsuario oBEUsuario)
        {
            if (!CrearXML() || !CrearXMLUsuarioPermiso()) throw new Exception("No se pudo cargar el XML");
            BDXML = XDocument.Load(ruta);

            List<BEPermiso> lista = new List<BEPermiso>();

            var nodos = BDXML.Root.Element("Usuario_Permisos")
                .Descendants("usuario_permiso")
                .Where(x => x.Element("Id_Usuario").Value.Trim() == oBEUsuario.Id.ToString().Trim())
                .ToList();

            foreach (var n in nodos)
            {
                string idPermiso = n.Element("Id_Permiso").Value.Trim();
                var permisoXML = BDXML.Root.Element("Permisos").Descendants("permiso")
                    .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == idPermiso);

                if (permisoXML != null)
                {
                    lista.Add(new BEPermiso(long.Parse(idPermiso), permisoXML.Element("Nombre").Value.Trim()));
                }
            }

            return lista;
        }

        public List<BEPermiso> ListarTodosLosPermisosDelUsuario(BEUsuario u)
        {
            if (!CrearXML()) throw new Exception("No se pudo cargar el XML");
            BDXML = XDocument.Load(ruta);

            var lista = new List<BEPermiso>();

            if (BDXML.Root.Element("Usuario_Permisos") != null)
            {
                var directos = BDXML.Root.Element("Usuario_Permisos")
                    .Descendants("usuario_permiso")
                    .Where(x => x.Element("Id_Usuario").Value.Trim() == u.Id.ToString().Trim());

                foreach (var d in directos)
                {
                    string idPermiso = d.Element("Id_Permiso").Value.Trim();
                    var nodoPermiso = BDXML.Root.Element("Permisos")
                        .Descendants("permiso")
                        .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == idPermiso);

                    if (nodoPermiso != null)
                    {
                        var be = new BEPermiso(long.Parse(idPermiso), nodoPermiso.Element("Nombre").Value.Trim());
                        if (!lista.Any(x => x.Id == be.Id))
                            lista.Add(be);
                    }
                }
            }

            var rolesUsuario = ListarRolesDeUsuario(u);
            foreach (var rol in rolesUsuario)
            {
                var permisosDelRol = BDXML.Root.Element("Rol_Permisos")
                    .Descendants("rol_permiso")
                    .Where(x => x.Element("Id_Rol").Value.Trim() == rol.Id.ToString().Trim());

                foreach (var pr in permisosDelRol)
                {
                    string idPermiso = pr.Element("Id_Permiso").Value.Trim();
                    var nodoPermiso = BDXML.Root.Element("Permisos")
                        .Descendants("permiso")
                        .FirstOrDefault(x => x.Attribute("Id").Value.Trim() == idPermiso);

                    if (nodoPermiso != null)
                    {
                        var be = new BEPermiso(long.Parse(idPermiso), nodoPermiso.Element("Nombre").Value.Trim());
                        if (!lista.Any(x => x.Id == be.Id))
                            lista.Add(be);
                    }
                }
            }

            return lista;
        }

        #endregion

        #region Usuario jerárquico sencillo

        public BEUsuario ListarObjetoJerarquico(BEUsuario u)
        {
            var usu = ListarObjetoPorId(u);
            if (usu == null) return null;

            usu.listaRoles = ListarRolesDeUsuario(usu);
            usu.listaPermisos = ListarTodosLosPermisosDelUsuario(usu);

            return usu;
        }

        #endregion
    }
}
