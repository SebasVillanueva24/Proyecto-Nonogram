using System;
using System.Collections.Generic;
using System.Text;

namespace Nonograma
{
    class Matriz
    {


        string tamaño = "";

        int cantFilas = 0;
        int cantColumnas = 0;

        List<Linea> Filas = new List<Linea>();
        List<Linea> Columnas = new List<Linea>();


        public Matriz(List<string> pDatosFilas, List<string> pDatosColumnas, string pTamaño)
        {
            tamaño = pTamaño;

            cantFilas = int.Parse(pTamaño[0].ToString());

            cantColumnas = int.Parse(pTamaño[3].ToString());




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

            // Console.WriteLine("eo");


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

        public void prueba()
        {
            Filas[1].llenar();

        }


        public void pistas()
        {
            Filas.ForEach(el => el.llenar());
            Columnas.ForEach(el => el.llenar());

            Filas.ForEach(el => el.actualizar());
            Columnas.ForEach(el => el.actualizar());

            Filas.ForEach(el => el.limpiar());
            //Columnas.ForEach(el => el.limpiar());

        }



        public bool buscarVacio()
        {
            for (int f = 0; f < Filas.Count; f++)
            {

                for (int c = 0; c < Filas[f].getCasillas().Count; c++)
                {
                    if (Filas[f].getCasillas()[c].getValor() == 'v')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Casilla sacarVacio()
        {
            for (int f = 0; f < Filas.Count; f++)
            {

                for (int c = 0; c < Filas[f].getCasillas().Count; c++)
                {
                    if (Filas[f].getCasillas()[c].getValor() == 'v')
                    {
                        return Filas[f].getCasillas()[c];
                    }
                }
            }
            return null;
        }

        public void pintar(Casilla nCasilla)
        {
            nCasilla.setValor('p');
        }

        //backtracking(0,0);
            
        public void mostrar()
        {
            for (int i = 0; i < cantFilas; i++)
            {
                Filas[i].getCasillas().ForEach(el => Console.Write(el.getValor() + " "));
                Console.WriteLine();
            }

        }


        public int getCantColumnas()
        {
            return cantColumnas;
        }

    }
}
