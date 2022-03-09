using Microsoft.EntityFrameworkCore;
using Santader.UserControl.Data;
using Santader.UserControl.Models;

namespace Santader.UserControl.Repositories
{

    public interface IDeleteRepository
    {
        public Task<bool> InsertDeleteUser(int Idusers);
        public Task<DeleteUsers> FindUser(string nome, string password);
    }
    public class DeleteUserRepository : IDeleteRepository
    {
        private readonly AppDbContextOra db;
        
        public DeleteUserRepository(AppDbContextOra _db)
        {
            db = _db;
        }
        public async Task<bool> InsertDeleteUser(int Idusers)
        {
            try
            {
                var users_db = new DeleteUsers()
                {                  
                    idUser = Idusers,
                    ResignationDate = DateTime.Now,
                    Process = "0",
                   

                };
                db.DeleteUsers.AddAsync(users_db);
                db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DeleteUsers> FindUser(string nome, string password)
        {
            List<DeleteUsers> users = new List<DeleteUsers>();

            DeleteUsers UserQuery = db
                .DeleteUsers                
                .AsTracking()
                .FirstOrDefault(x => x.Process == "0" );

            return UserQuery;
        }
    }
}
