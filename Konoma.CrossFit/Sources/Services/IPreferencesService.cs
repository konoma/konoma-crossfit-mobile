namespace Konoma.CrossFit
{
    public interface IPreferencesService
    {
        bool ReadBool(string key, bool defaultValue = default);

        void WriteBool(string key, bool value);

        int ReadInt(string key, int defaultValue = default);

        void WriteInt(string key, int value);

        long ReadLong(string key, long defaultValue = default);

        void WriteLong(string key, long value);

        float ReadFloat(string key, float defaultValue = default);

        void WriteFloat(string key, float value);

        double ReadDouble(string key, double defaultValue = default);

        void WriteDouble(string key, double value);

        string? ReadString(string key);

        void WriteString(string key, string value);

        bool HasKey(string key);

        void Remove(string key);
    }
}
