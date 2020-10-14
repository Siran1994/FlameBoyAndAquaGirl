// DecompilerFi decompiler from Assembly-CSharp.dll class: DebuggerWindow
// SourcesPostProcessor 
using UnityEngine;

public class DebuggerWindow : MonoBehaviour
{
	public KeyCode OpenKey = KeyCode.Menu;

	public bool AutoShow = true;

	public bool ShowWindow;

	public GUIStyle TextStyle;

	private string Log;

	private string Trace;

	private Rect Position;

	private Rect CloseButton;

	private Rect ScrollView;

	private Rect RectView;

	private Vector2 ScrollPos;

	private void Awake()
	{
		Application.RegisterLogCallback(HandleLog);
		Position = new Rect(Screen.width / 2, Screen.height / 2, Screen.width - 10, Screen.height / 2);
		CloseButton = new Rect(0f, 0f, Position.width / 10f, Position.height / 10f);
		ScrollView = new Rect(0f, Position.height / 10f, Position.width, Position.height * 0.9f);
		RectView = new Rect(0f, 0f, ScrollView.width, ScrollView.height);
		ScrollPos = Vector2.zero;
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(OpenKey))
		{
			ShowWindow = true;
		}
	}

	private void HandleLog(string logString, string stackTrace, LogType type)
	{
		Log = Log + logString + "\n";
		if (AutoShow)
		{
			ShowWindow = true;
		}
	}

	private void OnGUI()
	{
        TextStyle.CalcMinMaxWidth(new GUIContent(Log), out float _, out float maxWidth);
        float num = GUI.skin.label.CalcHeight(new GUIContent(Log), maxWidth);
        if (maxWidth > RectView.width)
        {
            RectView.width = maxWidth;
        }
        if (num >= RectView.height)
        {
            RectView.height = num;
        }
        if (ShowWindow)
        {
            Position = GUI.Window(100, Position, DrawWindow, string.Empty);
        }
    }

    private void DrawWindow(int id)
	{
		if (GUI.Button(CloseButton, "X"))
		{
			ShowWindow = false;
			Log = string.Empty;
		}
		ScrollPos = GUI.BeginScrollView(ScrollView, ScrollPos, RectView);
		GUI.Label(RectView, Log, TextStyle);
		GUI.EndScrollView();
		GUI.DragWindow();
	}
}
