
namespace apiOef14._6.Services.Classes
{
    public interface IJsonService<T>
    {
         Task<List<T>> GetJson(string filePath);
    }
}