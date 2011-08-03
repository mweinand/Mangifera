namespace Mangifera.Phone
{
    public interface ISettingsManager
    {
        TType Get<TType>(string name);
        TType Get<TType>(string name, TType defaultValue);
        void Put(string name, object data);
        bool Contains(string name);
        void Remove(string name);
        void Save();
    }
}