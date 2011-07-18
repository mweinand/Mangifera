using System.IO.IsolatedStorage;

namespace Mangifera.Phone
{
    public class SettingsManager : ISettingsManager
    {
        public TType Get<TType>(string name)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(name))
            {
                return default(TType);
            }
            var data = (TType) IsolatedStorageSettings.ApplicationSettings[name];
            return data;
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
