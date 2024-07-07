using Character;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class CharacterHealthBar : MonoBehaviour
	{
		[SerializeField] private GameObject _healthBar;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService)
		{
			_persistentProgressService = persistentProgressService;
		}

		private void Awake() => 
			UpdateHealthBar();

		public void UpdateHealthBar()
		{
			float currentHealth = _persistentProgressService.Progress.CharacterData.CurrentHealth;
			float maxHealth = _persistentProgressService.Progress.CharacterData.MaxHealth;

			Vector3 scale = Vector3.one;
			float value = currentHealth / maxHealth;
			scale.x = value;
			_healthBar.transform.localScale = scale;
		}
	}
}