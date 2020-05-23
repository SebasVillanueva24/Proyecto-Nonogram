using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using UnityEngine.UI;
using System.Threading;

namespace Nonograma
{
    public class Matriz
    {


        string tamaño = "";

        int cantFilas = 0;
        int cantColumnas = 0;

        public bool animado;

        public Stack posPintadas = new Stack();

        Stack tempPintadas = new Stack();

        Stack posRestringida = new Stack();


        public Cell[,] porPintar;


        List<Linea> Filas = new List<Linea>();
        List<Linea> Columnas = new List<Linea>();


        public Matriz(List<string> pDatosFilas, List<string> pDatosColumnas, string pTamaño)
        {
            tamaño = pTamaño;

            string verTamano = pTamaño[0].ToString() + pTamaño[1].ToString();

            try
            {
                int numTamaño = (Int16.Parse(verTamano));

                if (numTamaño > 9)
                {
                    cantFilas = numTamaño;
                    cantColumnas = numTamaño;
                }
                else
                {
                    cantFilas = int.Parse(pTamaño[0].ToString());

                    cantColumnas = int.Parse(pTamaño[3].ToString());

                }
            }
            catch
            {
                cantFilas = int.Parse(pTamaño[0].ToString());

                cantColumnas = int.Parse(pTamaño[3].ToString());

            }








            for (int i = 0; i < cantFilas; i++)
            {
                Linea Fila = new Linea(pDatosFilas[i + 1]);

                for (int j = 0; j < cantColumnas; j++)
                {
                    Casilla nueva = new Casilla('v');
                    Fila.addCasilla(nueva);
                }

                Filas.Add(Fila);
            }




            for (int t = 0; t < cantColumnas; t++)
            {
                Linea Columna = new Linea(pDatosColumnas[t + 1]);

                Filas.ForEach(el => Columna.addCasilla((el.getCasillas()[t])));

                Columnas.Add(Columna);

            }




        }


        public int getCantFilas()
        {
            return cantFilas;
        }

        public void mostrar()
        {
            for (int i = 0; i < cantFilas; i++)
            {
                Filas[i].getCasillas().ForEach(el => Console.Write(el.getValor() + " "));
                //Console.WriteLine();
            }

        }


        public int getCantColumnas()
        {
            return cantColumnas;
        }


        public void retornoTemp(int fila, int tipo)
        {
            int suma1 = 0;
            int temp = 0;
            int cantE = 0;


            if (fila > 0)
            {

                ////////////////////////////////////////////////////////////////////////////////
                ///   Esto es para limpiar la linea

                for (int i = 0; i < Filas[fila].getDatos().Length; i++)
                {

                    if (Int16.Parse(Filas[fila].getDatos()[i]) < 24)
                    {
                        temp = (Int16.Parse(Filas[fila].getDatos()[i]) + 24);
                        Filas[fila].getDatos()[i] = temp.ToString();
                    }


                }

            }


            int varx = 0;
            int vary = 0;


            if (tipo == 1)
            {
                //Console.WriteLine("tipo 1");
                while (tempPintadas.Count > 1)
                {
                    tempPintadas.Pop();
                }
                string ultimo = tempPintadas.Peek().ToString();

                varx = Int16.Parse(ultimo[1].ToString());
                vary = Int16.Parse(ultimo[4].ToString());

                //Console.WriteLine(tempPintadas.Peek() + " peek");

                tempPintadas.Clear();
                posRestringida.Clear();

                //Console.WriteLine(ultimo + " ultimo");
            }
            else
            {
                //Console.WriteLine("tipo 2"); // aca se despicha
                ////////////////////////////////////////////////
                ///

                for (int i = Filas[fila].getDatos().Length; i > 0; i--)
                {

                    if (Int16.Parse(Filas[fila].getDatos()[i - 1]) > 24)
                    {
                        cantE = (Int16.Parse(Filas[fila].getDatos()[i - 1]) - 24);

                        Filas[fila].getDatos()[i - 1] = cantE.ToString();
                        break;
                    }
                }




                for (int e = 0; e <= cantE - 1; e++)
                {
                    tempPintadas.Pop();
                }

                foreach (ValueTuple<int, int> element in tempPintadas)
                {
                    //Debug.Log(element);
                }





                string ultimo = tempPintadas.Pop().ToString();

                varx = Int16.Parse(ultimo[1].ToString());
                vary = Int16.Parse(ultimo[4].ToString());

                posRestringida.Pop();


            }

            if (vary < cantFilas-1)
            {
                B(varx, vary + 1);
            }
            else
            {
                B(varx - 1, 0);
            }

        }

