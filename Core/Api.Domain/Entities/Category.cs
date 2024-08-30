using Api.Domain.Comman;

namespace Api.Domain.Entities
{
    public class Category :EntityBase,IEntityBase
    {
        public Category() { }

        //
        public Category(int parentId, string name, int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }

        public  int ParentId { get; set; } //doldurulması zorunlu alanlarda required
        public  string Name { get; set; }
        public  int Priorty { get; set; }

        public ICollection<Detail> Details { get; set; } // bire çok ilişki 1 kategorini birden çok detay olur
        public ICollection<Product> Products { get; set; }    
    }
}
