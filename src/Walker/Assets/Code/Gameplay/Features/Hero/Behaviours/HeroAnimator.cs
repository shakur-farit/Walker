using Code.Gameplay.Common.Direction;
using Code.Gameplay.Common.Visuals;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Behaviours
{
  public class HeroAnimator : MonoBehaviour, IDamageTakenAnimator
  {
	  [SerializeField] private Animator _animator;
	  [SerializeField] private SpriteRenderer _spriteRenderer;

		private readonly int _isMoving = Animator.StringToHash("isMoving");

		private FacingDirection _currentDirection = FacingDirection.Unknown;

		private void OnDestroy() =>
			DOTween.Kill(_spriteRenderer);

		public void StartIdling() => _animator.SetBool(_isMoving, false);
		public void StartMoving() => _animator.SetBool(_isMoving, true);

		public void PlayDamageTaken() =>
			_spriteRenderer.DOColor(Color.red, 0.1f).OnComplete(() => 
				_spriteRenderer.DOColor(Color.white, 0.1f));
  }
}