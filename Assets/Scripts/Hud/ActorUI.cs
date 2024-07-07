using Character;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class ActorUI : MonoBehaviour
	{
		[SerializeField] private CharacterHealthBar _healthBar;

		private ICharacterHealth _health;

		[Inject]
		public void Constructor(ICharacterHealthProvider provider) => 
			_health = provider.CharacterHealth;

		private void OnEnable() => 
			_health.HealthChanged += UpdateHealthBar;

		private void OnDisable() => 
			_health.HealthChanged -= UpdateHealthBar;

		private void Awake() => 
			UpdateHealthBar();

		private void UpdateHealthBar() => 
			_healthBar.UpdateHealthBar();
	}
}