using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes.Models
{
        public class Villain
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string BadActs { get; set; }
            public bool HasMinions { get; set; }
            public GenderType Gender { get; set; }
        }
}
