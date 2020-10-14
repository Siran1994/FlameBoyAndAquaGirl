// DecompilerFi decompiler from Assembly-CSharp.dll class: moveTestObj
// SourcesPostProcessor 
using UnityEngine;

public class moveTestObj : MonoBehaviour
{
	private Rigidbody2D rb2d;

	public GameObject ObjCan;

	public bool isGround;

	private Vector2 move;

	private Vector2 directionMove;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
		{
			move = new Vector2(-1f, 0f);
		}
		else if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
		{
			move = new Vector2(1f, 0f);
		}
		else
		{
			move = Vector2.zero;
		}
		if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}

	private void FixedUpdate()
	{
		Movement(move);
	}

	private void Movement(Vector2 _move)
	{
		if (_move.x == 0f)
		{
			return;
		}
		if (ObjCan != null)
		{
			float num = Mathf.Sign(_move.x);
			Vector3 position = ObjCan.transform.position;
			float x = position.x;
			Vector3 position2 = base.transform.position;
			if (num != Mathf.Sign(x - position2.x))
			{
				if (isGround)
				{
					base.transform.position += new Vector3(_move.x * 2f * directionMove.y, _move.x * 2f * (0f - directionMove.x)) * Time.smoothDeltaTime;
				}
				else
				{
					base.transform.position += new Vector3(_move.x * 2f, 0f, 0f) * Time.smoothDeltaTime;
				}
				ObjCan = null;
			}
		}
		else if (isGround)
		{
			base.transform.position += new Vector3(_move.x * 2f * directionMove.y, _move.x * 2f * (0f - directionMove.x)) * Time.smoothDeltaTime;
		}
		else
		{
			base.transform.position += new Vector3(_move.x * 2f, 0f, 0f) * Time.smoothDeltaTime;
		}
	}

	private void Jump()
	{
		if (isGround)
		{
			isGround = false;
			rb2d.velocity = new Vector2(0f, 8f);
		}
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (!col.enabled)
		{
			return;
		}
		if (col.contacts.Length == 1)
		{
			Vector2 point = col.contacts[0].point;
			float y = point.y;
			Vector3 position = base.transform.position;
			if (y < position.y)
			{
				Vector2 normal = col.contacts[0].normal;
				if (Mathf.Abs(normal.x) != 1f)
				{
					isGround = true;
					base.transform.parent = col.transform;
					directionMove = col.contacts[0].normal;
				}
				else
				{
					ObjCan = col.gameObject;
				}
			}
		}
		else
		{
			if (col.contacts.Length != 2)
			{
				return;
			}
			Vector2 point2 = col.contacts[0].point;
			float y2 = point2.y;
			Vector2 point3 = col.contacts[1].point;
			if (y2 == point3.y)
			{
				Vector2 point4 = col.contacts[0].point;
				float y3 = point4.y;
				Vector3 position2 = base.transform.position;
				if (y3 < position2.y)
				{
					isGround = true;
					base.transform.parent = col.transform;
					directionMove = col.contacts[0].normal;
				}
			}
			else
			{
				ObjCan = col.gameObject;
			}
		}
	}

	private void OnCollisionStay2D(Collision2D col)
	{
		if (!col.enabled)
		{
			return;
		}
		if (col.contacts.Length == 1)
		{
			Vector2 velocity = rb2d.velocity;
			if (!(velocity.y <= 0.1f))
			{
				return;
			}
			Vector2 point = col.contacts[0].point;
			float y = point.y;
			Vector3 position = base.transform.position;
			if (y < position.y)
			{
				Vector2 normal = col.contacts[0].normal;
				if (Mathf.Abs(normal.x) != 1f)
				{
					isGround = true;
					base.transform.parent = col.transform;
					directionMove = col.contacts[0].normal;
				}
				else
				{
					ObjCan = col.gameObject;
				}
			}
		}
		else
		{
			if (col.contacts.Length != 2)
			{
				return;
			}
			Vector2 point2 = col.contacts[0].point;
			float y2 = point2.y;
			Vector2 point3 = col.contacts[1].point;
			if (y2 == point3.y)
			{
				Vector2 velocity2 = rb2d.velocity;
				if (velocity2.y <= 0.1f)
				{
					Vector2 point4 = col.contacts[0].point;
					float y3 = point4.y;
					Vector3 position2 = base.transform.position;
					if (y3 < position2.y)
					{
						isGround = true;
						base.transform.parent = col.transform;
						directionMove = col.contacts[0].normal;
					}
				}
			}
			else
			{
				ObjCan = col.gameObject;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject == ObjCan)
		{
			ObjCan = null;
		}
	}
}
