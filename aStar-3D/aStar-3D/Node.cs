using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aStar_3D
{
    class Node
    {
        public int  x, y, z;
        public int  gCost, hCost;
        public bool walkable;
        public Node parent;

        public Node(int _x, int _y, int _z, bool _walkable, int _gCost)
        {
            walkable = _walkable;
            gCost = _gCost;
            x = _x;
            y = _y;
            z = _z;
        }

        public int fCost { get { return gCost + hCost; } }
    }
}
