using System.IO.IsolatedStorage;

namespace Mangifera.Phone
{
    public class SettingsManager : ISettingsManager
    {
        public TType Get<TType>(string name)
        {
            return Get(name, default(TType));
        }

        public TType Get<TType>(string name, TType defaultValue)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(name))
            {
                return defaultValue;
            }
            var data = (TType)IsolatedStorageSettings.ApplicationSettings[name];
            return data;
        }

        public bool Contains(string name)
        {
            return IsolatedStorageSettings.ApplicationSettings.Contains(name);
        }

        public void Put(string name, object data) {

            if(!IsolatedStorageSettings.ApplicationSettings.Contains(name))
            {
                IsolatedStorageSettings.ApplicationSettings.Add(name, data);
            } else
            {
                IsolatedStorageSettings.ApplicationSettings[name] = data;
            }
        }

        public void Remove(string name)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(name))
            {
                return;
            }
            IsolatedStorageSettings.ApplicationSettings.Remove(name);
        }

        public void Save()
        {
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
}
