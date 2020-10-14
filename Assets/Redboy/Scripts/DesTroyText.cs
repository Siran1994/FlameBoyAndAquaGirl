// DecompilerFi decompiler from Assembly-CSharp.dll class: DesTroyText
// SourcesPostProcessor 
using UnityEngine;

public class DesTroyText : MonoBehaviour
{
	public int aliveTime;

	private float timeDie;

	private void Start()
	{
	}

	private void Update()
	{
		timeDie += Time.deltaTime;
		if (timeDie >= (float)aliveTime)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
