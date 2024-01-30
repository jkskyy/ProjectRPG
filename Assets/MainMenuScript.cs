using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource _mainMenuMusic;
    public GameObject FirstBackground;
    public GameObject SecondBackground;
    // Start is called before the first frame update
    void Start()
    {
        _mainMenuMusic.Play();
        FirstBackground.transform.position = new Vector2(0, 0);
        SecondBackground.transform.position = new Vector2(21.4f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(SecondBackground.transform.position.x < -21.4)
        {
            SecondBackground.transform.position = new Vector2(21.4f, 0);
        }

        if (FirstBackground.transform.position.x < -21.4)
        {
            FirstBackground.transform.position = new Vector2(21.4f, 0);
        }

        FirstBackground.transform.position = new Vector2(FirstBackground.transform.position.x - 0.001f, FirstBackground.transform.position.y);
        SecondBackground.transform.position = new Vector2(SecondBackground.transform.position.x - 0.001f, SecondBackground.transform.position.y);
    }

    public IEnumerator firstBG()
    {
        while(FirstBackground)
        {
            yield return new WaitForSeconds(0.0008f);
            FirstBackground.transform.position = new Vector2(FirstBackground.transform.position.x - 0.001f, FirstBackground.transform.position.y);
            
        }
        yield return 0;
    }

    public void Play()
    {
        SceneManager.LoadScene("Introducion", LoadSceneMode.Single);
    }

    public void Controls()
    {
        GameObject.FindGameObjectWithTag("MainUI").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("ControlsUI").GetComponent<Canvas>().enabled = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        GameObject.FindGameObjectWithTag("ControlsUI").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("MainUI").GetComponent<Canvas>().enabled = true;
    }
}
