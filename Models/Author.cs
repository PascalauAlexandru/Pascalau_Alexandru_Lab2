using System.ComponentModel.DataAnnotations;

namespace Pascalau_Alexandru_Lab2.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;

        [Display(Name ="Full Name")]
        public string FullName
        {
            get 
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
