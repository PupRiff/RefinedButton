#if REFINEDBUTTON_SUPPORT_UNITASK
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.EventSystems;

namespace RefinedButton
{
	public static class RefinedButtonUniTaskExtensions
	{
		public static async UniTask WaitUntilPressAsync(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			await pressable.WaitUntilEventCoreAsync<PointerEventData>(h => pressable.Pressed += h, h => pressable.Pressed -= h, cancellationToken);
		}

		public static async UniTask WaitUntilReleaseAsync(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			await pressable.WaitUntilEventCoreAsync<PointerEventData>(h => pressable.Released += h, h => pressable.Released -= h, cancellationToken);
		}

		public static async UniTask WaitUntilClickAsync(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			await pressable.WaitUntilEventCoreAsync<PointerEventData>(h => pressable.Clicked += h, h => pressable.Clicked -= h, cancellationToken);
		}

		public static async UniTask WaitUntilEnterAsync(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			await pressable.WaitUntilEventCoreAsync<PointerEventData>(h => pressable.Entered += h, h => pressable.Entered -= h, cancellationToken);
		}

		public static async UniTask WaitUntilExitAsync(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			await pressable.WaitUntilEventCoreAsync<PointerEventData>(h => pressable.Exited += h, h => pressable.Exited -= h, cancellationToken);
		}

		public static async UniTask WaitUntilInteractableStateChangedAsync(this Pressable pressable, CancellationToken cancellationToken = default)
		{
			await pressable.WaitUntilEventCoreAsync<bool>(h => pressable.InteractableStateChanged += h, h => pressable.InteractableStateChanged -= h, cancellationToken);
		}

		private static async UniTask<T> WaitUntilEventCoreAsync<T>(this Pressable pressable, Action<Action<T>> addHandler, Action<Action<T>> removeHandler, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(pressable.destroyCancellationToken, cancellationToken);

			var completionSource = AutoResetUniTaskCompletionSource<T>.Create();
			addHandler(Handler);

			try
			{
				return await completionSource.Task.AttachExternalCancellation(linkedCts.Token);
			}
			catch (Exception ex)
			{
				completionSource.TrySetException(ex);
				throw;
			}
			finally
			{
				removeHandler(Handler);
			}

			void Handler(T value)
			{
				completionSource.TrySetResult(value);
			}
		}
	}
}
#endif