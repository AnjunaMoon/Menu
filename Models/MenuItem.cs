using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
            Items = new List<MenuItem>();
            Id = Guid.NewGuid().ToString();
        }
        public IEnumerable<MenuItem> GetItemAndSubitems()
        {
            return new[] { this }
                   .Concat(Items.SelectMany(item => item.GetItemAndSubitems()));
        }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Label { get; set; }
        public string Url { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
