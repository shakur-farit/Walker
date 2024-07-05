using Character.Factory;
using Hud.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Input;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Factory;
using Infrastructure.States.StatesMachine;
using Zenject;

namespace Installers
{
	public class SceneGamePlayInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterServices();
			RegisterFactories();
			Container.BindInterfacesAndSelfTo<GameStatesMachine>().AsSingle();
		}

		private void RegisterFactories()
		{
			Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
			Container.Bind<IHudFactory>().To<HudFactory>().AsSingle();
			Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();
		}

		private void RegisterServices()
		{
			Container.BindInterfacesAndSelfTo<CharacterInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
			Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
		}
	}
}
