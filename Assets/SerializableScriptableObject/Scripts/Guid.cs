using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
public struct Guid : IEquatable<Guid>
{
    #if UNITY_EDITOR
    public const string VALUE0_FIELDNAME = nameof(m_Value0);
    public const string VALUE1_FIELDNAME = nameof(m_Value1);
    public const string VALUE2_FIELDNAME = nameof(m_Value2);
    public const string VALUE3_FIELDNAME = nameof(m_Value3);
    #endif
    
    [SerializeField, HideInInspector] uint m_Value0;
    [SerializeField, HideInInspector] uint m_Value1;
    [SerializeField, HideInInspector] uint m_Value2;
    [SerializeField, HideInInspector] uint m_Value3;

    public uint Value0 => m_Value0;
    public uint Value1 => m_Value1;
    public uint Value2 => m_Value2;
    public uint Value3 => m_Value3;

    public Guid(uint val0, uint val1, uint val2, uint val3)
    {
        m_Value0 = val0;
        m_Value1 = val1;
        m_Value2 = val2;
        m_Value3 = val3;
    }

    public Guid(string hexString)
    {
        m_Value0 = 0U;
        m_Value1 = 0U;
        m_Value2 = 0U;
        m_Value3 = 0U;
        TryParse(hexString, out this);
    }
    
    public static bool operator ==(Guid x, Guid y) => x.m_Value0 == y.m_Value0 && x.m_Value1 == y.m_Value1 && x.m_Value2 == y.m_Value2 && x.m_Value3 == y.m_Value3;
    public static bool operator !=(Guid x, Guid y) => !(x == y);
    public bool Equals(Guid other) => this == other;
    public override bool Equals(object obj) => obj != null && obj is GUID && Equals((GUID) obj);
    public override int GetHashCode() => (((int) m_Value0 * 397 ^ (int) m_Value1) * 397 ^ (int) m_Value2) * 397 ^ (int) m_Value3;

    public string ToHexString()
    {
        return $"{m_Value0:X8} {m_Value1:X8} {m_Value2:X8} {m_Value3:X8}";
    }

    static void TryParse(string hexString, out Guid guid)
    {
        guid.m_Value0 = Convert.ToUInt32(hexString.Substring(0, 8), 16);
        guid.m_Value1 = Convert.ToUInt32(hexString.Substring(8, 8), 16);
        guid.m_Value2 = Convert.ToUInt32(hexString.Substring(16, 8), 16);
        guid.m_Value3 = Convert.ToUInt32(hexString.Substring(24, 8), 16);
    }
}

#region BinaryReader and BinaryWriter Extensions
public static class BinaryReaderExtensions
{
    public static Guid ReadGuid(this BinaryReader reader)
    {
        return new Guid(reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32());
    }
}

public static class BinaryWriterExtensions
{
    public static void Write(this BinaryWriter writer, Guid guid)
    {
        writer.Write(guid.Value0);
        writer.Write(guid.Value1);
        writer.Write(guid.Value2);
        writer.Write(guid.Value3);
    }
}
#endregion