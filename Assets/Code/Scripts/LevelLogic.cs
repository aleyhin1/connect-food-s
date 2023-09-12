using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelLogic : MonoBehaviour
{
    public Image LevelPrefabImage;
    public Image PlayButtonImage;
    public TextMeshProUGUI LevelNumberTextMeshPro;
    public TextMeshProUGUI HighestScoreTextMeshPro;

    public void SetPlayable(bool isPlayable)
    {
        if (isPlayable)
        {
            BrightenImage(LevelPrefabImage);
            BrightenImage(PlayButtonImage);
        }
        else
        {
            DarkenImage(LevelPrefabImage);
            DarkenImage(PlayButtonImage);
        }
    }

    public void SetLevelNumber(int numberToChange)
    {
        ChangeText(LevelNumberTextMeshPro, numberToChange.ToString());
    }

    public void SetHighestScore(int scoreToChange)
    {
        ChangeText(HighestScoreTextMeshPro, scoreToChange.ToString()); 
    }

    private void DarkenImage(Image image)
    {
        image.color = Color.gray;
    }

    private void BrightenImage(Image image)
    {
        image.color = Color.white;
    }

    private void ChangeText(TextMeshProUGUI textMeshPro, string textToChange)
    {
        textMeshPro.text = textToChange;
    }
}