        public void retornoMedio(int fila)
        {
            int suma1 = 0;
            int temp = 0;
            int cantE = 0;


            if (fila > 0)
            {

                ////////////////////////////////////////////////////////////////////////////////
                ///   Esto es para limpiar la linea

                for (int i = 0; i < Filas[fila].getDatos().Length; i++)
                {

                    if (Int16.Parse(Filas[fila].getDatos()[i]) < 24)
                    {
                        temp = (Int16.Parse(Filas[fila].getDatos()[i]) + 24);
                        Filas[fila].getDatos()[i] = temp.ToString();
                    }
                    /* else
                     {
                         temp = Int16.Parse(Filas[fila].getDatos()[i]);
                         Filas[fila].getDatos()[i] = temp.ToString();
                     }*/

                }




                //Console.WriteLine("fila: " + fila);

                for (int i = Filas[fila].getDatos().Length; i > 0; i--)
                {

                    //Console.WriteLine("Datos: " + Int16.Parse(Filas[fila].getDatos()[i - 1]));
                    if (Int16.Parse(Filas[fila].getDatos()[i - 1]) > 24)
                    {

                        // tengo que ver cuanto vale, sacar esa cantidad de la pila y sumarle 1


                        cantE = (Int16.Parse(Filas[fila].getDatos()[i - 1]) - 24);

                        Filas[fila].getDatos()[i - 1] = cantE.ToString();
                        break;
                    }
                }


                //Console.WriteLine("Estoy en el retorno");
                //Console.WriteLine("Cantidad a eliminar: " + cantE);

                string ultimo = "";

                posPintadas.Pop();


                ultimo = posPintadas.Peek().ToString();

                //Console.WriteLine(ultimo);

                int varx = Int16.Parse(ultimo[1].ToString());
                int vary = Int16.Parse(ultimo[4].ToString());

                int cantP = 0;

                if (cantE == 1)
                {

                    string aux = posPintadas.Pop().ToString();

                    int auxy = Int16.Parse(ultimo[4].ToString());

                    foreach (ValueTuple<int, int> element in posPintadas)
                    {
                        if (element.Item2 == auxy)
                        {
                            cantP++;
                        }
                    }

                    if (cantP == 0)
                    {
                        string temp2 = "";
                        for (int d = 0; d < Columnas[auxy].getDatos().Length; d++)
                        {
                            if (Int16.Parse(Columnas[auxy].getDatos()[d]) > 24)
                            {
                                temp2 = (Int16.Parse(Columnas[auxy].getDatos()[d]) - 24).ToString();
                                Columnas[auxy].getDatos()[d] = temp2;
                            }
                        }
                    }

                }
                else    // para mas de 1
                {
                    for (int e = 0; e < cantE - 1; e++)
                    {
                        string aux = posPintadas.Pop().ToString();

                        int auxy = Int16.Parse(ultimo[4].ToString());

                        foreach (ValueTuple<int, int> element in posPintadas)
                        {
                            if (element.Item2 == auxy)
                            {
                                cantP++;
                            }
                        }

                        if (cantP == 0)
                        {
                            string temp2 = "";
                            for (int d = 0; d < Columnas[auxy].getDatos().Length; d++)
                            {
                                if (Int16.Parse(Columnas[auxy].getDatos()[d]) > 24)
                                {
                                    temp2 = (Int16.Parse(Columnas[auxy].getDatos()[d]) - 24).ToString();
                                    Columnas[auxy].getDatos()[d] = temp2;
                                }

                            }

                        }
                    }

                }





                //Console.WriteLine("------------------------");
                //Console.WriteLine(vary);
                //Console.WriteLine("------------------------");
                foreach (ValueTuple<int, int> element in posPintadas)
                {
                    //Debug.Log(element);
                }

                tempPintadas.Clear();
                posRestringida.Clear();

                // hacer el if de la misma fila

                string ver = posPintadas.Peek().ToString();

                int verNum = Int16.Parse(ver[1].ToString());


                //Console.WriteLine(posPintadas.Peek().ToString()[1] + "  ==  " + varx);

                if (verNum == varx)
                {
                    //Console.WriteLine("que eddddddddd");
                    tempPintadas.Push(posPintadas.Pop());
                }





                // restringir las varas

                string aux2 = posPintadas.Peek().ToString();
                int vary2 = Int16.Parse(aux2[4].ToString());

                //Console.WriteLine(aux2 + " ddddddd ");
                for (int n = vary2 + 1; n <= vary; n++)
                {
                    posRestringida.Push((varx, n));


                }



                if (vary < cantFilas-1)
                {
                    B(varx, vary + 1);
                }
                else
                {
                    B(varx - 1, 0);
                }




            }





        }

