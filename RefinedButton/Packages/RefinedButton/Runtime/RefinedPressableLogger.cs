using UnityEngine;
using UnityEngine.Assertions;

namespace RefinedButton
{
	public class RefinedPressableLogger : MonoBehaviour
	{
		private void Start()
		{
			var pressable = GetComponent<IPressable>();
			Assert.IsNotNull(pressable, "pressable != null");

			pressable.Pressed += () => Debug.Log("Pressed");
			pressable.Released += () => Debug.Log("Released");
			pressable.Clicked += () => Debug.Log("Clicked");
			pressable.Focused += () => Debug.Log("Focused");
			pressable.Unfocused += () => Debug.Log("Unfocused");
		}
	}
}