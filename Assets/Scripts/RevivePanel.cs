using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevivePanel : MonoBehaviour
{
  
    public Button ReviveBtn;//复活
    public Button NoReviveBtn;//不复活
    void Start()
    {
        ReviveBtn.onClick.AddListener(delegate
        {
            InputManager.IPmanager.yesHoiSinh();
        });
        NoReviveBtn.onClick.AddListener(delegate
        {
            this.gameObject.SetActive(false);
            InputManager.IPmanager.FaileP.SetActive(true);
        });
    }
}
