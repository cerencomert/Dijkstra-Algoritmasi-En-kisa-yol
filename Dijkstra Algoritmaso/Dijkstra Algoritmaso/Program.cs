using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Algoritmaso
{
    class GFG
    {
        static int V = 9;         //yollar
        int minDistance(int[] uzaklik,
                        bool[] sptSet)
        {
            // min değer tanımı
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && uzaklik[v] <= min)
                {
                    min = uzaklik[v];
                    min_index = v;
                }

            return min_index;
        }
            //Yollar ve Noktaların uzaklığının yazımı
        void yazdir(int[] uzaklik, int n)
        {
            Console.Write("Nokta      "
                          + "Kaynaktan Uzaklığı\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + uzaklik[i] + "\n");
        }

        void dijkstra(int[,] graph, int kaynak)
        {
            int[] uzaklik = new int[V];       //sptset burada yeni bulunan yolun daha kısamı uzunmu olduğunun değerini tutuyor.
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                uzaklik[i] = int.MaxValue;
                sptSet[i] = false;
            }
            uzaklik[kaynak] = 0;  //Kaynağın kendine olan uzaklığı herzaman 0

            for (int count = 0; count < V - 1; count++)
              { 
                int u = minDistance(uzaklik, sptSet);
                sptSet[u] = true;
                for (int v = 0; v < V; v++)
                    if (!sptSet[v] && graph[u, v] != 0 &&
                         uzaklik[u] != int.MaxValue && uzaklik[u] + graph[u, v] < uzaklik[v])

                        uzaklik[v] = uzaklik[u] + graph[u, v];
            }

            yazdir(uzaklik, V);
        } 
        public static void Main()
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            GFG nesne = new GFG();
            nesne.dijkstra(graph, 0);
            Console.ReadLine();
        }
    }
}
