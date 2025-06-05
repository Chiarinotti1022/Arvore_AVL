using System;

namespace Arvore_AVL
{
    public class No
    {
        public int Valor;
        public No Esquerda;
        public No Direita;
        public int Altura;

        public No(int valor)
        {
            Valor = valor;
            Altura = 1;
        }
    }
}
