namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem
{
    public interface ISaveableComponent
    {
        void LoadMembers(string[] members);
        string[] SaveMembers();
    }
}