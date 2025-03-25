#if REFINEDBUTTON_SUPPORT_R3
using System;
using System.Threading;
using R3;
using UnityEngine.EventSystems;

namespace RefinedButton
{
	public static class PressableR3Extensions
	{
		public static Observable<PointerEventData> OnPressAsObservable(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			return pressable.OnEventAsObservableCore<PointerEventData>(h => pressable.Pressed += h, h => pressable.Pressed -= h, cancellationToken);
		}

		public static Observable<PointerEventData> OnReleaseAsObservable(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			return pressable.OnEventAsObservableCore<PointerEventData>(h => pressable.Released += h, h => pressable.Released -= h, cancellationToken);
		}

		public static Observable<PointerEventData> OnClickAsObservable(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			return pressable.OnEventAsObservableCore<PointerEventData>(h => pressable.Clicked += h, h => pressable.Clicked -= h, cancellationToken);
		}

		public static Observable<PointerEventData> OnEnterAsObservable(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			return pressable.OnEventAsObservableCore<PointerEventData>(h => pressable.Entered += h, h => pressable.Entered -= h, cancellationToken);
		}

		public static Observable<PointerEventData> OnExitAsObservable(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			return pressable.OnEventAsObservableCore<PointerEventData>(h => pressable.Exited += h, h => pressable.Exited -= h, cancellationToken);
		}

		public static Observable<bool> OnInteractableStateChangedAsObservable(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			return pressable.OnEventAsObservableCore<bool>(h => pressable.InteractableStateChanged += h, h => pressable.InteractableStateChanged -= h, cancellationToken);
		}

		private static Observable<T> OnEventAsObservableCore<T>(this Pressable pressable, Action<Action<T>> addHandler, Action<Action<T>> removeHandler, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested) return Observable.Empty<T>();

			var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(pressable.destroyCancellationToken, cancellationToken);

			return Observable.FromEvent(addHandler, removeHandler, linkedCts.Token)
				.Do(onDispose: linkedCts.Dispose);
		}
	}
}
#endif