        public void retorno(int fila)
        {
            int suma1 = 0;
            int temp = 0;

            if (fila > 0)
            {

                ////////////////////////////////////////////////////////////////////////////////
                ///   Esto es para limpiar la linea

                for (int i = 0; i < Filas[fila].getDatos().Length; i++)
                {

                    if (Int16.Parse(Filas[fila].getDatos()[i]) > 24)
                    {
                        temp = (Int16.Parse(Filas[fila].getDatos()[i]) - 24);
                        Filas[fila].getDatos()[i] = temp.ToString();
                    }
                    else
                    {
                        temp = Int16.Parse(Filas[fila].getDatos()[i]);
                        Filas[fila].getDatos()[i] = temp.ToString();
                    }

                }

                ////////////////////////////////////////////////////////////////////////////////
                for (int i = 0; i < Filas[fila - 1].getDatos().Length; i++)
                {

                    if (Int16.Parse(Filas[fila - 1].getDatos()[i]) > 24)
                    {
                        temp = (Int16.Parse(Filas[fila - 1].getDatos()[i]) - 24);
                        //Console.WriteLine(temp + " este es un valor");
                        Filas[fila - 1].getDatos()[i] = temp.ToString();

                    }
                    else
                    {
                        //Console.WriteLine(Int16.Parse(Filas[fila - 1].getDatos()[i]) + " este es un valor");

                        temp = Int16.Parse(Filas[fila - 1].getDatos()[i]);
                        Filas[fila - 1].getDatos()[i] = temp.ToString();
                    }

                    suma1 += temp;


                }
            }
            else
            {
                for (int i = 0; i < Filas[fila].getDatos().Length; i++)
                {

                    if (Int16.Parse(Filas[fila].getDatos()[i]) > 24)
                    {
                        temp = Int16.Parse(Filas[fila].getDatos()[i]) - 24;
                        //Console.WriteLine(temp + " este es un valor");

                    }
                    else
                    {
                        //Console.WriteLine(Int16.Parse(Filas[fila].getDatos()[i]) + " este es un valor");

                        temp = Int16.Parse(Filas[fila].getDatos()[i]);
                    }

                    //suma1 += temp;

                    Filas[fila].getDatos()[i] = temp.ToString();
                }
            }

            //////////////////////////////////////////////////////////////////////
            ///     VAN LAS COLUMNAS
            //for (int d = 0; d < Columnas[numPos].getDatos().Length; d++)
            //{
            //    suma1 += Int16.Parse(Columnas[numPos].getDatos()[d]);


            //}

            //foreach (ValueTuple<int, int> element in posPintadas)
            //{
            //    if (element.Item2 == numPos)
            //    {
            //        suma2++;
            //    }
            //}


            string ultimo = "";

            ultimo = posPintadas.Peek().ToString();

            int varx = Int16.Parse(ultimo[1].ToString());
            int vary = Int16.Parse(ultimo[4].ToString());

            int cantE = 0;
            foreach (ValueTuple<int, int> element in posPintadas)
            {
                //Console.WriteLine(element);
                if (element.Item1 == (varx))
                {
                    cantE++;
                }
            }

            int cantP = 0;
            for (int e = 0; e < cantE - 1; e++)
            {
                string aux = posPintadas.Pop().ToString();

                int auxy = Int16.Parse(aux[4].ToString());

                foreach (ValueTuple<int, int> element in posPintadas)
                {
                    if (element.Item2 == auxy)
                    {
                        cantP++;
                    }
                }

                if (cantP == 0)
                {
                    string temp2 = "";
                    for (int d = 0; d < Columnas[auxy].getDatos().Length; d++)
                    {
                        if (Int16.Parse(Columnas[auxy].getDatos()[d]) > 24)
                        {
                            temp2 = (Int16.Parse(Columnas[auxy].getDatos()[d]) - 24).ToString();
                            Columnas[auxy].getDatos()[d] = temp2;
                        }

                    }

                }

                ultimo = posPintadas.Pop().ToString();

                varx = Int16.Parse(ultimo[1].ToString());
                vary = Int16.Parse(ultimo[4].ToString());

            }


            //Console.WriteLine("------------------------");
            //Console.WriteLine(vary);
            //Console.WriteLine("------------------------");
            foreach (ValueTuple<int, int> element in posPintadas)
            {
                //Debug.Log(element);
            }

            tempPintadas.Clear();
            posRestringida.Clear();

            if (vary < cantFilas-1)
            {
                B(varx, vary + 1);
            }
            else
            {
                B(varx - 1, 0);
            }



        }

