using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoCanvasVoiceOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenSound1());
    }

    void Update()
    {
        
    }

    IEnumerator OpenSound1()
    {

        yield return new WaitForSeconds(5);
        if (RevampedVisualScheduler.soundLock == false)
        {
            AudioListener.volume = 0;
            AudioListener.volume = 1;
            this.GetComponents<AudioSource>()[1].Play();
            StartCoroutine(OpenSound2());
        }
    }

    IEnumerator OpenSound2()
    {
        if (RevampedVisualScheduler.soundLock == false)
        {
            yield return new WaitForSeconds(9);
            AudioListener.volume = 0;
            AudioListener.volume = 1;
            this.GetComponents<AudioSource>()[2].Play();
        }
    }
}
