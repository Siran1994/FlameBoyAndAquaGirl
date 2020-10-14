// DecompilerFi decompiler from Assembly-CSharp.dll class: starControl
// SourcesPostProcessor 
using UnityEngine;

public class starControl : MonoBehaviour
{
	public GameObject[] starObj;

	public GameObject popSL;

	public GameObject khung;

	public GameObject Par;

	private void Start()
	{
		for (int i = 0; i < starObj.Length; i++)
		{
			starObj[i].SetActive(value: false);
		}
	}

	public void clickStar(int index)
	{
		if (index < 3)
		{
			khung.SetActive(value: false);
			for (int i = 0; i < starObj.Length; i++)
			{
				if (i > index)
				{
					starObj[i].SetActive(value: false);
				}
				else
				{
					starObj[i].SetActive(value: true);
				}
			}
			ClosePopUp();
			return;
		}
		for (int j = 0; j < starObj.Length; j++)
		{
			if (j > index)
			{
				starObj[j].SetActive(value: false);
			}
			else
			{
				starObj[j].SetActive(value: true);
			}
		}
		ClosePopUp();
		PlayerPrefs.SetInt("rateOpenMap", 0);
		PlayerPrefs.Save();		
	}

	public void ClosePopUp()
	{
		Par.SetActive(value: false);
		popSL.SetActive(value: false);
		khung.SetActive(value: true);
	}
}
