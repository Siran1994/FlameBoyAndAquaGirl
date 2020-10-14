// DecompilerFi decompiler from Assembly-CSharp.dll class: KimCuong
// SourcesPostProcessor 
using UnityEngine;

public class KimCuong : MonoBehaviour
{
	public int typeD;

	public AudioSource audioDiamond;

	private void Start()
	{
		if (typeD == 0)
		{
			InputManager.IPmanager.InitKc(0);
		}
		if (typeD == 1)
		{
			InputManager.IPmanager.InitKc(1);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (typeD == 0 && other.gameObject.tag == "PlayerIce")
		{
			InputManager.IPmanager.DestroyKimcuong(0);
			audioDiamond.Play();
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (typeD == 1 && other.gameObject.tag == "Player")
		{
			InputManager.IPmanager.DestroyKimcuong(1);
			audioDiamond.Play();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
