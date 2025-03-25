using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RefinedButton
{
	public class Pressable :
		Interactable,
		IPointerDownHandler,
		IPointerUpHandler,
		IPointerEnterHandler,
		IPointerExitHandler
	{
		private RectTransform _rectTransform;

		private Action<PointerEventData> _pressed;
		private Action<PointerEventData> _released;
		private Action<PointerEventData> _clicked;
		private Action<PointerEventData> _entered;
		private Action<PointerEventData> _exited;
		private Action<bool> _interactableStateChanged;

		public event Action<PointerEventData> Clicked
		{
			add => _clicked += value;
			remove => _clicked -= value;
		}

		public event Action<PointerEventData> Entered
		{
			add => _entered += value;
			remove => _entered -= value;
		}

		public event Action<PointerEventData> Exited
		{
			add => _exited += value;
			remove => _exited -= value;
		}

		public event Action<PointerEventData> Pressed
		{
			add => _pressed += value;
			remove => _pressed -= value;
		}

		public event Action<PointerEventData> Released
		{
			add => _released += value;
			remove => _released -= value;
		}

		public event Action<bool> InteractableStateChanged
		{
			add => _interactableStateChanged += value;
			remove => _interactableStateChanged -= value;
		}

		public bool IsPressing { get; private set; }

		public bool IsEntering { get; private set; }

		protected virtual void OnPressed(PointerEventData eventData)
		{
			_pressed?.Invoke(eventData);
		}

		protected virtual void OnReleased(PointerEventData eventData)
		{
			_released?.Invoke(eventData);
		}

		protected virtual void OnClicked(PointerEventData eventData)
		{
			_clicked?.Invoke(eventData);
		}

		protected virtual void OnEntered(PointerEventData eventData)
		{
			_entered?.Invoke(eventData);
		}

		protected virtual void OnExited(PointerEventData eventData)
		{
			_exited?.Invoke(eventData);
		}

		protected override void OnInteractionStateChanged(bool isInteractable)
		{
			if (!isInteractable)
			{
				if (EventSystem.current is { } eventSystem && eventSystem.currentSelectedGameObject == gameObject)
				{
					eventSystem.SetSelectedGameObject(null);
				}
			}

			_interactableStateChanged?.Invoke(isInteractable);
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			if (!IsInteractable) return;

			if (!IsPressing)
			{
				IsPressing = true;
				OnPressed(eventData);
			}
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (!IsInteractable) return;

			if (IsPressing)
			{
				IsPressing = false;
				OnReleased(eventData);

				if (IsEntering)
				{
					OnClicked(eventData);
				}
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (!IsInteractable) return;

			if (!IsEntering)
			{
				IsEntering = true;
				
				OnEntered(eventData);
			}
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (!IsInteractable) return;

			if (IsEntering)
			{
				IsEntering = false;

				if (IsPressing)
				{
					IsPressing = false;
					OnReleased(eventData);
				}

				OnExited(eventData);
			}
		}
	}
}