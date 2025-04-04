namespace PrestamosVehiculos.Domain.Interfaces
{
    public interface ICacheService
    {
        T GetOrSet<T>(string key, Func<T> factory, TimeSpan expiration);
        void Remove(string key);
    }
}
