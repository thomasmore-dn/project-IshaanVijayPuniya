using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maui.Models;

namespace maui.Services
{
    public interface IDataService
    {
        //DEPENDENCY SERVICES WITHIN THE PROJECT
        // T U or V type parameters

        Task<List<Sneaker>> GetAllSneakerAsync();
        Task AddSneakerAsync(Sneaker sneak);
        Task UpdateSneakerAsync(Sneaker sneak);
        Task DeleteSneakerAsync(int id);

    }
}