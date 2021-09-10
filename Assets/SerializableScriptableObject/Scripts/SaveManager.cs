using System.IO;
using UnityEngine;

public class SaveManager
{
    public static void SaveBinary(string filePath, SaveData saveData)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
        {
            writer.Write(saveData.EntityGuids.Length);
            for (int i = 0; i < saveData.EntityGuids.Length; ++i)
            {
                writer.Write(saveData.EntityGuids[i]);
                var position = saveData.EntityPositions[i];
                writer.Write(position.x);
                writer.Write(position.y);
                writer.Write(position.z);
            }
        }

        Debug.Log($"Saved Binary to {filePath}");
    }

    public static void LoadBinary(string filePath, SaveData saveData)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            var entityCount = reader.ReadInt32();
            saveData.EntityGuids = new Guid[entityCount];
            saveData.EntityPositions = new Vector3[entityCount];
            for (int i = 0; i < entityCount; ++i)
            {
                saveData.EntityGuids[i] = reader.ReadGuid();
                saveData.EntityPositions[i] = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            }
        }

        Debug.Log($"Loaded Binary from {filePath}");
    }
}