// DecompilerFi decompiler from Assembly-CSharp.dll class: LoadingScenesControll
// SourcesPostProcessor 
using UnityEngine;

public class LoadingScenesControll : MonoBehaviour
{
	public string NextScenes;

	private float countTime = 5f;

	private void OnEnable()
	{
		countTime = 5f;
	}

	private void Update()
	{
		countTime -= Time.unscaledDeltaTime;
		if (countTime <= 0f)
		{
			countTime = 150f;
			Next();
		}
	}

	private void Next()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(NextScenes);
	}
}
