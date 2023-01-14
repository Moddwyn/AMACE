using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsCounter : MonoBehaviour
{
    public TMP_Text statsText;
    public int totalCorrect;
    public int totalRooms;

    public static StatsCounter Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        statsText.text = "Rooms Completed: " + totalRooms + "\nAnswered Correctly: " + totalCorrect;
    }
}
