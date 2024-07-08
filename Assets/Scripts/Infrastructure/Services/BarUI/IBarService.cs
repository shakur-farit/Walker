using UnityEngine;

namespace Hud
{
	public interface IBarService
	{
		void UpdateBar(float currentValue, float maxValue, GameObject bar);
	}
}