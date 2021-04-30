using System.Collections.Generic;

namespace ToDoList.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<CategoryItem> Categories { get; }
        public bool Completed { get; set; } = false;
        public Item()
        {
            this.Categories = new HashSet<CategoryItem>();
        }
    }
}