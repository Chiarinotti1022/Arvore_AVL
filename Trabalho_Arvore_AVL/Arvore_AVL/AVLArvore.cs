using System;

namespace Arvore_AVL
{
    public class ArvoreAVL
    {
        public No Raiz;

        // Retorna a altura de um nó (0 se for nulo)
        int ObterAltura(No no)
        {
            return no == null ? 0 : no.Altura;
        }

        // Calcula o fator de balanceamento de um nó
        int ObterFatorBalanceamento(No no)
        {
            return no == null ? 0 : ObterAltura(no.Esquerda) - ObterAltura(no.Direita);
        }

        // Realiza rotação simples à direita (caso esquerda-esquerda)
        No RotacaoDireita(No y)
        {
            No x = y.Esquerda;
            No T2 = x.Direita;

            x.Direita = y;
            y.Esquerda = T2;

            // Atualiza alturas após a rotação
            y.Altura = Math.Max(ObterAltura(y.Esquerda), ObterAltura(y.Direita)) + 1;
            x.Altura = Math.Max(ObterAltura(x.Esquerda), ObterAltura(x.Direita)) + 1;

            return x; // Nova raiz da subárvore
        }

        // Realiza rotação simples à esquerda (caso direita-direita)
        No RotacaoEsquerda(No x)
        {
            No y = x.Direita;
            No T2 = y.Esquerda;

            y.Esquerda = x;
            x.Direita = T2;

            // Atualiza alturas após a rotação
            x.Altura = Math.Max(ObterAltura(x.Esquerda), ObterAltura(x.Direita)) + 1;
            y.Altura = Math.Max(ObterAltura(y.Esquerda), ObterAltura(y.Direita)) + 1;

            return y; // Nova raiz da subárvore
        }

        // Insere um valor na árvore e realiza balanceamento se necessário
        public No Inserir(No no, int valor)
        {
            if (no == null)
                return new No(valor); // Cria novo nó se posição estiver vazia

            if (valor < no.Valor)
                no.Esquerda = Inserir(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Inserir(no.Direita, valor);
            else
                return no; // Valor duplicado não é inserido

            // Atualiza altura do nó atual
            no.Altura = 1 + Math.Max(ObterAltura(no.Esquerda), ObterAltura(no.Direita));

            // Calcula o fator de balanceamento
            int balanceamento = ObterFatorBalanceamento(no);

            // Caso Esquerda-Esquerda
            if (balanceamento > 1 && valor < no.Esquerda.Valor)
                return RotacaoDireita(no);

            // Caso Direita-Direita
            if (balanceamento < -1 && valor > no.Direita.Valor)
                return RotacaoEsquerda(no);

            // Caso Esquerda-Direita
            if (balanceamento > 1 && valor > no.Esquerda.Valor)
            {
                no.Esquerda = RotacaoEsquerda(no.Esquerda);
                return RotacaoDireita(no);
            }

            // Caso Direita-Esquerda
            if (balanceamento < -1 && valor < no.Direita.Valor)
            {
                no.Direita = RotacaoDireita(no.Direita);
                return RotacaoEsquerda(no);
            }

            return no; // Retorna nó atualizado
        }

        // Busca por um valor na árvore (retorna true se encontrar)
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

        // Retorna o nó com o menor valor (mais à esquerda)
        No MenorValorNo(No no)
        {
            No atual = no;
            while (atual.Esquerda != null)
                atual = atual.Esquerda;
            return atual;
        }

        // Remove um valor da árvore e reequilibra, se necessário
        public No Remover(No no, int valor)
        {
            if (no == null)
                return no;

            // Busca o nó a ser removido
            if (valor < no.Valor)
                no.Esquerda = Remover(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Remover(no.Direita, valor);
            else
            {
                // Nó com apenas um filho ou nenhum
                if ((no.Esquerda == null) || (no.Direita == null))
                {
                    No temp = no.Esquerda ?? no.Direita;

                    if (temp == null)
                    {
                        no = null;
                    }
                    else
                    {
                        no = temp; // Substitui o nó pelo filho existente
                    }
                }
                else
                {
                    // Nó com dois filhos: obtém o sucessor
                    No temp = MenorValorNo(no.Direita);
                    no.Valor = temp.Valor;
                    no.Direita = Remover(no.Direita, temp.Valor);
                }
            }

            if (no == null)
                return no;

            // Atualiza altura do nó
            no.Altura = Math.Max(ObterAltura(no.Esquerda), ObterAltura(no.Direita)) + 1;

            // Calcula fator de balanceamento
            int balanceamento = ObterFatorBalanceamento(no);

            // Caso Esquerda-Esquerda
            if (balanceamento > 1 && ObterFatorBalanceamento(no.Esquerda) >= 0)
                return RotacaoDireita(no);

            // Caso Esquerda-Direita
            if (balanceamento > 1 && ObterFatorBalanceamento(no.Esquerda) < 0)
            {
                no.Esquerda = RotacaoEsquerda(no.Esquerda);
                return RotacaoDireita(no);
            }

            // Caso Direita-Direita
            if (balanceamento < -1 && ObterFatorBalanceamento(no.Direita) <= 0)
                return RotacaoEsquerda(no);

            // Caso Direita-Esquerda
            if (balanceamento < -1 && ObterFatorBalanceamento(no.Direita) > 0)
            {
                no.Direita = RotacaoDireita(no.Direita);
                return RotacaoEsquerda(no);
            }

            return no; // Retorna nó reequilibrado
        }

        // Percorre a árvore em pré-ordem e imprime os valores dos nós
        public void PreOrdem(No no)
        {
            if (no != null)
            {
                Console.Write(no.Valor + " ");
                PreOrdem(no.Esquerda);
                PreOrdem(no.Direita);
            }
        }

        // Imprime o fator de balanceamento de cada nó (em ordem simétrica)
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

        // Exibe a altura total da árvore a partir da raiz
        public void ImprimirAltura()
        {
            Console.WriteLine($"Altura da árvore: {ObterAltura(Raiz)}");
        }
    }
}
