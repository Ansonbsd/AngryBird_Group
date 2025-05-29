using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{

    public GameObject lockUI;
    public GameObject starUI;
    public TextMeshProUGUI starCountTextUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(int starCount)
    {
        if(starCount < 0)
        {
            GetComponent<Button>().enabled = false;
            lockUI.SetActive(true);
            lockUI.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            starUI.SetActive(false);
        }
        else
        {
            lockUI.SetActive(false);
            starUI.SetActive(true);
            starCountTextUI.text = starCount.ToString();
        }
    }
}
