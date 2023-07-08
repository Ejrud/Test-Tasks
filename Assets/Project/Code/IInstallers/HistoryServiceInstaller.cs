using UnityEngine;
using Zenject;

public class HistoryServiceInstaller : MonoInstaller
{
    [SerializeField] private HistoryService _historyService;

    public override void InstallBindings()
    {
        Container
            .Bind<HistoryService>()
            .FromInstance(_historyService)
            .AsSingle();
    }
}
