using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnce : MonoBehaviour
{
    public GameObject nextCanvas;
	public GameObject playDone;
	public GameObject playUndone;
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
        yield return new WaitForSeconds(21);
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
        nextCanvas.SetActive(true);
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        this.gameObject.SetActive(false);
		learnUndone.transform.position = watchUndone.transform.position;
		watchUndone.transform.position = playUndone.transform.position;
		playDone.SetActive(true);
		playUndone.SetActive(false);
		RevampedVisualScheduler.currentProgress = 1;
		happyFace.SetActive(true);
    }


}
