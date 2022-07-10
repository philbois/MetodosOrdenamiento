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
        public void crear(int indice)
        {
            vector = new int[indice];

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = rnd.Next(50000);
            }

        }
        public int[] elVector() { return vector; }
        public void burbuja()
        {
            int mayor = 0;
            bool bandera = false;
            int contador = 0;

            for (int i = 0; i < vector.Length - 1; i++)
            {
                if (bandera)
                {
                    break;
                }
                bandera = true;
                for (int j = 0; j < vector.Length - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        mayor = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = mayor;
                        bandera = false;

                    }
                    contador++;

                }
            }
        }
        public void insertion()
        {

            for (int i = 0; i < vector.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (vector[j - 1] > vector[j])
                    {
                        int temp = vector[j - 1];
                        vector[j - 1] = vector[j];
                        vector[j] = temp;
                    }
                }
            }
        }
        public  void MergeSort()
        {
            MergeSort( 0, vector.Length - 1);
        }

         private void MergeSort( int desde, int hasta)
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
    }
}
