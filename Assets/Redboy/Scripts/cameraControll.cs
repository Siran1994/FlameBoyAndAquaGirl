// DecompilerFi decompiler from Assembly-CSharp.dll class: cameraControll
// SourcesPostProcessor 
using UnityEngine;
using UnityEngine.EventSystems;

public class cameraControll : MonoBehaviour
{
	private Vector3 mouse1;

	private Vector3 mouse2;

	private Vector2 dir;

	private Camera cam;

	public float camDis;

	public float smoothing;

	private Vector3 targetCamPos;

	public float lowX;

	public float highX;

	public float lowY = -2f;

	public float highY = 2f;

	public GameObject Pfire;

	public GameObject Pwater;

	private GameObject selBtn;

	private string abc;

	private void Start()
	{
		Pfire = GameObject.FindWithTag("Player");
		Pwater = GameObject.FindWithTag("PlayerIce");
		cam = Camera.main;
		camDis = 10f;
		if (InputManager.fire)
		{
			Vector3 position = Pfire.transform.position;
			float x = position.x;
			Vector3 position2 = Pfire.transform.position;
			float y = position2.y;
			Vector3 position3 = base.transform.position;
			targetCamPos = new Vector3(x, y, position3.z);
		}
		else
		{
			Vector3 position4 = Pwater.transform.position;
			float x2 = position4.x;
			Vector3 position5 = Pwater.transform.position;
			float y2 = position5.y;
			Vector3 position6 = base.transform.position;
			targetCamPos = new Vector3(x2, y2, position6.z);
		}
	}

	private void Update()
	{
		smoothing = Mathf.MoveTowards(smoothing, 2f, 0.03f);
		Pfire = GameObject.FindWithTag("Player");
		Pwater = GameObject.FindWithTag("PlayerIce");
	}

	private void FixedUpdate()
	{
		selBtn = EventSystem.current.currentSelectedGameObject;
		if (Input.GetMouseButtonDown(0))
		{
			Camera camera = cam;
			Vector3 mousePosition = UnityEngine.Input.mousePosition;
			float x = mousePosition.x;
			Vector3 mousePosition2 = UnityEngine.Input.mousePosition;
			mouse1 = camera.ScreenToWorldPoint(new Vector3(x, mousePosition2.y, camDis));
		}
		if (Input.GetMouseButton(0))
		{
			if (selBtn == null || selBtn.gameObject.layer != LayerMask.NameToLayer("UI"))
			{
				Camera camera2 = cam;
				Vector3 mousePosition3 = UnityEngine.Input.mousePosition;
				float x2 = mousePosition3.x;
				Vector3 mousePosition4 = UnityEngine.Input.mousePosition;
				mouse2 = camera2.ScreenToWorldPoint(new Vector3(x2, mousePosition4.y, camDis));
				dir = mouse2 - mouse1;
				float x3 = targetCamPos.x - dir.x;
				float y = targetCamPos.y - dir.y;
				Vector3 position = base.transform.position;
				targetCamPos = new Vector3(x3, y, position.z);
			}
			else
			{
				Vector3 position2 = Pwater.transform.position;
				float x4 = position2.x;
				Vector3 position3 = Pfire.transform.position;
				if (Mathf.Abs(x4 - position3.x) >= 16f)
				{
					if (InputManager.fire)
					{
						Vector3 position4 = Pfire.transform.position;
						float x5 = position4.x;
						Vector3 position5 = Pfire.transform.position;
						float y2 = position5.y;
						Vector3 position6 = base.transform.position;
						targetCamPos = new Vector3(x5, y2, position6.z);
					}
					else
					{
						Vector3 position7 = Pwater.transform.position;
						float x6 = position7.x;
						Vector3 position8 = Pwater.transform.position;
						float y3 = position8.y;
						Vector3 position9 = base.transform.position;
						targetCamPos = new Vector3(x6, y3, position9.z);
					}
				}
				else
				{
					Vector3 position10 = Pwater.transform.position;
					float y4 = position10.y;
					Vector3 position11 = Pfire.transform.position;
					if (Mathf.Abs(y4 - position11.y) >= 5f)
					{
						if (InputManager.fire)
						{
							Vector3 position12 = Pfire.transform.position;
							float x7 = position12.x;
							Vector3 position13 = Pfire.transform.position;
							float y5 = position13.y;
							Vector3 position14 = base.transform.position;
							targetCamPos = new Vector3(x7, y5, position14.z);
						}
						else
						{
							Vector3 position15 = Pwater.transform.position;
							float x8 = position15.x;
							Vector3 position16 = Pwater.transform.position;
							float y6 = position16.y;
							Vector3 position17 = base.transform.position;
							targetCamPos = new Vector3(x8, y6, position17.z);
						}
					}
					else
					{
						Vector3 position18 = Pwater.transform.position;
						float x9 = position18.x;
						Vector3 position19 = Pfire.transform.position;
						float x10 = (x9 + position19.x) / 2f;
						Vector3 position20 = Pwater.transform.position;
						float y7 = position20.y;
						Vector3 position21 = Pfire.transform.position;
						float y8 = (y7 + position21.y) / 2f;
						Vector3 position22 = base.transform.position;
						targetCamPos = new Vector3(x10, y8, position22.z);
					}
				}
			}
		}
		if (targetCamPos.x < lowX)
		{
			targetCamPos.x = lowX;
		}
		if (targetCamPos.x > highX)
		{
			targetCamPos.x = highX;
		}
		if (targetCamPos.y < lowY)
		{
			targetCamPos.y = lowY;
		}
		if (targetCamPos.y > highY)
		{
			targetCamPos.y = highY;
		}
		base.transform.position = Vector3.Lerp(base.transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
