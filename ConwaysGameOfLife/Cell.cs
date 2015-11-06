using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        private bool state = false;

        public bool State
        {
            get { return state; }
            set { this.state = value; }
        }
    }
}
