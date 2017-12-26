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
    class Floyd : Algorithms
    {
        int[,] G;//ma tran lien ket
        int[,] A;//ma tran coppy tu G
        int[,] P;//ma tran phu luu vet
        public Floyd()
            : base()
        {

            G = Form1.getInstance().ConverMatrix();
            A = new int[Form1.getInstance().MainListVertex.Count, Form1.getInstance().MainListVertex.Count];
            P = new int[Form1.getInstance().MainListVertex.Count, Form1.getInstance().MainListVertex.Count];
        }
        public int Max()
        {
            int sum = 0;
            for (int i = 0; i < Form1.getInstance().MainListVertex.Count; i++)
            {
                for (int j = 0; j < Form1.getInstance().MainListVertex.Count; j++)
                {
                    if (G[i, j] > 0)
                        sum += G[i, j];
                }
            }
            return sum;
        }
        public override void Run(int vStart, int vEnd)
        {
            for (int i = 0; i < Form1.getInstance().MainListVertex.Count; i++)
            {
                for (int j = 0; j < Form1.getInstance().MainListVertex.Count; j++)
                {
                    if (G[i, j] > 0)
                    {
                        A[i, j] = G[i, j];
                    }
                    else
                    {
                        A[i, j] = Max();
                    }
                    P[i, j] = -1;
                }
            }

            for (int k = 0; k < Form1.getInstance().MainListVertex.Count; k++)
            {
                for (int i = 0; i < Form1.getInstance().MainListVertex.Count; i++)
                {
                    for (int j = 0; j < Form1.getInstance().MainListVertex.Count; j++)
                    {
                        if (i != j && j != k && k != i && A[i, k] > 0 && A[k, j] > 0 && A[i, j] > A[i, k] + A[k, j])
                        {
                            A[i, j] = A[i, k] + A[k, j];
                            P[i, j] = k;

                        }
                    }
                }
            }
            String temp = "";


            Stack<int> st = new Stack<int>();
            st.Push(vEnd);
            st.Push(vStart);
            while (true)
            {
                int i = st.Pop();
                int j = st.Pop();
                int k = P[i, j];

                st.Push(j);
                if (k == -1)
                {
                    st.Push(i);
                    break;
                }
                st.Push(k);
                st.Push(i);
            }

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
                    if (v != -1)
                    {
                        Form1.getInstance().MainListEdge[v].Color = Color.Blue;
                        //ve canh 
                        Form1.getInstance().DrawMoveV(s, e);
                        Thread.Sleep(Form1.timeSleep * 20);
                    }
                }
                s = e;
            }
            Form1.getInstance().fInvalidate();
            if (A[vStart, vEnd] != Max())
                MessageBox.Show("Khoang cach tu tu " + vStart + "->" + vEnd + " = " + A[vStart, vEnd].ToString());
            else MessageBox.Show("Khong co duong di tu " + vStart + "->" + vEnd);
        }
    }
}
