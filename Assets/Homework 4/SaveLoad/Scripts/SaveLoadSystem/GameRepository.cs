﻿using System.Collections.Generic;
using System.IO;
using Homework_4.SaveLoad.Scripts.Encrypt;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem.Serializer;
using Sirenix.Serialization;
using UnityEngine;
using Zenject;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public class GameRepository : IGameRepository
    {
        private const string GAME_SAVE_FILE = "/SaveFile.crypt";
        
        [Inject] private IEncryptor encryptor;
        [Inject] private ISerializer serializer;

        private Dictionary<string, object> gameState = new();
        
        public void LoadState()
        {
            if (File.Exists(GetSaveFilePath()))
            {
                var bytes = File.ReadAllBytes(GetSaveFilePath());
                bytes = encryptor.Decrypt(bytes);
                gameState = serializer.Deserialize<Dictionary<string, object>>(bytes);
            }
            else
            {
                gameState = new Dictionary<string, object>();
            }
        }

        public void SaveState()
        {
            var bytes = serializer.Serialize(gameState);
            bytes = encryptor.Encrypt(bytes);
            File.WriteAllBytes(GetSaveFilePath(), bytes);
        }

        private string GetSaveFilePath()
        {
            return Application.persistentDataPath + GAME_SAVE_FILE;
        }
    
        public T GetData<T>(string key)
        {
            var serializedData = gameState[key];
            return (T)serializedData;
        }

        public bool TryGetData<T>(string key,out T value)
        {
            if (gameState.TryGetValue(key, out var serializedData))
            {
                value = (T)serializedData;
                return true;
            }

            value = default;
            return false;
        }

        public void SetData<T>(string key,T value)
        {
            gameState[key] = value;
        }
    }
}