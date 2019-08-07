using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiigoTaskScheduleController : MonoBehaviour
{
    public GameObject thingsToCanvas;
    public GameObject totalScheduleCanvas;
    public GameObject firstWaterCanvas;
    public GameObject quizCanvas;
    public GameObject secondYouTubeCanvas;
    public GameObject quizCanvas2;
    public GameObject thirdDanceCanvas;
    public GameObject goodjobCanvas;
    public GameObject waterHappyCanvas;
    public GameObject youTubeHappyCanvasStart;
    public GameObject selectVideoCanvas;
    public GameObject youTubeHappyCanvasEnd;
    public GameObject quizCanvas3;
    public GameObject danceHappyCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AdminSequence());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator AdminSequence() {
        yield return new WaitForSeconds(4);
        thingsToCanvas.SetActive(false);
        totalScheduleCanvas.SetActive(true);
        StartCoroutine(TaskDrinkWater());
    }

    IEnumerator TaskDrinkWater()
    {
        yield return new WaitForSeconds(12);
        totalScheduleCanvas.SetActive(false);
        firstWaterCanvas.SetActive(true);
        yield return new WaitForSeconds(8);
        firstWaterCanvas.SetActive(false);
        quizCanvas.SetActive(true);
    }

    public void Quiz1Continue() {
        quizCanvas.SetActive(false);
        waterHappyCanvas.SetActive(true);
        StartCoroutine(TaskWatchYouTubeVideo());
    }

    IEnumerator TaskWatchYouTubeVideo()
    {
        yield return new WaitForSeconds(5);
        waterHappyCanvas.SetActive(false);
        secondYouTubeCanvas.SetActive(true);
        yield return new WaitForSeconds(8);
        secondYouTubeCanvas.SetActive(false);
        quizCanvas2.SetActive(true);
    }

    public void Quiz2Continue()
    {
        quizCanvas2.SetActive(false);
        selectVideoCanvas.SetActive(true);
    }

    public void VideoSelectionContinue() {
        selectVideoCanvas.SetActive(false);
        StartCoroutine(YouTubeFace());
    }

    IEnumerator YouTubeFace() {
        youTubeHappyCanvasStart.SetActive(true);
        yield return new WaitForSeconds(15);
        youTubeHappyCanvasStart.SetActive(false);
        youTubeHappyCanvasEnd.SetActive(true);
        yield return new WaitForSeconds(9);
        youTubeHappyCanvasEnd.SetActive(false);
        StartCoroutine(TaskDance());
    }

    IEnumerator TaskDance()
    {
        thirdDanceCanvas.SetActive(true);
        yield return new WaitForSeconds(11);
        thirdDanceCanvas.SetActive(false);
        quizCanvas3.SetActive(true);
    }

    public void Quiz3Continue()
    {
        quizCanvas3.SetActive(false);
        StartCoroutine(LetsDance());
    }

    IEnumerator LetsDance()
    {
        danceHappyCanvas.SetActive(true);
        yield return new WaitForSeconds(9);
        danceHappyCanvas.SetActive(false);
        goodjobCanvas.SetActive(true);
    }

    IEnumerator GoodJob() {
        goodjobCanvas.SetActive(true);
        yield return null;
    }
}
