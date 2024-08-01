using System;
using UnityEngine;

namespace RefinedButton
{
	public class CanvasGroupController : MonoBehaviour
	{
		private CanvasGroup _canvasGroup;

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_canvasGroup.interactable = !_canvasGroup.interactable;
			}
		}
	}
}