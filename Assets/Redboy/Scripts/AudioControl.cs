// DecompilerFi decompiler from Assembly-CSharp.dll class: AudioControl
// SourcesPostProcessor 
//using DarkTonic.MasterAudio;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
	public static AudioControl Instance;

	public static bool enbaleSound = true;
    
	private void Awake()
	{
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	public void OpenSound(string name)
	{
		if (enbaleSound)
		{
//			MasterAudio.PlaySound(name);
		}
	}

	public void StopSound(string name)
	{
//		MasterAudio.StopAllOfSound(name);
	}

	public void StopAllSound()
	{
//		MasterAudio.StopEverything();
	}
}
