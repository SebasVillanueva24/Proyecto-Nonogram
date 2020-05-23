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
    public class GameManager : MonoBehaviour
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

            //Console.WriteLine(tablero.validar2(1, 2));
            mBoard.Create(file);

            //tablero.porPintar = mBoard.mAllCells;
            ////mBoard.mAllCells[0, 0].GetComponent<Image>().color = new Color32(0, 255, 225, 100);

            ////tablero.celdasPorPintar[0, 0].transform.GetChild(0).GetComponent<Image>.color = new Color32(0, 255, 225, 100);
            tablero.animado = true;

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            tablero.B(0, 0);

            watch.Stop();

            Debug.Log($"Execution Time: {watch.ElapsedMilliseconds} ms");

        }

        void Update()
        {
            //if (color <= 4)
            //{
            //    mBoard.mAllCells[color,color ].GetComponent<Image>().color = new Color32(0, 255, 225, 100);
            //    color++;
            //    Thread.Sleep(1000);

            //}
            if (tablero.posPintadas.Count != 0)
            {
                string ultimo = tablero.posPintadas.Peek().ToString();

                int varx = Int16.Parse(ultimo[1].ToString());
                int vary = Int16.Parse(ultimo[4].ToString());
                mBoard.mAllCells[varx, vary].GetComponent<Image>().color = new Color32(0, 255, 225, 100);
                tablero.posPintadas.Pop();
                Thread.Sleep(1000);
            }

        }

    }
}

