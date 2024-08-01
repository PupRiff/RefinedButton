#if REFINEDBUTTON_SUPPORT_R3
using System.Threading;
using R3;

namespace RefinedButton
{
	public static class RefinedButtonR3Extensions
	{
		/// <summary>
		/// Creates an observable that emits when the pressable is pressed.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An observable that emits when the pressable is pressed.</returns>
		public static Observable<Unit> OnPressAsObservable(this IPressable pressable,
			CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return Observable.FromEvent(h => pressable.Pressed += h, h => pressable.Pressed -= h, cts.Token);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable is released.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An observable that emits when the pressable is released.</returns>
		public static Observable<Unit> OnReleaseAsObservable(this IPressable pressable,
			CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return Observable.FromEvent(h => pressable.Released += h, h => pressable.Released -= h, cts.Token);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable is clicked.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An observable that emits when the pressable is clicked.</returns>
		public static Observable<Unit> OnClickAsObservable(this IPressable pressable,
			CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return Observable.FromEvent(h => pressable.Clicked += h, h => pressable.Clicked -= h, cts.Token);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable gains focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An observable that emits when the pressable gains focus.</returns>
		public static Observable<Unit> OnFocusAsObservable(this IPressable pressable,
			CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return Observable.FromEvent(h => pressable.Focused += h, h => pressable.Focused -= h, cts.Token);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable loses focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>An observable that emits when the pressable loses focus.</returns>
		public static Observable<Unit> OnUnfocusAsObservable(this IPressable pressable,
			CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return Observable.FromEvent(h => pressable.Unfocused += h, h => pressable.Unfocused -= h, cts.Token);
		}
	}
}
#endif