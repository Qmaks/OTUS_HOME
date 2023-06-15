using System.Collections.Generic;
using System.Linq;
using Homework_4.SaveLoad.Scripts.SaveLoadSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Homeworks.SaveLoad.LevelResources
{
    public class SavableObjectsManager : MonoBehaviour , IInitializable
    {
        [Inject] private SavableObject[] savableObjects;
        
        public void Initialize()
        {
            InitializeFromScene();
        }

        public void InitializeFromScene()
        {
            //resources = GetComponentsInChildren<ResourceObject>().ToList();
        }

        public void Setup(List<SavableObject.Data> data)
        {
            // Загрузим данными обьекты которые уже присуствуют в сцене
            for (var i = 0; i < m_CurrentSceneSaveables.Count; i++)
            {
                if (data.TryGetValue(m_CurrentSceneSaveables[i].GetGuid().ToString(), out SaveableObject.Data objData))
                    m_CurrentSceneSaveables[i].Load(objData);
                else
                    Destroy(m_CurrentSceneSaveables[i].gameObject);
            }
        }

        public IEnumerable<SavableObject.Data> GetObjects()
        {
            return savableObjects.Select(s => s.Save());
        }
    }
}
