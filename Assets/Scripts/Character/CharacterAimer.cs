using UnityEngine;

namespace Character
{
	public class CharacterAimer : MonoBehaviour
	{
		private void Aim()
		{
			Vector2 aimVector = new Vector2();
			float angleDegree = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angleDegree, Vector3.forward);
		}
	}
}
