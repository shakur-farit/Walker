using Ammo.Factory;
using Character;
using UnityEngine;
using Zenject;

namespace DropLogic
{
	public class DropData : MonoBehaviour
	{
		private int _value;
		private DropType _type;

		public int Value => _value;
		public DropType Type => _type;

		private void Awake()
		{
			_type = DropType.Heart;
			_value = 2;
		}
	}
}