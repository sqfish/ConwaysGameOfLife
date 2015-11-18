using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public interface Board
    {
        List<List<bool>> ToList();

        void Tick();
    }
}