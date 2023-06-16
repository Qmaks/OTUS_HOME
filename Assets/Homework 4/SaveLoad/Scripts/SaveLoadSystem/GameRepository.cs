using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class GameRepository : IGameRepository
{
    private const string GAME_STATE_KEY = "GameState";

    private Dictionary<string, string> gameState = new();
    private IGameRepository gameRepositoryImplementation;

    public void LoadState()
    {
        if (PlayerPrefs.HasKey(GAME_STATE_KEY))
        {
            var serializedState = PlayerPrefs.GetString(GAME_STATE_KEY);
            gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(serializedState);
        }
        else
        {
            gameState = new Dictionary<string, string>();
        }
    }

    public void SaveState()
    {
        var serializedState = JsonConvert.SerializeObject(gameState);
        PlayerPrefs.SetString(GAME_STATE_KEY, serializedState);
    }
    
    public T GetData<T>(string key)
    {
        var serializedData = gameState[key];
        return JsonConvert.DeserializeObject<T>(serializedData);
    }

    public bool TryGetData<T>(string key,out T value)
    {
        if (gameState.TryGetValue(key, out var serializedData))
        {
            value = JsonConvert.DeserializeObject<T>(serializedData);
            return true;
        }

        value = default;
        return false;
    }

    public void SetData<T>(string key,T value)
    {
        var serializedData = JsonConvert.SerializeObject(value);
        gameState[key] = serializedData;
    }
}