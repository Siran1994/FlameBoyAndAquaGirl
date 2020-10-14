// DecompilerFi decompiler from Assembly-CSharp.dll class: GameManagerDemo
// SourcesPostProcessor 

using UnityEngine;
using UnityEngine.Advertisements;

public class GameManagerDemo : MonoBehaviour
{
    public static GameManagerDemo Instance;

    public LoadingScenesControll _loading;

    public GameObject WinPanel;

    public GameObject PausePanel;

    public GameObject LosePanel;

    public GameObject HsPanel;



    public string nameMenu;

    private int countHS;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

      //  SDK.Instance.ShowBanner();
        countHS = 0;
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausePanel.activeInHierarchy)
            {
                Home();
            }
            else if ((WinPanel == null || (WinPanel != null && !WinPanel.activeInHierarchy)) && (LosePanel == null || (LosePanel != null && !LosePanel.activeInHierarchy)) && (HsPanel == null || (HsPanel != null && !HsPanel.activeInHierarchy)) && (_loading == null || (_loading != null && !_loading.gameObject.activeInHierarchy)))
            {
                Time.timeScale = 0f;
                PausePanel.SetActive(value: true);
            }
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
        {
            WinCall();
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.L))
        {
            LoseCall();
        }
    }

    public void WinCall()
    {
        Time.timeScale = 0f;
        WinPanel.SetActive(value: true);
    }

    public void LoseCall()
    {
        Time.timeScale = 0f;
        if (HsPanel != null)
        {
            if (countHS == 0)
            {
                countHS++;
                HsPanel.SetActive(value: true);
            }
            else
            {
                LosePanel.SetActive(value: true);
                HsPanel.SetActive(value: false);
            }
        }
        else
        {
            LosePanel.SetActive(value: true);
        }
    }

    public void hs()
    {



    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(value: false);
    }

    public void Next()
    {
        //SDK.Instance.HideBanner();
        UnityEngine.Debug.Log("next");
    }

    public void Replay()
    {
       // SDK.Instance.HideBanner();
        if (_loading == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            return;
        }
        _loading.NextScenes = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        _loading.gameObject.SetActive(value: true);
        Time.timeScale = 0f;
    }

    public void Home()
    {
       // SDK.Instance.HideBanner();
        if (_loading == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nameMenu);
            return;
        }
        _loading.NextScenes = nameMenu;
        _loading.gameObject.SetActive(value: true);
        Time.timeScale = 0f;
    }
}
