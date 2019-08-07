using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnceWatch : MonoBehaviour
{
    public GameObject nextCanvas;
    public GameObject watchDone;
    public GameObject watchUndone;
    public GameObject learnUndone;
    public GameObject happyFace;

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
        yield return new WaitForSeconds(8);
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        this.GetComponents<AudioSource>()[0].enabled = false;
    }

    public void MuteSound()
    {
        this.gameObject.SetActive(false);
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        this.GetComponents<AudioSource>()[0].enabled = false;
    }

    public void OpenNext()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        nextCanvas.SetActive(true);
        this.gameObject.SetActive(false);
        learnUndone.transform.position = watchUndone.transform.position;
        watchDone.SetActive(true);
        watchUndone.SetActive(false);
        RevampedVisualScheduler.currentProgress = 2;
        happyFace.SetActive(true);
    }


}
