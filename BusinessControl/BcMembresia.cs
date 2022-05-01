using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace BusinessControl
{
    public class DalcMembresia
    {
        public BeLoginResult Login(BeCredencials credencials)
        {
            //Obtenemos el usuario deesde la BD
            var user = BcUsers.Get(credencials.userName);

            //Si llega nulo damos mensaje de error
            if (user == null) return new BeLoginResult(false, $"El usuario '{credencials.userName}' no existe", null);

            //Encriptamos la contraseña digitada por en usuario pegada con la salt previamente guardada
            string encriptedGivenPassword = BcCriptografia.ComputeSha256Hash($"{credencials.passWord}")+user.Salt;

            //Compramos que el password encriptado guardado a este usuario, coincide con el password digitado que acabamos de encriptar
            if (encriptedGivenPassword == user.Password+user.Salt) return new BeLoginResult(true, $"Exito al iniciar sesion", user);

            return new BeLoginResult(false, $"Usuario o contraseña no validos", null);
        }
    }
}
