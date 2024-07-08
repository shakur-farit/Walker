using UnityEngine;

namespace Hud
{
	public class BarService : IBarService
	{
		public void UpdateBar(float currentValue, float maxValue, GameObject bar)
		{
			Vector3 scale = Vector3.one;
			float value = currentValue / maxValue;
			scale.x = value;
			bar.transform.localScale = scale;
		}
	}
}