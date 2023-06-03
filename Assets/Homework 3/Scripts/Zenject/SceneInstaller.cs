using System;
using Lessons.Architecture.PM;
using UnityEngine;
using Zenject;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Homework_3.Scripts.Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        public PlayerLevel PlayerLevel;
        public CharacterStat CharacterStat;
        public CharacterInfo CharacterInfo;
        public UserInfo UserInfo;
        public override void InstallBindings()
        {

        }
    }
}
