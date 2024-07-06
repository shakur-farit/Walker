using System;
using UnityEngine;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		private Transform _targetTransform;

		private void Awake()
		{
			//_targetTransform
		}

		private void Aim()
		{
			Vector2 direction = _targetTransform.position - transform.position;

			float angleDegree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);
		}
	}
}
