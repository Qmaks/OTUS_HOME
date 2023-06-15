    using Zenject;

    public abstract class SaveLoader<TData, TService> : ISaveLoader
    {
        [Inject] private IGameRepository repository;
        [Inject] private TService service;
        
        void ISaveLoader.LoadGame()
        {
            if (repository.TryGetData(out TData data))
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
            repository.SetData(data);
        }

        protected abstract void SetupData(TService service, TData data);

        protected abstract TData ConvertToData(TService service);

        protected virtual void SetupByDefault(TService service)
        {
        }
    }
