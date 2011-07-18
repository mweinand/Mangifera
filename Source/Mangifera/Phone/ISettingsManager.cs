namespace Mangifera.Phone
{
    public interface ISettingsManager
    {
        TType Get<TType>(string name);
        void Put(string name, object data);
        void Remove(string name);
        void Save();
    }
}