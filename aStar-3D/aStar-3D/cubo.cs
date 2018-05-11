using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aStar_3D
{
    class Cubo
    {
        private int sizeX, sizeY, sizeZ;
        public Node[,,] grid { get; private set; }

        public Cubo(int _sizeX, int _sizeY, int _sizeZ)
        {
            sizeX = _sizeX;
            sizeY = _sizeY;
            sizeZ = _sizeZ;
            createGrid();
        }

        public void createGrid()
        {
            int     peso = 0;
            bool    walkable;
            Random  rnd = new Random();
            grid = new Node[sizeX, sizeY, sizeZ];
            
            for (int x = 0; x < sizeX; x++)
            {
                for(int y = 0; y < sizeY; y++)
                {
                    for(int z = 0; z < sizeY; z++)
                    {
                        if (rnd.Next(0, 1) == 0) { walkable = false; }
                        else { walkable = true; peso = rnd.Next(1, 9); }
                        grid[x, y, z] = new Node(x, y, z, walkable, peso);
                    }
                }
            }
        }

        public Node getNodeFromGrid(int posX, int posY, int posZ)
        {
            if ((posX > sizeX && posX < 0) && (posY > sizeY && posY < 0) && (posZ > sizeZ && posZ < 0))
                return grid[posX, posY, posZ];
            return null;
        }
    }
}