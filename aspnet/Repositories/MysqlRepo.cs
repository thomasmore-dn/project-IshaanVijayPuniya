using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;
using aspnet.Contexts;

namespace aspnet.Repositories
{
    // MysqlRepo is a class implementing the IRepo interface to interact with MySQL database for Sneaker data.
    public class MysqlRepo : IRepo
    {
        // SneakerContext for interacting with the MySQL database
        private readonly SneakerContext _context;

        // Constructor for MysqlRepo
        public MysqlRepo(SneakerContext context)
        {
            _context = context;
        }

        // AddSneaker method to add a new sneaker to the database
        public void AddSneaker(Sneaker p)
        {
            _context.Sneakers.Add(p);
        }

        // DeleteSneaker method to remove a sneaker from the database
        public void DeleteSneaker(Sneaker p)
        {
            _context.Sneakers.Remove(p);
        }

        // GetAllSneakers method to retrieve all sneakers from the database
        public IEnumerable<Sneaker> GetAllSneakers()
        {
            return _context.Sneakers;
        }

        // GetSneakerById method to retrieve a specific sneaker by its ID from the database
        public Sneaker GetSneakerById(int id)
        {
            // Attempt to find a sneaker with the specified ID
            Sneaker? sneak = _context.Sneakers.FirstOrDefault<Sneaker>(t => t.Id == id);

            // Return the found sneaker or a new Sneaker instance if not found
            if (sneak != null)
                return sneak;
            else
                return new Sneaker();
        }

        // SaveChanges method to persist changes to the database
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        // UpdateSneaker method to update an existing sneaker in the database (Not implemented)
        public void UpdateSneaker(Sneaker p)
        {
            throw new NotImplementedException();
        }
    }
}
