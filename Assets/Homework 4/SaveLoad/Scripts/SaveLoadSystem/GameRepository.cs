using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class GameRepository : IGameRepository
{
    private const string GAME_STATE_KEY = "GameState";

    private Dictionary<string, string> gameState = new();

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
    
    public T GetData<T>()
    {
        var serializedData = gameState[typeof(T).Name];
        return JsonConvert.DeserializeObject<T>(serializedData);
    }

    public bool TryGetData<T>(out T value)
    {
        if (gameState.TryGetValue(typeof(T).Name, out var serializedData))
        {
            value = JsonConvert.DeserializeObject<T>(serializedData);
            return true;
        }

        value = default;
        return false;
    }

    public void SetData<T>(T value)
    {
        var serializedData = JsonConvert.SerializeObject(value);
        gameState[typeof(T).Name] = serializedData;
    }
}