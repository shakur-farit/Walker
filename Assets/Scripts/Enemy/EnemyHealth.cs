using System;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour, IEnemyHealth
	{
		public event Action HealthChanged;

		private int _current;

		private IEnemyDeath _enemyDeath;

		[Inject]
		public void Constructor(IEnemyDeath enemyDeath) => 
			_enemyDeath = enemyDeath;

		private void Awake() =>
			_current = 10;

		public void TakeDamage(int damage)
		{
			if(_current <= 0)
				return;

			_current -= damage;

			if ( _current <= 0 )
				_enemyDeath.Die(gameObject);
		}
	}
}