using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiigoSequenceController : MonoBehaviour
{
    public GameObject happyFace;
    public GameObject sadFace;
    public GameObject angryFace;
    public GameObject neturalFace;
    public GameObject waitFace;
    public GameObject cryingFace;
    public GameObject selectionFace;
    public GameObject blinkingFace;
    public GameObject selectedFace;
    public GameObject sleepingFace;
    public GameObject lullabyFace;
    public GameObject startScreen;

    public GameObject audioLibrary;

    void PlayAudio(int audioIndex) {
        audioLibrary.GetComponents<AudioSource>()[audioIndex].Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        ActivateWaitFace();
        StartCoroutine(SyncTimeForOpening());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SyncTimeForOpening()
    {
        yield return new WaitForSeconds(8);
        ActivateNeturalFace();
        PlayAudio(1);
        StartCoroutine(SyncTimeForLetsWatch());
    }

    IEnumerator SyncTimeForLetsWatch()
    {
        yield return new WaitForSeconds(3);
        PlayAudio(2);
        StartCoroutine(SyncTimeForSelection());
    }

    IEnumerator SyncTimeForSelection()
    {
        ActivateSelectionFace();
        yield return new WaitForSeconds(5);
        StartCoroutine(SyncTimeForSelected());
    }

    IEnumerator SyncTimeForSelected()
    {
        ActivateSelectedFace();
        PlayAudio(3);
        yield return new WaitForSeconds(2);
        StartCoroutine(SyncTimeForHappy());
        
    }

    IEnumerator SyncTimeForHappy()
    {
        ActivateNeturalFace();
        yield return new WaitForSeconds(8);
        ActivateHappyFace();
        StartCoroutine(SyncTimeForSad());
    }

    IEnumerator SyncTimeForSad()
    {
        yield return new WaitForSeconds(27);
        ActivateSadFace();
        StartCoroutine(SyncTimeForCry());
    }

    IEnumerator SyncTimeForCry()
    {
        yield return new WaitForSeconds(21);
        ActivateCryingFace();
        StartCoroutine(SyncTimeForAngry());
    }

    IEnumerator SyncTimeForAngry()
    {
        yield return new WaitForSeconds(8);
        ActivateAngryFace();
        StartCoroutine(SyncTimeForNiceVideo());
    }

    IEnumerator SyncTimeForNiceVideo()
    {
        yield return new WaitForSeconds(28);
        ActivateNeturalFace();
        PlayAudio(4);
        StartCoroutine(SyncTimeForBed());
    }

    IEnumerator SyncTimeForBed()
    {
        yield return new WaitForSeconds(5);
        PlayAudio(5);
        StartCoroutine(SyncTimeForGoodnight());
    }

    IEnumerator SyncTimeForGoodnight()
    {
        yield return new WaitForSeconds(5);
        ActivateSleepingFace();
        PlayAudio(6);
        StartCoroutine(SyncTimeForLullaby());
    }

    IEnumerator SyncTimeForLullaby()
    {
        yield return new WaitForSeconds(4);
        ActivateLullabyFace();
        PlayAudio(7);
    }

    void ShowOptionAudio() {
        PlayAudio(8);
    }

    void RightChoice() {
        ActivateHappyFace();
        PlayAudio(9);
    }

    void WrongChoice()
    {
        ActivateHappyFace();
        PlayAudio(10);
    }

    public void ActivateWaitFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(true);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
        PlayAudio(0);
    }

    void ActivateHappyFace() {
        happyFace.SetActive(true);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateSadFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(true);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateNeturalFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(true);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateAngryFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(true);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateWaitingFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(true);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateBlinkingFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(true);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateSelectionFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(true);
        cryingFace.SetActive(false);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateCryingFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(true);
        selectedFace.SetActive(false);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateSelectedFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(true);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateSleepingFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(true);
        sleepingFace.SetActive(true);
        lullabyFace.SetActive(false);
        startScreen.SetActive(false);
    }

    void ActivateLullabyFace()
    {
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        neturalFace.SetActive(false);
        waitFace.SetActive(false);
        blinkingFace.SetActive(false);
        selectionFace.SetActive(false);
        cryingFace.SetActive(false);
        selectedFace.SetActive(true);
        sleepingFace.SetActive(false);
        lullabyFace.SetActive(true);
        startScreen.SetActive(false);
    }
}
