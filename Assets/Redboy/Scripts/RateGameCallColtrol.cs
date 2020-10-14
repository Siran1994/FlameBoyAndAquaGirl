// DecompilerFi decompiler from Assembly-CSharp.dll class: RateGameCallColtrol
// SourcesPostProcessor 
using UnityEngine;

public class RateGameCallColtrol : MonoBehaviour
{
	public GameObject hc;

	public GameObject vc;

	public static RateGameCallColtrol Instance;

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		Instance = this;
	}

	public void CallRate(int index)
	{
		if (index == 1)
		{
			Object.Instantiate(hc);
		}
		else
		{
			Object.Instantiate(vc);
		}
	}
}
