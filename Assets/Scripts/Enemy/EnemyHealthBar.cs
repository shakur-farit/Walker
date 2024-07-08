using Hud;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyHealthBar : MonoBehaviour
	{
		[SerializeField] private GameObject _healthBar;
		[SerializeField] private EnemyHealth _health;

		private IBarService _barService;

		[Inject]
		public void Constructor(IBarService barService) => 
			_barService = barService;

		private void OnEnable() =>
			_health.HealthChanged += UpdateHealthBar;

		private void OnDisable() =>
			_health.HealthChanged -= UpdateHealthBar;


		private void Awake() =>
			UpdateHealthBar();

		public void UpdateHealthBar()
		{
			float currentHealth = _health.Current;
			float maxHealth = _health.Max;

			_barService.UpdateBar(currentHealth, maxHealth, _healthBar);
		}
	}
}