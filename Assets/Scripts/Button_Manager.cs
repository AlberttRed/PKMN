using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Button_Manager : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
 
    GameObject mycam;
    GameObject arrow1;
         GameObject arrow2;
         GameObject arrow3;
    ScreenFader sf;
    bool faded = false;
    void Awake()
    {
         arrow1 = GameObject.Find("arrow1");
         arrow2 = GameObject.Find("arrow2");
         arrow3 = GameObject.Find("arrow3");
    }
    void Start()
    {
        mycam = GameObject.Find("Main Camera");
        sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        arrow1.SetActive(true);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Select();
        //mycam.GetComponents<AudioSource>()[2].Play();
        //if (gameObject.name == "Continuar")
        //{

        //}
        //else if (gameObject.name == "NuevaPartida")
        //{

        //}
        //else
        //{

        //}
        
       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (arrow1.activeSelf)
            {
                Debug.Log("CONTINUAR");
                StartCoroutine(sf.FadeToBlack());
                
                SaveLoad.Load();
                StartCoroutine(End());
            
                   
                
            }
            else if (arrow2.activeSelf)
            {
                Debug.Log("NUEVA PARTIDA");
                sf.FadeToBlack();
            }
            else
            {
                Debug.Log("OPCIONES");
                sf.FadeToBlack();
            }
            
        }
      
    }

    public void OnSelect(BaseEventData eventData)
    {
        Select();
    }
    IEnumerator DoNothing()
    {
        yield return null;
    }

    void Select()
    {
        mycam.GetComponents<AudioSource>()[1].Play();
        if (gameObject.name == "Continuar")
        {
            arrow1.SetActive(true);
            arrow2.SetActive(false);
            arrow3.SetActive(false);         
        }
        else if (gameObject.name == "NuevaPartida")
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
            arrow3.SetActive(false);      
        }
        else
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(true);          
        }
    
}
    IEnumerator End()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("pkmnbo");
    }
}