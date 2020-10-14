// DecompilerFi decompiler from Assembly-CSharp.dll class: openDoorIce
// SourcesPostProcessor 
using UnityEngine;

public class openDoorIce : MonoBehaviour
{
	public static bool openIce;

	private Animator anim;
	private void Awake()
	{
		anim = GetComponent<Animator>();
		openIce = false;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerIce" && InputManager.IPmanager.blueOK)
		{
			anim.SetBool("isOpen", value: true);
			anim.SetBool("isClose", value: false);
			openIce = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "PlayerIce")
		{
			anim.SetBool("isClose", value: true);
			anim.SetBool("isOpen", value: false);
			openIce = false;
		}
	}
}
