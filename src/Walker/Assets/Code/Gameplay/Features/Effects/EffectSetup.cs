using System;
using UnityEngine;

namespace Code.Gameplay.Features.Effects
{
	[Serializable]
	public class EffectSetup
	{
		public EffectTypeId EffectTypeId;
		[Range(0f, 100f)] public float Value;

		public static EffectSetup FormId(EffectTypeId typeId, float value) =>
			new() { EffectTypeId = typeId, Value = value };
	}
}