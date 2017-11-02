namespace YggClientCore.Categories
{
    public class BaseCategory
    {
        public string Url { get; internal set; }
        public string Name { get; internal set; }
        public Categories Type { get; internal set; }

        public int Id { get; internal set; }

        public BaseCategory(Categories typeCategorie)
        {
            Type = typeCategorie;
        }
    }
}