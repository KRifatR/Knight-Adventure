using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishQuest : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
     public void Update()
    {
        if (_boss == null && PlayerData.Quest_1 == 0)
        {
            PlayerData.Quest_1 = 1;
        }
    }
}
