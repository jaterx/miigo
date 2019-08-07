using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RevampedVisualScheduler : MonoBehaviour
{
    public GameObject playCanvas;
    public GameObject watchCanvas;
    public GameObject learnCanvas;
    public GameObject sleepCanvas;
    
    public GameObject warningCanvas;
    public GameObject allDoneCanvas;
    public GameObject doneCanvas;

    public GameObject newHappyFace;
    public GameObject newAngryFace;
    public GameObject newNormalFace;
    public GameObject newSadFace;

    public GameObject toDoCanvas;

    public GameObject helpCanvasPlay;
    public GameObject helpCanvasWatch;
    public GameObject helpCanvasLearn;

    public GameObject playDone;
    public GameObject watchDone;
    public GameObject learnDone;

    public static int currentProgress = 0;

    public int faceNum = 0;
    public static bool soundLock = false;

    public static bool happyLock = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)){
            if (happyLock == false)
            {
                newHappyFace.SetActive(false);
                newAngryFace.SetActive(false);
                newNormalFace.SetActive(false);
                newSadFace.SetActive(false);
                AudioListener.volume = 0;
            }
		}

        /*
        if (faceNum == 1)
        {
            newHappyFace.SetActive(true);
            newAngryFace.SetActive(false);
            newNormalFace.SetActive(false);
            newSadFace.SetActive(false);
        }
        if (faceNum == 2)
        {
            newHappyFace.SetActive(false);
            newAngryFace.SetActive(true);
            newNormalFace.SetActive(false);
            newSadFace.SetActive(false);
        }
        if (faceNum == 3)
        {
            newHappyFace.SetActive(false);
            newAngryFace.SetActive(false);
            newNormalFace.SetActive(true);
            newSadFace.SetActive(false);
        }
        if (faceNum == 4)
        {
            newHappyFace.SetActive(false);
            newAngryFace.SetActive(false);
            newNormalFace.SetActive(false);
            newSadFace.SetActive(true);
        }
        if (faceNum > 4)
        {
            newHappyFace.SetActive(false);
            newAngryFace.SetActive(false);
            newNormalFace.SetActive(false);
            newSadFace.SetActive(false);
        }*/
    }

    public void ShowPlayCanvas() {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        playCanvas.SetActive(true);
        toDoCanvas.GetComponents<AudioSource>()[0].Stop();
        toDoCanvas.GetComponents<AudioSource>()[1].Stop();
        toDoCanvas.GetComponents<AudioSource>()[2].Stop();
        soundLock = true;
    }

    public void ClosePlayCanvas()
    {
        playCanvas.SetActive(false);
    }

    public void ShowWatchCanvas()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        watchCanvas.SetActive(true);
        toDoCanvas.GetComponents<AudioSource>()[0].Stop();
        toDoCanvas.GetComponents<AudioSource>()[1].Stop();
        toDoCanvas.GetComponents<AudioSource>()[2].Stop();
        soundLock = true;
    }

    public void PlayWatchSound()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        playCanvas.GetComponents<AudioSource>()[0].Stop();
        playCanvas.GetComponents<AudioSource>()[1].Play();
        //soundLock = true;
    }

    public void PlayPlanSound()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        GetComponents<AudioSource>()[0].Play();
    }

    public void PlayLearnSound()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        watchCanvas.GetComponents<AudioSource>()[0].Stop();
        watchCanvas.GetComponents<AudioSource>()[1].Play();
    }

    public void PlayHelpSound()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        GetComponents<AudioSource>()[1].Play();
    }
    public void PlayDoneSound()
    {
        AudioListener.volume = 1;
        GetComponents<AudioSource>()[2].Play();
    }

    public void CloseWatchCanvas()
    {
        watchCanvas.SetActive(false);
    }

    public void ShowLearnCanvas()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        learnCanvas.SetActive(true);
        toDoCanvas.GetComponents<AudioSource>()[0].Stop();
        toDoCanvas.GetComponents<AudioSource>()[1].Stop();
        toDoCanvas.GetComponents<AudioSource>()[2].Stop();
        soundLock = true;
    }

    public void CloseLearnCanvas()
    {
        learnCanvas.SetActive(false);
    }

	void SendLEDRequestASyncImage(int targetEmotion)
	{
		StartCoroutine(SendLEDRequestASyncHelperImage(targetEmotion));
	}

	IEnumerator SendLEDRequestASyncHelperImage(int te)
	{
		UnityWebRequest uwr = UnityWebRequest.Get("http://10.159.23.215:5000/image/" + te.ToString());
		yield return uwr.SendWebRequest();
	}

	public void ShowSleepCanvas()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        SendLEDRequestASyncImage(2);
		sleepCanvas.SetActive(true);
        toDoCanvas.GetComponents<AudioSource>()[0].Stop();
        toDoCanvas.GetComponents<AudioSource>()[1].Stop();
        toDoCanvas.GetComponents<AudioSource>()[2].Stop();
        soundLock = true;
    }

    public void CloseSleepCanvas()
    {
        sleepCanvas.SetActive(false);
    }

    public void ShowHelpCanvasPlay()
    {
        helpCanvasPlay.SetActive(true);
        playCanvas.GetComponents<AudioSource>()[0].Stop();
        playCanvas.GetComponents<AudioSource>()[1].Stop();
    }

    public void ShowHelpCanvasLearn()
    {
        helpCanvasLearn.SetActive(true);
        learnCanvas.GetComponents<AudioSource>()[0].Stop();
        learnCanvas.GetComponents<AudioSource>()[1].Stop();
    }

    public void ShowHelpCanvasWatch()
    {
        helpCanvasWatch.SetActive(true);
        watchCanvas.GetComponents<AudioSource>()[0].Stop();
        watchCanvas.GetComponents<AudioSource>()[1].Stop();
    }

    public void CloseHelpCanvasPlay()
    {
        helpCanvasPlay.SetActive(false);
        GetComponents<AudioSource>()[1].Stop();
    }

    public void CloseHelpCanvasLearn()
    {
        helpCanvasLearn.SetActive(false);
        GetComponents<AudioSource>()[1].Stop();
    }

    public void CloseHelpCanvasWatch()
    {
        helpCanvasWatch.SetActive(false);
        GetComponents<AudioSource>()[1].Stop();
    }

    public void ShowWatchWarngingCanvas() {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        if (RevampedVisualScheduler.currentProgress == 1)
        {
            ShowWatchCanvas();
        }
        else {
            warningCanvas.SetActive(true);
        }
        toDoCanvas.GetComponents<AudioSource>()[0].Stop();
        toDoCanvas.GetComponents<AudioSource>()[1].Stop();
        toDoCanvas.GetComponents<AudioSource>()[2].Stop();
        soundLock = true;
    }

    public void ShowLearnWarngingCanvas()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        if (RevampedVisualScheduler.currentProgress == 2)
        {
            ShowLearnCanvas();
        }
        else
        {
            warningCanvas.SetActive(true);
        }
        toDoCanvas.GetComponents<AudioSource>()[0].Stop();
        toDoCanvas.GetComponents<AudioSource>()[1].Stop();
        toDoCanvas.GetComponents<AudioSource>()[2].Stop();
        soundLock = true;
    }

    public void CloseWarngingCanvas()
    {
        warningCanvas.SetActive(false);
    }

    public void ShowDoneCanvas()
    {
		doneCanvas.SetActive(true);
    }

    public void CloseDoneCanvas()
    {
        doneCanvas.SetActive(false);
    }

    public void ShowAllDoneCanvas()
	{
        SendLEDRequestASyncImage(1);
	    allDoneCanvas.SetActive(true);
    }
}
