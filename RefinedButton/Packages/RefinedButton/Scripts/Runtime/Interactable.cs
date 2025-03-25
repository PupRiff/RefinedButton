using UnityEngine;

namespace RefinedButton
{
	public abstract class Interactable : MonoBehaviour
	{
		[SerializeField]
		private bool _isInteractable = true;

		private bool _isInteractableInHierarchy;

		public bool IsInteractable
		{
			get => _isInteractable;
			set => SetInteractable(value);
		}

		public bool IsInteractableInHierarchy => _isInteractable && _isInteractableInHierarchy;

		protected abstract void OnInteractionStateChanged(bool isInteractable);

		private void SetInteractable(bool interactable)
		{
			if (_isInteractable == interactable) return;
			_isInteractable = interactable;

			if (_isInteractableInHierarchy)
			{
				OnInteractionStateChanged(IsInteractableInHierarchy);
			}
		}

		private void UpdateInteractableInHierarchy()
		{
			var interactableInHierarchy = DetermineInteractionStateInHierarchy();

			if (_isInteractableInHierarchy == interactableInHierarchy) return;
			_isInteractableInHierarchy = interactableInHierarchy;

			if (_isInteractable)
			{
				OnInteractionStateChanged(IsInteractableInHierarchy);
			}
		}

		private bool DetermineInteractionStateInHierarchy()
		{
			var currentTransform = transform;

			while (currentTransform != null)
			{
				if (currentTransform.TryGetComponent(out CanvasGroup canvasGroup))
				{
					if (canvasGroup.enabled && !canvasGroup.interactable) return false;
					if (canvasGroup.ignoreParentGroups) return true;
				}

				currentTransform = currentTransform.parent;
			}

			return true;
		}

		protected virtual void Awake()
		{
			UpdateInteractableInHierarchy();
		}

		protected virtual void OnTransformParentChanged()
		{
			UpdateInteractableInHierarchy();
		}

		protected virtual void OnCanvasGroupChanged()
		{
			UpdateInteractableInHierarchy();
		}

		protected virtual void OnValidate()
		{
			if (_isInteractableInHierarchy)
			{
				OnInteractionStateChanged(IsInteractableInHierarchy);
			}
		}
	}
}