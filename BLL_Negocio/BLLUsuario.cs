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

        public BLLUsuario()
        {
            _mpp = new MPPUsuario();
            _bllRol = new BLLRol();
        }

        #region IGestor básicos

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Eliminar(BEUsuario oBEUsuario)
        {
            return _mpp.Eliminar(oBEUsuario);
        }

        public bool Guardar(BEUsuario oBEUsuario)
        {
            return _mpp.Guardar(oBEUsuario);
        }

        public BEUsuario ListarObjeto(BEUsuario oBEUsuario)
        {
            return _mpp.ListarObjeto(oBEUsuario);
        }

        public BEUsuario ListarObjetoPorId(BEUsuario oBEUsuario)
        {
            return _mpp.ListarObjetoPorId(oBEUsuario);
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

            // 1) traigo los roles del usuario
            var rolesUsuario = ListarRolesDelUsuario(oBEUsuario);

            if (rolesUsuario != null && rolesUsuario.Count > 0)
            {
                foreach (var rol in rolesUsuario)
                {
                    // 2) para cada rol veo sus permisos
                    var permisosDelRol = _bllRol.ListarPermisosDelRol(rol);
                    if (permisosDelRol != null && permisosDelRol.Any(p => p.Id == oBEPermiso.Id))
                    {
                        // 3) si ya está en un rol -> no dejo seguir
                        throw new Exception(
                            $"El usuario ya recibe el permiso \"{oBEPermiso.Nombre}\" por el rol \"{rol.Nombre}\".");
                    }
                }
            }

            // 4) si llegamos acá, el permiso no está en ningún rol del usuario
            
            return _mpp.AsociarPermisoAUsuario(oBEUsuario, oBEPermiso);
        }

        public bool DesasociarPermisoAUsuario(BEUsuario oBEUsuario, BEPermiso oBEPermiso)
        {
            return _mpp.DesasociarPermisoAUsuario(oBEUsuario, oBEPermiso);
        }

        public List<BEPermiso> ListarTodosLosPermisosDelUsuario(BEUsuario oBEusuario)
        {
            return _mpp.ListarTodosLosPermisosDelUsuario(oBEusuario);
        }
        public List<BEPermiso> ListarPermisosDirectosDelUsuario(BEUsuario oBEUsuario)
        {
            return _mpp.ListarPermisosDirectosDelUsuario(oBEUsuario);
        }

        #endregion

        #region Seguridad: Usuario completo (roles + permisos)

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
