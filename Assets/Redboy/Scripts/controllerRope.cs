// DecompilerFi decompiler from Assembly-CSharp.dll class: controllerRope
// SourcesPostProcessor 
using UnityEngine;

public class controllerRope : MonoBehaviour
{
	public GameObject Rope;

	public Transform pos1;

	public Transform pos2;

	public Transform pos1nut;

	public Transform pos2nut;

	public GameObject nutbam;

	public static bool down;

	public static bool down1;

	public static bool down2;

	private void Start()
	{
		pos1.parent = null;
		pos2.parent = null;
		pos1nut.parent = null;
		pos2nut.parent = null;
		down = false;
		down1 = false;
		down2 = false;
	}

	private void Update()
	{
		if (!down1 && !down2)
		{
			down = false;
		}
		if (down1 || down2)
		{
			down = true;
		}
		if (down)
		{
			Rope.transform.position = Vector3.MoveTowards(Rope.transform.position, pos2.transform.position, Time.deltaTime);
			nutbam.transform.position = Vector3.MoveTowards(nutbam.transform.position, pos2nut.transform.position, Time.deltaTime);
		}
		if (!down)
		{
			Rope.transform.position = Vector3.MoveTowards(Rope.transform.position, pos1.transform.position, Time.deltaTime);
			nutbam.transform.position = Vector3.MoveTowards(nutbam.transform.position, pos1nut.transform.position, Time.deltaTime);
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			down1 = true;
		}
		if (other.gameObject.tag == "PlayerIce")
		{
			down2 = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			down1 = false;
		}
		if (other.gameObject.tag == "PlayerIce")
		{
			down2 = false;
		}
	}
}
