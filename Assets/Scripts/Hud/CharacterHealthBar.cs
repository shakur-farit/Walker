using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class CharacterHealthBar : MonoBehaviour
	{
		[SerializeField] private GameObject _healthBar;

		private IPersistentProgressService _persistentProgressService;
		private IBarService _barService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IBarService barService)
		{
			_persistentProgressService = persistentProgressService;
			_barService = barService;
		}

		private void Awake() =>
			UpdateHealthBar();

		public void UpdateHealthBar()
		{
			float currentHealth = _persistentProgressService.Progress.CharacterData.CurrentHealth;
			float maxHealth = _persistentProgressService.Progress.CharacterData.MaxHealth;

			_barService.UpdateBar(currentHealth, maxHealth, _healthBar);
		}
	}
}