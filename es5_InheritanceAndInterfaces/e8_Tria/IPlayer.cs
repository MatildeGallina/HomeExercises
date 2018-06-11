using System;
using System.Collections.Generic;
using System.Text;

namespace e8_Tria
{
    interface IPlayer
    {
        List<int> ValidChoice(List<List<string>> board);

        int ReadSafeInt();
    }
}
