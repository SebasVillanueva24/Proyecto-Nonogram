using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Nonograma
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader archivo = new StreamReader("2x3.txt");  // NOMBRE DEL ARCHIVO

            string mensaje = archivo.ReadLine(); // Linea que se graba en el archivo

            string tamañoMatriz = mensaje;

            int bandera = 0;

            List<string> datosFilas = new List<string>();
            List<string> datosColumnas = new List<string>();

            while (mensaje != null)
            {
                if (mensaje == "FILAS")
                {
                    bandera = 1;
                }
                if (mensaje == "COLUMNAS")
                {
                    bandera = 2;
                }

                if (bandera == 1)
                {
                    datosFilas.Add(mensaje);
                }
                if (bandera == 2)
                {
                    datosColumnas.Add(mensaje);
                }
                mensaje = archivo.ReadLine();
            }

            archivo.Close();  // Cerrar el archivo


            Matriz tablero = new Matriz(datosFilas, datosColumnas, tamañoMatriz);

            //Console.WriteLine(tablero.validar2(1, 2));

            tablero.B(0, 0);


        }
    }
}
