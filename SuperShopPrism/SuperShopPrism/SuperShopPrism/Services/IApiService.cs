namespace SuperShopPrism.Services
{
    using SuperShopPrism.Models;
    using System.Threading.Tasks;

    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}
