using Code.Infrastructure.View;
using Entitas;
using UnityEngine;

namespace Code.Common
{
	[Game] public class View : IComponent { public IEntityView Value; }
	[Game] public class ViewPath : IComponent { public string Value; }
	[Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
	[Game] public class ViewParent : IComponent { public Transform Value; }

	[Game, Meta, Input] public class Destructed : IComponent { }
	[Game] public class SelfDestructedTimer : IComponent { public float Value; }

	[Game] public class Parented : IComponent { }
	[Game] public class Unparented : IComponent { }
}