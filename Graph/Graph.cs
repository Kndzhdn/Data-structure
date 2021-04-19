using System;
using System.Collections.Generic;


namespace Section5_Task8
{
    /// <summary>
    /// Граф
    /// </summary>
    public class Graph
    {
        private List<Vertex> _verticesList = new List<Vertex>();
        private List<Edge> _edgesList = new List<Edge>();

        public int VertexCount => _verticesList.Count;
        public int EdgeCount => _edgesList.Count;

        
        
        /// <summary>
        /// Добавление вершины
        /// </summary>
        public void AddVertex(Vertex vertex)
        {
            _verticesList.Add(vertex);
        }

        
        /// <summary>
        /// Добавление ребра
        /// </summary>
        public void AddEdge(Vertex from, Vertex to, int weight = 1)
        {
            var edge = new Edge(from, to, weight);
            _edgesList.Add(edge);
        }
        
        
        
        
        /// <summary>
        /// Матрица смежности
        /// </summary>
        public int[,] GetMatrix()
        {
            var matrix = new int[_verticesList.Count, _verticesList.Count];

            foreach (var edge in _edgesList)
            {
                var row = edge.From.Id - 1;
                var column = edge.To.Id - 1;

                matrix[row, column] = edge.Weight;
            }
            
            return matrix;
        }

        /// <summary>
        /// Вывод на экран матрицы смежности 
        /// </summary>
        public void DisplayMatrix()
        {
            Console.WriteLine("\n\n\nМатрица смежности:\n");
            var matrix = this.GetMatrix();

            var id = new string[VertexCount+1];
            for (var i = 0; i < VertexCount + 1; i++)
            {
                if (i == 0)
                {
                    id[i] = "id";
                }
                else
                {
                    id[i] = _verticesList[i-1].Id.ToString();
                }
                
            }
            
            PrintLine(77);
            PrintRow(77, id);
            PrintLine(77);

            for (var i = 0; i < VertexCount; i++)
            {
                var data = new string[VertexCount+1];
                for (var j = 0; j < VertexCount + 1; j++)
                {
                    if (j == 0)
                    {
                        data[j] = _verticesList[i].Id.ToString();
                    }
                    else
                    {
                        data[j] = matrix[i, j-1].ToString();
                    }
                }

                PrintRow(77, data);
            }
        }


        
        
        
        
        /// <summary>
        /// Список смежных вершин
        /// </summary>
        public Dictionary<Vertex, List<Vertex>> GetAdjacentVerticesList()
        {
            
            var resultDict = new Dictionary<Vertex, List<Vertex>>();

            foreach (var vertex in _verticesList)
            {
                var resultList = new List<Vertex>();
                
                foreach (var edge in _edgesList)
                {
                    if (edge.From == vertex)
                    {
                        resultList.Add(edge.To);
                    }
                }
                
                resultDict.Add(vertex, resultList);
            }

            return resultDict;
        }
        
        /// <summary>
        /// Вывод на экран списка смежных вершин
        /// </summary> 
        public void DisplayAdjacentVerticesList()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\n\n\nСписок смежных вершин:\n");

            foreach (KeyValuePair<Vertex, List<Vertex>> kvp in GetAdjacentVerticesList())
            {
                if (kvp.Value.Count == 0)
                {
                    Console.Write($"Вершина {kvp.Key.Id}: смежных вершин нет.");
                }
                else
                {
                    Console.Write($"Вершина {kvp.Key.Id}: ");
                    foreach (var adjacentVertex in kvp.Value)
                    {
                        Console.Write($" {adjacentVertex.Id}");
                    }
                }
                

                Console.WriteLine();
            }
        }



        
        
         
        /// <summary>
        /// Обход в ширину
        /// </summary> 
        public bool BreadthFirstSearch(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>{ start };
            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var adjacentVertex in GetAdjacentVerticesList()[vertex])
                {
                    if (!list.Contains(adjacentVertex))
                    {
                        list.Add(adjacentVertex);
                    }
                }
            }

            return list.Contains(finish);
        }

        /// <summary>
        /// Обход в глубину
        /// </summary>
        public bool DepthFirstSearch(Vertex start, Vertex finish)
        {
            if (start == finish)
            {
                return true;
            }

            if (start.IsVisited)
            {
                return false;
            }

            start.IsVisited = true;

            foreach (var adjacentVertex in GetAdjacentVerticesList()[start])
            {
                if (!adjacentVertex.IsVisited)
                {
                    var reached = DepthFirstSearch(adjacentVertex, finish);
                    if (reached)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        
        
        
        
        
        
        
        
        
        ///<summary>
        /// Методы для вывода данных в консоль в табличном виде
        /// </summary>
        public static void PrintLine(int tablewidth)
        {
            Console.WriteLine(new string('-', tablewidth));
        }
 
        public static void PrintRow(int tablewidth, params string[] columns)
        {
            var width = (tablewidth - columns.Length) / columns.Length;
            string row = "|";
 
            foreach (var column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
 
            Console.WriteLine(row);
        }
 
        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
 
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}