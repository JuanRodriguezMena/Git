using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosImpuesto
    {
        public static bool GuardarResultadoEnArchivo(string idEstablecimiento, string nombreEstablecimiento, decimal impuesto)
        {
            string rutaArchivo = "resultados_impuestos.txt";

            try
            {
                bool identificacionRepetida = VerificarIdentificacionRepetida(rutaArchivo, idEstablecimiento);

                if (identificacionRepetida)
                {
                    Console.WriteLine("La identificación del establecimiento ya existe en el archivo. El resultado no se guardó.");
                    return false;
                }

                using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
                {
                    sw.WriteLine($"Identificación: {idEstablecimiento}, Nombre: {nombreEstablecimiento}, Impuesto: {impuesto:C}");
                    Console.WriteLine("Resultados guardados en el archivo.");
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar en el archivo: {ex.Message}");
                return false;
            }
        }

        private static bool VerificarIdentificacionRepetida(string rutaArchivo, string idEstablecimiento)
        {
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    if (linea.Contains($"Identificación: {idEstablecimiento}"))
                    {
                        return true; 
                    }
                }
            }
            return false; 
        }
    }
 }