        public void verificar(int numPos, int tipo, int y2)
        {
            if (tipo == 1) // Las filas
            {

                //nuevo
                int suma3 = 0;
                foreach (ValueTuple<int, int> element in tempPintadas)
                {
                    //Console.WriteLine(element);
                    if (element.Item1 == numPos)
                    {
                        suma3++;
                    }
                }
                //Console.WriteLine("Esta es la suma en X: " + suma3);




                int suma4 = 0;

                for (int d = 0; d < Filas[numPos].getDatos().Length; d++)
                {
                    if (Int16.Parse(Filas[numPos].getDatos()[d]) > 24)
                    {
                        suma4 += Int16.Parse(Filas[numPos].getDatos()[d]) - 24;
                    }
                    else
                    {
                        suma4 += Int16.Parse(Filas[numPos].getDatos()[d]);
                    }

                }

                //Console.WriteLine(suma4 + " total vs pintadas " + suma3);
                if (suma3 < suma4 && y2 == (Columnas.Count - 1) && numPos > 0)
                {
                    //Console.WriteLine("aca se retorna");
                    retorno(numPos);
                }


                if (suma4 == suma3)
                {
                    //Console.WriteLine("De aca sale: " + (numPos, y2 + 1));
                    posRestringida.Push((numPos, y2 + 1));
                    return;
                }

                //////  aca esta el error
                ///

                for (int d = 0; d < Filas[numPos].getDatos().Length; d++)
                {

                    if (Int16.Parse(Filas[numPos].getDatos()[d]) < 25)
                    {
                        //Console.WriteLine(Int16.Parse(Filas[numPos].getDatos()[d]) + "  dato " + tempPintadas.Count);

                        if (Int16.Parse(Filas[numPos].getDatos()[d]) == (tempPintadas.Count - posRestringida.Count) ||
                            (Int16.Parse(Filas[numPos].getDatos()[d]) == 1 && (tempPintadas.Count - posRestringida.Count) == 0)
                            && y2 < 1)
                        {
                            //Console.WriteLine("meti esta (" + numPos + "," + (y2 + 1) + ")");

                            posRestringida.Push((numPos, y2 + 1));


                            int nuevo = Int16.Parse(Filas[numPos].getDatos()[d]) + 24;
                            string myString = nuevo.ToString();

                            Filas[numPos].getDatos()[d] = myString;




                        }
                        return;


                    }

                }

            }
            if (tipo == 2)
            {

                int suma = 0;
                foreach (ValueTuple<int, int> element in posPintadas)
                {
                    //Console.WriteLine(element);
                    if (element.Item2 == numPos)
                    {
                        suma++;
                    }
                }


                if (suma == 0)
                {
                    string temp2 = "";
                    for (int d = 0; d < Columnas[numPos].getDatos().Length; d++)
                    {
                        if (Int16.Parse(Columnas[numPos].getDatos()[d]) > 24)
                        {
                            temp2 = (Int16.Parse(Columnas[numPos].getDatos()[d]) - 24).ToString();
                            Columnas[numPos].getDatos()[d] = temp2;
                        }

                    }
                }

                //Console.WriteLine("Esta es la suma en Y: " + suma);


                int suma1 = 0;

                for (int d = 0; d < Columnas[numPos].getDatos().Length; d++)
                {
                    //Console.WriteLine(Int16.Parse(Columnas[numPos].getDatos()[d]) + " que pasa");

                    if (Int16.Parse(Columnas[numPos].getDatos()[d]) > 24)
                    {
                        suma1 = suma1 + (Int16.Parse(Columnas[numPos].getDatos()[d]) - 24);
                    }
                    else
                    {
                        suma1 += Int16.Parse(Columnas[numPos].getDatos()[d]);
                    }

                }







                // errores

                //Console.WriteLine(suma1 + " suma1 vertical" + suma);

                if (Columnas[numPos].getDatos().Length == 1)
                {
                    if (suma1 > suma)
                    {
                        if (Int16.Parse(Columnas[numPos].getDatos()[0]) > 24)
                        {
                            Columnas[numPos].getDatos()[0] = (Int16.Parse(Columnas[numPos].getDatos()[0]) - 24).ToString();
                        }

                    }

                }

                if (suma == suma1)
                {
                    if (Filas[y2].getDatos().Length == 1)
                    {
                        // verifica si la linea esta llena
                        if (Int16.Parse(Filas[y2].getDatos()[0]) == Filas[y2].getCasillas().Count)
                        {
                            // maguiver
                            //Console.WriteLine("vale 5 la linea");
                            retornoMedio(y2 - 1);
                            return;

                        }
                        //Console.WriteLine("En teoria meto eso: " + (y2, numPos));

                        foreach (ValueTuple<int, int> element in posRestringida)
                        {
                            //Console.WriteLine(element);

                        }


                        if (Int16.Parse(Columnas[numPos].getDatos()[0]) < 24)
                        {
                            posRestringida.Push((y2, numPos));
                            int nuevo = Int16.Parse(Columnas[numPos].getDatos()[0]) + 24;
                            string myString = nuevo.ToString();
                            Columnas[numPos].getDatos()[0] = myString;
                            //Console.WriteLine("le sume 24");
                            return;
                        }
                        else
                        {
                            posRestringida.Push((y2, numPos));
                        }


                        return;

                    }
                    else
                    {
                        // hay que arreglar
                        posRestringida.Push((y2, numPos));

                        int nuevo = Int16.Parse(Columnas[numPos].getDatos()[0]) + 24;
                        string myString = nuevo.ToString();
                        Columnas[numPos].getDatos()[0] = myString;
                        //Console.WriteLine("le sume 24");
                        return;
                    }

                }
                // aca termina


                /////// solo de 1 
                ///
                if (Columnas[numPos].getDatos().Length == 1)
                {
                    if (Int16.Parse(Columnas[numPos].getDatos()[0]) < 25)
                    {

                        if (suma > 0)
                        {
                            if (posRestringida.Count > 0)
                            {
                                if (Int16.Parse(Columnas[numPos].getDatos()[0]) - suma == 1)
                                {
                                    if (posRestringida.Peek().ToString() == (y2, numPos).ToString())
                                    {
                                        // hacer retorno
                                        retornoTemp(y2, 1);
                                    }

                                }

                            }

                        }





                        if (Int16.Parse(Columnas[numPos].getDatos()[0]) == (suma))//|| (Int16.Parse(Filas[numPos].getDatos()[d]) == 1 && (tempPintadas.Count - posRestringida.Count) == 0))
                        {
                            //Console.WriteLine("meti esta " + (y2, numPos) + "  por vlidar en Y");

                            if (posRestringida.Count > 0)
                            {
                                if (posRestringida.Peek().ToString() != (y2, numPos).ToString())
                                {
                                    posRestringida.Push((y2, numPos));
                                }
                                else
                                {
                                    //Console.WriteLine("son iguales");
                                    return;
                                }
                            }
                            else
                            {
                                posRestringida.Push((y2, numPos));
                            }

                            int nuevo = Int16.Parse(Columnas[numPos].getDatos()[0]) + 24;
                            string myString = nuevo.ToString();

                            Columnas[numPos].getDatos()[0] = myString;
                            return;
                        }
                    }
                    else
                    {
                        posRestringida.Push((y2, numPos));
                        return;

                    }


                }

                /////// mas de 1

                for (int d = 0; d < Columnas[numPos].getDatos().Length; d++)
                {


                    if (Int16.Parse(Columnas[numPos].getDatos()[d]) < 25)
                    {
                        //cambios nesecita

                        //Console.WriteLine(Columnas[numPos].getDatos()[d] + " suma = " + suma);

                        //aca se debe fijar




                        if (suma > 0)
                        {
                            if (posRestringida.Count > 0)
                            {
                                if (Int16.Parse(Columnas[numPos].getDatos()[d]) - suma == 1)
                                {
                                    if (posRestringida.Peek().ToString() == (y2, numPos).ToString())
                                    {
                                        //Console.WriteLine(Filas[y2].getDatos().Length);
                                        // hacer retorno
                                        if (Filas[y2].getDatos().Length > 1)
                                        {
                                            retornoTemp(y2, 2);
                                        }
                                        else
                                        {

                                            retornoTemp(y2, 1);
                                        }

                                    }

                                }

                            }




                            if ((Int16.Parse(Columnas[numPos].getDatos()[d]) == y2 && y2 == suma))//|| (Int16.Parse(Columnas[numPos].getDatos()[d]) == 1 && (y2 - suma) == 0))
                            {
                                // Console.WriteLine("meti esta " + (y2, numPos) + "  por vlidar en Y2");

                                // atajo

                                int dato = Int16.Parse(Filas[y2].getDatos()[0]);

                                if (dato > 24)
                                {
                                    dato = dato - 24;
                                }
                                if (Filas[y2].getDatos().Length == 1)
                                {
                                    // Console.WriteLine("temp: " + tempPintadas.Count + " , tamaño: " + dato);
                                    if (tempPintadas.Count > 0 && tempPintadas.Count - 1 < dato)
                                    {
                                        retornoTemp(y2, 1);
                                    }
                                }


                                if (posRestringida.Count > 0)
                                {
                                    if (posRestringida.Peek().ToString() != (y2, numPos).ToString())
                                    {
                                        posRestringida.Push((y2, numPos));
                                    }
                                    else
                                    {
                                        //Debug.Log(" son iguales ");

                                    }
                                }
                                else
                                {
                                    posRestringida.Push((y2, numPos));

                                }


                                int nuevo = Int16.Parse(Columnas[numPos].getDatos()[d]) + 24;
                                string myString = nuevo.ToString();

                                Columnas[numPos].getDatos()[d] = myString;
                                //Console.WriteLine("le sume 24");
                                return;

                            }


                        }
                        return;

                    }





                }



            }



        }

