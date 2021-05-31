using Newtonsoft.Json;
using UnityEngine;

public class PlayerPrefsStorage : IStorage
{
    public void Save<TModel>(string key, TModel model)
    {
        PlayerPrefs.SetString(key, JsonConvert.SerializeObject(model));
    }

    public TValue Get<TValue>(string key)
    {
        return JsonConvert.DeserializeObject<TValue>(PlayerPrefs.GetString(key));
    }
}