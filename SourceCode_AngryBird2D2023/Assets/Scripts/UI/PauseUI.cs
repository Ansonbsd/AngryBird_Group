using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        anim.SetBool("IsShow", true);
    }
    public void OnContinueButtonClick()
    {
        Time.timeScale = 1;
        anim.SetBool("IsShow", false);
    }
    public void OnRestartButtonClick()
    {
        GameManager.Instance.RestartLevel();
    }
    public void OnLevelListButtonClick()
    {
        GameManager.Instance.LevelList();
    }

}
