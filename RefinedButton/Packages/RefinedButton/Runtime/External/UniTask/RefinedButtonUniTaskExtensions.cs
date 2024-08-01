using System.Threading;
using Cysharp.Threading.Tasks;

#if REFINEDBUTTON_SUPPORT_UNITASK
namespace RefinedButton
{
	public static class RefinedButtonUniTaskExtensions
	{
		/// <summary>
		/// Waits until the pressable is pressed.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilPressedAsync(this IPressable pressable, CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Pressed += h, h => pressable.Pressed -= h, cts.Token);
		}

		/// <summary>
		/// Waits until the pressable is released.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilReleasedAsync(this IPressable pressable, CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Released += h, h => pressable.Released -= h, cts.Token);
		}

		/// <summary>
		/// Waits until the pressable is clicked.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilClickedAsync(this IPressable pressable, CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Clicked += h, h => pressable.Clicked -= h, cts.Token);
		}

		/// <summary>
		/// Waits until the pressable gains focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilFocusedAsync(this IPressable pressable, CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Focused += h, h => pressable.Focused -= h, cts.Token);
		}

		/// <summary>
		/// Waits until the pressable loses focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilUnfocusedAsync(this IPressable pressable, CancellationToken cancellationToken = default)
		{
			using var cts = CancellationTokenSource.CreateLinkedTokenSource(pressable.DestroyCancellationToken, cancellationToken);
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Unfocused += h, h => pressable.Unfocused -= h, cts.Token);
		}
	}
}
#endif