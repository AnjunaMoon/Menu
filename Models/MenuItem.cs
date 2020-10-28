using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class MenuItem
    {
        public string Label { get; set; }
        public string Url { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
