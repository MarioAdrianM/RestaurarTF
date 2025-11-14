using Abstraccion;
using BE.BEComposite;
using MPP;
using System;
using System.Collections.Generic;
using System.Xml;

namespace BLL_Negocio
{
    public class BLLRol : IGestor<BERol>
    {
        private readonly MPPRol _mpp;

        public BLLRol()
        {
            _mpp = new MPPRol();
        }

        public bool CrearXML()
        {
            return _mpp.CrearXML();
        }

        public bool Eliminar(BERol oBERol)
        {
            return _mpp.Eliminar(oBERol);
        }

        public bool Guardar(BERol oBERol)
        {
            return _mpp.Guardar(oBERol);
        }

        public BERol ListarObjeto(BERol oBERol)
        {
            return _mpp.ListarObjeto(oBERol);
        }

        public List<BERol> ListarTodo()
        {
            return _mpp.ListarTodo();
        }

        public long ObtenerUltimoId()
        {
            return _mpp.ObtenerUltimoId();
        }

        public bool VerificarExistenciaObjeto(BERol objeto)
        {
            return _mpp.VerificarExistenciaObjeto(objeto);
        }

        public List<BEPermiso> ListarPermisos()
        {
            return _mpp.ListarPermisos();
        }

        public List<BEPermiso> ListarPermisosDeRol(BERol rol)
        {
            return _mpp.ListarPermisosDeRol(rol);
        }
        
        public List<BEPermiso> ListarPermisosDelRol(BERol rol)
        {
            return _mpp.ListarPermisosDelRol(rol);
        }

        public bool AsociarRolaPermiso(BERol rol, BEPermiso permiso)
        {
            return _mpp.AsociarRolaPermiso(rol, permiso);
        }

        public bool DesasociarRolaPermiso(BERol rol, BEPermiso permiso)
        {
            return _mpp.DesasociarRolaPermiso(rol, permiso);
            //if (rol.Nombre.Equals("admin", StringComparison.OrdinalIgnoreCase))
            //    throw new Exception("No se pueden modificar los permisos del rol Administrador.");
            //return _mpp.DesasociarRolaPermiso(rol, permiso);
        }
    }
}
