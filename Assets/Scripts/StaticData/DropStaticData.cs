using Drop;
using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Drop Static Data", menuName = "Scriptable Objects/Static Data/Drop")]
	public class DropStaticData : ScriptableObject
	{
		public DropType Type;
		public Sprite Sprite;
		public int PackCount;
		public int Value;
	}
}