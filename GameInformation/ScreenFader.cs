using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour {
    /*
    //not using yet
    private float fadingTime = 1.5f;
    private Color colorToUse = Color.black;

    //works
    private Animator anim;
    private bool isFading = false;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public IEnumerator FadeToClear() {
        isFading = true;
        anim.SetTrigger("FadeIn");
        while(isFading) {
            yield return null;
        }
    }

    public IEnumerator FadeToColor() {
        isFading = true;
        anim.SetTrigger("FadeOut");
        while(isFading) {
            yield return null;
        }
    }

    void AnimationComplete() {
        isFading = false;
    }*/
    
    public float fadeTime = 5f;
    private static Graphic fadeImage;
    private static ScreenFader faderInformation;
    public static bool fading = true;

    void Awake() {
        if(faderInformation == null) {
            DontDestroyOnLoad(gameObject);
        }
        else if(faderInformation != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        try {
            fadeImage = GameObject.FindGameObjectWithTag("Fader").GetComponent<Graphic>();
        }
        catch { }
        FaderToBlack(false);
    }

    private static void FadeToColor(bool fade) {
        ScreenFader use = new ScreenFader();
        //if(fading) {
        fading = true;
            if(fade) {
                fadeImage.CrossFadeAlpha(1, use.fadeTime, false);
            }
            else {
                fadeImage.CrossFadeAlpha(0, use.fadeTime, false);
            }
            //yield return new WaitForSeconds(use.fadeTime);
           fading = false;
        //}
    }
    private static void FaderToColor(bool fade, Color color, float time) {
        Color tempColor = color;
        ScreenFader use = new ScreenFader();
        if(time > 0) {
            use.fadeTime = time;
        }
        else {
            use.fadeTime = 0f;
        }
        fadeImage.color = tempColor;
        //Debug.Log("alpha: " + fadeImage.color.a);
        fading = true;
        FadeToColor(fade);
    }
    private static void FaderToBlack(bool fade) {
        Color black = Color.black;
        ScreenFader use = new ScreenFader();
        if(fade) {
            black.a = 0f;
        }
        fadeImage.color = black;
        FadeToColor(fade);
    }
    public static void FadeToColor(bool fade, Color color, float time) {
        if(fade) {
            FaderToColor(fade, color, time);
            //yield return new WaitForSeconds(time);
        }
        else {
            //yield return new WaitForSeconds(time);
            FaderToColor(fade, color, time);
        }
        fading = true;
        /*while(fading) {
            yield return null;
        }*/
    }
    //need to figure out corutines
    public static IEnumerator FadeToBlack(bool fade) {
        ScreenFader use = new ScreenFader();
        if(fade) {
            yield return new WaitForSeconds(use.fadeTime);
            FaderToBlack(fade);
        }
        else {
            FaderToBlack(fade);
            yield return new WaitForSeconds(use.fadeTime);
        }
    }
}
