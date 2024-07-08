using Character;
using UnityEngine;
using Zenject;

namespace Drop
{
	public class DropData : MonoBehaviour
	{
		private DropType _type;
		private int _packCount;
		private int _value;

		private IDropProvider _provider;

		[Inject]
		public void Constructor(IDropProvider provider) => 
			_provider = provider;

		public DropType Type => _type;
		public int PackCount => _packCount;
		public int Value => _value;

		private void Awake()
		{
			DropStaticData dropStaticData = _provider.StaticData;

			_type = dropStaticData.Type;
			_packCount = dropStaticData.PackCount;
			_value = dropStaticData.Value;
		}
	}
}