using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = new List<int> { 0, 0, 1 };
            var j = new List<int> { 1, 2, 2 };
            int vertex_number = 3;
            Graph g = new Graph
                (i, j, vertex_number);
            g.Print();
        }
    }
    
    public class Graph
    {
        
        public struct IJ
        {
            public int i;
            public int j;
            public IJ(int I, int J) 
            {
                i = I;
                j = J;
            }
        }
        List<IJ> Pair = new List<IJ>();
        List<int> H = new List<int>();
        List<int> L = new List<int>();
        public Graph(List<int> i, List<int> j, int vertex_number)
        {
           for (int k=0; k < vertex_number; k++)
            {
                H.Add(-1);
            }
           for (int k=0; k < i.Count; k++)
            {
                Add(i[k], j[k]);
                Add(j[k], i[k]);
            }

        }
        public void Add(int i, int j)
        {
            L.Add(H[i]);
            Pair.Add(new IJ(i,j));
            H[i] = (int)Pair.Count - 1;
        }
        public void Print()
        {
            string writePath = @"C:\Users\nikit\Desktop\graph.txt";
            string header = "Graph G { \n";
            string body = "";
            for (int k = 0; k < Pair.Count; k+=2)
            {
                body+=(Pair[k].i + 1).ToString() + "--" + (Pair[k].j + 1).ToString() + ";\n";
            }
            body += "}";
            File.WriteAllText(writePath, header + body);
        }
    }
    
}
