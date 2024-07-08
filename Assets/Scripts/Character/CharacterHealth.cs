using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
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
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IPersistentProgressService progressService, ICharacterDeath characterDeath,
			ICharacterHealthProvider provider, IStaticDataService staticDataService)
		{
			_persistentProgressService = progressService;
			_characterDeath = characterDeath;
			_provider = provider;
			_staticDataService = staticDataService;
		}

		private void Awake() => 
			SetStartData();

		private void SetStartData()
		{
			_current = _staticDataService.CharacterStaticData.StartHealth;
			_max = _staticDataService.CharacterStaticData.MaxHealth;

			_persistentProgressService.Progress.CharacterData.MaxHealth = _max;
			_persistentProgressService.Progress.CharacterData.CurrentHealth = _current;

			_damageTakingCooldown = _staticDataService.CharacterStaticData.DamageTakingCooldown;
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

		private async void TakeCooldown()
		{
			_canTakeDamage = false;
			await UniTask.Delay(_damageTakingCooldown);
			_canTakeDamage = true;
		}
	}
}