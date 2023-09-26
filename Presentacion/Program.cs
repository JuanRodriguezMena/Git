using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Logica;

namespace Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Liquidación de Impuestos de Industria y Comercio");
            Console.WriteLine("------------------------------------------------");

            Console.Write("Ingrese la identificación del establecimiento: ");
            string idEstablecimiento = Console.ReadLine();

            Console.Write("Ingrese el nombre del establecimiento: ");
            string nombreEstablecimiento = Console.ReadLine();

            Console.Write("Ingrese el valor de ingresos anuales: ");
            decimal ingresosAnuales = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor de gastos anuales: ");
            decimal gastosAnuales = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese el tiempo de funcionamiento (en años): ");
            int tiempoFuncionamiento = int.Parse(Console.ReadLine());

            Console.Write("¿Es responsable de IVA? (S/N): ");
            bool esResponsableIVA = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase);
            decimal impuesto = LogicaImpuento.CalcularImpuesto(ingresosAnuales, gastosAnuales, tiempoFuncionamiento, esResponsableIVA);
            bool guardadoExitoso = DatosImpuesto.GuardarResultadoEnArchivo(idEstablecimiento, nombreEstablecimiento, impuesto);

            Console.WriteLine();
            if (guardadoExitoso)
            {
                Console.WriteLine("Resumen de la liquidación de impuestos:");
                Console.WriteLine($"Identificación del establecimiento: {idEstablecimiento}");
                Console.WriteLine($"Nombre del establecimiento: {nombreEstablecimiento}");
                Console.WriteLine($"Impuesto a pagar: {impuesto:C}");
                Console.WriteLine("Los resultados se han guardado en el archivo.");
            }
            else
            {
                Console.WriteLine("No se guardaron resultados debido a una identificación de establecimiento repetida.");
            }
            Console.WriteLine("Presione cualquier tecla para salir.");
            Console.ReadKey();
        }

    }
}
