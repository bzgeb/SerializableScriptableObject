using UnityEditor;
using UnityEngine;

public class SaveDataDebugTools
{
    [MenuItem("Tools/Save Game (Binary)")]
    static void SaveBinaryGame()
    {
        if (Application.isPlaying)
        {
            var game = GameObject.FindObjectOfType<Game>();
            game.SaveGame();
        }
    }

    [MenuItem("Tools/Load Game (Binary)")]
    static void LoadBinaryGame()
    {
        if (Application.isPlaying)
        {
            var game = GameObject.FindObjectOfType<Game>();
            game.LoadGame();
        }
    }
}