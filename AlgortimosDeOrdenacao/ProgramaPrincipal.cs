using System;
using System.IO;
using System.Diagnostics;

namespace AlgoritmoDeOrdenacao {
            /*
            * Atividade de Analise de Algoritmos
            * Nome: Pedro Henrique - Felipe Pontes
            * Insertion-Sort || Merge-Sort || Selection-Sort
            */
    class ProgramaPrincipal {

        static void Main(string[] args) {
            int opcao = 0;

            while (opcao != 4) {
                Console.WriteLine("1- Insertion-Sort");
                Console.WriteLine("2- Merge-Sort");
                Console.WriteLine("3- Selection Sort");
                Console.WriteLine("4- Sair");
                opcao = int.Parse(Console.ReadLine());

                //Classe Stopwatch para fazer a contagem do tempo de execução de cada método de ordenação
                Stopwatch tempo = new Stopwatch();
                //Estrutura Timespan para conversão de tempo vindo da variavel "tempo" de Stopwatch
                TimeSpan sp = new TimeSpan();
                //Chamada da leitura de arquivo na classe "Algoritmos"
                int[] vetorArquivo = Algoritmos.lerArquivo();
                switch (opcao) {
                    // Menu simples de opções entre as 3 opções de ordenação
                    case 1:
                        int[] teste = new int[vetorArquivo.Length];
                        tempo.Start();

                        Algoritmos.insertionSort(vetorArquivo);
  
                        tempo.Stop();
                        sp = tempo.Elapsed;
                        Algoritmos.stringFormato(sp);
                        Algoritmos.salvarArquivo(vetorArquivo);
                        break;
                    case 2:
                        tempo.Start();
                        int[] w = new int[vetorArquivo.Length];
                        Console.Write("\n");

                        Algoritmos.mergeSort(vetorArquivo, w, 0, vetorArquivo.Length - 1);

                        tempo.Stop();
                        sp = tempo.Elapsed;
                        Algoritmos.stringFormato(sp);
                        Algoritmos.salvarArquivo(vetorArquivo);
                        break;
                    case 3:
                        tempo.Start();

                        Algoritmos.SelectionSort(vetorArquivo);

                        Console.Write("Saida: ");

                        tempo.Stop();
                        sp = tempo.Elapsed;
                        Algoritmos.stringFormato(sp);
                        Algoritmos.salvarArquivo(vetorArquivo);
                        break;
                    case 4:
                        Console.WriteLine("Finalizando. Aperte ENTER para encerrar o programa!");
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            } 
        }
    }
}
