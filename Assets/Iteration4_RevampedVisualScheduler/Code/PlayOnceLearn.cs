using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnceLearn : MonoBehaviour
{
    public GameObject nextCanvas;
    public GameObject learnDone;
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
        yield return new WaitForSeconds(7);
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        this.GetComponents<AudioSource>()[0].enabled = false;
    }

    public void MuteSound()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        this.gameObject.SetActive(false);
        this.GetComponents<AudioSource>()[0].enabled = false;
    }

    public void OpenNext()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        nextCanvas.SetActive(true);
        this.gameObject.SetActive(false);
        learnDone.SetActive(true);
        learnUndone.SetActive(false);
        happyFace.SetActive(true);
    }


}
