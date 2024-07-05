using System;
using System.Collections.Generic;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterMover : MonoBehaviour
	{
		private float _movementSpeed;

		private IMovementInputService _movementInputService;

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
			}
		}
	}
}
