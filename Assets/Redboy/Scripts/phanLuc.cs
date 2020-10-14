// DecompilerFi decompiler from Assembly-CSharp.dll class: phanLuc
// SourcesPostProcessor 
using UnityEngine;

public class phanLuc : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		other.gameObject.transform.position += new Vector3(0f, 10f, 0f) * Time.smoothDeltaTime;
		UnityEngine.Debug.Log(1);
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		other.gameObject.transform.position += new Vector3(0f, 10f, 0f) * Time.smoothDeltaTime;
		UnityEngine.Debug.Log(2);
	}
}
