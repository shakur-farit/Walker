using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, ICharacterHealth
	{
		private int _current;
		private int _max;
		private int _damageTakingCooldown;
		private bool _canTakeDamage;

		private IPersistentProgressService _persistentProgressService;
		private ICharacterDeath _characterDeath;

		[Inject]
		public void Constructor(IPersistentProgressService progressService, ICharacterDeath characterDeath)
		{
			_persistentProgressService = progressService;
			_characterDeath = characterDeath;
		}

		private void Awake()
		{
			_current = 20;
			_damageTakingCooldown = 1000;
			_canTakeDamage = true;
		}

		public void TakeDamage(int damage)
		{
			if (_current <=0)
				return;

			if(_canTakeDamage == false)
				return;

			_current -= damage;

			if (_current <= 0)
			{
				_characterDeath.Die();
				return;
			}

			TakeCooldown();
		}

		public void AddHealth(int value)
		{
			_current += value;

			if(_current > _max)
				_current = _max;
		}

		private async void TakeCooldown()
		{
			_canTakeDamage = false;
			await UniTask.Delay(_damageTakingCooldown);
			_canTakeDamage = true;
		}
	}
}