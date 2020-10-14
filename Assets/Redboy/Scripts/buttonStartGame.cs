// DecompilerFi decompiler from Assembly-CSharp.dll class: buttonStartGame
// SourcesPostProcessor 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonStartGame : MonoBehaviour
{
	public static buttonStartGame btnSG;

	public GameObject popUpSLM;

	public GameObject popUpEasy;

	public GameObject popRate;

	public GameObject popRate2;

	public GameObject popUpNormal;

	public GameObject popUpCommingSoon;

	private bool Bg;

	public GameObject btnOnS;//开

	public GameObject btnOffS;//关

	public GameObject btnNoAds;

	public GameObject selectlv1to10;

	public GameObject selectlv11to20;

	public GameObject selectlv21to30;

	public GameObject selectNormallv1to10;

	public GameObject selectNormallv11to20;

	public GameObject selectNormallv21to30;

	public GameObject buttonNext;

	public GameObject buttonPreview;

	public GameObject buttonNextNor;

	public GameObject buttonPreviewNor;

	public GameObject[] clock;

	public GameObject[] btn;

	public GameObject[] clockN;

	public GameObject[] btnN;



	private bool pressed;

	private int indexlevel;

	private int indexNormal;

	public AudioSource audioClick;

	public AudioSource audioClicklv;

    public Button NorLv, Adbtn;
    private void Awake()
	{      
		btnSG = this;
	}


   // public static bool isToLock = false;
    //public void ToLocked()
    //{
    //    PlayerPrefs.SetInt("Locked", 1);
    //}

    private void Start()
	{
        //Adbtn.onClick.AddListener(delegate
        //{
        //   // SDKManager.Instance.MakeToast("暂无广告!!!");
        //    // SDKManager.Instance.ShowAd(ShowAdType.Reward, 1, "点击解锁普通关卡");
        //  //  isToLock = true;
        //   // ToLocked();
        //});

        if (!PlayerPrefs.HasKey("rateOpenMap"))
		{
			int num = UnityEngine.Random.Range(0, 100);
			if (num >= 50)
			{
				PlayerPrefs.SetInt("rateOpenMap", 1);
			}
			else
			{
				PlayerPrefs.SetInt("rateOpenMap", 0);
			}
		}
		pressed = false;
		indexlevel = 0;
		indexNormal = 0;
		Time.timeScale = 1f;
		Bg = true;
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            AudioListener.volume = 1f;
            btnOnS.SetActive(value: true);
            btnOffS.SetActive(value: false);
        }
        else
        {
            btnOnS.SetActive(value: false);
            btnOffS.SetActive(value: true);
            AudioListener.volume = 0f;
        }
        if (!PlayerPrefs.HasKey("saveScenceEasy"))
		{
			PlayerPrefs.SetInt("saveScenceEasy", 1);
			PlayerPrefs.SetInt("saveScenceNormal", 1);
			PlayerPrefs.Save();
		}
		for ( int i = 0; i <= 19; i++)
		{
			if (i < PlayerPrefs.GetInt("saveScenceEasy") - 1)
			{
				clock[i].SetActive(value: false);
				btn[i].SetActive(value: true);
			}
		}
		for (int j = 0; j <= 19; j++)
		{
			if (j < PlayerPrefs.GetInt("saveScenceNormal") - 1)
			{
				clockN[j].SetActive(value: false);
				btnN[j].SetActive(value: true);
			}
		}		
		if (InputManager.inGame)
		{
			indexlevel = 1;
			popUpEasy.SetActive(value: true);
		}
	}

	private void Update()
	{
        //if (PlayerPrefs.GetInt("Locked", 0) == 1)
        //{
        //    NorLv.interactable = true;
        //}
        //else
        //{
        //    NorLv.interactable = false;
        //}

        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !pressed)
		{
			pressed = true;
			if (!Bg)
			{
				popUpSLM.SetActive(value: false);
			}
			else
			{
				//Application.Quit();
			}
		}
		if (UnityEngine.Input.GetKeyUp(KeyCode.Escape))
		{
			pressed = false;
		}
		if (indexlevel == 0)
		{
			buttonNext.SetActive(value: true);
			buttonPreview.SetActive(value: false);
			selectlv1to10.SetActive(value: true);
			selectlv11to20.SetActive(value: false);
			selectlv21to30.SetActive(value: false);
		}
		if (indexlevel == 1)
		{
			buttonNext.SetActive(value: true);
			buttonPreview.SetActive(value: true);
			selectlv1to10.SetActive(value: false);
			selectlv11to20.SetActive(value: true);
			selectlv21to30.SetActive(value: false);
		}
		if (indexlevel == 2)
		{
			buttonNext.SetActive(value: false);
			buttonPreview.SetActive(value: true);
			selectlv1to10.SetActive(value: false);
			selectlv11to20.SetActive(value: false);
			selectlv21to30.SetActive(value: true);
		}
		if (indexNormal == 0)
		{
			buttonNextNor.SetActive(value: true);
			buttonPreviewNor.SetActive(value: false);
			selectNormallv1to10.SetActive(value: true);
			selectNormallv11to20.SetActive(value: false);
			selectNormallv21to30.SetActive(value: false);
		}
		if (indexNormal == 1)
		{
			buttonNextNor.SetActive(value: true);
			buttonPreviewNor.SetActive(value: true);
			selectNormallv1to10.SetActive(value: false);
			selectNormallv11to20.SetActive(value: true);
			selectNormallv21to30.SetActive(value: false);
		}
		if (indexNormal == 2)
		{
			buttonNextNor.SetActive(value: false);
			buttonPreviewNor.SetActive(value: true);
			selectNormallv1to10.SetActive(value: false);
			selectNormallv11to20.SetActive(value: false);
			selectNormallv21to30.SetActive(value: true);
		}
	}

	public void btnPlay()  //点击开始
	{
		audioClick.Play();
		popUpSLM.SetActive(value: true);
		Bg = false;
	}

	public void btnBack()
	{
		audioClick.Play();
		popUpSLM.SetActive(value: false);
	}

	public void btnBackSLM()
	{
		audioClick.Play();
		popUpSLM.SetActive(value: true);
		popUpEasy.SetActive(value: false);
		popUpNormal.SetActive(value: false);
		popUpCommingSoon.SetActive(value: false);
	}

	public void playEasy()  //简单关卡
	{
        audioClick.Play();
		popUpEasy.SetActive(value: true);
		popUpSLM.SetActive(value: false);
	}

	public void playNormal()  //一般关卡
	{
        audioClick.Play();
		popUpNormal.SetActive(value: true);
		popUpSLM.SetActive(value: false);
	}

	public void commingsoon()
	{
		audioClick.Play();
		popUpCommingSoon.SetActive(value: true);
	}

	public void Onsound() //点击声音
	{
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt("Sound", 0);
        btnOnS.SetActive(value: false);
		btnOffS.SetActive(value: true);
	}

	public void nextEasy()
	{
		audioClick.Play();
		indexlevel++;
	}

	public void previewEasy()
	{
		audioClick.Play();
		indexlevel--;
	}

	public void nextNormal()
	{
		audioClick.Play();
		indexNormal++;
	}

	public void previewNormal()
	{
		audioClick.Play();
		indexNormal--;
	}

	public void OffSound()  //关闭音乐
	{
        AudioListener.volume =1;
        PlayerPrefs.SetInt("Sound", 1);
		btnOnS.SetActive(value: true);
		btnOffS.SetActive(value: false);
	}

	public void Rate()
	{
		audioClick.Play();
		popRate.SetActive(value: true);
	}

	public void lv1Easy() 
	{
        audioClicklv.Play();
		SceneManager.LoadScene("easy01");
	}

	public void lv1Normal()
	{
        audioClicklv.Play();
		SceneManager.LoadScene("normal01");
	}

	public void selectlv(int level)
	{
		audioClick.Play();
		if (level == 12 && PlayerPrefs.GetInt("rateOpenMap") == 1)
		{
			popRate2.SetActive(value: true);
		}
		else
		{
			SceneManager.LoadScene(level);
		}
	}
}
