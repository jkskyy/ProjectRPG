using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float TimeToLive = 1;
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
