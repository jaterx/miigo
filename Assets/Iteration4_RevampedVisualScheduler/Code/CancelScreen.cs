using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(OpenSound());
    }

    IEnumerator OpenSound()
    {
        yield return new WaitForSeconds(5);
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        this.gameObject.SetActive(false);
    }
}
