// DecompilerFi decompiler from Assembly-CSharp.dll class: gatCan
// SourcesPostProcessor 
using UnityEngine;

public class gatCan : MonoBehaviour
{
	public GameObject Rope;

	public Transform pos1;

	public Transform pos2;

	public GameObject guong;

	public GameObject guong2;

	private void Start()
	{
		if (Rope != null)
		{
			pos1.parent = null;
			pos2.parent = null;
		}
	}

	private void Update()
	{
		Quaternion rotation = base.transform.rotation;
		if (rotation.z <= 0f)
		{
			if (Rope != null)
			{
				Rope.transform.position = Vector3.MoveTowards(Rope.transform.position, pos1.position, Time.deltaTime);
			}
			if (Rope == null)
			{
				Quaternion b = Quaternion.Euler(0f, 0f, 90f);
				Quaternion b2 = Quaternion.Euler(0f, 0f, 90f);
				guong.transform.rotation = Quaternion.Slerp(guong.transform.rotation, b, Time.deltaTime);
				guong2.transform.rotation = Quaternion.Slerp(guong2.transform.rotation, b2, Time.deltaTime);
			}
		}
		Quaternion rotation2 = base.transform.rotation;
		if (rotation2.z > 0f)
		{
			if (Rope != null)
			{
				Rope.transform.position = Vector3.MoveTowards(Rope.transform.position, pos2.position, Time.deltaTime);
			}
			if (Rope == null)
			{
				Quaternion b3 = Quaternion.Euler(0f, 0f, 0f);
				Quaternion b4 = Quaternion.Euler(0f, 0f, -90f);
				guong.transform.rotation = Quaternion.Slerp(guong.transform.rotation, b3, Time.deltaTime);
				guong2.transform.rotation = Quaternion.Slerp(guong2.transform.rotation, b4, Time.deltaTime);
			}
		}
	}
}
