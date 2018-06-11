using System;
using System.Collections.Generic;
using System.Text;

namespace e8_Tria
{
    class ComputerPlayer : IPlayer
    {
        public ComputerPlayer(string name)
        {
            Name = name;
        }

        public string Name
        { get; }

        public int ReadSafeInt()
        {
            throw new NotImplementedException();
        }

        public List<int> ValidChoice(List<List<string>> board)
        {
            throw new NotImplementedException();
        }
    }
}
