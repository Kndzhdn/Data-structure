using System;
///<summary>
///ЗАДАНИЕ
///Реализуйте взвешенный односвязный граф вещественных чисел с
///использованием матрицы смежности. Определите метод для обхода графа в
///глубину.
///</summary>
namespace Section5_Task8
{
    public class Nadezhdin_5_8
    {
        static void Main(string[] args)
        {
            ///<summary>
            ///Создаём граф
            ///</summary> 
            var graph = new Graph();
            
            ///<summary>
            ///Создаём массив вершин
            /// </summary>
            var vertices = new Vertex[7];
            for (int i = 0; i < 7; i++)
            {
                vertices[i] = new Vertex(i+1);
            }
            
            ///<summary>
            ///Добавляем вершины в граф
            ///</summary>
            foreach (Vertex vertex in vertices)
            {
                graph.AddVertex(vertex);
            }
            
            ///<summary>
            ///Добавляем рёбра в граф
            ///</summary>
            graph.AddEdge(vertices[0], vertices[1], 15);
            graph.AddEdge(vertices[0], vertices[2], 25);
            graph.AddEdge(vertices[2], vertices[3], 56);
            graph.AddEdge(vertices[1], vertices[4], 67);
            graph.AddEdge(vertices[1], vertices[5], 123);
            graph.AddEdge(vertices[5], vertices[4], 45);
            graph.AddEdge(vertices[4], vertices[5], 11);
            
            ///<summary>
            ///Выводим матрицу смежности на экран
            /// </summary>
            graph.DisplayMatrix();

            

            ///<summary>
            /// Выводим список смежных вершин
            /// </summary>
            graph.DisplayAdjacentVerticesList();
            
            
            ///<summary>
            /// Проверка обхода в ширину
            ///</summary>
            Console.WriteLine("\n\n\nСложность Breadth-First Search - O(N), где N - количество вершин.");
            Console.WriteLine(graph.BreadthFirstSearch(vertices[0], vertices[4]));
            Console.WriteLine(graph.BreadthFirstSearch(vertices[1], vertices[3]));
            
            
            ///<summary>
            /// Проверка обхода в глубину
            ///</summary>
            Console.WriteLine("\n\n\nСложность Depth-First Search - O(N), где N - количество вершин.");
            Console.WriteLine(graph.DepthFirstSearch(vertices[0], vertices[4]));
            Console.WriteLine(graph.DepthFirstSearch(vertices[1], vertices[3]));
        }
    }
}