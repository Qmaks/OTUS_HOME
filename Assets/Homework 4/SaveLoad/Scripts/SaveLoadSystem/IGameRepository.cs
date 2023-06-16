public interface IGameRepository
{
    T GetData<T>(string key);
    bool TryGetData<T>(string key,out T value);
    void SetData<T>(string key,T value);
    void SaveState();
    void LoadState();
}