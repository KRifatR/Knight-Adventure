using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    [SerializeField] private string[] _parameters;

    
    private void Update()
    {
        gameObject.GetComponent<Text>().text = _parameters[0] + "\n" + _parameters[1] + "\n" + _parameters[2];

    }
}
