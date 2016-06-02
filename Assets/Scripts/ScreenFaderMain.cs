using UnityEngine;
using System.Collections;

public class ScreenFaderMain : MonoBehaviour {

    Animator anim;
    bool isFading = false;

    // Use this for initialization
    void Start()
    {


    }

    public IEnumerator FadeToClear()
    {
        anim = GetComponent<Animator>();
        Debug.Log("FadeToClear");
        isFading = true;
        anim.SetTrigger("Fade In");

        while (isFading)
            yield return null;
    }

    public IEnumerator FadeToBlack()
    {
        anim = GetComponent<Animator>();
        Debug.Log("FadeToBlack");
        isFading = true;
        anim.SetTrigger("Fade Out");

        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
        Debug.Log(isFading);
    }

    public bool GetFading()
    {
        return isFading;
    }
}
