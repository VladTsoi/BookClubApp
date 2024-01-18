using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BookClubApp.Models
{
    public class Crud
    {
        public async static Task Insert(User user, ApplicationContext db)
        {
            var currentUser = await db.Users.FirstOrDefaultAsync(u => u.Login == user.Login);
            if (currentUser?.Id == null)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                await Books.Take(user, db);
            }
        }
        public async static Task Update(int? id, ApplicationContext db)
        {
            if (id != null)
            {
                var currentBook = await db.Catalogs.FirstOrDefaultAsync(u => u.Id == id);
                if (currentBook.Status == false)
                {
                    currentBook.Status = true;
                }
                else
                {
                    currentBook.Status = false;
                }
                await db.SaveChangesAsync();
            }     
        }
    }
}
