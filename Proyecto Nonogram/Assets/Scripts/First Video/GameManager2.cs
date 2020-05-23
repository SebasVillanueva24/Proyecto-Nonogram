using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace Nonograma
{
    public class GameManager2 : MonoBehaviour
    {

        public Board mBoard;
        public Matriz tablero;
        int color = 0;

        void Start()
        {

            string file = EditorUtility.OpenFilePanel("Seleccionar nivel", "", "txt");

            StreamReader archivo = new StreamReader(file);  // NOMBRE DEL ARCHIVO

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

            tablero = new Matriz(datosFilas, datosColumnas, tamañoMatriz);

            mBoard.Create(file);

            tablero.porPintar = mBoard.mAllCells;

            tablero.animado = false;

            tablero.B(0, 0);
        }
    }
}

