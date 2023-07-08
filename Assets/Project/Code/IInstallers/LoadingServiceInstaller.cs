using UnityEngine;
using Zenject;

public class LoadingServiceInstaller : MonoInstaller
{
    [SerializeField] private LoadingService _loadingService;
    
    public override void InstallBindings()
    {
        Container
            .Bind<LoadingService>()
            .FromInstance(_loadingService)
            .AsSingle();
    }
}
