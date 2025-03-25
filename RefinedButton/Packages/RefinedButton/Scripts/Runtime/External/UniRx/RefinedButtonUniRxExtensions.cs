#if REFINEDBUTTON_SUPPORT_UNIRX
using System;
using UniRx;
using UnityEngine.EventSystems;

namespace RefinedButton
{
	public static class RefinedButtonUniRxExtensions
	{
		public static IObservable<PointerEventData> OnPressAsObservable(this Pressable pressable)
		{
			return OnEventAsObservableCore<PointerEventData>(h => pressable.Pressed += h, h => pressable.Pressed -= h);
		}

		public static IObservable<PointerEventData> OnReleaseAsObservable(this Pressable pressable)
		{
			return OnEventAsObservableCore<PointerEventData>(h => pressable.Released += h, h => pressable.Released -= h);
		}

		public static IObservable<PointerEventData> OnClickAsObservable(this Pressable pressable)
		{
			return OnEventAsObservableCore<PointerEventData>(h => pressable.Clicked += h, h => pressable.Clicked -= h);
		}

		public static IObservable<PointerEventData> OnEnterAsObservable(this Pressable pressable)
		{
			return OnEventAsObservableCore<PointerEventData>(h => pressable.Entered += h, h => pressable.Entered -= h);
		}

		public static IObservable<PointerEventData> OnExitAsObservable(this Pressable pressable)
		{
			return OnEventAsObservableCore<PointerEventData>(h => pressable.Exited += h, h => pressable.Exited -= h);
		}

		public static IObservable<bool> OnInteractableStateChangedAsObservable(this Pressable pressable)
		{
			return OnEventAsObservableCore<bool>(h => pressable.InteractableStateChanged += h, h => pressable.InteractableStateChanged -= h);
		}

		private static IObservable<T> OnEventAsObservableCore<T>(Action<Action<T>> addHandler, Action<Action<T>> removeHandler)
		{
			return Observable.FromEvent(addHandler, removeHandler);
		}
	}
}
#endif