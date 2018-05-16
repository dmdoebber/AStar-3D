using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aStar_3D
{
    class Program
    {
        static void Main(string[] args)
        {
            PathFinding p = new PathFinding(5, 5, 5);
            List<Node> l = p.FindPath();

            if(l != null)
            {
                Console.Write("\nCaminho = ");
                for (int i = 0; i < l.Count; i++)
                    Console.Write("(" + l[i].x + "," + l[i].y + "," + l[i].z + ")");
                Console.Write("\nCusto total = "+l[l.Count-1].gCost);
            }

            Console.ReadKey();
        }
    }
}
