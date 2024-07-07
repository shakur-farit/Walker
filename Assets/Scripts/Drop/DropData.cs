using UnityEngine;

namespace Drop
{
	public class DropData : MonoBehaviour
	{
		private DropType _type;
		private int _packCount;
		private int _value;

		public DropType Type => _type;
		public int PackCount => _packCount;
		public int Value => _value;

		private void Awake()
		{
			_type = DropType.Helmet;
			_packCount = 5;
			_value = 2;
		}
	}
}