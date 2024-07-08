using UnityEngine;
using Zenject;

namespace Drop
{
	public class DropView : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		private IDropProvider _dropProvider;

		[Inject]
		public void Construct(IDropProvider dropProvider) => 
			_dropProvider = dropProvider;

		private void Awake() =>
			_spriteRenderer.sprite = _dropProvider.StaticData.Sprite;
	}
}