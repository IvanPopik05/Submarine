using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnArrows : MonoBehaviour
{
    [SerializeField] private MainSubmarineScript movementGame;
    [SerializeField] private Score score;
    [SerializeField] private AnswerPanelScript answerPanel;


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
    private void Movement(float value) 
    {
        if (movementGame.Dir == Vector2.left && value == 0)
        {
            CorrectAnswer(25);
        }
        else if (movementGame.Dir == Vector2.right && value == 1)
        {
            CorrectAnswer(25);
        }
        else if (movementGame.Dir == Vector2.up && value == 2)
        {
            CorrectAnswer(25);
        }
        else if (movementGame.Dir == Vector2.down && value == 3)
        {
            CorrectAnswer(25);
        }
        else 
        {
            WrongAnswer(50);
        }
    }
    private void Turned(float value) 
    {
        float zTurned = movementGame.Boat.transform.eulerAngles.z;
        if (zTurned == 180 && value == 0)
        {
            CorrectAnswer(25);
        }
        else if ((zTurned == 0 || zTurned == 360) && value == 1)
        {
            CorrectAnswer(25);
        }
        else if (zTurned == 90 && value == 2)
        {
            CorrectAnswer(25);
        }
        else if (zTurned == 270 && value == 3)
        {
            CorrectAnswer(25);
        }
        else 
        {
            WrongAnswer(50);
        }
    }

    private void SelectBtn(float value)
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
    public void LeftBtn(float value)
    {
        SelectBtn(value);
    }
    public void RightBtn(float value)
    {
        SelectBtn(value);
    }
    public void UpBtn(float value)
    {
        SelectBtn(value);
    }
    public void DownBtn(float value) 
    {
        SelectBtn(value);
    }
}
