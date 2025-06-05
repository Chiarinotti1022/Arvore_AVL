using System;

namespace Arvore_AVL
{
    internal class ArvoreAVL
    {
        public No Raiz;

        // Altura de um nó
        int ObterAltura(No no)
        {
            return no == null ? 0 : no.Altura;
        }

        // Fator de balanceamento
        int ObterFatorBalanceamento(No no)
        {
            return no == null ? 0 : ObterAltura(no.Esquerda) - ObterAltura(no.Direita);
        }

        // Rotação à direita
        No RotacaoDireita(No y)
        {
            No x = y.Esquerda;
            No T2 = x.Direita;

            x.Direita = y;
            y.Esquerda = T2;

            y.Altura = Math.Max(ObterAltura(y.Esquerda), ObterAltura(y.Direita)) + 1;
            x.Altura = Math.Max(ObterAltura(x.Esquerda), ObterAltura(x.Direita)) + 1;

            return x;
        }

        // Rotação à esquerda
        No RotacaoEsquerda(No x)
        {
            No y = x.Direita;
            No T2 = y.Esquerda;

            y.Esquerda = x;
            x.Direita = T2;

            x.Altura = Math.Max(ObterAltura(x.Esquerda), ObterAltura(x.Direita)) + 1;
            y.Altura = Math.Max(ObterAltura(y.Esquerda), ObterAltura(y.Direita)) + 1;

            return y;
        }

        // Inserção
        public No Inserir(No no, int valor)
        {
            if (no == null)
                return new No(valor);

            if (valor < no.Valor)
                no.Esquerda = Inserir(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Inserir(no.Direita, valor);
            else
                return no;

            no.Altura = 1 + Math.Max(ObterAltura(no.Esquerda), ObterAltura(no.Direita));

            int balanceamento = ObterFatorBalanceamento(no);

            // LL
            if (balanceamento > 1 && valor < no.Esquerda.Valor)
                return RotacaoDireita(no);

            // RR
            if (balanceamento < -1 && valor > no.Direita.Valor)
                return RotacaoEsquerda(no);

            // LR
            if (balanceamento > 1 && valor > no.Esquerda.Valor)
            {
                no.Esquerda = RotacaoEsquerda(no.Esquerda);
                return RotacaoDireita(no);
            }

            // RL
            if (balanceamento < -1 && valor < no.Direita.Valor)
            {
                no.Direita = RotacaoDireita(no.Direita);
                return RotacaoEsquerda(no);
            }

            return no;
        }

        // Busca
        public bool Buscar(No no, int valor)
        {
            if (no == null)
                return false;
            if (valor == no.Valor)
                return true;
            if (valor < no.Valor)
                return Buscar(no.Esquerda, valor);
            else
                return Buscar(no.Direita, valor);
        }

        // Encontrar menor valor
        No MenorValorNo(No no)
        {
            No atual = no;
            while (atual.Esquerda != null)
                atual = atual.Esquerda;
            return atual;
        }

        // Remoção
        public No Remover(No no, int valor)
        {
            if (no == null)
                return no;

            if (valor < no.Valor)
                no.Esquerda = Remover(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Remover(no.Direita, valor);
            else
            {
                if ((no.Esquerda == null) || (no.Direita == null))
                {
                    No temp = no.Esquerda ?? no.Direita;

                    if (temp == null)
                    {
                        temp = no;
                        no = null;
                    }
                    else
                    {
                        no = temp;
                    }
                }
                else
                {
                    No temp = MenorValorNo(no.Direita);
                    no.Valor = temp.Valor;
                    no.Direita = Remover(no.Direita, temp.Valor);
                }
            }

            if (no == null)
                return no;

            no.Altura = Math.Max(ObterAltura(no.Esquerda), ObterAltura(no.Direita)) + 1;

            int balanceamento = ObterFatorBalanceamento(no);

            // LL
            if (balanceamento > 1 && ObterFatorBalanceamento(no.Esquerda) >= 0)
                return RotacaoDireita(no);

            // LR
            if (balanceamento > 1 && ObterFatorBalanceamento(no.Esquerda) < 0)
            {
                no.Esquerda = RotacaoEsquerda(no.Esquerda);
                return RotacaoDireita(no);
            }

            // RR
            if (balanceamento < -1 && ObterFatorBalanceamento(no.Direita) <= 0)
                return RotacaoEsquerda(no);

            // RL
            if (balanceamento < -1 && ObterFatorBalanceamento(no.Direita) > 0)
            {
                no.Direita = RotacaoDireita(no.Direita);
                return RotacaoEsquerda(no);
            }

            return no;
        }

        // Impressão em pré-ordem
        public void PreOrdem(No no)
        {
            if (no != null)
            {
                Console.Write(no.Valor + " ");
                PreOrdem(no.Esquerda);
                PreOrdem(no.Direita);
            }
        }

        // Impressão dos fatores de balanceamento
        public void ImprimirFatores(No no)
        {
            if (no != null)
            {
                ImprimirFatores(no.Esquerda);
                int fb = ObterFatorBalanceamento(no);
                Console.WriteLine($"Nó {no.Valor}: Fator de balanceamento {fb}");
                ImprimirFatores(no.Direita);
            }
        }

        // Impressão da altura da árvore
        public void ImprimirAltura()
        {
            Console.WriteLine($"Altura da árvore: {ObterAltura(Raiz)}");
        }
    }
}
