#if REFINEDBUTTON_SUPPORT_UNIRX
using System;
using UniRx;

namespace RefinedButton
{
	public static class RefinedButtonUniRxExtensions
	{
		/// <summary>
		/// Creates an observable that emits when the pressable is pressed.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable is pressed.</returns>
		public static IObservable<Unit> OnPressAsObservable(this IPressable pressable)
		{
			var cancelToken = pressable.DestroyCancellationToken;
			return UniRxHelper.FromEventWithCancellation(h => pressable.Pressed += h, h => pressable.Pressed -= h, cancelToken);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable is released.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable is released.</returns>
		public static IObservable<Unit> OnReleaseAsObservable(this IPressable pressable)
		{
			var cancelToken = pressable.DestroyCancellationToken;
			return UniRxHelper.FromEventWithCancellation(h => pressable.Released += h, h => pressable.Released -= h, cancelToken);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable is clicked.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable is clicked.</returns>
		public static IObservable<Unit> OnClickAsObservable(this IPressable pressable)
		{
			var cancelToken = pressable.DestroyCancellationToken;
			return UniRxHelper.FromEventWithCancellation(h => pressable.Clicked += h, h => pressable.Clicked -= h, cancelToken);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable gains focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable gains focus.</returns>
		public static IObservable<Unit> OnFocusAsObservable(this IPressable pressable)
		{
			var cancelToken = pressable.DestroyCancellationToken;
			return UniRxHelper.FromEventWithCancellation(h => pressable.Focused += h, h => pressable.Focused -= h, cancelToken);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable loses focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable loses focus.</returns>
		public static IObservable<Unit> OnUnfocusAsObservable(this IPressable pressable)
		{
			var cancelToken = pressable.DestroyCancellationToken;
			return UniRxHelper.FromEventWithCancellation(h => pressable.Unfocused += h, h => pressable.Unfocused -= h, cancelToken);
		}
	}
}
#endif