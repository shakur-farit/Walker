using Character;
using Character.Factory;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Enemy
{
	public class EnemyMover : MonoBehaviour
	{
		[SerializeField] private Transform _body;

		private float _movementSpeed;
		private float _detectRadius;
		private GameObject _target;

		private ICharacterFactory _characterFactory;
		private IStaticDataService _staticDataService;

		private Vector2 TurnCharacterToLeft => new(-1, 1);
		private Vector2 TurnCharacterToRight => new(1, 1);

		[Inject]
		public void Constructor(ICharacterFactory characterFactory, IStaticDataService staticDataService)
		{
			_characterFactory = characterFactory;
			_staticDataService = staticDataService;
		}

		private void Awake()
		{
			_target = _characterFactory.Character;
			_movementSpeed = _staticDataService.EnemyStaticData.MovementSpeed;
			_detectRadius = _staticDataService.EnemyStaticData.CharcterDetectRange;
		}

		private void Update() => 
			Move();


		private void Move()
		{
			if (_target == null)
				return;

			Vector3 difference = transform.position - _target.transform.position;
			float distanceSquared = difference.sqrMagnitude;
			float distance = Mathf.Sqrt(distanceSquared);

			if(distance > _detectRadius)
				return;

			if (distance < Mathf.Epsilon)
				return;

			Vector2 targetPosition = _target.transform.position;
			Vector2 enemyPosition = transform.position;

			Vector2 direction = targetPosition - enemyPosition;

			direction.Normalize();

			enemyPosition = Vector2.MoveTowards(enemyPosition,
				targetPosition, _movementSpeed * Time.deltaTime);

			_body.localScale = direction.x < 0 ? TurnCharacterToLeft : TurnCharacterToRight;

			transform.position = enemyPosition;
		}
	}
}
