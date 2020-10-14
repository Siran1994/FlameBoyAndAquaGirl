// DecompilerFi decompiler from Assembly-CSharp.dll class: OpenDoor
// SourcesPostProcessor 
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
	private Animator anim;

	public static bool openFire;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		openFire = false;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && InputManager.IPmanager.redOK)
		{
			anim.SetBool("isOpen", value: true);
			anim.SetBool("isClose", value: false);
			openFire = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			anim.SetBool("isClose", value: true);
			anim.SetBool("isOpen", value: false);
			openFire = false;
		}
	}
}
