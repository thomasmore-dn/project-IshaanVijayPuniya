using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;

namespace aspnet.Repositories
{
    public interface IRepo
    {
        IEnumerable<Sneaker> GetAllSneakers();

        Sneaker GetSneakerById(int id);

        void AddSneaker(Sneaker p);

        void UpdateSneaker(Sneaker p);

        void DeleteSneaker(Sneaker p);

        void SaveChanges();
    }
}