using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Drawing_vs1
{
    class Kruskal:Algorithms
    {
        private int[,] MST;
        public override void Run(int verIDStart, int verIDEnd = 0)
        {
            MST=new int[ListVertex.Count,ListVertex.Count];
            InitParent();
            Sort();
            for(int i =0;i<ListEdge.Count;i++)
            {
                int v1 = FindSet(ListEdge[i].V1.Name);
                int v2 = FindSet(ListEdge[i].V2.Name);
                if(v1!=v2)
                {
                    int x = ListEdge[i].V1.Name;
                    int y = ListEdge[i].V2.Name;
                    ListVertex[x].Color = Color.Blue;
                    ListVertex[y].Color = Color.Blue;
                    ListEdge[i].Color = Color.Blue;
                    Form1.getInstance().fInvalidate();
                    Thread.Sleep(Form1.timeSleep * 20);
                    MST[x, y] = ListEdge[i].G;
                    Union(v1, v2);
                }
            }
        }

        private void Union(int u,int v)
        {
            if(Parent[u]>Parent[v])
            {
                Parent[v] += Parent[u];
                Parent[u] = v;
            }
            else
            {
                Parent[u] += Parent[v];
                Parent[v] = u;
            }
        }

        private int FindSet(int v)
        {
            while(Parent[v]>0)
            {
                v = Parent[v];
            }
            return v;
        }

        private void Sort()
        {
            for (int i = 0; i < ListEdge.Count; i++)
            {
                for (int j = ListEdge.Count - 1; j >= 1; j--)
                {
                    if (ListEdge[j - 1].G > ListEdge[j].G)
                    {
                        Edge temp = ListEdge[j - 1];
                        ListEdge[j - 1] = ListEdge[j];
                        ListEdge[j] = temp;
                    }
                }
            }
        }
    }
}
