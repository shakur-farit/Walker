using Character;
using Drop;
using Drop.Factory;
using Enemy.Factory;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
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

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IDropFactory dropFactory, IStaticDataService staticDataService,
			IDropProvider dropProvider, IRandomService randomizer)
		{
			_enemyFactory = enemyFactory;
			_dropFactory = dropFactory;
			_staticDataService = staticDataService;
			_dropProvider = dropProvider;
			_randomizer = randomizer;
		}

		public void Die(GameObject gameObject)
		{
			SetRandomDrop();

			CreateDropGameObject(gameObject);

			Destroy(gameObject);
		}

		private void SetRandomDrop()
		{
			int random = _randomizer.NextZeroToHundred();

			DropType randomDrop = random < 70 ? DropType.Helmet : DropType.Ammo;

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