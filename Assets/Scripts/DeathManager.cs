using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    GameObject player;
    bool gameover=false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (player == null && !gameover) {
            GameOver();
        }
    }
    void GameOver() {
        gameover = true;
        if(PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
        StartCoroutine(LoadGameOver());
    }
    IEnumerator LoadGameOver() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
