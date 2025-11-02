using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Title : MonoBehaviour
{
    public TMP_Text press_any_key;
    private Animator myAnim;
    public Animator textAnimator;
    private bool muteClicked;
    private GameObject muteButton;

    // Start is called before the first frame update
    void Start()
    {
        muteClicked = false;
        myAnim = GetComponent<Animator>();
        muteButton = GameObject.Find("Mute").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        switch(FSM.fsm.state)
        {
            case FSM.gamestate.title :
                if (Input.anyKeyDown)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        myAnim.Play("FadeOut");
                    }
                    else if (Input.GetMouseButtonDown(0))
                    {
                        PointerEventData pointerData = new PointerEventData(EventSystem.current);
                        pointerData.position = Input.mousePosition;

                        // Run raycast
                        List<RaycastResult> results = new List<RaycastResult>();
                        EventSystem.current.RaycastAll(pointerData, results);
                        bool mutePressed = false;

                        // Check every raycast results
                        foreach (RaycastResult result in results)
                        {
                            // If the clicked object is my button, perform condition
                            if (result.gameObject == muteButton)
                            {
                                mutePressed = true;
                            }
                        }

                        if (!mutePressed)
                        {
                            if (!muteClicked)
                            {
                                FSM.fsm.state = FSM.gamestate.menu;
                                Main.main.comeFromTitle = true;
                                textAnimator.SetTrigger("startDissolve");
                                break;
                            }
                        }
                        
                    }
                }
                    
                break;
        }   

    }

    public void onMuteClicked()
    {
        muteClicked = true;
    }

    public void onFadeOutCompleted()
    {
        FSM.fsm.state = FSM.gamestate.credits;
    }
}
