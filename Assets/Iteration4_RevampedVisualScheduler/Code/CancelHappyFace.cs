using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelHappyFace : MonoBehaviour
{
    public GameObject todoCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.SetActive(false);
            todoCanvas.SetActive(true);
            todoCanvas.GetComponents<AudioSource>()[0].Play();
        }
    }
}
