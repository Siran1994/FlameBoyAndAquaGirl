//  splPageControl


using System;
using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class splPageControl : MonoBehaviour
{

	//public GameObject popupNetwork;

	//public Button btnStartGame;

	private void Awake()
	{
		//popupNetwork.SetActive(value: false);
		//StartCoroutine("CheckNetWorkError1");
		
		//try
		//{
			   
  //               SDK.Instance.InterstitialAdLoadFailed += this.onAdError;
  //               SDK.Instance.InterstitialLoaded += this.onAdLoaded;
		//}
		//catch (Exception ex)
		//{
		//	UnityEngine.Debug.Log("Crash : " + ex.Message);
		//	StopCoroutine("CheckNetWorkError1");
		//	SceneManager.LoadScene(1);
		//}
	}

	private void Start()
    {
        StartCoroutine(GotoGame());

        //if (PlayerPrefs.HasKey("Rated"))
        //{
        //	PlayerPrefs.SetInt("Rated", 0);
        //	PlayerPrefs.SetInt("Victory", 0);
        //	PlayerPrefs.Save();
        //}
    }

    private IEnumerator GotoGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }


    private IEnumerator CheckNetWorkError1()
	{
		yield return new WaitForSeconds(7f);
			SceneManager.LoadScene(1);
		// popupNetwork.SetActive(value: true);
		// btnStartGame.onClick.AddListener(TaskOnClickPopUp);
	}

	private IEnumerator CheckNetWorkError2()
	{
		yield return new WaitForSeconds(7f);
			SceneManager.LoadScene(1);
		// popupNetwork.SetActive(value: true);
		// btnStartGame.onClick.AddListener(TaskOnClickPopUp);
	}

	private void TaskOnClickPopUp()
	{
		SceneManager.LoadScene(1);
	}
	
}
