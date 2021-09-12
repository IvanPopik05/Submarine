using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPanelScript : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image imgAnswer;
    private Image _panelImage;

    private void Awake()
    {
        _panelImage = GetComponent<Image>();
    }
    public void CorrectAnswer() 
    {
        StartCoroutine(ShowAnswer(sprites[0]));
    }
    public void WrongAnswer() 
    {
        StartCoroutine(ShowAnswer(sprites[1]));
    }
    private IEnumerator ShowAnswer(Sprite sprite) 
    {
        while (_panelImage.color.a < 0.5f)
        {
            _panelImage.color += new Color(1,1,1,0.05f);
            SetSprite(sprite);
            yield return null;
        }
        _panelImage.color = new Color(1, 1, 1, 0);
        imgAnswer.enabled = false;
    }
    private void SetSprite(Sprite sprite) 
    {
        imgAnswer.sprite = sprite;
        imgAnswer.enabled = true;
    }
}
