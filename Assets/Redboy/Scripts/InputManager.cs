// DecompilerFi decompiler from Assembly-CSharp.dll class: InputManager
// SourcesPostProcessor 

using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public enum ButtonState
    {
        None,
        PressedDown,
        Released,
        Held
    }
    public static InputManager IPmanager;

    public static bool fire;

    public static bool inGame;

    [SerializeField]
    private touchButton btnSwap;

    public bool blueOK;

    public bool redOK;

    public int kcBl;

    public int kcRe;

    public Text textBl;

    public Text textRe;

    public Text textSkip;

    public int levelindex;

    public AudioSource audioWin;

    public AudioSource audioBG;

    private AudioSource audioClick;

    private bool win;

    public GameObject popPause;

    public GameObject popVic;

    public GameObject popGO;//��Ϸ�������

    public GameObject popHS; //�Ƿ񸴻�

    public GameObject popSkip;//����

    public Animator animF;

    public Animator animI;

    public GameObject sangF;

    public GameObject sangI;

    public GameObject ImaRed;

    public GameObject ImaBlue;

    public GameObject Pfire;

    public GameObject Pwater;

    public GameObject doorF;

    public GameObject doorI;

    private int counths;

    private bool isCalWin;

    private bool swap;

    private bool isLoadGo;

    #region ���ر���
    public GameObject SuccessP;
    public GameObject FaileP;
    public GameObject PauseP;
    public GameObject ReceiveP;
    #endregion

    private void Awake()
    {
        IPmanager = this;
        textSkip.transform.parent.gameObject.SetActive(false);

        SuccessP = Instantiate(Resources.Load<GameObject>("SuccessPanel"), this.transform);
        SuccessP.SetActive(false);
        FaileP = Instantiate(Resources.Load<GameObject>("FailPanel"), this.transform);
        FaileP.SetActive(false);
        PauseP = Instantiate(Resources.Load<GameObject>("PausePanel"), this.transform);
        PauseP.SetActive(false);
        ReceiveP = Instantiate(Resources.Load<GameObject>("RevivePanel"), this.transform);
        ReceiveP.SetActive(false);
    }

    private void Start()
    {
        Time.timeScale = 1;
        levelindex = SceneManager.GetActiveScene().buildIndex;
        isCalWin = false;
        inGame = false;
        swap = true;
        Pfire = GameObject.FindWithTag("Player");
        Pwater = GameObject.FindWithTag("PlayerIce");
        audioClick = GetComponent<AudioSource>();           
    }

    private void Update()
    {
        if (!fire)
        {
            ImaBlue.SetActive(value: true);
            ImaRed.SetActive(value: false);
        }
        if (fire)
        {
            ImaBlue.SetActive(value: false);
            ImaRed.SetActive(value: true);
        }
        if (btnSwap.CurrentState == ButtonState.Held && swap)
        {
            fire = !fire;
            swap = false;
        }
        if (btnSwap.CurrentState == ButtonState.None || (btnSwap.CurrentState == ButtonState.Released && swap))
        {
            swap = true;
        }
        if (OpenDoor.openFire && openDoorIce.openIce)
        {
            win = true;
        }
        if (win && !isCalWin)
        {
            isCalWin = true;
            FireController.canMove = false;
            FireController.canJump = false;
            IceController.canJump = false;
            IceController.canMove = false;
            StartCoroutine(victory());
        }
        textSkip.text = string.Empty + PlayerPrefs.GetInt("itemSkip");      

    }

    public void die() //����
    {
        if (popHS.activeInHierarchy || popGO.activeInHierarchy)
        {
            return;
        }
        if (counths == 0)
        {
            counths++;

           
            if (SDKManager.Instance.IsCanShowAd)
            {
                ReceiveP.SetActive(value: true);
                SDKManager.Instance.CloseBanner("ԭ�����չʾ�ر�Banner");
            }
            else
            {
                popHS.SetActive(value: true);
            }
        }
        else if (isLoadGo)
        {           
            isLoadGo = false;
        }
        else
        {
            if (SDKManager.Instance.IsCanShowAd)
            {
                ReceiveP.SetActive(value: false);
                SDKManager.Instance.RepeatShowBan(1.5f, 30);
            }
            else
            {
                popHS.SetActive(value: false);
            }
            if (SDKManager.Instance.IsCanShowAd)
            {
                FaileP.SetActive(value: true);
                SDKManager.Instance.CloseBanner("ԭ�����չʾ�ر�Banner");
            }
            else
            {
                popGO.SetActive(value: true);
            }
           
        }
    }

    public static bool IsFH = false;  //����  
    public void yesHoiSinh()  //����
    {
        SDKManager.Instance.ShowAd(ShowAdType.Reward, 1, "�������"); //�ȿ�������Ƶ���  
        IsFH = true;
    }
    public void FH()
    {
        ReceiveP.SetActive(false);
        audioClick.Play();
        FireController.coHS = false;
        if (FireController.Die)
        {
            Pfire.GetComponent<FireController>().hoisinh(); //���Ż��˵���������
        }
        if (IceController.Die)
        {
            Pwater.GetComponent<IceController>().hoisinh(); //���ű�Ů����������
        }
        popHS.SetActive(value: false);  //�رո������
        if (SDKManager.Instance.IsCanShowAd)
        {
            FaileP.SetActive(value: false);   //�رռ������  
            SDKManager.Instance.RepeatShowBan(1.5f,30);
        }
        else
        {
            popGO.SetActive(value: false);   //�رռ������ 
        }
       
    }

    public static bool IsSK = false;  //����   
    public void btnSkipLv()
    {
        SDKManager.Instance.ShowAd(ShowAdType.Reward, 1, "�������"); //�ȿ�������Ƶ���  
        IsSK = true;
    }

    public void ToGetSkip()
    {
        audioClick.Play();
        int num = SceneManager.GetActiveScene().buildIndex + 1;
        if (num >= 1 && num <= 20)
        {
            PlayerPrefs.SetInt("EasyLvUnLockde", (PlayerPrefs.GetInt("EasyLvUnLockde", 1) + 1));
        }
        else
        {
            PlayerPrefs.SetInt("NormalLvUnLockde", (PlayerPrefs.GetInt("NormalLvUnLockde", 1) + 1));
        }
        SceneManager.LoadScene(num);
        PlayerPrefs.SetInt("itemSkip", PlayerPrefs.GetInt("itemSkip") - 1);
    }

    public void noHoiSinh() //������
    {
        audioClick.Play();
        if (isLoadGo)
        {          
            isLoadGo = false;
        }
        else
        {
            popHS.SetActive(value: false);
            if (SDKManager.Instance.IsCanShowAd)
            {
                FaileP.SetActive(value: true);
                SDKManager.Instance.CloseBanner("ԭ�����չʾ�ر�Banner");
            }
            else
            {
                popGO.SetActive(value: true);
            }
        }
    }

    public void btnPause() //��ͣ
    {
        audioClick.Play();
        if (SDKManager.Instance.IsCanShowAd)
        {
            PauseP.SetActive(value: true);
            SDKManager.Instance.CloseBanner("ԭ�����չʾ�ر�Banner");
        }
        else
        {
            popPause.SetActive(value: true);
        }
        Time.timeScale = 0f;
    }

    public void btnResume() //�������
    {
        audioClick.Play();
        if (SDKManager.Instance.IsCanShowAd)
        {
            PauseP.SetActive(value: false);
            SDKManager.Instance.RepeatShowBan(1.5f, 30);
        }
        else
        {
            popPause.SetActive(value: false);
        }
        
        Time.timeScale = 1f;
    }

    public void btnReplay() //�ؿ�
    {
        
        audioClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void btnHome() //����������
    {
       audioClick.Play();    
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void btnNext() //��һ��
    {
        audioClick.Play();
        int num = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(num);

        Time.timeScale = 1f;
    }
    private IEnumerator victory()
    {
        audioWin.Play();
        audioBG.Stop();
        Pfire.transform.position = Vector3.MoveTowards(Pfire.transform.position, doorF.transform.position, 3000f);
        Pwater.transform.position = Vector3.MoveTowards(Pwater.transform.position, doorI.transform.position, 3000f);
        yield return new WaitForSeconds(1f);
        sangF.SetActive(value: false);
        sangI.SetActive(value: false);
        animF.SetBool("isVic", value: true);
        animI.SetBool("isVic", value: true);
    }

    public void willcall()
    {
        if (GameObject.Find("Tips")!=null)
        {
            GameObject.Find("Tips").SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex <= 20)
        {
            PlayerPrefs.SetInt("EasyLvUnLockde", (PlayerPrefs.GetInt("EasyLvUnLockde", 1) + 1));
        }
        else
        {
            PlayerPrefs.SetInt("NormalLvUnLockde", (PlayerPrefs.GetInt("NormalLvUnLockde", 1) + 1));
        }
        if (SDKManager.Instance.IsCanShowAd)
        {
            SuccessP.SetActive(value: true);
            SDKManager.Instance.CloseBanner("ԭ�����չʾ�ر�Banner");
        }
        else
        {
            popVic.SetActive(value: true);
        }
       
    }

    public void InitKc(int index)
    {
        switch (index)
        {
            case 0:
                kcBl++;
                textBl.text = " " + kcBl;
                break;
            case 1:
                kcRe++;
                textRe.text = " " + kcRe;
                break;
        }
    }

    public void DestroyKimcuong(int index)
    {
        switch (index)
        {
            case 0:
                kcBl--;
                textBl.text = " " + kcBl;
                break;
            case 1:
                kcRe--;
                textRe.text = " " + kcRe;
                break;
        }
        if (kcBl == 0)
        {
            blueOK = true;
        }
        if (kcRe == 0)
        {
            redOK = true;
        }
    }
    public void btnXSkip()
    {
        // popSkip.SetActive(value: false);
        if (SDKManager.Instance.IsCanShowAd)
        {
            FaileP.SetActive(value: true);
            SDKManager.Instance.CloseBanner("ԭ�����չʾ�ر�Banner");
        }
        else
        {
            popGO.SetActive(value: true);
        }
       
    }    
}
