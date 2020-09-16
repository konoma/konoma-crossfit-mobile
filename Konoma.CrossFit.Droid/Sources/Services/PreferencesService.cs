using System;
using Android.App;
using Android.Content;

namespace Konoma.CrossFit
{
    public class PreferencesService : IPreferencesService
    {
        #region Initialization

        public PreferencesService(string name, FileCreationMode mode = FileCreationMode.Private)
            : this(Application.Context.GetSharedPreferences(name, mode)!)
        {
        }

        public PreferencesService(ISharedPreferences preferences)
        {
            this.Preferences = preferences;
        }

        #endregion

        #region Dependencies

        private readonly ISharedPreferences Preferences;

        #endregion

        #region Reading and Writing Preferences

        public bool ReadBool(string key, bool defaultValue)
            => this.Preferences.GetBoolean(key, defaultValue);

        public void WriteBool(string key, bool value)
            => this.Edit(prefs => prefs.PutBoolean(key, value));

        public int ReadInt(string key, int defaultValue)
            => this.Preferences.GetInt(key, defaultValue);

        public void WriteInt(string key, int value)
            => this.Edit(prefs => prefs.PutInt(key, value));

        public long ReadLong(string key, long defaultValue)
            => this.Preferences.GetLong(key, defaultValue);

        public void WriteLong(string key, long value)
            => this.Edit(prefs => prefs.PutLong(key, value));

        public float ReadFloat(string key, float defaultValue)
            => this.Preferences.GetFloat(key, defaultValue);

        public void WriteFloat(string key, float value)
            => this.Edit(prefs => prefs.PutFloat(key, value));

        public double ReadDouble(string key, double defaultValue)
            => BitConverter.Int64BitsToDouble(
                this.Preferences.GetLong(key, BitConverter.DoubleToInt64Bits(defaultValue)));

        public void WriteDouble(string key, double value)
            => this.Edit(prefs => prefs.PutLong(key, BitConverter.DoubleToInt64Bits(value)));

        public string? ReadString(string key)
            => this.Preferences.GetString(key, null);

        public void WriteString(string key, string value)
            => this.Edit(prefs => prefs.PutString(key, value));

        public bool HasKey(string key)
            => this.Preferences.Contains(key);

        public void Remove(string key)
            => this.Edit(prefs => prefs.Remove(key));

        #endregion

        #region Helpers

        private void Edit(Action<ISharedPreferencesEditor> edit)
        {
            var editor = this.Preferences.Edit()!;
            edit(editor);
            editor.Apply();
        }

        #endregion
    }
}
