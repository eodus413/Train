public class Item
{
    public Item(string name,int id)
    {
        this.name = name;
        this.id = id;
    }
    public string name { get; private set; }
    public int id { get; private set; }
}