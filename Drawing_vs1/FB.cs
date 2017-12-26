using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_vs1
{
    class FB : Algorithms
    {
        private int[] Truoc;
        private int[] khoangcach;

        public FB() {
            Matrix = Form1.getInstance().ConverMatrix();
            Truoc = new int[Form1.getInstance().MainListVertex.Count];
            khoangcach = new int[Form1.getInstance().MainListVertex.Count];
        }

        public override void Run(int verIDStart, int verIDEnd = 0)
        {
            for (int i = 0; i < Form1.getInstance().MainListVertex.Count; i++)
            {
                if (Matrix[verIDStart, i] > 0)
                    khoangcach[i] = Matrix[verIDStart, i];
                else khoangcach[i] = int.MaxValue;
                if (Matrix[verIDStart, i] > 0)
                    Truoc[i] = verIDStart;
                else Truoc[i] = -1;
            }
            for (int i = 0; i < Form1.getInstance().MainListVertex.Count - 2; i++)
            {
                for (int u = 0; u < Form1.getInstance().MainListVertex.Count; u++)
                {
                    for (int v = 0; v < Form1.getInstance().MainListVertex.Count; v++)
                    {
                        if (verIDStart != u && u != v && verIDStart != v && Matrix[u,v]>0)
                        {
                            
                            if (khoangcach[v] > khoangcach[u] + Matrix[u, v])
                            {
                                khoangcach[v] = khoangcach[u] + Matrix[u, v]; ;
                                Truoc[v] = u;
                            }
                        }
                    }
                }
            }

            //chuyen duong di ngan nhat vao stack
            Stack<int> st = new Stack<int>();
            st.Push(verIDEnd);
            while (true) {
                int v = st.Pop();
                if (v == verIDStart) {
                    st.Push(v);
                    break;
                }
                if (v == -1) {
                    break;
                }
                int vTrc = Truoc[v];
                
                st.Push(v);
                st.Push(vTrc);
            }
            int s = -1;
            int e = -1;
            //duyet do hoa cho duong di ngan nhat
            while (st.Count != 0) {
                e = st.Pop();
                if (Form1.getInstance().MainListVertex[e].Color != Color.Red)
                    Form1.getInstance().MainListVertex[e].Color = Color.Blue;//to mau dinh
                Form1.getInstance().fInvalidate();
                Thread.Sleep(Form1.timeSleep * 20);
                if (s != -1) {
                    int v = GetEdgeFromVertex(s, e);
                    Form1.getInstance().MainListEdge[v].Color = Color.Blue;
                    //ve canh 
                    Form1.getInstance().DrawMoveV(s, e);
                    Thread.Sleep(Form1.timeSleep * 20);
                }
                s = e;
            }
           
            Form1.getInstance().fInvalidate();
            if (khoangcach[verIDEnd] != int.MaxValue)
                MessageBox.Show("Khoang cach tu tu " + verIDStart + "->" + verIDEnd + " = " + khoangcach[verIDEnd].ToString());
            else
                MessageBox.Show("khong co duong di ngan nhat tu " + verIDStart + "->" + verIDEnd);
        }
    }
}
