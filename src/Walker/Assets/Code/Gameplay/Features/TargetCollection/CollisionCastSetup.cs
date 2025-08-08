using System;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection
{
	[Serializable]
	public class CollisionCastSetup
	{
		public Vector2 CastStartPosiotion;
		[Range(0f, 100f)] public float ForwardCastDistance;
		[Range(0f, 100f)] public float Width;
		[Range(0f, 100f)] public float Height;
	}
}