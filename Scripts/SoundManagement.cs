using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    public AudioClip batterHit, correct, incorrect;
    static AudioSource audioSrc;

    void Start()
    {
        //batterHit = Resources.Load<AudioClip>("BatterHit");
        //correct = Resources.Load<AudioClip>("Correct");
        //incorrect = Resources.Load<AudioClip>("Incorrect");

        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "batterHit":
                audioSrc.PlayOneShot(batterHit);
                break;
            case "correct":
                audioSrc.PlayOneShot(correct);
                break;
            case "incorrect":
                audioSrc.PlayOneShot(incorrect);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
