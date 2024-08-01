#if REFINEDBUTTON_SUPPORT_UNIRX
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;

namespace RefinedButton
{
	internal static class UniRxHelper
	{
		public static IObservable<Unit> FromEventWithCancellation(Action<Action> addHandler, Action<Action> removeHandler,
			CancellationToken cancellationToken)
		{
			if (!cancellationToken.CanBeCanceled)
				throw new ArgumentException("The cancellation token must be cancellable.", nameof(cancellationToken));
			if (cancellationToken.IsCancellationRequested) return Observable.Empty<Unit>();

			var subject = new Subject<Unit>();

			addHandler(Handler);

			cancellationToken.RegisterWithoutCaptureExecutionContext(() =>
			{
				subject.OnCompleted();
				removeHandler(Handler);
			});

			return subject.AsObservable();

			void Handler() => subject.OnNext(Unit.Default);
		}
	}
}
#endif