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
            Console.Write("Digite as dimencoes do cubo:\n");
            Console.Write("X = ");
            int sizeX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y = ");
            int sizeY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Z = ");
            int sizeZ = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a coordenada do ponto de saida:\n");
            Console.Write("X = ");
            int xStart = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y = ");
            int yStart = Convert.ToInt32(Console.ReadLine());
            Console.Write("Z = ");
            int zStart = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a coordenada do ponto de chegada:\n");
            Console.Write("X = ");
            int xEnd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y = ");
            int yEnd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Z = ");
            int zEnd = Convert.ToInt32(Console.ReadLine());




            PathFinding p = new PathFinding(sizeX, sizeY, sizeZ);
            List<Node> l = p.FindPath(xStart, yStart, zStart, xEnd, yEnd, zEnd);

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
