namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public interface ISaveableComponent
    {
        void LoadMembers(object[] members);
        object[] SaveMembers();
    }
}