using Drop.Factory;
using Enemy.Factory;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyDeath : IEnemyDeath
	{
		private IEnemyFactory _enemyFactory;
		private IDropFactory _dropFactory;

		[Inject]
		public void Constructor(IEnemyFactory enemyFactory, IDropFactory dropFactory)
		{
			_enemyFactory = enemyFactory;
			_dropFactory = dropFactory;
		}

		public void Die(GameObject gameObject)
		{
			_dropFactory.Create(gameObject.transform.position);
			Destroy(gameObject);
		}

		private void Destroy(GameObject gameObject) => 
			_enemyFactory.Destroy(gameObject);
	}
}