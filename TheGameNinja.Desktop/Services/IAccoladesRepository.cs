using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheGameNinja.Data;

namespace TheGameNinja.Desktop.Services
{
    public interface IAccoladesRepository
    {
        Task<List<Accolade>> GetAccoladesForVideoGamesAsync(int videoGameId);
        Task<List<Accolade>> GetAllAccoladesAsync();
        Task<Accolade> AddAccoladeAsync(Accolade accolade);
        Task<Accolade> UpdateAccoladeAsync(Accolade accolade);
        Task DeleteAccoladeAsync(int accoladeId);

        //Task<List<Product>> GetProductsAsync();
        //Task<List<ProductOption>> GetProductOptionsAsync();
        //Task<List<ProductSize>> GetProductSizesAsync();
        //Task<List<OrderStatus>> GetOrderStatusesAsync();
    }
}
