using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    
    public bool win;
    public static TriggerWin Instance;

    void Awake()
    {
        Instance = this;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            win = true;
            PlayerDeath.Instance.deadPanel.transform.parent.GetChild(3).gameObject.SetActive(true);
            FirstPersonController.Instance.allowJump = false;
            FirstPersonController.Instance.allowLook = false;
            FirstPersonController.Instance.allowMove = false;
            FirstPersonController.Instance.gameObject.GetComponent<CharacterController>().enabled = false;
        }
    }
}
