using System.IO;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] EntityRegistry _entityRegistry;

    static string _saveFolderPath;

    void OnEnable()
    {
        _saveFolderPath = $"{Application.persistentDataPath}/Saves";

        if (!Directory.Exists(_saveFolderPath))
            Directory.CreateDirectory(_saveFolderPath);
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        var entities = FindObjectsOfType<Entity>();
        saveData.SetEntities(entities);
        SaveManager.SaveBinary($"{_saveFolderPath}/savedata01.dat", saveData);
    }

    public void LoadGame()
    {
        var entities = FindObjectsOfType<Entity>();
        foreach (var entity in entities)
        {
            Destroy(entity.gameObject);
        }

        SaveData saveData = new SaveData();
        SaveManager.LoadBinary($"{_saveFolderPath}/savedata01.dat", saveData);

        for (int i = 0; i < saveData.EntityGuids.Length; ++i)
        {
            var entityGuid = saveData.EntityGuids[i];
            var entityPosition = saveData.EntityPositions[i];

            var entityDescriptor = _entityRegistry.FindByGuid(entityGuid);
            Instantiate(entityDescriptor.EntityPrefab, entityPosition, Quaternion.identity);
        }
    }
}