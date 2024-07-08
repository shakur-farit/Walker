using Character.Factory;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Camera
{
	public class CharacterFollower : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera _virtualCamera;
		
		private ICharacterFactory _characterFactory;

		[Inject]
		public void Constructor(ICharacterFactory characterFactory) => 
			_characterFactory = characterFactory;

		private void Awake() => 
			_virtualCamera.Follow = _characterFactory.Character.transform;
	}
}
