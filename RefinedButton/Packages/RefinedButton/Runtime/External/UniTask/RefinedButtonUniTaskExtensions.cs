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
		public static UniTask WaitUntilPressedAsync(this IRefinedPressable pressable, CancellationToken cancellationToken = default)
		{
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Pressed += h, h => pressable.Pressed -= h, cancellationToken);
		}
		
		/// <summary>
		/// Waits until the pressable is released.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilReleasedAsync(this IRefinedPressable pressable, CancellationToken cancellationToken = default)
		{
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Released += h, h => pressable.Released -= h, cancellationToken);
		}
		
		/// <summary>
		/// Waits until the pressable is clicked.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilClickedAsync(this IRefinedPressable pressable, CancellationToken cancellationToken = default)
		{
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Clicked += h, h => pressable.Clicked -= h, cancellationToken);
		}
		
		/// <summary>
		/// Waits until the pressable gains focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilFocusedAsync(this IRefinedPressable pressable, CancellationToken cancellationToken = default)
		{
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Focused += h, h => pressable.Focused -= h, cancellationToken);
		}
		
		/// <summary>
		/// Waits until the pressable loses focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		public static UniTask WaitUntilUnfocusedAsync(this IRefinedPressable pressable, CancellationToken cancellationToken = default)
		{
			return UniTaskHelper.WaitUntilEventAsync(h => pressable.Unfocused += h, h => pressable.Unfocused -= h, cancellationToken);
		}
	}
}
#endif