using System;
using System.Collections.Generic;
using System.Text;

namespace Nonograma
{
    class Casilla
    {
        int id = 0;
        char valor = 'v';
        int posX = 0;
        int posY = 0;

        public Casilla(char valor)
        {
            this.valor = valor;
            //this.posX = posX;
            //this.posY = posY;

            //this.id = (posX - 1) * 5 + posY;
        }

        public void setValor(char v)
        {
            this.valor = v;
        }
        void setPosX(int x)
        {
            this.posX = x;
        }
        void setPosY(int y)
        {
            this.posY = y;
        }

        public int getID()
        {
            return id;
        }

        public char getValor()
        {
            return valor;
        }
        public int getPosX()
        {
            return posX;
        }
        public int getPosY()
        {
            return posY;
        }

    }
}
