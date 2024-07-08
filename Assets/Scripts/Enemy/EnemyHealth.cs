using System;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour, IEnemyHealth
	{
		public event Action HealthChanged;

		private IEnemyDeath _enemyDeath;
		private IStaticDataService _staticDataService;

		public int Current { get; private set; }
		public int Max { get; private set; }

		[Inject]
		public void Constructor(IEnemyDeath enemyDeath, IStaticDataService staticDataService)
		{
			_enemyDeath = enemyDeath;
			_staticDataService = staticDataService;
		}

		private void Awake()
		{
			Current = _staticDataService.EnemyStaticData.StartHealth;
			Max = _staticDataService.EnemyStaticData.MaxHealth;
		}

		public void TakeDamage(int damage)
		{
			if(Current <= 0)
				return;

			Current -= damage;
			HealthChanged?.Invoke();

			if ( Current <= 0 )
				_enemyDeath.Die(gameObject);
		}
	}
}