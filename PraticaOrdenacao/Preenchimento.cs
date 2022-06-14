using System;

namespace Pratica5 {
    class Preenchimento {
        public static void Aleatorio(int[] vet, int limite) {
            Random r = new Random();
            for (int i = 0; i < vet.Length; i++) {
                vet[i] = r.Next(0, limite);
            }
        }
        public static void Crescente(int[] vet, int limite) {
            Random r = new Random();
            for (int i = 0; i < vet.Length; i++)
            {
                vet[i] = r.Next(0, limite);
            }
            quickSort(vet, 0, vet.Length - 1);
        }
        public static void Decrescente(int[] vet, int limite) {
            Random r = new Random();
            for (int i = 0; i < vet.Length; i++)
            {
                vet[i] = r.Next(0, limite);
            }
            quickSortReverse(vet, 0, vet.Length - 1);
        }
        public static void quickSortReverse(int[] vet, int esq, int dir)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x < vet[i]) i++;
                while (x > vet[j]) j--;
                if (i <= j)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (esq < j) quickSortReverse(vet, esq, j);
            if (i < dir) quickSortReverse(vet, i, dir);
        }
        public static void quickSort(int[] vet, int esq, int dir)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i]) i++;
                while (x < vet[j]) j--;
                if (i <= j)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (esq < j) quickSort(vet, esq, j);
            if (i < dir) quickSort(vet, i, dir);
        }
    }
}
