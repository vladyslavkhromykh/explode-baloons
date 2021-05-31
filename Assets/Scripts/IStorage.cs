
public interface IStorage
{
    void Save<TModel>(string key, TModel model);
    TValue Get<TValue>(string key);
}