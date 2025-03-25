using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace RefinedButton
{
	public class RefinedButton : Pressable
	{
		private readonly static int PressedAnimatorTrigger = Animator.StringToHash("Pressed");
		private readonly static int ReleasedAnimatorTrigger = Animator.StringToHash("Released");
		private readonly static int ClickedAnimatorTrigger = Animator.StringToHash("Clicked");
		private readonly static int EnteredAnimatorTrigger = Animator.StringToHash("Entered");
		private readonly static int ExitedAnimatorTrigger = Animator.StringToHash("Exited");

		[SerializeField]
		private Animator _animator = null!;

		private void Start()
		{
			Assert.IsNotNull(_animator, nameof(_animator));
		}

		protected override void OnPressed(PointerEventData eventData)
		{
			base.OnPressed(eventData);
			_animator.SetTrigger(PressedAnimatorTrigger);
		}

		protected override void OnReleased(PointerEventData eventData)
		{
			base.OnReleased(eventData);
			_animator.SetTrigger(ReleasedAnimatorTrigger);
		}

		protected override void OnClicked(PointerEventData eventData)
		{
			base.OnClicked(eventData);
			_animator.SetTrigger(ClickedAnimatorTrigger);
		}

		protected override void OnEntered(PointerEventData eventData)
		{
			base.OnEntered(eventData);
			_animator.SetTrigger(EnteredAnimatorTrigger);
		}

		protected override void OnExited(PointerEventData eventData)
		{
			base.OnExited(eventData);
			_animator.SetTrigger(ExitedAnimatorTrigger);
		}
	}
}