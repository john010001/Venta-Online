using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace VentaOnline.UI.MVC.Helpers
{
    public class SecurityHelpers
    {
        //Claims Identity: les permite guardar información
        //personalizada del usuario logeado
        public static List<Claim> CrearClaimsUsuario(string nombreCompletoUsuario,
                                string login, string email, string usuarioID, string roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, nombreCompletoUsuario));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, login));
            claims.Add(new Claim(ClaimTypes.Email, email));
            claims.Add(new Claim("UsuarioID", usuarioID));

            //Creando claims de roles para ser utilizados en conjunto
            //con el atributo Authorize de MVC
            string[] arrRoles = null;
            arrRoles = roles.Split(';');
            foreach (string rol in arrRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            return claims;
        }

        public static List<Claim> GetClaimByType(string type)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = identity.Claims.Where(item => item.Type == type).ToList();

            return claims;
        }

        public static string GetUserFullName()
        {
            return GetClaimByType(ClaimTypes.Name).FirstOrDefault()?.Value;
        }

        public static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static bool IsInRole(string roleName)
        {
            return HttpContext.Current.User.IsInRole(roleName);
        }

        public static int GetUsuarioID()
        {
            var claimValue = GetClaimByType("UsuarioID").FirstOrDefault() != null ?
                           Convert.ToInt32(GetClaimByType("UsuarioID").FirstOrDefault().Value) : 0;
            return claimValue;
        }
    }
}