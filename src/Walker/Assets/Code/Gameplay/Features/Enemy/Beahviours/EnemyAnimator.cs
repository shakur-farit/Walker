using Code.Gameplay.Common.Visuals;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.Features.Enemy
{
	public class EnemyAnimator : MonoBehaviour, IDamageTakenAnimator
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private Transform _takenDamage;
		[SerializeField] private TextMeshProUGUI _takenDamageText;

		private readonly int _isMoving = Animator.StringToHash("isMoving");


		private void Start() => 
			_takenDamage.gameObject.SetActive(false);

		private void OnDestroy()
		{
			DOTween.Kill(_spriteRenderer);
			DOTween.Kill(_takenDamage);
			DOTween.Kill(_takenDamageText);
		}

		public void StartIdling() => _animator.SetBool(_isMoving, false);
		public void StartMoving() => _animator.SetBool(_isMoving, true);


		public void PlayDamageTaken(float value)
		{
			_takenDamage.gameObject.SetActive(true);
			_takenDamageText.text = $"-{value}";

			_takenDamage.transform.localPosition = new(0, 2.3f);
			_takenDamageText.alpha = 1f;

			_spriteRenderer.DOColor(Color.red, 0.1f).OnComplete(() =>
				_spriteRenderer.DOColor(Color.white, 0.1f));

			_takenDamage.DOLocalMoveY(3.1f, 0.8f).SetEase(Ease.OutCubic);
			_takenDamage.DOShakePosition(0.8f, new Vector3(0.3f, 0f, 0f), 
					vibrato: 4, randomness: 10f, snapping: false, fadeOut: true)
				.SetRelative(true);

			_takenDamageText.DOFade(0f, 0.8f).SetEase(Ease.InQuad)
				.OnComplete(() => _takenDamage.gameObject.SetActive(false));
		}

		public void SetRuntimeAnimatorController(RuntimeAnimatorController runtimeAnimatorController) =>
			_animator.runtimeAnimatorController = runtimeAnimatorController;
	}
}