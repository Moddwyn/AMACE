using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void Die(bool deathAnswer)
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
        if(life <= 0 || (DungeonGenerator.Instance.currentRoom + 1 == DungeonGenerator.Instance.roomCount))
        {
            deadPanel.transform.GetChild(2).gameObject.SetActive(false);
            deadPanel.transform.GetChild(5).gameObject.SetActive(true);
            deadPanel.transform.GetChild(3).GetComponent<TMP_Text>().text = "GAME OVER";
        }
        deadPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = "You have " + life + " lives left";

        if(deathAnswer)
        {
            deadPanel.transform.GetChild(4).GetComponent<TMP_Text>().text = "ROOM " + (DungeonGenerator.Instance.currentRoom) + "/" + DungeonGenerator.Instance.roomCount;
            deadPanel.transform.GetChild(1).GetComponent<Image>().sprite = 
            DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom-1).GetChild(1).GetComponentInChildren<QuestionsManager>()._questions.solution;
        } else
        {
            deadPanel.transform.GetChild(4).GetComponent<TMP_Text>().text = "ROOM " + (DungeonGenerator.Instance.currentRoom+1) + "/" + DungeonGenerator.Instance.roomCount;
            deadPanel.transform.GetChild(1).GetComponent<Image>().sprite = 
            DungeonGenerator.Instance.transform.GetChild(DungeonGenerator.Instance.currentRoom).GetChild(1).GetComponentInChildren<QuestionsManager>()._questions.solution;
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
