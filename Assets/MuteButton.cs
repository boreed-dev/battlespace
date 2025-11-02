using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{ 
    private Image muteButton;
    public Sprite muteOn;
    public Sprite muteOff;
    private bool isMuted;
    // Start is called before the first frame update
    void Start()
    {
        muteButton = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSprite()
    {
        if (!isMuted)
        {
            muteButton.sprite = muteOff;
            isMuted = true;
        }
        else
        {
            muteButton.sprite = muteOn;
            isMuted = false;
        }
    }
}
