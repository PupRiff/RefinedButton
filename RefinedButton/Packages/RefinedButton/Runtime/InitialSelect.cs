using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace RefinedButton
{
	public class InitialSelect : MonoBehaviour
	{
		private void Start()
		{
			var button = GetComponent<Button>();
			Assert.IsNotNull(button, "button != null");
			button.Select();
		}
	}
}