// DecompilerFi decompiler from Assembly-CSharp.dll class: selectLevel
// SourcesPostProcessor 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectLevel : MonoBehaviour
{
	public int level;

	private Button btn;

	private void Start()
	{
		btn = GetComponent<Button>();
	}

	public void selectLV()
	{
        SceneManager.LoadScene(level);
	}
}
