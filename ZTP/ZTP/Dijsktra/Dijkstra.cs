using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZTP.Dijsktra
{
    public class Dijkstra : IDijkstra
    {

        private readonly int NO_PARENT = -1;
        public DijkstraResult[] AlghoritmResult { get; set; }

        // funkcja implementująca algorytm dijkstry kozystającego z macierzy odległości
        void IDijkstra.Run(int[,] adjacencyMatrix, int startVertex)
        {
            int nVertices = adjacencyMatrix.GetLength(0);

            AlghoritmResult = new DijkstraResult[nVertices];

            for (int i = 0; i < nVertices; i++)
            {
                AlghoritmResult[i] = new DijkstraResult();
            }
            // najkrótsza ścieżka ze źródla do wierzchołka i znajduje się w shortestDistances[i]
            int[] shortestDistances = new int[nVertices];

            // added[i] będzie prawdziwe jeżeli krawędź i będzie zawarta w drzewie najkrótszej drogi
            // lub najkrótsza odległość ze źródła do i będzie obliczona.
            bool[] added = new bool[nVertices];

            for (int vertexIndex = 0; vertexIndex < nVertices;
                                                vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            //Odległość wierzchołka od samego siebie zawsze wynosi 0
            shortestDistances[startVertex] = 0;

            // tablica rodziców w dzrewie najkrótsze ścieżki
            int[] parents = new int[nVertices];

            //startowa krawędź nie posiada rodzica
            parents[startVertex] = NO_PARENT;

            // znalezienie najkrótszej ścieżki dla wszystkich rodziców
            for (int i = 1; i < nVertices; i++)
            {

                // nearestVertex, jest równa -1 w pierwsze iteracji 
                // Wybierana zostaje nakrótsza wartośc wagi krawędzi ze zbioru dostępnych krawędzi
                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    if (!added[vertexIndex] &&
                        shortestDistances[vertexIndex] <
                        shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }

                //Zaznacz najbliższą krawędź jako obecnie przetwarzaną
                added[nearestVertex] = true;

                //Aktualizacja obecnej najkrótszej odległości
                for (int vertexIndex = 0;
                        vertexIndex < nVertices;
                        vertexIndex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                    if (edgeDistance > 0
                        && shortestDistance + edgeDistance <
                            shortestDistances[vertexIndex])
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance +
                                                        edgeDistance;
                    }
                }
            }

            WriteSolution(startVertex, shortestDistances, parents);
        }
        //Funkcja zapisująca wynik
        private void WriteSolution(int startVertex,
            int[] distances,
            int[] parents)
        {
            int nVertices = distances.Length;

            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                AlghoritmResult[vertexIndex].SourceNodeId = startVertex;
                AlghoritmResult[vertexIndex].TargetNodeId = vertexIndex;
                AlghoritmResult[vertexIndex].Value = distances[vertexIndex];
                WritePath(AlghoritmResult[vertexIndex].Path, vertexIndex, parents);
            }
        }

        //Funkcja zapisująca odwiedzone Miasta
        private void WritePath(List<int> Path, int currentVertex, int[] parents)
        {

            // Base case : Odwiedzono wierzchołek źródła
            if (currentVertex == NO_PARENT)
            {
                return;
            }
            WritePath(Path, parents[currentVertex], parents);
            Path.Add(currentVertex);

        }
    }
}
