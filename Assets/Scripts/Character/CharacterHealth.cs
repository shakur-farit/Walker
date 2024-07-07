using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterHealth : MonoBehaviour, ICharacterHealth
	{
		public event Action HealthChanged;

		private int _current;
		private int _max;
		private int _damageTakingCooldown;
		private bool _canTakeDamage;

		private IPersistentProgressService _persistentProgressService;
		private ICharacterDeath _characterDeath;
		private ICharacterHealthProvider _provider;

		[Inject]
		public void Constructor(IPersistentProgressService progressService, ICharacterDeath characterDeath, ICharacterHealthProvider provider)
		{
			_persistentProgressService = progressService;
			_characterDeath = characterDeath;
			_provider = provider;
		}

		private void Awake()
		{
			_current = 20;
			_max = 20;

			_persistentProgressService.Progress.CharacterData.MaxHealth = _max;
			_persistentProgressService.Progress.CharacterData.CurrentHealth = _current;

			_damageTakingCooldown = 1000;
			_canTakeDamage = true;

			_provider.CharacterHealth = this;
		}

		public void TakeDamage(int damage)
		{
			if (_current <= 0 || !_canTakeDamage)
				return;

			_current -= damage;

			if (_current < 0)
				_current = 0;

			_persistentProgressService.Progress.CharacterData.CurrentHealth = _current;
			HealthChanged?.Invoke();

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

			if (_current > _max)
				_current = _max;

			_persistentProgressService.Progress.CharacterData.CurrentHealth = _current;
			HealthChanged?.Invoke();
		}

		private async void TakeCooldown()
		{
			_canTakeDamage = false;
			await UniTask.Delay(_damageTakingCooldown);
			_canTakeDamage = true;
		}
	}
}