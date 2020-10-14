using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessPanel : MonoBehaviour
{
    public Button HomeBtn;//返回首页
    public Button RetaryBtn;//重新开始
    public Button NextLvBtn;//下一关
    void Start()
    {
        HomeBtn.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
            InputManager.IPmanager.btnHome();
        });
        RetaryBtn.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
            InputManager.IPmanager.btnReplay();
        });
        NextLvBtn.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
            InputManager.IPmanager.btnNext();
        });
    }

   
}
