using System;
using Arvore_AVL;

namespace Arvore_AVL
{
    public class Programa
    {
        public static void Main()
        {
            ArvoreAVL arvore = new ArvoreAVL();

            string caminho;

            do
            {
                Console.Write("Digite o caminho (Lembre de retirar as aspas): ");
                caminho = Console.ReadLine();

                if (!File.Exists(caminho))
                {
                    Console.WriteLine("\nArquivo não encontrado! Tente novamente.\n");
                }

            } while (!File.Exists(caminho));

            Console.WriteLine("\nArquivo encontrado com sucesso!\n");


            var linhas = File.ReadAllLines(caminho);

            foreach (var linha in linhas)
            {
                var partes = linha.Trim().Split();

                if (partes.Length == 0)
                    continue;

                string comando = partes[0];

                if (comando == "I")
                {
                    int valor = int.Parse(partes[1]);
                    arvore.Raiz = arvore.Inserir(arvore.Raiz, valor);
                }
                else if (comando == "R")
                {
                    int valor = int.Parse(partes[1]);
                    arvore.Raiz = arvore.Remover(arvore.Raiz, valor);
                }
                else if (comando == "B")
                {
                    int valor = int.Parse(partes[1]);
                    bool encontrado = arvore.Buscar(arvore.Raiz, valor);
                    Console.WriteLine(encontrado ? "Valor encontrado" : "Valor não encontrado");
                }
                else if (comando == "P")
                {
                    Console.Write("Árvore em pré-ordem: ");
                    arvore.PreOrdem(arvore.Raiz);
                    Console.WriteLine();
                }
                else if (comando == "F")
                {
                    Console.WriteLine("Fatores de balanceamento:");
                    arvore.ImprimirFatores(arvore.Raiz);
                }
                else if (comando == "H")
                {
                    arvore.ImprimirAltura();
                }
            }
        }
    }
}
