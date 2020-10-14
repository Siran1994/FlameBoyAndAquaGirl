// DecompilerFi decompiler from Assembly-CSharp.dll class: woodMove
// SourcesPostProcessor 
using UnityEngine;

public class woodMove : MonoBehaviour
{
	public Transform pos1;

	public Transform pos2;

	private Transform pos;

	private void Start()
	{
		pos1.parent = null;
		pos2.parent = null;
		pos = pos1;
	}

	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, pos.position, Time.deltaTime);
		if (base.transform.position == pos1.position)
		{
			pos = pos2;
		}
		if (base.transform.position == pos2.position)
		{
			pos = pos1;
		}
	}
}
