﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    private TextGenerator t;
    public Text theText;
    float _oldWidth;
    float _oldHeight;
    float _fontSize = 14;
    float Ratio = 20; // public
    public TextAsset textFile;
    public string[] textLines;
    private int char_visibles = 0;
    public int currentLine;
    public int endAtLine;
    public int altura = 70;
    public bool isActive;
    public bool stopPlayerMovement;
    Camera mycam;
    public Player player;
    private bool first = true;
    private bool isTyping = false;
    private bool cancelTyping = false;
    RectTransform panelRectTransform;
    public float typeSpeed;


    

    void Start()
    {
        SaveLoad.Load();
        Debug.Log("mic");
        panelRectTransform = GameObject.FindGameObjectWithTag("TextBoxOverWorld").GetComponent<RectTransform>();
        mycam = GetComponent<Camera>();
        // yield return new WaitForSeconds(1);

        player = GameObject.FindWithTag("Player").GetComponent<Player>();


        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
            Debug.Log("Finestra si, jugador parat, canmove = " + player.CanMove);
        }
        else
        {
            DisableTextBox();
            Debug.Log("Finestra no, jugador actiu, canmove= " + player.CanMove);
        }


    }



    void Update()
    {
        //if (_oldWidth != Screen.width || _oldHeight != Screen.height)
        //{
        //    _oldWidth = Screen.width;
        //    _oldHeight = Screen.height;
        //    _fontSize = Mathf.Min(Screen.width, Screen.height) / Ratio;
        //}
        //theText.fontSize = (int)_fontSize;
      //  panelRectTransform.sizeDelta = new Vector2(panelRectTransform.sizeDelta.x, mycam.pixelHeight/(mycam.pixelHeight / altura));// Screen.height/100*20);
        //panelRectTransform.sizeDelta = new Vector2(200, 200);
        Debug.Log(panelRectTransform.gameObject.name);
        if (!isActive)
        {
            return;
        }

   //     theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {

            
            currentLine += 1;
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                    Debug.Log("end: " + player.CanMove);
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }

            }
            else
            {
                if(isTyping && !cancelTyping)
                {
                    cancelTyping = true; 
                }
            }
        }
  
    }
    static IEnumerable<string> Split(string str, int chunkSize)
    {

        double length = str.Length;
        double size = chunkSize;
        int count = (int)Math.Ceiling(length / size);

        return Enumerable.Range(0, count)
            .Select(i => str.Substring(i * chunkSize, (i * chunkSize + chunkSize <= str.Length) ? chunkSize : str.Length - i * chunkSize));
       //     .Select(i => str.Substring((i * chunkSize + chunkSize <= str.Length) ? chunkSize : str.Length - i * chunkSize));
        // .Select(i => str.Substring(i * chunkSize, chunkSize));

    }
    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        
        //if (first)
        //{

        // //   StartCoroutine(CalculateCharactersVisibles(lineOfText));
        //}
        //while (theText.text.Length == 0)
        //{
        //    theText.text = lineOfText;
        //    yield return null;// new WaitForSeconds(0.001f);
        //}
        ////  StartCoroutine(ClearTextBox());

       
        //while (t == null)
        //{
        //    t = theText.cachedTextGenerator;
         
        //    Debug.Log("cached :" + t);

        //    yield return null; // new WaitForSeconds(0.001f);
        //}
        //while (char_visibles == 0)
        //{
        //    char_visibles = t.characterCountVisible;
        //    Debug.Log("charvisibles :" + char_visibles);

        //    yield return null;// new WaitForSeconds(0.001f);
        //}
        //while (theText.text != "")
        //{
        //    theText.text = "";
        //    Debug.Log("Lol :" + theText.text);

        //    yield return null;// new WaitForSeconds(0.001f);
        //}
        isTyping = true;
        cancelTyping = false;
        //t = theText.cachedTextGenerator;
        //char_visibles = t.characterCountVisible;
      //  Debug.Log(char_visibles);
        theText.text = "";
        yield return null;
        //  string result = theText.text.Substring(0, t.characterCountVisible);
        //Debug.Log("Generated " + t.characterCountVisible + " characters");
        //Debug.Log("Visible string is: ");
        //Debug.Log(result);
        // theText.text = "";
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter++;

            if (theText.text.Length == 70)
            {
                cancelTyping = true;
            }
            yield return new WaitForSeconds(1 / typeSpeed);
        }
        if(lineOfText.Length >= 70)
        {
            theText.text = lineOfText.Substring(0, 70);
        }
        else
        {
            theText.text = lineOfText.Substring(0, lineOfText.Length);
        }
        
        
        
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if (stopPlayerMovement)
        {
            Debug.Log("Ha entrat");
            player.CanMove = false;
        }
        StartCoroutine(TextScroll(textLines[currentLine]));

    }

    //public void EnableTextBox(string text)
    //{
    //    textBox.SetActive(true);
    //    isActive = true;
    //    if (stopPlayerMovement)
    //    {
    //        Debug.Log("Ha entrat");
    //        player.CanMove = false;
    //    }

    //    StartCoroutine(TextScroll(text));

    //}

    public void TextBox_Write(string text)
    {
        textLines = Split(text, 70).ToArray<string>();
        currentLine = 0;
        endAtLine = textLines.Length -1;
        EnableTextBox();
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.CanMove = true;
        
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));

        }
    }

}
