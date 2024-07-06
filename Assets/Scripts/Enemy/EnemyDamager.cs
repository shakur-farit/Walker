using Character;
using UnityEngine;

namespace Enemy
{
	public class EnemyDamager : MonoBehaviour
	{
		private int _damage;

		private void Awake() =>
			_damage = 2;

		private void OnTriggerEnter2D(Collider2D other) => 
			TryDealDamage(other);

		private void OnTriggerStay2D(Collider2D other) => 
			TryDealDamage(other);

		private void TryDealDamage(Collider2D other)
		{
			if (other.gameObject.TryGetComponent(out ICharacterHealth characterHealth)) 
				DealDamage(characterHealth);
		}

		private void DealDamage(ICharacterHealth characterHealth) => 
			characterHealth.TakeDamage(_damage);
	}
}