namespace ExplodeBalloons.Storage
{
    public interface IStorage
    {
        void Save<TModel>(string key, TModel model);
        TModel Get<TModel>(string key);
    }
}