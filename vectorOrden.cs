using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosOrdenamiento
{
    internal class vectorOrden
    {
        Random rnd = new Random();
        int[] vector;

        public int[] Vector { get => vector;  }
        public static void quickSortiterativo(int[] a)
        {
            int[] stk = new int[a.Length];            // stack
            int sti = 0;                        // stack index
            stk[sti++] = a.Length - 1;
            stk[sti++] = 0;
            while (sti != 0)
            {
                int lo = stk[--sti];
                int hi = stk[--sti];
                while (lo < hi)
                {
                    // Hoare partition
                    int md = lo + (hi - lo) / 2;
                    int ll = lo - 1;
                    int hh = hi + 1;
                    int p = a[md];
                    int t;
                    while (true)
                    {
                        while (a[++ll] < p) ;
                        while (a[--hh] > p) ;
                        if (ll >= hh)
                            break;
                        t = a[ll];
                        a[ll] = a[hh];
                        a[hh] = t;
                    }
                    ll = hh++;
                    // ll = last left index, hh = first right index
                    // push larger partition indexes onto stack
                    // loop back for smaller partition
                    if ((ll - lo) > (hi - hh))
                    {
                        stk[sti++] = ll;
                        stk[sti++] = lo;
                        lo = hh;
                    }
                    else
                    {
                        stk[sti++] = hi;
                        stk[sti++] = hh;
                        hi = ll;
                    }
                }
            }
        }
        public void quickiterativo()
        {
            quickSortiterativo(vector);
        }
        public void crear(int indice)
        {
            vector = new int[indice];

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = rnd.Next(500000);
            }

        }
        public int[] elVector() { return vector; }
        public void burbuja()
        {
            int aux = 0;
            int contador = 0;

            for (int i = 0; i < vector.Length - 1; i++)
            {
                

                    for (int j = i +1; j < vector.Length; j++)
                {

                    if (vector[i] > vector[j])
                    {
                        aux = vector[i];
                        vector[i] = vector[j];
                        vector[j] = aux;
                    }
                    contador++;

                }
            }
        }
        public void Seleccion()
        {

            int minimo = 0;
            int temp;
            for (int i = 0; i < vector.Length - 1; i++)
            {
                minimo = i;
                for (int j = i + 1; j < vector.Length; j++)
                {
                    if (vector[minimo] > vector[j])
                    {
                        minimo = j;
                    }
                }
                temp = vector[minimo];
                vector[minimo] = vector[i];
                vector[i] = temp;
            }
        }
        public void MergeSort()
        {
            MergeSort(0, vector.Length - 1);
        }
     


        private void MergeSort(int desde, int hasta)
        {
            //Condicion de parada
            if (desde == hasta)
                return;
            //Calculo la mitad del vector
            int mitad = (desde + hasta) / 2;
            //Voy a ordenar recursivamente la primera mitad
            //y luego la segunda
            MergeSort(desde, mitad);
            MergeSort(mitad + 1, hasta);
            //Mezclo las dos mitades ordenadas
            int[] aux = Merge(desde, mitad, mitad + 1, hasta);
            Array.Copy(aux, 0, vector, desde, aux.Length);
        }

        //Método que mezcla las dos mitades ordenadas
        private int[] Merge(int desde1, int hasta1, int desde2, int hasta2)
        {
            int a = desde1;
            int b = desde2;
            int[] result = new int[hasta1 - desde1 + hasta2 - desde2 + 2];

            for (int i = 0; i < result.Length; i++)
            {
                if (b != vector.Length)
                {
                    if (a > hasta1 && b <= hasta2)
                    {
                        result[i] = vector[b];
                        b++;
                    }
                    if (b > hasta2 && a <= hasta1)
                    {
                        result[i] = vector[a];
                        a++;
                    }
                    if (a <= hasta1 && b <= hasta2)
                    {
                        if (vector[b] <= vector[a])
                        {
                            result[i] = vector[b];
                            b++;
                        }
                        else
                        {
                            result[i] = vector[a];
                            a++;
                        }
                    }
                }
                else
                {
                    if (a <= hasta1)
                    {
                        result[i] = vector[a];
                        a++;
                    }
                }
            }
            return result;

        }
        public void quick()
        {
            quicksort(vector, 0, vector.Length - 1);
        }
        private void quicksort(int[] vector, int primero, int ultimo)
        {
            int i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = vector[central];
            i = primero;
            j = ultimo;
            while (i <= j)
            {
                while (vector[i] < pivote) i++;
                {
                    while (vector[j] > pivote) j--;
                    {
                        if (i <= j)
                        {
                            int temp;
                            temp = vector[i];
                            vector[i] = vector[j];
                            vector[j] = temp;
                            i++;
                            j--;
                        }
                    }
                }
            }

            if (primero < j)
            {
                quicksort(vector, primero, j);
            }
            if (i < ultimo)
            {
                quicksort(vector, i, ultimo);
            }
        }
    }
}
  

    class Main
    {
        public static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static int partition(int [] a, int start, int end)
        {
            // Elija el elemento más a la derecha como un pivote de la array
            int pivot = a[end];

            // los elementos menores que el pivote irán a la izquierda de `pIndex`
            // elementos más que el pivote irán a la derecha de `pIndex`
            // elementos iguales pueden ir en cualquier dirección
            int pIndex = start;

            // cada vez que encontramos un elemento menor o igual que el pivote,
            // `pIndex` se incrementa, y ese elemento se colocaría
            // antes del pivote.
            for (int i = start; i < end; i++)
            {
                if (a[i] <= pivot)
                {
                    swap(a, i, pIndex);
                    pIndex++;
                }
            }

            // intercambiar `pIndex` con pivote
            swap(a, pIndex, end);

            // devuelve `pIndex` (índice del elemento pivote)
            return pIndex;
        }

        // Rutina iterativa Quicksort



        // Implementación iterativa de Quicksort

    }

