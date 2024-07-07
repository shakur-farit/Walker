using Character;
using UnityEngine;

namespace Drop
{
	public class DropCollider : MonoBehaviour
	{
		[SerializeField] private DropData _dropData;
		[SerializeField] private DropView _dropView;
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.TryGetComponent(out CharacterDropPickuper dropPickuper))
				dropPickuper.PickupDrop(gameObject, _dropData.Type, _dropView.Sprite, _dropData.PackCount, _dropData.Value);
		}
	}
}