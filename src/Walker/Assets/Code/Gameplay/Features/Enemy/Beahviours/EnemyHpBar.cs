using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyHpBar : MonoBehaviour
	{
		[SerializeField] private Transform _hpBar;

		public void UpdateHpBar(float currentHp, float maxHp)
		{
			if (maxHp <= 0) 
				return;

			float normalized = Mathf.Clamp01((float)currentHp / maxHp);
			Vector3 scale = _hpBar.localScale;
			scale.x = normalized;
			_hpBar.localScale = scale;
		}
	}
}