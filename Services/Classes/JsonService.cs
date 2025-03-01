using apiOef14._6.Models;
using apiOef14._6.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace apiOef14._6.Services.Classes
{
    public class JsonService<T> : IJsonService<T>
    {
        public async Task<List<T>> GetJson(string filePath)
        {
            if (File.Exists(filePath) is false)
            {
                throw new FileNotFoundException();
            }
            var file = await File.ReadAllTextAsync(filePath);
            var readFile = JsonConvert.DeserializeObject<List<T>>(file) ?? new List<T>();
            
            return readFile.ToList();
        }
    }
}
