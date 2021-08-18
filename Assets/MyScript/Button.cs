using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string[] textMessage;
    public string[,] textWords;

    private int rowLength;
    private int columnLength;

    void Start()
    {
        TextAsset textAsset = new TextAsset();
        textAsset = Resources.Load("Test", typeof(TextAsset)) as TextAsset;
        string TextLines = textAsset.text;

        textMessage = TextLines.Split('\n');

        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        textWords = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {
            string[] tempWords = textMessage[i].Split('\t');

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n];
                Debug.Log(textWords[i, n]);
            }
        }
    }
}
