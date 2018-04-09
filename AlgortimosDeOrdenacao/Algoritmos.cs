using System;
using System.IO;
using System.Diagnostics;

namespace AlgoritmoDeOrdenacao {
    class Algoritmos {
        /* O método lerArquivos utiliza a classe StreamReader para fazer a leitura de um arquivo externo
        * Após receber esse arquivo realiza uma conversão dentro de uma variavel simples do tipo string
        * para em seguida colocar em um vetor de string o conteudo do arquivo
        *
        * Todo o conteudo do vetor de string é passado para um vetor de inteiro dentro de um laço for
        * e retorna esse vetor para quem fez o chamado     
        */
        public static int[] lerArquivo() {
            StreamReader file = new StreamReader(@"C:\Users\Pedro Henrique\Desktop\Faculdade\testeDeLeitura.txt");
            string txt = file.ReadToEnd();
            string[] separadores = { " ", "\n" };
            string[] vetS = txt.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            int[] guardado = new int[vetS.Length];
            for (int i = 0; i < vetS.Length; i++) {
                guardado[i] = int.Parse(vetS[i]);
            }
            file.Close();
            return guardado;
        }

        /*
        * Metodo para salvar arquivo depois de ordenar o Vetor
        * O metodo vai receber um vetor de inteiros já ordenado e salvar cada numero com um espaço em branco entre eles 
        */
        public static void salvarArquivo(int[] vetor) {
            StreamWriter sw = File.CreateText(@"C:\Users\Pedro Henrique\Desktop\Faculdade\gravarNumero.txt");
            for (int i = 0; i < vetor.Length;i++) {
                sw.Write(vetor[i] + " ");
                
            }
            sw.Close();
        }

        public static void insertionSort(int[] vetor) {
            int i, j, chave;
            for (i = 1; i < vetor.Length; i++) {
                chave = vetor[i];
                j = i;
                while ((j > 0) && (vetor[j-1] > chave)) {
                    vetor[j] = vetor[j - 1];
                    j--;
                }
                vetor[j] = chave;
            }
        }

        public static void SelectionSort(int[] vetor) {
            int min, aux;
            for (int i = 0; i < vetor.Length; i++) {
                min = i;
                for (int j = i + 1; j < vetor.Length; j++) {
                    if (vetor[j] < vetor[min]) {
                        min = j;
                    }
                }

                if (min != i) {
                    aux = vetor[min];
                    vetor[min] = vetor[i];
                    vetor[i] = aux;
                }
            }
        }

        public static void mergeSort(int[] vetor, int[] w, int ini, int fim) {
            if (ini < fim) {
                int meio = (ini + fim) / 2;
                mergeSort(vetor, w, ini, meio);
                mergeSort(vetor, w, meio + 1, fim);
                combinar(vetor, w, ini, meio, fim);
            }
        }

        public static void combinar(int[] vetor, int[] w, int ini, int meio, int fim) {
            for (int k = ini; k <= fim; k++) {
                w[k] = vetor[k];
            }

            int i = ini;
            int j = meio + 1;

            for (int k = ini; k <= fim; k++) {
                if (i > meio) vetor[k] = w[j++];
                else if (j > fim) vetor[k] = w[i++];
                else if (w[i] < w[j]) vetor[k] = w[i++];
                else vetor[k] = w[j++];
            }
        }

        public static void stringFormato(TimeSpan ts) {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}