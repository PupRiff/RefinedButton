using System;
using System.Threading;

namespace RefinedButton
{
	/// <summary>
	/// Interface for a pressable object.
	/// </summary>
	public interface IPressable
	{
		internal CancellationToken DestroyCancellationToken { get; }

		/// <summary>Whether the pressable is allowed to interact.</summary>
		bool IsAllowedInteract { get; set; }

		/// <summary>Whether the pressable is interactable.</summary>
		bool IsInteractable { get; }

		/// <summary>Event that is triggered when the pressable is pressed.</summary>
		event Action Pressed;

		/// <summary>Event that is triggered when the pressable is released.</summary>
		event Action Released;

		/// <summary>Event that is triggered when the pressable is clicked.</summary>
		event Action Clicked;

		/// <summary>
		/// Event that is triggered when the pressable gains focus, either by pointer entering its area,
		/// touch input, or becoming the main target for user interaction (e.g., keyboard focus).
		/// </summary>
		event Action Focused;

		/// <summary>
		/// Event that is triggered when the pressable loses focus, either by pointer exiting its area,
		/// touch input, or another object becoming the main target for user interaction (e.g., keyboard focus).
		/// </summary>
		event Action Unfocused;
	}
}