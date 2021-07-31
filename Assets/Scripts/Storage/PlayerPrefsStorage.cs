using Newtonsoft.Json;
using UnityEngine;

namespace ExplodeBalloons.Storage
{
    public class PlayerPrefsStorage : IStorage
    {
        public void Save<TModel>(string key, TModel model)
        {
            PlayerPrefs.SetString(key, JsonConvert.SerializeObject(model));
        }

        public TModel Get<TModel>(string key)
        {
            string json = PlayerPrefs.GetString(key);
            if (string.IsNullOrWhiteSpace(json))
            {
                return default(TModel);
            }

            return JsonConvert.DeserializeObject<TModel>(json);
        }
    }
}