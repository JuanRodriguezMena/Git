using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaImpuento
    {
        public static decimal CalcularImpuesto(decimal ingresosAnuales, decimal gastosAnuales, int tiempoFuncionamiento, bool esResponsableIVA)
        {
            decimal ganancias = ingresosAnuales - gastosAnuales;
            decimal tarifa = 0;

            if (esResponsableIVA)
            {
                if (ganancias >= 0 && ganancias < 100000)
                    tarifa = 5;
                else if (ganancias >= 100000 && ganancias < 200000)
                    tarifa = 10;
                else if (ganancias >= 400000)
                    tarifa = 15;
            }
            else
            {
                if (ganancias > 100000)
                {
                    if (tiempoFuncionamiento < 6)
                        tarifa = 1;
                    else if (tiempoFuncionamiento >= 6 && tiempoFuncionamiento < 10)
                        tarifa = 2;
                    else
                        tarifa = 3;
                }
            }

            return (ganancias * tarifa) / 100;
        }
    }
}
