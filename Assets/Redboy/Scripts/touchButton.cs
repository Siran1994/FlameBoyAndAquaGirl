// DecompilerFi decompiler from Assembly-CSharp.dll class: touchButton
// SourcesPostProcessor 
using UnityEngine;

public class touchButton : MonoBehaviour
{
	private bool pressedDown;

	private bool pressedLastFrame;

	public InputManager.ButtonState CurrentState;

	public void PressDown()
	{
		pressedDown = true;
	}

	public void Release()
	{
		pressedDown = false;
	}

	private void Update()
	{
		if (pressedDown)
		{
			if (pressedLastFrame)
			{
				CurrentState = InputManager.ButtonState.Held;
			}
			else
			{
				CurrentState = InputManager.ButtonState.PressedDown;
			}
		}
		else if (pressedLastFrame)
		{
			CurrentState = InputManager.ButtonState.Released;
		}
		else
		{
			CurrentState = InputManager.ButtonState.None;
		}
	}

	private void LateUpdate()
	{
		pressedLastFrame = pressedDown;
	}
}
