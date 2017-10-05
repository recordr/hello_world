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
            
            g.Delete(0, 1);
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
        public void Delete(int I, int J)
        {
            int index = H[I];
            int pred = -1;
            bool deleted = false;
            while (true)
            {
                if (Pair[index].i == I && Pair[index].j == J)
                {
                    if (pred == -1)
                    {
                        H[I] = L[index];
                    }
                    else
                    {
                       L[pred] = L[index];
                    }
                    deleted = true;
                }
                if (L[index] == -1)
                    break;
                pred = index;
                index = L[index];
            }
            
            if (!deleted)
                throw new Exception("i j edge doesnt exist");
            deleted = false;
            index = H[J];
            pred = -1;
            while(true)
            {
                if (Pair[index].j == I && Pair[index].i == J)
                {
                    if (pred == -1)
                    {
                        H[J] = L[index];
                    }
                    else
                    {
                        L[pred] = L[index];
                    }
                    deleted = true;
                }
                if (L[index] == -1)
                    break;
                pred = index;
                index = L[index];
            } 
            if (!deleted)
                throw new Exception("j i edge doesnt exist");
        }
        public void Print()
        {
            string writePath = @"C:\Users\nikit\Desktop\graph.txt";
            string header = "Graph G { \n";
            string body = "";
            
            foreach (int index in H)
            {
                int k = index;
                while (true)
                {
                    body += (Pair[k].i + 1).ToString() + "--" + (Pair[k].j + 1).ToString() + ";\n";
                    if (L[k] == -1)
                        break;
                    k = L[k];
                } 
            }
            body += "}";
            File.WriteAllText(writePath, header + body);
        }
    }
    
}
