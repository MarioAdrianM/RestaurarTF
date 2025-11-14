using Abstraccion;
using BE;
using BE.BEComposite;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BLL_Negocio
{
    public class BLLUsuario : IGestor<BEUsuario>
    {
        private readonly MPPUsuario _mpp;
        private readonly BLLRol _bllRol;
        private readonly BLLPermiso _bllPermiso;

        public BLLUsuario()
        {
            _mpp = new MPPUsuario();
            _bllRol = new BLLRol();
            _bllPermiso = new BLLPermiso();
        }

        #region IGestor básicos

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Eliminar(BEUsuario oBEUsuario)
        {
            if (oBEUsuario.Usuario=="admin") 
                throw new Exception("El usuario administrador no puede eliminarse.");
            return _mpp.Eliminar(oBEUsuario);
        }

        public bool Guardar(BEUsuario oBEUsuario)
        {
            return _mpp.Guardar(oBEUsuario);
        }

        public BEUsuario ListarObjeto(BEUsuario oBEUsuario)
        {
            var usuario = _mpp.ListarObjeto(oBEUsuario);

            if (usuario == null)
                return null;

            if (usuario.Usuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                var todosLosPermisos = _bllPermiso.ListarTodo();
                usuario.listaPermisos = todosLosPermisos;
            }

            return usuario;
        }

        public BEUsuario ListarObjetoPorId(BEUsuario oBEUsuario)
        {
            var usuario = _mpp.ListarObjetoPorId(oBEUsuario);

            if (usuario == null)
                return null;

            if (usuario.Usuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                var todos = _bllPermiso.ListarTodo();
                usuario.listaPermisos = todos;
            }

            return usuario;
        }

        public List<BEUsuario> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public long ObtenerUltimoId()
        {
            return _mpp.ObtenerUltimoId();
        }

        public bool VerificarExistenciaObjeto(BEUsuario objeto)
        {
            return _mpp.VerificarExistenciaObjeto(objeto);
        }

        #endregion

        #region Seguridad: password / login

        public string EncriptarPassword(string pPassword)
        {
            return _mpp.EncriptarPassword(pPassword);
        }

        public string DesencriptarPassword(string pPassword)
        {
            return _mpp.DesencriptarPassword(pPassword);
        }

        public bool Login(BEUsuario oBEUsuario)
        {
            return _mpp.Login(oBEUsuario);
        }

        #endregion

        #region Seguridad: Roles de usuario

        public bool AsociarUsuarioARol(BEUsuario oBEUsuario, BERol oBERol)
        {
            return _mpp.AsociarUsuarioARol(oBEUsuario, oBERol);
        }

        public bool DesasociarUsuarioARol(BEUsuario oBEUsuario, BERol oBERol)
        {
            return _mpp.DesasociarUsuarioARol(oBEUsuario, oBERol);
        }

        public List<BERol> ListarRolesDeUsuario(BEUsuario oBEUsuario)
        {
            return _mpp.ListarRolesDeUsuario(oBEUsuario);
        }

        #endregion

        #region Seguridad: Permisos directos al usuario

        public bool AsociarPermisoAUsuario(BEUsuario oBEUsuario, BEPermiso oBEPermiso)
        {
            if (oBEUsuario == null || oBEUsuario.Id == 0)
                throw new Exception("Debe seleccionar un usuario válido.");

            if (oBEPermiso == null || oBEPermiso.Id == 0)
                throw new Exception("Debe seleccionar un permiso válido.");


            var rolesUsuario = ListarRolesDelUsuario(oBEUsuario);

            if (rolesUsuario != null && rolesUsuario.Count > 0)
            {
                foreach (var rol in rolesUsuario)
                {
         
                    var permisosDelRol = _bllRol.ListarPermisosDelRol(rol);
                    if (permisosDelRol != null && permisosDelRol.Any(p => p.Id == oBEPermiso.Id))
                    {
                   
                        throw new Exception(
                            $"El usuario ya recibe el permiso \"{oBEPermiso.Nombre}\" por el rol \"{rol.Nombre}\".");
                    }
                }
            }

            
            return _mpp.AsociarPermisoAUsuario(oBEUsuario, oBEPermiso);
        }

        public bool DesasociarPermisoAUsuario(BEUsuario oBEUsuario, BEPermiso oBEPermiso)
        {
            return _mpp.DesasociarPermisoAUsuario(oBEUsuario, oBEPermiso);
        }

        public List<BEPermiso> ListarTodosLosPermisosDelUsuario(BEUsuario oBEusuario)
        {
            if (oBEusuario != null &&
         oBEusuario.Usuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                var bllPermiso = new BLLPermiso();
                return bllPermiso.ListarTodo();
            }

           
            return _mpp.ListarTodosLosPermisosDelUsuario(oBEusuario);
        }
        public List<BEPermiso> ListarPermisosDirectosDelUsuario(BEUsuario oBEUsuario)
        {
            return _mpp.ListarPermisosDirectosDelUsuario(oBEUsuario);
        }

        #endregion

        #region Seguridad: Usuario completo (roles + permisos)
        public bool CambiarPassword(BEUsuario usuarioLogueado, string passwordActualClaro, string passwordNuevaClaro)
        {
            var usuarioBD = _mpp.ListarObjeto(usuarioLogueado);
            if (usuarioBD == null)
                throw new Exception("No se encontró el usuario.");

            var passActualEncriptada = _mpp.EncriptarPassword(passwordActualClaro);

            if (usuarioBD.Password.Trim() != passActualEncriptada.Trim())
                throw new Exception("La contraseña actual no es correcta.");

            usuarioBD.Password = passwordNuevaClaro;

            return _mpp.Guardar(usuarioBD);
        }

        public BEUsuario ListarObjetoJerarquico(BEUsuario oBEUsuario)
        {
            return _mpp.ListarObjetoJerarquico(oBEUsuario);
        }
        public List<BERol> ListarRolesDelUsuario(BEUsuario usuario)
        {
            return _mpp.ListarRolesDelUsuario(usuario);
        }
        #endregion
    }
}
