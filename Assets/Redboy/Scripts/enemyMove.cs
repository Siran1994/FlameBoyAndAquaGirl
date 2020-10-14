// DecompilerFi decompiler from Assembly-CSharp.dll class: enemyMove
// SourcesPostProcessor 
using System.Collections;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
	public bool enemyGai;

	public Transform pos1;

	public Transform pos2;

	private Transform pos;

	private bool choiLen;

	private bool faceRight;

	private void Start()
	{
		pos1.parent = null;
		pos2.parent = null;
		pos = pos1;
		faceRight = false;
	}

	private void Update()
	{
		if (!enemyGai)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, pos.position, Time.deltaTime * 2f);
			if (base.transform.position == pos1.position)
			{
				pos = pos2;
				flip();
			}
			if (base.transform.position == pos2.position)
			{
				pos = pos1;
				flip();
			}
		}
		if (enemyGai)
		{
			base.transform.position = Vector3.MoveTowards(base.transform.position, pos.position, Time.deltaTime * 0.2f);
			if (base.transform.position == pos1.position)
			{
				pos = pos2;
				choiLen = false;
				StartCoroutine(aa());
			}
			if (base.transform.position == pos2.position && choiLen)
			{
				pos = pos1;
			}
		}
	}

	private void flip()
	{
		faceRight = !faceRight;
		Transform transform = base.transform;
		Vector3 localScale = base.transform.localScale;
		float x = 0f - localScale.x;
		Vector3 localScale2 = base.transform.localScale;
		float y = localScale2.y;
		Vector3 localScale3 = base.transform.localScale;
		transform.localScale = new Vector3(x, y, localScale3.z);
	}

	private IEnumerator aa()
	{
		yield return new WaitForSeconds(4f);
		choiLen = true;
	}
}
