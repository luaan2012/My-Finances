namespace SistemaContas.Models.IService
{
    public interface IUserService<T>
    {
        Task CreateAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(int? id);
        Task<T> GetAsync(int? id);
        Task<T> GetByEmail(T user);
    }
}
