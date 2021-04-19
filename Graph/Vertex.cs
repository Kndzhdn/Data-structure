using System.Data.Common;

namespace Section5_Task8
{
    
    /// <summary>
    /// Вершина графа
    /// </summary>
    public class Vertex
    {
        public int Id { get; set; }
        private string Data { get; set; }
        public bool IsVisited = false;
       
        
        public Vertex(int id)
        {
            Id = id;
        }

        public Vertex(int id, string data)
        {
            Id = id;
            Data = data;
        }
    }
}