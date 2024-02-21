using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class String : MonoBehaviour
{
    MiniGameController mngc;

    public float timToDestroy = 3f;
    private void Start()
    {
        mngc = FindObjectOfType<MiniGameController>();
        Destroy(gameObject, timToDestroy);
        ChuoiCoSan();
    }
    private void Update()
    {

    }

    public string FixString(string txt)
    {
        string result = "";
        txt = txt.Trim();
        while (txt.IndexOf("  ") != -1)
        {
            txt = txt.Replace("  ", " ");
        }
        string[] subString = txt.Split(' ');
        for (int i = 0; i < subString.Length; i++)
        {
            string firstChar = subString[i].Substring(0, 1);
            string otherChar = subString[i].Substring(1);
            subString[i] = firstChar.ToUpper() + otherChar.ToLower();
            result += subString[i] + " ";
           
        }

        return result;
    }
    public void ChuoiCoSan()
    {
        System.Random rand = new System.Random();
        string[] ar = { "Cailon", "Concu", "x", "y", "z" };
        int index = rand.Next(ar.Length);
        string randomString = ar[index];
        randomString = FixString(randomString);
        mngc.TextToDisplay("hhhhh" + randomString);
        
        //Console.WriteLine(randomString);
        
    }





}
