using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NOTE_BodyScript : MonoBehaviour
{
    [SerializeField]
    GameObject g_clef, bass_clef;

    [SerializeField]
    GameObject[] additionalLines;

    [SerializeField]
    GameObject notesHolder;

    [SerializeField]
    GameObject trueSign, falseSign, yourText, correctText;

    [SerializeField]
    bool _doLogs;
    [SerializeField, Range(1, 10)]
    int _delayAfterChoice;

    private bool isBassKey;
    private int noteNumber = 1;
    private string correctAnswer;

    private Dictionary<string, string> EN_Notes = new Dictionary<string, string> 
    { {"A","A"}, { "B", "B" }, { "C", "C" }, { "D", "D" }, { "E", "E" }, { "F", "F" }, { "G", "G" } };

    private Dictionary<string, string> RU_Notes = new Dictionary<string, string> 
    { { "A", "Ля" }, { "B", "Си" }, { "C", "До" }, { "D", "Ре" }, { "E", "Ми" }, { "F", "Фа" }, { "G", "Соль" } };

    void Start()
    {
        GenerateNew();
    }
    
    void GenerateNew()
    {
        //choose key for notes
        if (Random.Range(0, 2) == 0)
        {
            isBassKey = false;
            g_clef.SetActive(true);
        }
        else
        {
            isBassKey = true;
            bass_clef.SetActive(true);
        }

        //generate note number & 
        noteNumber = Random.Range(1, 20);
        //turn it on with additional lines
        notesHolder.transform.Find($"{noteNumber}").gameObject.SetActive(true);
        if (noteNumber <= 2)
            additionalLines[0].SetActive(true);
        if (noteNumber <= 4)
            additionalLines[1].SetActive(true);
        if (noteNumber >= 16)
            additionalLines[2].SetActive(true);
        if (noteNumber >= 18)
            additionalLines[3].SetActive(true);

        correctAnswer = whatIsItThisNote();
        correctText.GetComponent<TextMeshProUGUI>().text = correctAnswer;

        Log(correctAnswer);
    }

    void Update()
    {
        if (NOTE_VariableSaver._currentVar != "X" && !yourText.activeSelf)
        {
            YourChoiseIs();
        }
    }

    private void Log(string _str)
    {
        if (_doLogs)
        {
            Debug.Log(_str);
        }
    }

    private string whatIsItThisNote()
    {
        string result = "C";
        int tmpNoteNumber = noteNumber;
        if (isBassKey)
        {
            tmpNoteNumber = noteNumber + 2;
        }
        tmpNoteNumber %= 7;
        if (tmpNoteNumber == 0)
            tmpNoteNumber = 7;
        Log($"{noteNumber}; {tmpNoteNumber};");
        switch (tmpNoteNumber)
        {
            case 1:
                result = "G";
                break;
            case 2:
                result = "A";
                break;
            case 3:
                result = "B";
                break;
            case 4:
                result = "C";
                break;
            case 5:
                result = "D";
                break;
            case 6:
                result = "E";
                break;
            case 7:
                result = "F";
                break;
        }
        return result;
    }

    private void YourChoiseIs()
    {
        if (NOTE_VariableSaver._currentVar == correctAnswer)
        {
            trueSign.SetActive(true);
            yourText.SetActive(true);
            correctText.SetActive(true);
        }
        else
        {
            falseSign.SetActive(true);
            yourText.SetActive(true);
            correctText.SetActive(true);
        }
        Invoke("GenerateNewAndSelfDelete", _delayAfterChoice);
    }

    private void GenerateNewAndSelfDelete()
    {
        falseSign.SetActive(false);
        trueSign.SetActive(false);
        yourText.SetActive(false);
        correctText.SetActive(false);


        notesHolder.transform.Find($"{noteNumber}").gameObject.SetActive(false);

        if (noteNumber <= 2)
            additionalLines[0].SetActive(false);
        if (noteNumber <= 4)
            additionalLines[1].SetActive(false);
        if (noteNumber >= 16)
            additionalLines[2].SetActive(false);
        if (noteNumber >= 18)
            additionalLines[3].SetActive(false);

        NOTE_VariableSaver._currentVar = "X";

        g_clef.SetActive(false);
        bass_clef.SetActive(false);

        GenerateNew();

    }
    public void _AssignTextToVar(string _str)
    {
        if (!yourText.activeSelf)
        {
            NOTE_VariableSaver._currentVar = _str;
            yourText.GetComponent<TextMeshProUGUI>().text = _str;
        }
    }
}
