using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_vs1
{
    abstract class Algorithms
    {
        protected List<int> Visited;// dinh da di qua
        protected int[,] Matrix;//ma tran lien ket
        protected int[] Parent;//ma tran cha con
        private List<Vertex> _listVertex;
        protected List<Vertex> ListVertex
        {
            get
            {
                return _listVertex ?? (_listVertex = Form1.getInstance().MainListVertex);
            }
            private set
            {

            }
        }

        private List<Edge> _listEdge;
        protected List<Edge> ListEdge
        {
            get
            {
                return _listEdge ?? (_listEdge = Form1.getInstance().MainListEdge);
            }
            private set
            {

            }
        }
        public Algorithms()
        {
            Visited = new List<int>();
            Matrix = Form1.getInstance().ConverMatrix();
            Parent = new int[ListVertex.Count];
        }
        
        public List<int> GenerateNextVertex(int v)
        {
            List<int> lVertex = new List<int>(); ;//dinh co the di
            for (int i = 0; i < ListVertex.Count; i++)
            {
                if (Matrix[v, i] > 0)
                {
                    lVertex.Add(i);
                }
            }
            return lVertex;
        }
        public bool IsVertexVisited(int v)
        {
            foreach (int i in Visited)
            {
                if (i == v) return true;
            }
            return false;
        }
        public int GetEdgeFromVertex(int v1, int v2)
        {
            for (int i = 0; i < ListEdge.Count; i++)
            {
                if (ListEdge[i].V1.Name == v1 && ListEdge[i].V2.Name == v2)
                    return i;
            }
            return -1;
        }
        public abstract void Run(int verIDStart,int verIDEnd=0);
        
    }
}
