using System;
using System.Collections.Generic;
using System.Text;

namespace Nonograma
{
    class Linea
    {

        int id = 0;

        bool enable = true;

        int casillasPintadas = 0;

        int casilasBloqueadas = 0;

        string[] datos;
        List<Casilla> casillas = new List<Casilla>();

        public Linea(string pDatos)
        {
            datos = pDatos.Split(",");

        }

        public List<Casilla> getCasillas()
        {
            return casillas;
        }


        public void addCasilla(Casilla nCasilla)
        {
            casillas.Add(nCasilla);
        }


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

        public void actualizar()
        {
            int nuevaPintadas = 0;
            int bloqueadas = 0;

            for (int i = 0; i < casillas.Count; i++)
            {
                if( casillas[i].getValor() == 'p')
                {
                    nuevaPintadas++;
                }
                else if(casillas[i].getValor() == 'x')
                {
                    bloqueadas++;
                }
            }
            casillasPintadas = nuevaPintadas;
            casilasBloqueadas = bloqueadas;

        }


        public void limpiar()
        {
            int cantPintadas = 0;

            if (enable && casillasPintadas != 0)
            {
                Console.WriteLine(Int16.Parse(datos[0]));
                if (datos.Length == 1)
                {
                    if (casillasPintadas == Int16.Parse(datos[0]))
                    {
                        bloquear();
                        enable = false;
                    }
                    else
                    {
                        
                        bool bandera = false;
                        for (int i = 0; i < casillas.Count; i++)
                        {

                            if (bandera && cantPintadas < Int16.Parse(datos[0]))
                            {
                                casillas[i].setValor('p');
                                cantPintadas++;
                            }
                            else
                            {
                                if (casillas[i].getValor() == 'p' && i == 0)
                                {
                                    cantPintadas++;
                                    bandera = true;
                                }
                                else
                                {
                                    bloquear();
                                }

                            }
                            
                        }
                        enable = false;
                    }
                    
                }
                else
                {

                    for (int i = 0; i < casillas.Count; i++)
                    {

                        if (casillas[i].getValor() == 'p')
                        {
                            cantPintadas++;
                        }
                        else if (casillas[i].getValor() == 'v')
                        {

                            for (int p = 0; p < datos.Length; p++)
                            {
                                if (cantPintadas == Int16.Parse(datos[p]))
                                {
                                    casillas[i].setValor('x');
                                    cantPintadas = 0;
                                    //datos[p] = "0";
                                    break;
                                }
                            }
                        }
                    }
                }
            }

        }

        public void llenar()
        {
            if (datos.Length == 1 &&  Int16.Parse(datos[0]) == casillas.Count)
            {
                if (enable)
                {
                    casillas.ForEach(el => el.setValor('p'));
                    enable = false;
                }
            }
            else
            {
                
                int suma = 0;

                for (int d = 0; d < datos.Length; d++)
                {
                    suma = suma + Int16.Parse(datos[d]);
                }

                suma = suma + (datos.Length - 1);

                if (suma == casillas.Count)
                {
                    for (int i = 0; i < datos.Length; i++)
                    {
                        for (int p = 0; p < Int16.Parse(datos[i]); p++)
                        {
                            casillas[p + casillasPintadas].setValor('p');

                           // casilasBloqueadas.Add(casillas[p + casillasPintadas]);

                        }


                        casillasPintadas += Int16.Parse(datos[i]);

                        if ((casillasPintadas) < casillas.Count)
                        {
                            casillas[casillasPintadas].setValor('x');
                            casillasPintadas++;
                        }

                    }

                    enable = false;

                }
            }


        }


    }
}
