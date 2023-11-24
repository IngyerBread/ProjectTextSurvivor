using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    private int currentStage;
    private void Awake()
    {
        instance = this;
    }


}
