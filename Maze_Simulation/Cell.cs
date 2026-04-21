using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Simulation
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public System.Windows.Forms.Label Label { get; set; }

        public Cell(int x, int y, System.Windows.Forms.Label label)
        {
            this.X = x;
            this.Y = y;
            this.Label = label;
        }
    }
}
