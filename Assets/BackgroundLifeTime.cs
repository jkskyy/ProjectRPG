using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLifeTime : MonoBehaviour
{
    public float TimeToLive = 23;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(TimeToLive);
        Destroy(gameObject);
    }
}
