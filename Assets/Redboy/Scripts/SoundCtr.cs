using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundCtr : MonoBehaviour {

    public Sprite On;
    public Sprite Off;
    public Button muteButton;
    void Update()
    {
        CheckSound();
    }
    public void MuteUnmute()
    {
     //   SDKManager.Instance.ShowAd(ShowAdType.ChaPing, 1, "点击音量");
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            PlayerPrefs.SetInt("Mute", 1);
        }
        else if (PlayerPrefs.GetInt("Mute") == 1)
        {
            PlayerPrefs.SetInt("Mute", 0);
        }
    }


    void CheckSound()
    {
        if (PlayerPrefs.GetInt("Mute") == 0)
        {
            AudioListener.volume = 1;
            muteButton.GetComponent<Image>().sprite = On;
        }
        else
        {
            AudioListener.volume = 0;
            muteButton.GetComponent<Image>().sprite = Off;
        }
    }
}
