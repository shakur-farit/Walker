using Drop;
using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Drop Static Data", menuName = "Scriptable Objects/Static Data/Drop")]
	public class DropStaticData : ScriptableObject
	{
		public DropType Type;
		public Sprite Sprite;
		[Range(1, 100)] public int PackCount;
		[Range(1, 100)] public int Value;
	}
}