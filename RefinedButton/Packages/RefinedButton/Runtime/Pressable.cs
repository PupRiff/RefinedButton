using System;
using System.Collections.Generic;
using System.Threading;
using RefinedButton.Internal.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RefinedButton
{
	public class Pressable : MonoBehaviour, IPressable,
		IPointerDownHandler,
		IPointerUpHandler,
		IPointerEnterHandler,
		IPointerExitHandler
	{
		[SerializeField]
		private bool _isAllowedInteraction = true;

		CancellationToken IPressable.DestroyCancellationToken => destroyCancellationToken;

		public event Action Pressed;

		public event Action Released;

		public event Action Clicked;

		public event Action Focused;

		public event Action Unfocused;

		private readonly List<CanvasGroup> _cachedParentCanvasGroups = new();
		private bool _isAllowedInteractionByParentGroup = true;
		private bool _isPressed;
		private bool _isFocused;

		public bool IsAllowedInteract
		{
			get => _isAllowedInteraction;
			set
			{
				if (StructHelper.Exchange(ref _isAllowedInteraction, value)) OnInteractionStateChanged();
			}
		}

		public bool IsPressed => _isPressed;

		public bool IsFocused => _isFocused;

		public virtual bool IsInteractable => _isAllowedInteractionByParentGroup && _isAllowedInteraction;

		private void Press() => Pressed?.Invoke();
		private void Release() => Released?.Invoke();
		private void Click() => Clicked?.Invoke();
		private void Focus() => Focused?.Invoke();
		private void Unfocus() => Unfocused?.Invoke();

		private void CacheParentCanvasGroups()
		{
			GetComponentsInParent(true, _cachedParentCanvasGroups);
		}

		private bool IsAllowedInteractionByParentGroup()
		{
			foreach (var canvasGroup in _cachedParentCanvasGroups)
			{
				if (canvasGroup.enabled && !canvasGroup.interactable) return false;
				if (canvasGroup.ignoreParentGroups) return true;
			}
			return true;
		}

		private void OnInteractionStateChanged()
		{
			if (IsInteractable)
			{
				Focus();
			}
			else
			{
				if (StructHelper.Exchange(ref _isPressed, false)) Release();
				Unfocus();
			}
		}

		protected virtual void Awake()
		{
			CacheParentCanvasGroups();
		}

		private void OnTransformParentChanged()
		{
			CacheParentCanvasGroups();
		}

		private void OnCanvasGroupChanged()
		{
			if (StructHelper.Exchange(ref _isAllowedInteractionByParentGroup, IsAllowedInteractionByParentGroup()))
				OnInteractionStateChanged();
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			if (!IsInteractable || eventData.button != PointerEventData.InputButton.Left) return;
			if (!StructHelper.Exchange(ref _isPressed, true)) return;
			Press();
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (!IsInteractable || eventData.button != PointerEventData.InputButton.Left) return;
			if (!StructHelper.Exchange(ref _isPressed, false)) return;
			Release();
			if (IsFocused) Click();
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (!IsInteractable || !StructHelper.Exchange(ref _isFocused, true)) return;
			Focus();
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (!IsInteractable || !StructHelper.Exchange(ref _isFocused, false)) return;
			if (StructHelper.Exchange(ref _isPressed, false)) Release();
			Unfocus();
		}
	}
}