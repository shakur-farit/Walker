using UnityEngine;

namespace Drop
{
	public class DropData : MonoBehaviour
	{
		private int _value;
		private DropType _type;

		public int Value => _value;
		public DropType Type => _type;

		private void Awake()
		{
			_type = DropType.Helmet;
			_value = 2;
		}
	}
}