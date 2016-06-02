using UnityEngine;
using System.Collections;

public class CameraMainMenu : MonoBehaviour {
    ScreenFader sf;
    Camera mycam;
    Animator anim;
    GameObject portada;
    GameObject background;
    GameObject menu;
    bool enter;
    // Use this for initialization
    IEnumerator Start () {
        enter = false;
        mycam = GetComponent<Camera>();
         portada = GameObject.Find("Panel_Portada");
         background = GameObject.Find("Background");
        menu = GameObject.Find("Panel_Menu");
        //GameObject.Find("Panel").transform.localScale = new Vector3(mycam.orthographicSize / 2 * (Screen.width / Screen.height), mycam.orthographicSize / 2, 0f);
        //GameObject.Find("Panel_Portada").transform.localScale = new Vector3(mycam.orthographicSize / 2 * (Screen.width / Screen.height), mycam.orthographicSize / 2, 0f);
        //GameObject.Find("Image").transform.localScale = new Vector3(mycam.orthographicSize / 2 * (Screen.width / Screen.height), mycam.orthographicSize / 2, 0f);
        sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        Debug.Log("MainMenuCamera");
        if (!sf.GetFading())
        {
            menu.SetActive(false);
            portada.SetActive(false);
            //background.SetActive(false);
            yield return StartCoroutine(sf.FadeToClear());
            yield return StartCoroutine(sf.FadeToBlack());
            
            GameObject.Find("Panel_Credits").SetActive(false);
            mycam.GetComponents<AudioSource>()[0].Play();
            portada.SetActive(true);
            // background.SetActive(true);
            yield return StartCoroutine(sf.FadeToClear());
            background.GetComponentInChildren<Animation>().Play();
            GameObject.Find("PressIntro").GetComponent<Animation>().Play();
        }
     
       // yield return StartCoroutine(sf.FadeToBlack());
        //LOL(); 
    }
	
	// Update is called once per frame
	void Update () {
        //GameObject.Find("Image").transform.localScale = new Vector3(mycam.orthographicSize / 2 * (Screen.width / Screen.height), mycam.orthographicSize / 2, 0f);
       // RectTransform panelRectTransform = GameObject.Find("Panel").GetComponent<RectTransform>();
        //panelRectTransform.sizeDelta = new Vector2((float)xPos + 10, panelRectTransform.sizeDelta.y);
        mycam.orthographicSize = (Screen.height / 100f) / 2f;
        GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta = new Vector2(mycam.pixelWidth, mycam.pixelHeight);

        if (Input.GetKeyDown(KeyCode.Return))
        {
           
           

                if (!enter)
                {
                    enter = true;
                    Debug.Log("MEC");
                    StartCoroutine(Enter());
                }
            
           
        }
    }

    IEnumerator Enter()
    {
        Debug.Log("COMEON");
        enter = true;
        mycam.GetComponents<AudioSource>()[2].Play();
        yield return StartCoroutine(sf.FadeToBlack());
        portada.SetActive(false);
        menu.SetActive(true);
        yield return StartCoroutine(sf.FadeToClear());
       
    }
   

}
