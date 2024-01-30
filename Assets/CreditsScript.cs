using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsScript : MonoBehaviour
{
    public GameObject Credits;
    public GameObject ThankYou;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Credits.transform.position.y < 3600) Credits.transform.position = new Vector2(Credits.transform.position.x, Credits.transform.position.y + 0.05f);
        else ThankYou.SetActive(true);
    }
}
