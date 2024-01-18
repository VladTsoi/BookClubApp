using System.ComponentModel.DataAnnotations;

namespace BookClubApp.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        [Display(Name = "Название книги")]
        public string Name { get; set; }
        [Display(Name = "Прочтен")]
        public bool Status { get; set; }
        [Display(Name = "Пользователь")]
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
