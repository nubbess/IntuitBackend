using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsLibrary
{
    using System.Text.RegularExpressions;

    public static class CuitValidator
    {
        public static bool CuitIsValid(string cuit)
        {
            bool result = false;

            // Verifico que el CUIT no sea nulo
            if (string.IsNullOrEmpty(cuit))
            {
                return false;
            }
            else
            {
                // Verifico que el CUIT esté bien formado
                if (Regex.IsMatch(cuit, @"^(\d){2}-(\d){8}-(\d)|(\d){11}$"))
                {
                    // Elimino los '-' si es necesario
                    if (cuit.Length == 13)
                    {
                        cuit = Regex.Replace(cuit, @"-", "");
                    }

                    char[] cuitArray = cuit.ToCharArray();
                    int[] serie = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                    int aux = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        aux += int.Parse(cuitArray[i].ToString()) * serie[i];
                    }

                    aux = 11 - (aux % 11);
                    aux = (aux == 11) ? 0 : aux;
                    aux = (aux == 10) ? 9 : aux;

                    if (aux == int.Parse(cuitArray[10].ToString()))
                    {
                        result = true;
                    }
                }
                else
                {
                    return false;
                }
            }

            return result;
        }
    }

}
