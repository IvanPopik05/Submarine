using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnArrows : MonoBehaviour
{
    [SerializeField] private MainSubmarineScript movementGame;
    [SerializeField] private Score score;
    [SerializeField] private AnswerPanelScript answerPanel;

    const int LeftBtn = 0;
    const int RightBtn = 1;
    const int UpBtn = 2;
    const int DownBtn = 3;

    const int SubstractScore = 50;
    const int AddSCore = 25;
    private void CorrectAnswer(int amountScore) 
    {
        score.AddScore(amountScore);
        answerPanel.CorrectAnswer();
    }
    private void WrongAnswer(int amountScore)
    {
        score.SubstractScore(amountScore);
        answerPanel.WrongAnswer();
    }
    private void Movement(int value) 
    {
        if (movementGame.Dir == Vector2.left && value == LeftBtn)
        {
            CorrectAnswer(AddSCore);
        }
        else if (movementGame.Dir == Vector2.right && value == RightBtn)
        {
            CorrectAnswer(AddSCore);
        }
        else if (movementGame.Dir == Vector2.up && value == UpBtn)
        {
            CorrectAnswer(AddSCore);
        }
        else if (movementGame.Dir == Vector2.down && value == DownBtn)
        {
            CorrectAnswer(AddSCore);
        }
        else 
        {
            WrongAnswer(SubstractScore);
        }
    }
    private void Turned(float value) 
    {
        float zTurned = movementGame.Boat.transform.eulerAngles.z;
        if (zTurned == 180 && value == LeftBtn)
        {
            CorrectAnswer(AddSCore);
        }
        else if ((zTurned == 0 || zTurned == 360) && value == RightBtn)
        {
            CorrectAnswer(AddSCore);
        }
        else if (zTurned == 90 && value == UpBtn)
        {
            CorrectAnswer(AddSCore);
        }
        else if (zTurned == 270 && value == DownBtn)
        {
            CorrectAnswer(SubstractScore);
        }
        else 
        {
            WrongAnswer(50);
        }
    }

    public void SelectBtn(int value)
    {
        switch (movementGame.TypeBoat)
        {
            case TypeBoat.MovementBoat:
                Movement(value);
                break;
            case TypeBoat.TurnedBoat:
                Turned(value);
                break;
            default:
                break;
        }
        movementGame.NewBoat();
    }

    private void GetKey() 
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            SelectBtn(LeftBtn);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectBtn(RightBtn);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectBtn(UpBtn);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectBtn(DownBtn);
        }
    }
    private void Update()
    {
        GetKey();
    }
}
