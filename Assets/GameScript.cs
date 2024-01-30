using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{
    private bool paused = false;
    public GameObject pauseMenu;
    public Camera mainCamera;
    public GameObject player;
    public GameObject background;
    public LayerMask enemyLayers;
    public GameObject HPVar;
    public GameObject DMGVar;
    public GameObject RANGEVar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused) PauseGame();
            else ResumeGame();
        }
    }

    void PauseGame()
    {
        paused = true;
        player.GetComponent<PlayerScript>().paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        HPVar.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerScript>().hp.ToString();
        DMGVar.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerScript>().damage.ToString();
        RANGEVar.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerScript>().range.ToString();
    }

    void ResumeGame()
    {
        paused = false;
        player.GetComponent<PlayerScript>().paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
