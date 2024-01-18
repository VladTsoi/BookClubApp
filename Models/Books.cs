using Microsoft.EntityFrameworkCore;

namespace BookClubApp.Models
{
    public class Books
    {
        public async static Task Take(User user, ApplicationContext db)
        {
            Catalog book1 = new Catalog { Name = "Пигмалион", UserId = user.Id };
            Catalog book2 = new Catalog { Name = "Дон Кихот", UserId = user.Id };
            Catalog book3 = new Catalog { Name = "Приключения Тома Сойера", UserId = user.Id };
            Catalog book4 = new Catalog { Name = "Маленький принц", UserId = user.Id };
            db.Catalogs.AddRange(book1, book2, book3, book4);
            await db.SaveChangesAsync();
        }
    }
}
