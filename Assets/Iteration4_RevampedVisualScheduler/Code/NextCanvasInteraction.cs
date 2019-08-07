using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCanvasInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCanvas()
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        this.gameObject.SetActive(false);
    }

    public void GoNext(GameObject targetCanvas)
    {
        AudioListener.volume = 0;
        AudioListener.volume = 1;
        targetCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
