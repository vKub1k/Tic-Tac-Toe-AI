using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    System.Random random = new System.Random();
    [SerializeField] GameObject _restartButton;

    string charPicked;
    string botChar;
    string aiType;

    bool gameEnd = false;

    string[] gameFieldData = new string[9] { "", "", "", "", "", "", "", "", "" };

    [SerializeField] GameObject[] _chooseCharGroup = new GameObject[3];
    [SerializeField] GameObject[] _chooseAIGroup = new GameObject[3];
    [SerializeField] GameObject[] _playFieldGroup = new GameObject[9];


    private void _RefreshFieldChars()
    {
        for (int i = 0; i < 9; i++)
        {
            _playFieldGroup[i].GetComponentInChildren<TextMeshProUGUI>().text = gameFieldData[i];
        }
        _CheckIsSomeOneWin();
    }

    private void _SetActiveForGroup(GameObject[] _goTab, bool _setActive)
    {
        foreach (GameObject item in _goTab)
        {
            item.SetActive(_setActive);
        }
    }

    private void _SetInteractableForGroup(GameObject[] _goTab, bool _setInteractable)
    {
        int i = 0;
        foreach (GameObject item in _goTab)
        {
            if (_setInteractable)
            {
                if (gameFieldData[i] == "")
                    item.GetComponent<Button>().interactable = true;
                else if (gameFieldData[i] == "X" || gameFieldData[i] == "O")
                    item.GetComponent<Button>().interactable = false;
            }
            else
            {
                item.GetComponent<Button>().interactable = false;
            }
            i++;
        }
    }

    public void _PickChar(string _str)
    {
        charPicked = _str;

        if (_str == "X")
            botChar = "O";
        else
            botChar = "X";

        _SetActiveForGroup(_chooseCharGroup, false);
        _SetActiveForGroup(_chooseAIGroup, true);
        _RefreshFieldChars();
    }

    public void _ChooseAIType(string _str)
    {
        aiType = _str;

        _SetActiveForGroup(_chooseAIGroup, false);
        _SetActiveForGroup(_playFieldGroup, true);
        _restartButton.SetActive(true);

        _StartGame();
    }

    public void _StartGame()
    {
        if (charPicked == "X")
        {
            _SetInteractableForGroup(_playFieldGroup, true);
        }
        else
        {
            _SetInteractableForGroup(_playFieldGroup, false);
            _AIMakeMove();
        }
    }

    private void _AIMakeMove()
    {
        if (aiType.ToLower() == "random")
        {
            _AIMakeRandomMove();
        }
        else if (aiType.ToLower() == "minimax")
        {

        }
    }

    private void _AIMakeRandomMove()
    {
        List<int> freeCells = new List<int>();
        //Debug.Log("New list:");
        for (int i = 0; i < 9; i++)
        {
            if (gameFieldData[i] == "")
            {
                freeCells.Add(i);
                //Debug.Log(i);
            }
        }
        int aiChoosenCell = freeCells[random.Next(freeCells.Count)];
        //Debug.Log($"Bot choose: {aiChoosenCell}");
        gameFieldData[aiChoosenCell] = botChar;

        _RefreshFieldChars();
        if (!gameEnd)
            _SetInteractableForGroup(_playFieldGroup, true);
    }

    public void _ChoosenCell(int _cellNumber)
    {
        gameFieldData[_cellNumber] = charPicked;
        _RefreshFieldChars();
        _SetInteractableForGroup(_playFieldGroup, false);
        if (!gameEnd)
            _AIMakeMove();
    }

    public void _SetColorForCell(int c1, int c2, int c3, string _color)
    {
        Color color = new Color();
        
        if (_color == "green")
        {
            color = new Color(0.01f, 0.56f, 0);
        }
        else if (_color == "red")
        {
            color = new Color(0.56f, 0.01f, 0);
        }

        _playFieldGroup[c1].GetComponent<Image>().color = color;
        _playFieldGroup[c2].GetComponent<Image>().color = color;
        _playFieldGroup[c3].GetComponent<Image>().color = color;
    }


    public void _CheckIsSomeOneWin()
    {
        string whoWin = "\\_(0_0)_/";
        if (gameFieldData[0] == gameFieldData[3] && gameFieldData[6] == gameFieldData[0] && gameFieldData[0] != "")
        {
            if (gameFieldData[0] == botChar)
            {
                _SetColorForCell(0, 3, 6, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(0, 3, 6, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (gameFieldData[0] == gameFieldData[1] && gameFieldData[2] == gameFieldData[0] && gameFieldData[0] != "")
        {

            if (gameFieldData[0] == botChar)
            {
                _SetColorForCell(0, 1, 2, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(0, 1, 2, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (gameFieldData[1] == gameFieldData[4] && gameFieldData[7] == gameFieldData[1] && gameFieldData[1] != "")
        {

            if (gameFieldData[1] == botChar)
            {
                _SetColorForCell(1, 4, 7, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(1, 4, 7, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (gameFieldData[2] == gameFieldData[5] && gameFieldData[8] == gameFieldData[2] && gameFieldData[2] != "")
        {

            if (gameFieldData[2] == botChar)
            {
                _SetColorForCell(2, 5, 8, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(2, 5, 8, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (gameFieldData[3] == gameFieldData[4] && gameFieldData[5] == gameFieldData[3] && gameFieldData[3] != "")
        {

            if (gameFieldData[3] == botChar)
            {
                _SetColorForCell(3, 4, 5, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(3, 4, 5, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (gameFieldData[6] == gameFieldData[7] && gameFieldData[8] == gameFieldData[6] && gameFieldData[6] != "")
        {

            if (gameFieldData[6] == botChar)
            {
                _SetColorForCell(6, 7, 8, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(6, 7, 8, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (gameFieldData[0] == gameFieldData[4] && gameFieldData[8] == gameFieldData[0] && gameFieldData[0] != "")
        {

            if (gameFieldData[0] == botChar)
            {
                _SetColorForCell(0, 4, 8, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(0, 4, 8, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (gameFieldData[2] == gameFieldData[4] && gameFieldData[6] == gameFieldData[2] && gameFieldData[2] != "")
        {
            if (gameFieldData[2] == botChar)
            {
                _SetColorForCell(2, 4, 6, "red");
                whoWin = "bot";
            }
            else
            {
                _SetColorForCell(2, 4, 6, "green");
                whoWin = "player";
            }
            gameEnd = true;
        }
        if (Array.IndexOf(gameFieldData, "") < 0)
        {
            gameEnd = true;
            Debug.Log($"Winner: {whoWin}");
        }
    }

    public void _ResetAllValues()
    {
        gameEnd = false;
        gameFieldData = new string[9] { "", "", "", "", "", "", "", "", "" };

        _SetActiveForGroup(_chooseCharGroup, true);

        _SetActiveForGroup(_playFieldGroup, false);
        _SetActiveForGroup(_chooseAIGroup, false);


        for (int i = 0; i < 9; i++)
        {
            _playFieldGroup[i].GetComponent<Image>().color = new Color(0.345098f, 0.345098f, 0.345098f);
        }

        _RefreshFieldChars();
    }
}
