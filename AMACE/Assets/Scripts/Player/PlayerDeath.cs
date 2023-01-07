using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    public int life;
    public GameObject deadPanel;
    public static PlayerDeath Instance;
    // Start is called before the first frame update
    public bool dead;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        deadPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        dead = true;
        FirstPersonController.Instance.allowJump = false;
        FirstPersonController.Instance.allowLook = false;
        FirstPersonController.Instance.allowMove = false;
        FirstPersonController.Instance.gameObject.GetComponent<CharacterController>().enabled = false;
        deadPanel.SetActive(true);
        if(life > 0)
        {
            life--;
        }
        deadPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "you have " + life + " lives left";
    }
}
