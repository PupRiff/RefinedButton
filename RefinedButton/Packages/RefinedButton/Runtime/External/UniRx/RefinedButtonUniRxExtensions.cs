﻿#if REFINEDBUTTON_SUPPORT_UNIRX
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
		public static IObservable<Unit> OnPressAsObservable(this IRefinedPressable pressable)
		{
			return Observable.FromEvent(h => pressable.Pressed += h, h => pressable.Pressed -= h);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable is released.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable is released.</returns>
		public static IObservable<Unit> OnReleaseAsObservable(this IRefinedPressable pressable)
		{
			return Observable.FromEvent(h => pressable.Released += h, h => pressable.Released -= h);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable is clicked.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable is clicked.</returns>
		public static IObservable<Unit> OnClickAsObservable(this IRefinedPressable pressable)
		{
			return Observable.FromEvent(h => pressable.Clicked += h, h => pressable.Clicked -= h);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable gains focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable gains focus.</returns>
		public static IObservable<Unit> OnFocusAsObservable(this IRefinedPressable pressable)
		{
			return Observable.FromEvent(h => pressable.Focused += h, h => pressable.Focused -= h);
		}

		/// <summary>
		/// Creates an observable that emits when the pressable loses focus.
		/// </summary>
		/// <param name="pressable">The pressable object.</param>
		/// <returns>An observable that emits when the pressable loses focus.</returns>
		public static IObservable<Unit> OnUnfocusAsObservable(this IRefinedPressable pressable)
		{
			return Observable.FromEvent(h => pressable.Unfocused += h, h => pressable.Unfocused -= h);
		}
	}
}
#endif