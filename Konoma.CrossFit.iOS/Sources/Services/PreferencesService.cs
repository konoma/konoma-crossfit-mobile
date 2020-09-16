using Foundation;

namespace Konoma.CrossFit
{
    public class PreferencesService : IPreferencesService
    {
        #region Initialization

        public PreferencesService()
            : this(NSUserDefaults.StandardUserDefaults)
        {
        }

        public PreferencesService(NSUserDefaults userDefaults)
        {
            this.UserDefaults = userDefaults;
        }

        #endregion

        #region Dependencies

        private readonly NSUserDefaults UserDefaults;

        #endregion

        #region Reading and Writing Preferences

        public bool ReadBool(string key, bool defaultValue)
            => this.ReadNumberValue(key)?.BoolValue ?? defaultValue;

        public void WriteBool(string key, bool value)
            => this.UserDefaults.SetBool(value, key);

        public int ReadInt(string key, int defaultValue)
            => this.ReadNumberValue(key)?.Int32Value ?? defaultValue;

        public void WriteInt(string key, int value)
            => this.UserDefaults.SetInt(value, key);

        public long ReadLong(string key, long defaultValue)
            => this.ReadNumberValue(key)?.Int64Value ?? defaultValue;

        public void WriteLong(string key, long value)
            => this.UserDefaults.SetValueForKey(new NSNumber(value), new NSString(key));

        public float ReadFloat(string key, float defaultValue)
            => this.ReadNumberValue(key)?.FloatValue ?? defaultValue;

        public void WriteFloat(string key, float value)
            => this.UserDefaults.SetFloat(value, key);

        public double ReadDouble(string key, double defaultValue)
            => this.ReadNumberValue(key)?.DoubleValue ?? defaultValue;

        public void WriteDouble(string key, double value)
            => this.UserDefaults.SetDouble(value, key);

        public string? ReadString(string key)
            => this.UserDefaults.StringForKey(key);

        public void WriteString(string key, string value)
            => this.UserDefaults.SetString(value, key);

        public bool HasKey(string key)
            => this.UserDefaults.ValueForKey(new NSString(key)) != null;

        public void Remove(string key)
            => this.UserDefaults.RemoveObject(key);

        #endregion

        #region Helpers

        private NSNumber? ReadNumberValue(string key)
            => this.UserDefaults.ValueForKey(new NSString(key)) as NSNumber;

        #endregion
    }
}
