// DecompilerFi decompiler from Assembly-CSharp.dll class: controllerRope2
// SourcesPostProcessor 
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class controllerRope2 : MonoBehaviour
{
	public GameObject Rope;

	public Transform pos1;

	public Transform pos2;

	public Transform pos1nut;

	public Transform pos2nut;

	public GameObject nutbam;

	private bool down;

	private bool down1;

	private bool down2;

	private bool down3;

	public Slider timeSlider;

	public float timeOpen;

	public GameObject deNut;

	private float t;

	private void Start()
	{
		pos1.parent = null;
		pos2.parent = null;
		pos1nut.parent = null;
		pos2nut.parent = null;
		down = false;
		down1 = false;
		down2 = false;
		down3 = false;
	}

	private void Update()
	{
		if (!down1 && !down2 && !down3)
		{
			down = false;
		}
		if (down1 || down2 || down3)
		{
			down = true;
		}
		if (down)
		{
			Rope.transform.position = Vector3.MoveTowards(Rope.transform.position, pos2.transform.position, Time.deltaTime);
			nutbam.transform.position = Vector3.MoveTowards(nutbam.transform.position, pos2nut.transform.position, Time.deltaTime);
			if (deNut != null)
			{
				t = timeOpen;
				timeSlider.maxValue = t;
				timeSlider.value = t;
			}
		}
		if (!down)
		{
			nutbam.transform.position = Vector3.MoveTowards(nutbam.transform.position, pos1nut.transform.position, Time.deltaTime);
			if (deNut == null)
			{
				Rope.transform.position = Vector3.MoveTowards(Rope.transform.position, pos1.transform.position, Time.deltaTime);
			}
			if (deNut != null)
			{
				StartCoroutine(stopTime());
			}
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
		if (other.gameObject.tag == "box")
		{
			down3 = true;
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
		if (other.gameObject.tag == "box")
		{
			down3 = true;
		}
	}

	private IEnumerator stopTime()
	{
		yield return new WaitForSeconds(0f);
		t -= Time.deltaTime;
		timeSlider.value = t;
		if (t < 0f)
		{
			t = 0f;
			timeSlider.value = 0f;
			Rope.transform.position = Vector3.MoveTowards(Rope.transform.position, pos1.transform.position, Time.deltaTime);
		}
	}
}
