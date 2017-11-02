using System.Collections.Generic;

namespace YggClientCore.Categories
{
    public class Category : BaseCategory
    {
        public IEnumerable<SubCategory> SubCategorieses { get; internal set; }

        public Category(Categories typeCategorie) : base(typeCategorie)
        {
            Name = typeCategorie.ToString();
        }
    }
}