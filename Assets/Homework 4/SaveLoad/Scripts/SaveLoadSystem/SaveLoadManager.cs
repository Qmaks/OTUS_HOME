    using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class SaveLoadManager : MonoBehaviour
{
    [Inject] private ISaveLoader[] saveLoaders;
    [Inject] private IGameRepository gameRepository;
    
    [Button(ButtonSizes.Large),GUIColor(0,1,0)]
    public void Save()
    {
        foreach (var saveLoader in saveLoaders)
        {
            saveLoader.SaveGame();
        }
            
        gameRepository.SaveState();
    }

    [Button(ButtonSizes.Large),GUIColor(0,1,0)]
    public void Load()
    {
        gameRepository.LoadState();
        
        foreach (var saveLoader in this.saveLoaders)
        {
            saveLoader.LoadGame();
        }
    }
}