namespace apiOef14._6.Services.Interfaces
{
    public interface IJsonService<T>
    {
        Task<List<T>> GetJson(string filePath);
    }
}