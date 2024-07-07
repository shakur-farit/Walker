using Ammo;
using Ammo.Factory;
using Character;
using Character.Factory;
using Drop;
using Drop.Factory;
using Enemy;
using Enemy.Factory;
using Hud.Factory;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.Input;
using Infrastructure.Services.ObjectCreator;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Factory;
using Infrastructure.States.StatesMachine;
using UI.Factory;
using UI.Services.Windows;
using Zenject;

namespace Installers
{
	public class SceneGamePlayInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterServices();
			RegisterFactories();
			RegisterGameStateMachine();
		}

		private void RegisterFactories()
		{
			Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
			Container.Bind<IHudFactory>().To<HudFactory>().AsSingle();
			Container.Bind<IStatesFactory>().To<StatesFactory>().AsSingle();
			Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
			Container.Bind<IAmmoFactory>().To<AmmoFactory>().AsSingle();
			Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
			Container.Bind<IDropFactory>().To<DropFactory>().AsSingle();
		}

		private void RegisterServices()
		{
			Container.BindInterfacesAndSelfTo<CharacterInput>().AsSingle();
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
			Container.Bind<IObjectCreatorService>().To<ObjectCreatorService>().AsSingle();
			Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
			Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
			Container.Bind<IRandomService>().To<RandomService>().AsSingle();
			Container.Bind<IWindowsService>().To<WindowsService>().AsSingle();
			Container.Bind<IAmmoDeath>().To<AmmoDeath>().AsSingle();
			Container.Bind<IEnemyDeath>().To<EnemyDeath>().AsSingle();
			Container.Bind<ICharacterDeath>().To<CharacterDeath>().AsSingle();
			Container.Bind<IDropDeath>().To<DropDeath>().AsSingle();
		}

		private void RegisterGameStateMachine() => 
			Container.BindInterfacesAndSelfTo<GameStatesMachine>().AsSingle();
	}
}
