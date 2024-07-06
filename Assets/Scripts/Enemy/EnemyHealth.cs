using UnityEngine;

namespace Enemy
{
	public class EnemyHealth : MonoBehaviour
	{
		public void TakeDamage(int damage)
		{
			Debug.Log($"{gameObject.name} take {damage} damage");
		}
	}
}