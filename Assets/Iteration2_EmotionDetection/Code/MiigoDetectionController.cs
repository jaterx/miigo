using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiigoDetectionController : MonoBehaviour
{
    public GameObject startScreen;

    public GameObject audioLibrary;

    public List<GameObject> faceList;
    private int faceListLength = 0;
    

    void PlayAudio(int audioIndex) {
        audioLibrary.GetComponents<AudioSource>()[audioIndex].Play();
    }

    void ActivateFace(int targetFace)
    {
        for (int i = 0; i < faceListLength; i++)
        {
            if (i == targetFace)
            {
                faceList[i].SetActive(true);
            }
            else
            {
                faceList[i].SetActive(false);
            }
        }
    }

    void SendLEDRequestASync(int targetEmotion)
    {
        StartCoroutine(SendLEDRequestASyncHelper(targetEmotion));
    }

    IEnumerator SendLEDRequestASyncHelper(int te) {
        UnityWebRequest uwr = UnityWebRequest.Get("http://10.159.23.215:5000/color/" + te.ToString());
        yield return uwr.SendWebRequest();
    }

	public void MiigoMonitor() {
        //Program.miigoInt = 2;
        if (Program.miigoInt == -2)
        {
            ActivateFace(10);
            Program.miigoInt = -1;
        }

        if (Program.miigoInt == 0)
        {
            ActivateFace(2); //Angry
            SendLEDRequestASync(4);
            Program.miigoInt = -1;
        }

        if (Program.miigoInt == 3)
        {
            ActivateFace(0); //Happy
            SendLEDRequestASync(2);
            Program.miigoInt = -1;
        }

        if (Program.miigoInt == 4)
        {
            ActivateFace(1); //Sad
            SendLEDRequestASync(1);
            Program.miigoInt = -1;
        }

        if (Program.miigoInt == 5)
        {
            ActivateFace(3); //Neutral
            SendLEDRequestASync(0);
            Program.miigoInt = -1;
        }

        if (Program.miigoInt == 2)
        {
            ActivateFace(8); //shocked
            SendLEDRequestASync(3);
            Program.miigoInt = -1;
        }

        if (Program.miigoInt == 5)
        {
            ActivateFace(8); //shocked
            SendLEDRequestASync(3);
            Program.miigoInt = -1;
        }
    }

    void Start()
    {
        faceListLength = faceList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        MiigoMonitor();

        /*
         * testing using the keyboard
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SendLEDRequestASync(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SendLEDRequestASync(2);
        }*/
    }
}
