using System;
using System.Collections.Generic;
using System.Text;

namespace Nonograma
{
    class Filas
    {

        int id = 0;

        bool enable = true;

        int casillasPintadas = 0;

        List<Casilla> casilasBloqueadas = new List<Casilla>();

        List<int> datos = new List<int>();
        List<Casilla> casillas = new List<Casilla>();

        public Filas(List<int> datos, int tamaño, int id)
        {
            this.datos = datos;
            this.id = id;

            for (int i = 1; i < tamaño + 1; i++)
            {
                Casilla nueva = new Casilla('v');
                casillas.Add(nueva);
            }

        }



        public int getID()
        {
            return id;
        }

        public List<Casilla> getCasillas()
        {
            return casillas;
        }


        public void addCasilla(Casilla nCasilla)
        {
            casillas.Add(nCasilla);
        }

       

        public void llenar()
        {
            if (datos.Count == 1 && datos[0] == casillas.Count)
            {
                if (enable)
                {
                    casillas.ForEach(el => el.setValor('p'));
                    enable = false;
                }
                casillas.ForEach(el => Console.Write(el.getValor() + " "));
                Console.WriteLine("");
            }
            else
            {
                int suma = 0;

                datos.ForEach(el => suma = suma+el);

                suma = suma + (datos.Count-1);

                if (suma == casillas.Count)
                {
                    for(int i = 0;i<datos.Count;i++)
                    {
                        for (int p = 0;p<datos[i];p++)
                        {
                            casillas[p+casillasPintadas].setValor('p');

                            casilasBloqueadas.Add(casillas[p + casillasPintadas]);
                            
                        }


                        casillasPintadas += datos[i];

                        if ( (casillasPintadas)<casillas.Count)
                        {
                            casillas[casillasPintadas].setValor('x');
                            casillasPintadas++;
                        }
                        
                    }

                    enable = false;
                    casillas.ForEach(el => Console.Write(el.getValor()+" "));
                    Console.WriteLine("");

                }
                else
                {
                    Console.WriteLine("La linea no esta completa");
                }
            }

            
        }
        /////////////////////////////////////////////
        

        void bloquear()
        {
            for (int i = 0; i < casillas.Count; i++)
            {
                if (casillas[i].getValor() != 'p')
                {
                    casillas[i].setValor('x');
                }

            }

        }
        
        public void limpiar()
        {
            if(enable && casilasBloqueadas.Count!=0)
            {
                if (datos.Count == 1)
                {
                    bloquear();
                    enable = false;
                }
                else
                {
                    int cantPintadas = 0;

                    for (int i = 0; i < casillas.Count; i++)
                    {
                        if (casillas[i].getValor() == 'p')
                        {
                            cantPintadas++;
                        }
                        else if (casillas[i].getValor() == 'v')
                        {
                            
                            for (int p = 0; p < datos.Count; p++)
                            {
                                if (cantPintadas == datos[p])
                                {
                                    casillas[i].setValor('x');
                                    cantPintadas = 0;
                                    datos[p] = 0;
                                    break;
                                }


                            }
                            



                        }

                    }



                

                }
                casillas.ForEach(el => Console.Write(el.getValor() + " "));
                Console.WriteLine("");




            }

        }

        /////////////////////////////////

        public void pintar(int cant)
        {
            for(int p = 0; p < cant; p++)
                        {
                casillas[p+3].setValor('p');

                casilasBloqueadas.Add(casillas[p]);

            }
        }

    }
}
