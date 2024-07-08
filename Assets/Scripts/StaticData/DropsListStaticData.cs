using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	[CreateAssetMenu(fileName = "Drops List Static Data", menuName = "Scriptable Objects/Static Data/List/Drop")]
	public class DropsListStaticData : ScriptableObject
	{
		public List<DropStaticData> DropsList;
	}
}