namespace Konoma.CrossFit
{
    public interface IPreferencesService
    {
        bool ReadBool(string key, bool defaultValue = default);

        void WriteBool(string key, bool value);

        int ReadInt(string key, int defaultValue = default);

        void WriteInt(string key, int value);

        string? ReadString(string key);

        void WriteString(string key, string value);

        void Remove(string key);
    }
}
