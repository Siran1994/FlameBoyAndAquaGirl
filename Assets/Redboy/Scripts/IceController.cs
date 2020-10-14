// DecompilerFi decompiler from Assembly-CSharp.dll class: IceController
// SourcesPostProcessor 
using UnityEngine;

public class IceController : MonoBehaviour
{
	public enum ButtonState
	{
		None,
		PressedDown,
		Released,
		Held
	}

	private float playerSpeed = 3f;

	public AudioSource audioJump;

	public AudioSource audioDie;

	public bool ground;

	private Rigidbody2D rb;

	private bool faceRight;

	public static bool canMove;

	public static bool canJump;

	public GameObject sang;

	private Animator anim;

	private Vector2 MoveDirection;

	[SerializeField]
	private touchButton btnA;

	[SerializeField]
	private touchButton btnD;

	[SerializeField]
	private touchButton btnW;

	private bool jumped;

	public GameObject ObjCan;

	public static bool Die;

	private Vector2 move;

	private Vector3 hs;

	private Collider2D col;

	private float rby;

	private void Start()
	{
		faceRight = true;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<Collider2D>();
		canMove = true;
		canJump = true;
		Die = false;
	}

	private void Update()
	{
		if (canMove && !InputManager.fire)
		{
			if (btnA.CurrentState == InputManager.ButtonState.Held || btnA.CurrentState == InputManager.ButtonState.PressedDown || UnityEngine.Input.GetKey(KeyCode.LeftArrow))
			{
				move = new Vector2(-1f, 0f);
				anim.SetBool("isRun", value: true);
				base.transform.transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
				// if (faceRight)
				// {
				// 	flip();
				// }
			}
			else if (btnD.CurrentState == InputManager.ButtonState.Held || btnD.CurrentState == InputManager.ButtonState.PressedDown || UnityEngine.Input.GetKey(KeyCode.RightArrow))
			{
				move = new Vector2(1f, 0f);
				anim.SetBool("isRun", value: true);
				base.transform.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
				// if (!faceRight)
				// {
				// 	flip();
				// }
			}
			else
			{
				move = Vector2.zero;
				anim.SetBool("isRun", value: false);
			}
		}
		else
		{
			move = Vector2.zero;
			if (base.gameObject.activeInHierarchy)
			{
				anim.SetBool("isRun", value: false);
			}
		}
		if (canJump && !InputManager.fire && (btnW.CurrentState == InputManager.ButtonState.Held || UnityEngine.Input.GetKey(KeyCode.UpArrow)) && jumped)
		{
			Jump();
		}
		if (ground)
		{
			jumped = true;
		}
		Vector2 velocity = rb.velocity;
		rby = velocity.y;
		anim.SetFloat("rbY", rby);
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
				if (ground)
				{
					base.transform.position += new Vector3(_move.x * playerSpeed * MoveDirection.y, _move.x * playerSpeed * (0f - MoveDirection.x)) * Time.smoothDeltaTime;
				}
				else
				{
					base.transform.position += new Vector3(_move.x * playerSpeed, 0f, 0f) * Time.smoothDeltaTime;
				}
				ObjCan = null;
			}
		}
		else if (ground)
		{
			base.transform.position += new Vector3(_move.x * playerSpeed * MoveDirection.y, _move.x * playerSpeed * (0f - MoveDirection.x)) * Time.smoothDeltaTime;
		}
		else
		{
			base.transform.position += new Vector3(_move.x * playerSpeed, 0f, 0f) * Time.smoothDeltaTime;
		}
	}

	private void Jump()
	{
		if (ground)
		{
			audioJump.Play();
			jumped = false;
			ground = false;
			base.transform.parent = null;
			rb.velocity = new Vector2(0f, 6.5f);
			anim.SetBool("isRun", value: false);
			anim.SetBool("isJump", value: true);
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

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.enabled && other.gameObject.tag != "box")
		{
			if (other.contacts.Length == 1)
			{
				Vector2 point = other.contacts[0].point;
				float y = point.y;
				Vector3 position = base.transform.position;
				if (y < position.y)
				{
					Vector2 normal = other.contacts[0].normal;
					if (Mathf.Abs(normal.x) != 1f)
					{
						ground = true;
						anim.SetBool("isJump", value: false);
						MoveDirection = other.contacts[0].normal;
						if (other.gameObject.tag != "watter" && other.gameObject.tag != "Player")
						{
							base.transform.parent = other.transform;
						}
					}
					else
					{
						//ObjCan = other.gameObject;
					}
				}
			}
			else if (other.contacts.Length == 2)
			{
				Vector2 point2 = other.contacts[0].point;
				float y2 = point2.y;
				Vector2 point3 = other.contacts[1].point;
				if (y2 == point3.y)
				{
					Vector2 point4 = other.contacts[0].point;
					float y3 = point4.y;
					Vector3 position2 = base.transform.position;
					if (y3 < position2.y)
					{
						ground = true;
						anim.SetBool("isJump", value: false);
						MoveDirection = other.contacts[0].normal;
						if (other.gameObject.tag != "watter" && other.gameObject.tag != "Player")
						{
							base.transform.parent = other.transform;
						}
					}
				}
				else
				{
					// = other.gameObject;
				}
			}
		}
		if (other.gameObject.tag == "box")
		{
			Vector2 point5 = other.contacts[0].point;
			float y4 = point5.y;
			Vector3 position3 = base.transform.position;
			if (y4 < position3.y)
			{
				ground = true;
				anim.SetBool("isJump", value: false);
			}
		}
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if (other.enabled && other.gameObject.tag != "box" && other.gameObject.tag != "Fire" && other.gameObject.tag != "black")
		{
			if (other.contacts.Length == 1)
			{
				Vector2 point = other.contacts[0].point;
				float y = point.y;
				Vector3 position = base.transform.position;
				if (y < position.y)
				{
					Vector2 point2 = other.contacts[0].point;
					float x = point2.x;
					Vector2 point3 = other.contacts[0].point;
					hs = new Vector3(x, point3.y + 1f, 0f);
					Vector2 normal = other.contacts[0].normal;
					if (Mathf.Abs(normal.x) != 1f)
					{
						ground = true;
						anim.SetBool("isJump", value: false);
						MoveDirection = other.contacts[0].normal;
						if (other.gameObject.tag != "watter" && other.gameObject.tag != "Player")
						{
							base.transform.parent = other.transform;
						}
					}
					else
					{
						//ObjCan = other.gameObject;
					}
				}
			}
			else if (other.contacts.Length == 2)
			{
				Vector2 point4 = other.contacts[0].point;
				float y2 = point4.y;
				Vector2 point5 = other.contacts[1].point;
				if (y2 == point5.y)
				{
					Vector2 point6 = other.contacts[0].point;
					float y3 = point6.y;
					Vector3 position2 = base.transform.position;
					if (y3 < position2.y)
					{
						Vector2 point7 = other.contacts[0].point;
						float x2 = point7.x;
						Vector2 point8 = other.contacts[0].point;
						hs = new Vector3(x2, point8.y + 1f, 0f);
						ground = true;
						anim.SetBool("isJump", value: false);
						MoveDirection = other.contacts[0].normal;
						if (other.gameObject.tag != "watter" && other.gameObject.tag != "Player")
						{
							base.transform.parent = other.transform;
						}
					}
					else
					{
						//ObjCan = other.gameObject;
					}
				}
			}
		}
		if (other.gameObject.tag == "box")
		{
			Vector2 point9 = other.contacts[0].point;
			float y4 = point9.y;
			Vector3 position3 = base.transform.position;
			if (!(y4 < position3.y))
			{
				ground = true;
				anim.SetBool("isJump", value: false);
			}
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject == ObjCan)
		{
			ObjCan = null;
		}
		if (other.enabled && other.transform == base.transform.parent && base.gameObject.activeInHierarchy)
		{
			base.transform.parent = null;
		}
		if (other.gameObject.tag == "box" && other.transform == base.transform.parent && base.gameObject.activeInHierarchy)
		{
			base.transform.parent = null;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Fire")
		{
			Die = true;
			sang.SetActive(value: false);
			anim.SetBool("isDie", value: true);
			canJump = false;
			canMove = false;
			col.enabled = false;
			audioDie.Play();
			rb.velocity = new Vector2(0f, 0.1f);
			rb.isKinematic = true;
		}
		if (other.gameObject.tag == "black")
		{
			Die = true;
			sang.SetActive(value: false);
			anim.SetBool("isDie", value: true);
			canJump = false;
			canMove = false;
			col.enabled = false;
			audioDie.Play();
			rb.velocity = new Vector2(0f, 0.1f);
			rb.isKinematic = true;
		}
	}

	private void pDie()
	{
		InputManager.IPmanager.die();
	}

	private void pVic()
	{
		anim.SetBool("isVic", value: false);
		base.gameObject.SetActive(value: false);
	}

	public void hoisinh()
	{
		Time.timeScale = 1f;
		anim.SetBool("isDie", value: false);
		base.transform.position = Vector3.MoveTowards(base.transform.position, hs, 5000f);
		sang.SetActive(value: true);
		anim.Play("IceIdle", -1, 0f);
		canJump = true;
		canMove = true;
		col.enabled = true;
		rb.velocity = new Vector2(0f, 0f);
		rb.isKinematic = false;
	}
}
