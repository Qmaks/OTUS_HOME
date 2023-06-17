    using Zenject;

    public abstract class SaveLoader<TData, TService> : ISaveLoader
    {
        [Inject] private IGameRepository repository;
        [Inject] private TService service;
        
        protected string KEY;

        void ISaveLoader.LoadGame()
        {
            if (repository.TryGetData(KEY,out TData data))
            {
                SetupData(service, data);
            }
            else
            {
                SetupByDefault(service);
            }
        }

        void ISaveLoader.SaveGame()
        {
            var data = this.ConvertToData(service);
            repository.SetData(KEY,data);
        }

        protected abstract void SetupData(TService service, TData data);

        protected abstract TData ConvertToData(TService service);

        protected virtual void SetupByDefault(TService service)
        {
        }
    }
