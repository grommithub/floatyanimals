using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip myBGM, myPumpClip, myItemClip;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myBGM = Resources.Load<AudioClip>("BGM");
        myPumpClip = Resources.Load<AudioClip>("PumpClip");
        myItemClip = Resources.Load<AudioClip>("ItemClip");
        myAudio.PlayOneShot(myBGM);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            myAudio.PlayOneShot(myPumpClip);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Item"|| other.gameObject.name == "Item (1)" || other.gameObject.name == "Item (2)" || other.gameObject.name == "Item (3)" || other.gameObject.name == "Item (4)")
        {
            myAudio.PlayOneShot(myItemClip);
        }
    }
}
