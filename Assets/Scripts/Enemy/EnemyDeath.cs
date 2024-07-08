using Character;
using Drop;
using Drop.Factory;
using Enemy.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using Infrastructure.States.StatesMachine;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;
		private IDropFactory _dropFactory;
		private IStaticDataService _staticDataService;
		private IDropProvider _dropProvider;
		private IRandomService _randomizer;
		private IPersistentProgressService _persistentProgressService;
		private IGameStatesSwitcher _gameStateSwitcher;

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IDropFactory dropFactory, IStaticDataService staticDataService,
			IDropProvider dropProvider, IRandomService randomizer, IPersistentProgressService persistentProgressService,
			IGameStatesSwitcher gameStateSwitcher)
		{
			_enemyFactory = enemyFactory;
			_dropFactory = dropFactory;
			_staticDataService = staticDataService;
			_dropProvider = dropProvider;
			_randomizer = randomizer;
			_persistentProgressService = persistentProgressService;
			_gameStateSwitcher = gameStateSwitcher;
		}

		public void Die(GameObject gameObject)
		{
			SetRandomDrop();

			CreateDropGameObject(gameObject);

			Destroy(gameObject);

			_persistentProgressService.Progress.EnemyData.EnemiesList.Remove(gameObject);

			if(_persistentProgressService.Progress.EnemyData.EnemiesList.Count <= 0)
				_gameStateSwitcher.SwitchState<GameCompleteState>();
		}

		private void SetRandomDrop()
		{
			int percentToHelmetDrop = 70;

			int random = _randomizer.NextZeroToHundred();

			DropType randomDrop = random < percentToHelmetDrop ? DropType.Helmet : DropType.Ammo;

			foreach (DropStaticData dropStaticData in _staticDataService.DropsList.DropsList)
			{
				if (randomDrop == dropStaticData.Type) 
					_dropProvider.StaticData = dropStaticData;
			}
		}

		private void CreateDropGameObject(GameObject gameObject) => 
			_dropFactory.Create(gameObject.transform.position);

		private void Destroy(GameObject gameObject) =>
			_enemyFactory.Destroy(gameObject);
	}
}