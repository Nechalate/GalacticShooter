using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefText : MonoBehaviour
{
    public string name;
    // простое сохранение результата с помощью "PlayerPrefs".
    void Update()
    {
        GetComponent<Text>().text=PlayerPrefs.GetInt(name)+"";
    }
}
