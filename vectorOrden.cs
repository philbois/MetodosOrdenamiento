using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosOrdenamiento
{
    internal class vectorOrden
    {
        int[] comparaciones = { 0, 0, 0, 0 ,0};
        int[] intercambios = { 0, 0, 0, 0,0 };
        Random rnd = new Random();
        int[] vector;
        int[] vector1;
        int[] vector2;
        int[] vector3;
        int[] vector4;
        int[] vector5;
        double[] tiempos = new double[5];
        DateTime dt1,dt2,dt3,dt4,dt5,dt6, dt7,dt8,dt9 ,dt10= new DateTime();
      
        TimeSpan[] dt11= new TimeSpan[5];
        public void calculotiempo()
        {
            dt11[0] = dt2 - dt1;
            dt11[1] = dt4 - dt3;
            dt11[2] = dt6 - dt5;
            dt11[3] = dt8 - dt7;
            dt11[4] = dt10 - dt9;
            for (int i = 0; i < 5; i++)
            {
                tiempos[i] = dt11[i].TotalMilliseconds;
            }

        }

        public int[] Vector { get => vector; }
        public int[] Comparaciones { get => comparaciones;  }
        public int[] Intercambios { get => intercambios;}
        public  double[] Tiempos { get => tiempos;  }

        public void crear(int indice)
        {
            vector = new int[indice];
            vector1 = new int[indice];
            vector2 = new int[indice];
            vector3 = new int[indice];
            vector4 = new int[indice];
            vector5 = new int[indice];

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = rnd.Next(255);
            }
            for (int i = 0; i < vector.Length; i++)
            {
                vector1[i] = vector[i];
                vector2[i] = vector[i];
                vector3[i] = vector[i];
                vector4[i] = vector[i];
                vector5[i] = vector[i];


            }

        }
        public int[] elVector() { return vector1; }
        public void burbuja()
        {
            dt1 = DateTime.Now;
            int aux = 0;
            int contador = 0;

            for (int i = 0; i < vector.Length - 1; i++)
            {
                

                    for (int j = i +1; j < vector.Length; j++)
                {
                    comparaciones[0]++;

                    if (vector1[i] > vector1[j])
                    {
                        intercambios[0]++;
                        aux = vector1[i];
                        vector1[i] = vector1[j];
                        vector1[j] = aux;
                    }
                    contador++;

                }
            }
            dt2= DateTime.Now;
        }
        public void burbuja2()
        {
            dt1 = DateTime.Now;
            int aux = 0;
            int contador = 0;
            bool bandera = false;
            for (int i = 0; i < vector.Length - 1; i++)
            {
                if (bandera)
                {
                    break;
                }
                bandera = true;
                for (int j = 0; j < vector.Length-i-1; j++)
                {
                    comparaciones[0]++;

                    if (vector1[j] > vector1[j+1])
                    {
                        intercambios[0]++;
                        bandera= false;
                        aux = vector1[j];
                        vector1[j] = vector1[j+1];
                        vector1[j+1] = aux;
                    }
                    contador++;

                }
            }
            dt2 = DateTime.Now;
        }
        public void Seleccion()
        {dt3= DateTime.Now;

            int minimo = 0;
            int temp;
            for (int i = 0; i < vector2.Length - 1; i++)
            {
                minimo = i;
                for (int j = i + 1; j < vector2.Length; j++)
                {
                    comparaciones[1]++;
                    if (vector2[minimo] > vector2[j])
                    {
                        
                        minimo = j;
                    }
                }
                intercambios[1]++;
                temp = vector2[minimo];
                vector2[minimo] = vector2[i];
                vector2[i] = temp;
            }
            dt4 = DateTime.Now;
        }
        public void MergeSort()
        {
            dt5 = DateTime.Now;
            MergeSort(0, vector3.Length - 1);
            dt6 = DateTime.Now;
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
            Array.Copy(aux, 0, vector3, desde, aux.Length);
        }

        //Método que mezcla las dos mitades ordenadas
        private int[] Merge(int desde1, int hasta1, int desde2, int hasta2)
        {
            int a = desde1;
            int b = desde2;
            int[] result = new int[hasta1 - desde1 + hasta2 - desde2 + 2];

            for (int i = 0; i < result.Length; i++)
            {
                if (b != vector3.Length)
                {
                    comparaciones[2]++;
                    if (a > hasta1 && b <= hasta2)
                    {
                        intercambios[2]++;
                        result[i] = vector3[b];
                        b++;
                    }
                    if (b > hasta2 && a <= hasta1)
                    {
                        intercambios[2]++;
                        result[i] = vector3[a];
                        a++;
                    }
                    if (a <= hasta1 && b <= hasta2)
                    {
                        if (vector3[b] <= vector3[a])
                        {
                            intercambios[2]++;
                            result[i] = vector3[b];
                            b++;
                        }
                        else
                        {
                            intercambios[2]++;
                            result[i] = vector3[a];
                            a++;
                        }
                    }
                }
                else
                {
                    comparaciones[2]++;
                    if (a <= hasta1)
                    {
                        intercambios[2]++;
                        result[i] = vector3[a];
                        a++;
                    }
                }
            }
            return result;

        }
       
        public void quickSortiterativo(int[] vectorIn)
        {
            
            int[] copiaVector = new int[vectorIn.Length];            // stack
            int sti = 0;                        // stack index
            copiaVector[sti++] = vectorIn.Length - 1;
            copiaVector[sti++] = 0;
            while (sti != 0)
            {
                int lo = copiaVector[--sti];
                int hi = copiaVector[--sti];
                while (lo < hi)
                {
                    // Hoare partition
                    int md = lo + (hi - lo) / 2;
                    int ll = lo - 1;
                    int hh = hi + 1;
                    int p = vectorIn[md];
                    int t;
                    while (true)
                    {
                        comparaciones[3]++;
                        while (vectorIn[++ll] < p) ;
                        while (vectorIn[--hh] > p) ;
                        if (ll >= hh)
                            break;
                        intercambios[3]++;
                        t = vectorIn[ll];
                        vectorIn[ll] = vectorIn[hh];
                        vectorIn[hh] = t;
                    }
                    ll = hh++;
                    // ll = last left index, hh = first right index
                    // push larger partition indexes onto stack
                    // loop back for smaller partition
                    if ((ll - lo) > (hi - hh))
                    {
                        copiaVector[sti++] = ll;
                        copiaVector[sti++] = lo;
                        lo = hh;
                    }
                    else
                    {
                        copiaVector[sti++] = hi;
                        copiaVector[sti++] = hh;
                        hi = ll;
                    }
                }
            }
        }
        public void quickiterativo()
        {
            dt7 = DateTime.Now;
            quickSortiterativo(vector4);
            dt8 =DateTime.Now;
        }
        
        public void quick()
        {
            dt9= DateTime.Now;
            quicksort(vector5, 0, vector5.Length - 1);
            dt10 = DateTime.Now;
        }
        private void quicksort(int[] vectorIn, int primero, int ultimo)
        {
            int i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = vectorIn[central];
            i = primero;
            j = ultimo;
            while (i <= j)
            {
                while (vectorIn[i] < pivote) i++;
                {
                    while (vectorIn[j] > pivote) j--;
                    {
                        comparaciones[4]++;
                        if (i <= j)
                        {
                            intercambios[4]++;
                            int temp;
                            temp = vectorIn[i];
                            vectorIn[i] = vectorIn[j];
                            vectorIn[j] = temp;
                            i++;
                            j--;
                        }
                    }
                }
            }

            if (primero < j)
            {
                quicksort(vectorIn, primero, j);
            }
            if (i < ultimo)
            {
                quicksort(vectorIn, i, ultimo);
            }
        }
    }
}
  


