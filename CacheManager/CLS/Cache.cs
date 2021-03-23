using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManager.CLS
{
    public static class Cache
    {
        public static DataTable TodosLR()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"SELECT IDROL, ROL FROM roles ORDER BY Rol;";
            try 
            {
                Resultados = Consultor.Consultar(Consulta);
            } catch 
            {
                Resultados = new DataTable();
            }
            
            return Resultados;

        }
        public static DataTable INICIAR_SESION(string pUsuario, string pClave)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"select a.IdUsuario, a.Usuario, a.IdEmpleado, a.IdRol, 
                                concat(b.Nombres,' ', b.Apellidos) Empleados, c.Rol
                                from Usuarios a, Empleados b, Roles c  
                                where a.Usuario='" + pUsuario + @"' 
                                AND a.Clave=sha1(md5('" + pClave + @"'))        
                                AND a.IdEmpleado=b.IdEmpleado
                                AND a.IdRol=c.IdRol";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }

            return Resultados;

        }
    }
}
