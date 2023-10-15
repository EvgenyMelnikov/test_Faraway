using UnityEngine;
using Zenject;

/// <summary>
/// Класс биндит зависимости для основных систем и контроллеров мира
/// </summary>
public class RootInstaller : MonoInstaller
{
    [SerializeField] private GameObject _locationPlaceholder;
    
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        
        Container.Bind<LocationPlaceholder>().FromComponentOn(_locationPlaceholder).AsSingle();
        Container.BindInterfacesTo<World>().AsSingle().NonLazy();
        Container.BindInterfacesTo<Bootstrap>().AsSingle().NonLazy();
        Container.BindInterfacesTo<LocationController>().AsSingle().NonLazy();
        Container.BindInterfacesTo<CoinsController>().AsSingle().NonLazy();
        Container.BindInterfacesTo<ManualUpdateSystem>().AsSingle().NonLazy();

        Container.DeclareSignal<CoinContactSignal>();
    }
}