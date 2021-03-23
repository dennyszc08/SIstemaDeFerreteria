using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SesionManager.CLS
{
    public sealed class Sesion
    {
        private static Sesion instancia = null;
        private static object padlock = new object();
        //Atributos
        String _U;
        String _R;
        String _IDU;
        String _Em;
        public static Sesion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Sesion();
                        }
                    }
                }
                return instancia;
            }
        }

        public string U { 
            get => _U;  
        }
        public string R { 
            get => _R;  
        }
        public string IDU { 
            get => _IDU; 
        }
        public string Em { 
            get => _Em;
        }


        private Sesion()
        {
            U = "N/A";
        }

        public Boolean IniciarSesion(String pUsuario, String pClave)
        {
            Boolean Autorizado = false;
            DataTable DatosSesion = new DataTable();

            try
            {
                DatosSesion = CacheManager.CLS.Cache.INICIAR_SESION(pUsuario, pClave);
                if (DatosSesion.Rows.Count == 1)
                {
                    _U = DatosSesion.Rows[0]["Usuario"].ToString();
                    _IDU = DatosSesion.Rows[0]["IDUsuario"].ToString();
                    _R = DatosSesion.Rows[0]["Rol"].ToString();
                    _Em = DatosSesion.Rows[0]["Empleado"].ToString();
                    Autorizado = true;
                }
                else
                {
                    Autorizado = false;
                }
            }
            catch
            {
                Autorizado = false;
            }
            return Autorizado;

        }
    }
}
