using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Drawing_vs1
{
    class Dijkstra:Algorithms
    {
        int[] Len;
        int countVertex; 
        public Dijkstra():base()
        {
            countVertex = Form1.getInstance().MainListVertex.Count;
        }
        void KhoiTao(int verIDStart)
        {
            Len = new int[countVertex];
            for (int i = 0; i < countVertex; i++)
            {
                Len[i] = Int16.MaxValue;
                Parent[i] = verIDStart;
            }

            Len[verIDStart] = 0;
        }
        public override void Run(int verIDStart, int verIDEnd = 0)
        {
            KhoiTao(verIDStart);
            int i = 0;
            bool kt = true;
            while (!IsVertexVisited(verIDEnd))
            {
                for (i = 0; i < countVertex; i++)
                {
                    if (!IsVertexVisited(i) && Len[i] < Int16.MaxValue)
                        break;
                }
                if (i == countVertex)
                {
                    kt = false;
                    break;
                }
                for (int j = 0; j < countVertex; j++)
                {
                    if (!IsVertexVisited(j) && Len[i] > Len[j])
                        i = j;
                }
                int temp;
                Visited.Add(i);
                for (int j = 0; j < countVertex; j++)
                {
                    
                    if (!IsVertexVisited(j) && Len[i] + (temp = Matrix[i, j] != -1 ? Matrix[i, j] : Int16.MaxValue) < Len[j])
                    {
                        Len[j] = Len[i] + Matrix[i, j];
                        Parent[j] = i;
                    }
                }
            }
            if (kt)
            {
                Stack<int> st = new Stack<int>();
                int k = verIDEnd;
                while (k != verIDStart)
                {
                    st.Push(k);
                    k = Parent[k];
                }
                st.Push(verIDStart);
                int s = -1;
                int e = -1;
                while (st.Count != 0)
                {
                    e = st.Pop();
                    if (Form1.getInstance().MainListVertex[e].Color != Color.Red)
                        Form1.getInstance().MainListVertex[e].Color = Color.Blue;//to mau dinh
                    Form1.getInstance().fInvalidate();
                    Thread.Sleep(Form1.timeSleep * 20);
                    if (s != -1)
                    {
                        //to canh
                        int v = GetEdgeFromVertex(s, e);
                        Form1.getInstance().MainListEdge[v].Color = Color.Blue;
                        //ve canh 
                        Form1.getInstance().DrawMoveV(s, e);
                        Thread.Sleep(Form1.timeSleep * 20);
                    }
                    s = e;
                }
                Form1.getInstance().fInvalidate();
                MessageBox.Show("Khoang cach tu tu " + verIDStart + "->" + verIDEnd + " = " + Len[verIDEnd].ToString());
            }
            else
            {
                MessageBox.Show("Khong co duong di tu " + verIDStart + "->" + verIDEnd);
            }
        }
    }
}
