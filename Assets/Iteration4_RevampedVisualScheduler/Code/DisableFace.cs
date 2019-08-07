using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFace : MonoBehaviour
{
    public GameObject happyCanvas;
    public GameObject omgButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RevampedVisualScheduler.happyLock = true;
            happyCanvas.SetActive(true);
            omgButton.SetActive(true);

        }
    }
}
