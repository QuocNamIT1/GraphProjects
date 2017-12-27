using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Drawing_vs1
{
    class BFS : Algorithms
    {
        public BFS() :base()
        {
           
        }
        
        public override void Run(int verIDStart, int verIDEnd = 0)
        {
            int V, listTop = 0, listEnd = 0;
            List<int> listV = new List<int>();
            listV.Add(verIDStart);
            while (listTop <= listEnd) {
                V = listV[listTop];
                listTop++;

                int e = GetEdgeFromVertex(Parent[V], V);
                if (!IsVertexVisited(V))
                {
                    if (Parent[V] != -1 && e != -1)
                    {
                        // ve canh noi 2 dinh
                        Form1.getInstance().MainListEdge[e].Color = Color.Blue;
                        Form1.getInstance().DrawMoveV(Parent[V], V);
                    }
                    Form1.getInstance().MainListVertex[V].Color = Color.Blue;
                    listV = GhepList(V,listV, PhatSinhDinh(V));
                    listEnd = listV.Count - 1;
                    Form1.getInstance().fInvalidate();
                }
            }
        }
        public List<int> GhepList(int V,List<int> l1, List<int> l2) {
            for (int i = 0; i < l2.Count ; i++)
            {
                if (!CheckExists(l1, l2[i]))
                {
                    l1.Add(l2[i]);
                    Parent[l2[i]] = V;
                }
            }
            return l1;
        }
        bool CheckExists(List<int> L, int v) {
            for (int i = 0; i < L.Count; i++)
            {
                if (v == L[i]) return true;
            }
            return false;
        }
        
    }
}
