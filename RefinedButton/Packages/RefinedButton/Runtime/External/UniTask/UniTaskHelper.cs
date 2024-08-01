#if REFINEDBUTTON_SUPPORT_UNITASK
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace RefinedButton
{
	internal static class UniTaskHelper
	{
		public static async UniTask WaitUntilEventAsync(Action<Action> addHandler, Action<Action> removeHandler,
			CancellationToken cancellationToken = default)
		{
			cancellationToken.ThrowIfCancellationRequested();

			var completionSource = new UniTaskCompletionSource();

			try
			{
				addHandler(Handler);

				await using (cancellationToken.RegisterWithoutCaptureExecutionContext(cs => ((UniTaskCompletionSource)cs).TrySetCanceled(),
					             completionSource))
				{
					await completionSource.Task;
				}
			}
			finally
			{
				removeHandler(Handler);
			}

			return;

			void Handler() => completionSource.TrySetResult();
		}
	}
}
#endif