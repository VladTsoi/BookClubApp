using System.ComponentModel.DataAnnotations;

namespace BookClubApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите логин!")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

    }
}
