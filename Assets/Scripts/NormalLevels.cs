using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalLevels : MonoBehaviour
{
    public GameObject UnLockPan;
    public Button UnLockBtn;

    public Button[] UnLockBtns;


    void Start()
    {
        UnLockBtn.onClick.AddListener(delegate
        {
           // ToUnlock();
            SDKManager.Instance.ShowAd(ShowAdType.Reward, 1, "解锁关卡");
            IsToUnLock = true;
        });


        CheckLv();

    }

    void CheckLv()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("NormalLvUnLockde", 1); i++)
        {

            UnLockBtns[i + 1].onClick.AddListener(delegate
            {
                UnLockPan.SetActive(true);
            });
            UnLockBtns[i].gameObject.SetActive(false);
        }
    }

    public static bool IsToUnLock = false;
    public void ToUnlock()
    {
        PlayerPrefs.SetInt("NormalLvUnLockde", (PlayerPrefs.GetInt("NormalLvUnLockde", 1) + 1));
        UnLockPan.SetActive(false);
        CheckLv();
    }
}
