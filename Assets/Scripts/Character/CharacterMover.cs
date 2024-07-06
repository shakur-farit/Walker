using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		[SerializeField] private Transform _weaponRotationPoint;

		private float _movementSpeed;

		private IMovementInputService _movementInputService;

		private Vector2 TurnCharacterToLeft => new(-1, 1);
		private Vector2 TurnWeaponToLeft => new(-4, -4);
		private Vector2 TurnCharacterToRight => new(1, 1);
		private Vector2 TurnWeaponToRight => new(4, 4);

		[Inject]
		public void Construct(IMovementInputService movementInputService) => 
			_movementInputService = movementInputService;

		private void OnEnable() => 
			_movementInputService.OnEnable();

		private void OnDestroy() => 
			_movementInputService.OnDisable();

		private void Awake()
		{
			_movementInputService.RegisterMovementInputAction();
			_movementSpeed = 5;
		}

		private void FixedUpdate() => 
			Move();


		private void Move()
		{
			Vector2 movementAxis = _movementInputService.MovementAxis;

			if (movementAxis.sqrMagnitude > Mathf.Epsilon)
			{
				Vector2 movementVector = transform.TransformDirection(movementAxis);
				movementVector.Normalize();
				transform.Translate(movementVector * (_movementSpeed * Time.deltaTime));

				if (movementAxis.x < 0)
				{
					transform.localScale = TurnCharacterToLeft;
					_weaponRotationPoint.localScale = TurnWeaponToLeft;
				}
				else
				{
					transform.localScale = TurnCharacterToRight;
					_weaponRotationPoint.localScale = TurnWeaponToRight;
				}
			}
		}
	}
}
