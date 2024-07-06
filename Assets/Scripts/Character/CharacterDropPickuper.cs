using DropLogic;
using UnityEngine;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		[SerializeField] private CharacterHealth _health;
		private IDropDeath _dropDeath;

		public void Constructor(IDropDeath dropDeath) => 
			_dropDeath = dropDeath;

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out DropData dropData)) 
				PickupDrop(dropData);
		}

		public void PickupDrop(DropData dropData)
		{
			if (dropData.Type == DropType.Heart)
				AddHealthToCharacter(dropData.Value);

			Debug.Log("Pick");
			DestroyDrop(dropData.gameObject);
		}

		private void AddHealthToCharacter(int dropValue) => 
			_health.AddHealth(dropValue);

		private void DestroyDrop(GameObject drop) => 
			_dropDeath.Die(drop);
	}
}