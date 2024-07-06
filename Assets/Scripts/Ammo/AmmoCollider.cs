using Enemy;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoCollider : MonoBehaviour
	{
		[SerializeField] private BoxCollider2D _collider;

		private int _damage;

		private IAmmoDeath _ammoDeath;

		[Inject]
		public void Constructor(IAmmoDeath ammoDeath) => 
			_ammoDeath = ammoDeath;


		private void Awake()
		{
			SetupColliderRadius();

			SetupDamage();
		}

		private void OnTriggerEnter2D(Collider2D other) => 
			TryDealDamageToEnemy(other);

		private void SetupColliderRadius() =>
			_collider.size = new Vector2(0.15f, 0.03f);

		private void SetupDamage() =>
			_damage = 5;

		private void TryDealDamageToEnemy(Collider2D other)
		{
			if (other.gameObject.TryGetComponent(out IEnemyHealth enemyHealth))
				DealDamageToEnemy(enemyHealth);
		}

		private void DealDamageToEnemy(IEnemyHealth enemyHealth)
		{
			enemyHealth.TakeDamage(_damage);
			DestroyAmmo();
		}

		private void DestroyAmmo() => 
			_ammoDeath.Die(gameObject);
	}
}