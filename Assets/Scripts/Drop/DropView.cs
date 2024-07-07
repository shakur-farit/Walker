using UnityEngine;

namespace Drop
{
	public class DropView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private Sprite _sprite;

		public Sprite Sprite => _sprite;

		private void Awake() => 
			_spriteRenderer.sprite = _sprite;
	}
}