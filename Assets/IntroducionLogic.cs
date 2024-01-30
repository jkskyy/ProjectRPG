using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroducionLogic : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject text;
    private bool skipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!skipped)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                skipped = true;
                text.GetComponent<TextMeshProUGUI>().text = "Click Space to continue";
                image1.transform.position = new Vector2(1200, image1.transform.position.y);
                image2.transform.position = new Vector2(1600, image2.transform.position.y);
                image3.transform.position = new Vector2(1600, image3.transform.position.y);
                image4.transform.position = new Vector2(1600, image4.transform.position.y);
                image5.transform.position = new Vector2(1600, image5.transform.position.y);
                image6.transform.position = new Vector2(1600, image6.transform.position.y);
                image7.transform.position = new Vector2(1600, image7.transform.position.y);
            }
            if (image1.transform.position.x < 1200)
            {
                image1.transform.position = new Vector2(image1.transform.position.x + 0.1f, image1.transform.position.y);
            }
            else if (image2.transform.position.x < 1600)
            {
                image2.transform.position = new Vector2(image2.transform.position.x + 0.1f, image2.transform.position.y);
            }
            else if (image3.transform.position.x < 1600)
            {
                image3.transform.position = new Vector2(image3.transform.position.x + 0.1f, image3.transform.position.y);
            }
            else if (image4.transform.position.x < 1600)
            {
                image4.transform.position = new Vector2(image4.transform.position.x + 0.1f, image4.transform.position.y);
            }
            else if (image5.transform.position.x < 1600)
            {
                image5.transform.position = new Vector2(image5.transform.position.x + 0.1f, image5.transform.position.y);
            }
            else if (image6.transform.position.x < 1600)
            {
                image6.transform.position = new Vector2(image6.transform.position.x + 0.1f, image6.transform.position.y);
            }
            else if (image7.transform.position.x < 1600)
            {
                image7.transform.position = new Vector2(image7.transform.position.x + 0.1f, image7.transform.position.y);
            }
        }
        else if(skipped)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }
        }
    }
}
