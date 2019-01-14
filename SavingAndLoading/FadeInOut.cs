using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {

    public float fadeSpeed = 1.4f;//how quickly the alpha is increased or decreased (how fast the fader goes to black or clear)
    public float fadeDuration = 1.6f;// how long the script waits while fading. Typically this time should be longer than fadeSpeed
    public bool isFaded = true;//true to fade in and false to fade out
    public bool activated = false;//true to begin fading 
    public GameObject fader;//the fader object in the cavas that actually fades in and out
    Image im;//reference to the fader object
    private float curTime;

    void Start()
    {
        im = fader.GetComponent<Image>();
    }
    void Update()
    {
        if (activated) 
            {
            if (!isFaded)
            {
                FadeToBlack();
            }
            if (isFaded)
            {
                FadeToClear();

            }
        }
   
    }


    public void FadeToBlack()
    {
        im.color = Color.Lerp(im.color, Color.black, fadeSpeed * Time.deltaTime);
        if (curTime == 0)
            curTime = Time.time;
        if ((Time.time - curTime) >= fadeDuration)
        {
            curTime = 0;
            activated = false;
        }

    }
    public void FadeToClear()
    {
        im.color = Color.Lerp(im.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (curTime == 0)
            curTime = Time.time;
        if ((Time.time - curTime) >= fadeDuration)
        {
            curTime = 0;
            activated = false;

        }
    }
}
