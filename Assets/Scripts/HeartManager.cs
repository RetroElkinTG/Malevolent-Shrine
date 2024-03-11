using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Heart behaviour
public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite threeQuarterHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    // Update hearts in UI
    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++) 
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
}