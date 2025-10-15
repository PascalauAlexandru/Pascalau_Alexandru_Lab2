namespace Pascalau_Alexandru_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        
        public string PublisherName { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
