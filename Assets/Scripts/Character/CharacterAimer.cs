using UnityEngine;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		private Transform _targetTransform;

		private void Update() => 
			Aim();

		public void SetTarget(Transform target) => 
			_targetTransform = target;

		public void ClearTarget() => 
			_targetTransform = null;

		private void Aim()
		{
			float angleDegree = 0f;

			if (_targetTransform == null)
			{
				transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);
				return;
			}

			Vector2 direction = _targetTransform.position - transform.position;
			angleDegree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);
		}
	}
}
