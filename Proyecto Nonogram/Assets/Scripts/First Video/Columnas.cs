using System;
using System.Collections.Generic;
using System.Text;

namespace Nonograma
{
    class Columnas
    {


        int id = 0;

        bool enable = true;

        int casillasPintadas = 0;

        List<Casilla> casilasBloqueadas = new List<Casilla>();

        List<int> datos = new List<int>();
        List<Casilla> casillas = new List<Casilla>();



        public Columnas(List<Filas> Filas,int tamaño)
        {
             for (int t=0;t<tamaño;t++)
            {
                Filas.ForEach(el => casillas.Add((el.getCasillas()[t])));
            }
            
        }

        public List<Casilla> getCasillas()
        {
            return casillas;
        }



    }
}
