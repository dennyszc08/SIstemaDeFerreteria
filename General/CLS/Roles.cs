using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    //CLASE ENTIDAD
    class Roles
    {
        //Atributos
        String _IR;
        String _R;

        //propiedades

        public string IR 
        {
            get => _IR; 
            set => _IR = value; 
        }
        public string R 
        { 
            get => _R; 
            set => _R = value;
        }
        //Metodos

        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"INSERT INTO Roles(Rol) VALUES('" + this.R + "');";
            try
            {
                DataManager.CLS.OperacionBD Operacion = new DataManager.CLS.OperacionBD();
                if (Operacion.Insertar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;

                }
            }
            catch
            {
                Resultado = false;

            }
            return Resultado;
        }
        public Boolean Editar()
        {
            Boolean Resultado = false;
            String Sentencia = @"UPDATE Roles SET Rol= '" + this._R + "' WHERE IDRol=" + this._IR + ";";
            try
            {
                DataManager.CLS.OperacionBD Operacion = new DataManager.CLS.OperacionBD();
                if (Operacion.Actualizar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;

                }
            }
            catch
            {
                Resultado = false;

            }
            return Resultado;
        }
        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            String Sentencia = @"DELETE FROM Roles WHERE IDRol=" + this._IR + ";";
            try
            {
                DataManager.CLS.OperacionBD Operacion = new DataManager.CLS.OperacionBD();
                if (Operacion.Eliminar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;

                }
            }
            catch
            {
                Resultado = false;

            }
            return Resultado;
        }
    }
}
