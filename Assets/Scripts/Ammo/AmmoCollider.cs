using Enemy;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoCollider : MonoBehaviour
	{
		[SerializeField] private BoxCollider2D _collider;

		private int _damage;

		private IAmmoDeath _ammoDeath;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IAmmoDeath ammoDeath, IStaticDataService staticDataService)
		{
			_ammoDeath = ammoDeath;
			_staticDataService = staticDataService;
		}


		private void Awake()
		{
			SetupColliderRadius();

			SetupDamage();
		}

		private void OnTriggerEnter2D(Collider2D other) => 
			TryDealDamageToEnemy(other);

		private void SetupColliderRadius() =>
			_collider.size = _staticDataService.AmmoStaticData.ColliderSize;

		private void SetupDamage() =>
			_damage = _staticDataService.AmmoStaticData.Damage;

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

	public class AmmoView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;


		private void Awake() => 
			_spriteRenderer.sprite = _staticDataService.AmmoStaticData.Sprite;
	}
}