using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace ExplodeBalloons.Storage
{
    public class DiskStorage : IStorage
    {
        public void Save<TModel>(string key, TModel model)
        {
            string file = JsonConvert.SerializeObject(model);
            string path = Path.Combine(Application.persistentDataPath, key);
            File.WriteAllText(path, file);
        }

        public TModel Get<TModel>(string key)
        {
            string path = Path.Combine(Application.persistentDataPath, key);
            if (!File.Exists(path))
            {
                return default(TModel);
            }

            return JsonConvert.DeserializeObject<TModel>(File.ReadAllText(path));
        }
    }
}