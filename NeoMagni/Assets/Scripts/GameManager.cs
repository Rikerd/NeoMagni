using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int gameOverSceneIndex;
    
    [HideInInspector]
    public static bool gameOver;

    private Fader fade;
    private GameObject eventSystem;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;

        gameOver = false;

        fade = GetComponent<Fader>();
        eventSystem = GameObject.Find("EventSystem");
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            LoadSceneByIndex(gameOverSceneIndex);
            Time.timeScale = 0f;
        }
	}

    public void LoadSceneByIndex(int sceneIndex)
    {
        if (eventSystem != null)
            eventSystem.SetActive(false);
        StartCoroutine(FadeWait(sceneIndex));
    }

    IEnumerator FadeWait(int sceneIndex)
    {
        float fadeTime = fade.BeginSceneFade(1);
        fade.BeginAudioFade(1);

        yield return new WaitForSecondsRealtime(fadeTime);

        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneIndex);
    }

    public void setGameOver(bool status)
    {
        gameOver = status;
    }
}