        // Para la funcion validar: Recorrer la pila y bucscar todas las casillas que tienen la misma cantidad de Y


        // para sacar los valores usar Filas[0].getDatos(), y sumarlos 

        public bool validar2(int numPos, int tipo)
        {
            int suma1 = 0;
            int suma2 = 0;


            if (tipo == 1) // Las filas
            {
                foreach (ValueTuple<int, int> element in tempPintadas)
                {
                    if (element.Item1 == numPos)
                    {
                        suma2++;
                    }
                }

                for (int d = 0; d < Filas[numPos].getDatos().Length; d++)
                {
                    int dato = Int16.Parse(Filas[numPos].getDatos()[d]);

                    if (dato > 24)
                    {
                        dato = dato - 24;
                    }
                    suma1 += dato;
                }


                // Revisa las restringidas

                if (posRestringida.Count > 0)
                {


                    foreach (ValueTuple<int, int> element1 in posRestringida)
                    {
                        foreach (ValueTuple<int, int> element in tempPintadas)
                        {

                            if (element1 == element)
                            {
                                if (Filas[numPos].getDatos().Length == 1)
                                {
                                    // hace que si es 1 numero y encuentra un eror devuelve
                                    int dato = Int16.Parse(Filas[numPos].getDatos()[0]);

                                    if (dato > 24)
                                    {
                                        dato = dato - 24;
                                    }

                                    if (suma2 > 0 && suma2 <= dato && element.Item2 > 0)
                                    {
                                        //Console.WriteLine("coma caca");

                                        retornoTemp(numPos, 1);
                                    }
                                }
                                /*
                                else // mayor a 1 dato agarrar cada dato 
                                {
                                    int dato = 0;
                                    int numDato = 0;
                                    

                                    for (int i = 0; i < Filas[numPos].getDatos().Length; i++)
                                    {


                                        if (Int16.Parse(Filas[numPos].getDatos()[i]) > 24)
                                        {

                                            // tengo que ver cuanto vale, sacar esa cantidad de la pila y sumarle 1
                                            dato += (Int16.Parse(Filas[numPos].getDatos()[i]) - 24);


                                        }
                                        else
                                        {
                                            // dato += posRestringida.Count;
                                            numDato = i - 1;
                                            break;

                                        }
                                    }
                                    suma2--;
                                    Console.WriteLine(dato + "dato");
                                    Console.WriteLine(numDato + "numDato");
                                    Console.WriteLine(suma2 + "suma2");

                                    Console.WriteLine(Int16.Parse(Filas[numPos].getDatos()[numDato]));


                                    if ((suma2 - dato) > 0 && (suma2 - dato) < Int16.Parse(Filas[numPos].getDatos()[numDato])
                                        && ((suma2 + posRestringida.Count) - 1) != cantFilas - 1)
                                    {
                                        Console.WriteLine("coma caca2");

                                        //tempPintadas.Push((8, 8));

                                        retornoTemp(numPos, 1);
                                    }



                                }*/

                                //Console.WriteLine("encontro una restringida");
                                return false;
                            }
                        }

                    }
                }

                // usar retono medio con mas de 1 dato sino retono normal





                if (suma2 <= suma1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            if (tipo == 2) // Las columnas
            {
                posPintadas.Push(tempPintadas.Peek());
                for (int d = 0; d < Columnas[numPos].getDatos().Length; d++)
                {
                    suma1 += Int16.Parse(Columnas[numPos].getDatos()[d]);


                }

                foreach (ValueTuple<int, int> element in posPintadas)
                {
                    if (element.Item2 == numPos)
                    {
                        suma2++;
                    }
                }



                if (suma2 <= suma1)
                {
                    posPintadas.Pop();
                    return true;
                }
                else
                {
                    posPintadas.Pop();
                    return false;
                }

            }
            return false;
        }




        public void B(int x, int y)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            if (x < cantFilas) //x != cantFilas &&
            {
                int y2 = y;

                while (y2 < Columnas.Count - 1)
                {
                    //Console.WriteLine("");
                    //Console.WriteLine("********************");
                    //Console.WriteLine(y2);
                    //Console.WriteLine("");

                    tempPintadas.Push((x, y2));


                    // Evaluo que si funciona


                    if (x > 0)
                    {
                        verificar(y2, 2, x);
                    }

                    if (!validar2(x, 1) || !validar2(y2, 2)) // cambiar validar datos
                    {
                        // La posicion si funciona

                        //Console.WriteLine(x + "," + y2);
                        tempPintadas.Pop();


                    }

                    verificar(x, 1, y2);

                    //Console.WriteLine(" ---------------- ");
                    foreach (ValueTuple<int, int> element in tempPintadas)
                    {
                        //Debug.Log (element);
                    }

                    //Console.WriteLine(" ---------------- ");

                    y2++;


                }

                //foreach (ValueTuple<int, int> element in posPintadas)
                //{
                //    Console.WriteLine(element);

                //}

                //Console.WriteLine("--------------");
                //foreach (ValueTuple<int, int> element in posRestringida)
                //{
                //    Console.WriteLine(element);

                //}

                //Console.WriteLine("");
                //Console.WriteLine("********************");
                //Console.WriteLine(y2);
                //Console.WriteLine("");

                tempPintadas.Push((x, y2));

                if (x > 0)
                {
                    verificar(y2, 2, x);
                }

                if (!validar2(x, 1) || !validar2(y2, 2)) // cambiar validar datos
                {
                    // La posicion si funciona

                    tempPintadas.Pop();

                }

                verificar(x, 1, y2);


                System.Object[] arr = tempPintadas.ToArray();



                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    posPintadas.Push(arr.GetValue(i));
                }

                tempPintadas.Clear();
                posRestringida.Clear();
                B(x + 1, 0);


            }
            else
            {
                //Console.WriteLine("llegamos");

                //Console.WriteLine(posPintadas.Count);

                foreach (ValueTuple<int, int> element in posPintadas)
                {

                    if (!animado)
                    {
                        porPintar[element.Item1, element.Item2].GetComponent<Image>().color = new Color32(0, 255, 225, 100);
                    }

                }


                //Environment.Exit(0);

            }

            watch.Stop();

            Debug.Log($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }


    }
}

