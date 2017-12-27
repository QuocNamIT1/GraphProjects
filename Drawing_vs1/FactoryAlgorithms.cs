using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_vs1
{
    enum AObject { DFS,BFS,Floyd,Dijkstra, FB,Kruskal}
    class FactoryAlgorithms
    {
        public static Algorithms getAlgorithms(AObject obj)
        {
            Algorithms alg=null;
            switch (obj)
            {
                case AObject.BFS:
                    {
                        alg = new BFS();
                        break;
                    }
                case AObject.DFS:
                    {
                        alg = new DFS();
                        break;
                    }
                case AObject.Floyd:
                    {
                        alg = new Floyd();
                        break;
                    }
                case AObject.Dijkstra:
                    {
                        alg = new Dijkstra();
                        break;
                    }
                case AObject.FB: 
                    {
                        alg = new FB();
                        break;
                    }
                case AObject.Kruskal: 
                    {
                        alg = new Kruskal();
                        break;
                    }
                
            }
            return alg;
        }
    }
}
