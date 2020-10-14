// DecompilerFi decompiler from Assembly-CSharp.dll class: buttongSoundControl
// SourcesPostProcessor 
using UnityEngine;
using UnityEngine.UI;

public class buttongSoundControl : MonoBehaviour
{
	public Sprite sprOn;

	public Sprite sprOff;

	private Image _img;

	private void OnEnable()
	{
		_img = GetComponent<Image>();
		if (AudioControl.enbaleSound)
		{
			_img.sprite = sprOn;
		}
		else
		{
			_img.sprite = sprOff;
		}
	}

	public void ClickSound()
	{
		AudioControl.enbaleSound = !AudioControl.enbaleSound;
		if (AudioControl.enbaleSound)
		{
			_img.sprite = sprOn;
			UnityEngine.Debug.Log("theem dong mo am thanh bg vao");
		}
		else
		{
			_img.sprite = sprOff;
			AudioControl.Instance.StopAllSound();
		}
	}
}
