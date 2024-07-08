using Character;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyDamager : MonoBehaviour
	{
		private int _damage;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() =>
			_damage = _staticDataService.EnemyStaticData.Damage;

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