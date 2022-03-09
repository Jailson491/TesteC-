using Microsoft.EntityFrameworkCore;
using Santader.UserControl.Data;
using Santader.UserControl.Models;

namespace Santader.UserControl.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> Create(List<User> users);
        public Task<User> FindUserAsync(string nome, string password);
        public Task<IEnumerable<User>> GetAllUserAsync();
        public Task<bool> DisebledUser();

    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;
        private readonly AppDbContextOra dbOra;

        public UserRepository(AppDbContext _db, AppDbContextOra _dbOra)
        {
            db = _db;
            dbOra = _dbOra;
        }
        public async Task<bool> Create(List<User> users)
        {
            try
            {               
                db.User.AddRangeAsync(users);
                db.SaveChangesAsync();               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> FindUserAsync(string nome, string password)
        {
            var users = new User();
            try
            {
                users = await db
                    .User
                    .Where(x => x.UserName == nome && x.Password == password)
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return users;

        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            List<User> users = new List<User>();

            return await db.User.ToListAsync();

        }

        public async Task<bool> DisebledUser()
        {
            try
            {
                var DisableUser = dbOra.DeleteUsers
                           .Where(s => s.Process == "0")
                           .ToList();
                foreach (var item in DisableUser)
                {

                    User userAlter = db.User
                               .Where(s => s.Id == item.idUser)
                               .FirstOrDefault();

                    userAlter.Enable = false;
                    userAlter.DateAlter = DateTime.Now;

                    db.Update(userAlter);
                    db.SaveChanges();

                    item.Process = "1";
                    dbOra.Update(item);
                    dbOra.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }



    }

}
