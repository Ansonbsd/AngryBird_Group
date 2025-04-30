using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public GameObject unlockGo;
    public GameObject lockGo;

    public TextMeshProUGUI levelNumberText;
    public GameObject star0Go;
    public GameObject star1Go;
    public GameObject star2Go;
    public GameObject star3Go;

    private MapLevelUI mapLevelUI;
    private int levelID;

    public void Show(int starCount,int levelID,MapLevelUI mapLevelUI)
    {
        this.mapLevelUI = mapLevelUI;
        this.levelID = levelID;
        levelNumberText.text = levelID.ToString();
        star0Go.SetActive(false);
        star1Go.SetActive(false);
        star2Go.SetActive(false);
        star3Go.SetActive(false);

        if (starCount < 0)
        {
            unlockGo.SetActive(false);
            lockGo.SetActive(true);
        }
        else
        {
            unlockGo.SetActive(true);
            lockGo.SetActive(false);

            if (starCount == 3)
            {
                star3Go.SetActive(true);
            }else if (starCount == 2)
            {
                star2Go.SetActive(true);
            }
            else if (starCount == 1)
            {
                star1Go.SetActive(true);
            }
            else if (starCount == 0)
            {
                star0Go.SetActive(true);
            }

        }
    }

    public void OnClick()
    {
        mapLevelUI.OnLevelButtonClick(levelID);
    }
}
