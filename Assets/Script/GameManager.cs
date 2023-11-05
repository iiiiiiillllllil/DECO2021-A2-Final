using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool flag;
    private void Awake()
    {
        instance = this;
        flag = true;
    }
}
