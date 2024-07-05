using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		[SerializeField] private CharacterHealth _health;



		public void PickupDrop(DropType dropType, int dropValue)
		{
			AddHealthToCharacter(dropType, dropValue);
		}

		private void AddHealthToCharacter(DropType dropType, int dropValue)
		{
			if (dropType == DropType.Heart)
				_health.AddHealth(dropValue);
		}
	}
}