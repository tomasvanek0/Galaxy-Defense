using UnityEngine;
using System.Collections.Generic;

public class RadiusController : MonoBehaviour
{
    private GameManager gameManager;
    private SpriteRenderer sr;


    

    void Start()
    {
        gameManager = GameManager.Instance;
        sr = GetComponent<SpriteRenderer>();
    }
    public void ShowRadius()
    {
        if (gameManager == null || gameManager.TowersRadius == null) return;
        foreach (GameObject radius in gameManager.TowersRadius)
        {
            if (radius != null)
            {
                // Získáme SpriteRenderer konkrétního objektu v seznamu
                SpriteRenderer targetSr = radius.GetComponent<SpriteRenderer>();
                if (targetSr != null)
                {
                    Color newColor = targetSr.color;
                    newColor.a = 0.15f;
                    targetSr.color = newColor;
                }
            }
        }
        
    }

    public void HideRadius()
    {
        if (gameManager == null || gameManager.TowersRadius == null) return;

        foreach (GameObject radius in gameManager.TowersRadius)
        {
            if (radius != null)
            {
                // Získáme SpriteRenderer konkrétního objektu v seznamu
                SpriteRenderer targetSr = radius.GetComponent<SpriteRenderer>();
                if (targetSr != null)
                {
                    Color newColor = targetSr.color;
                    newColor.a = 0f;
                    targetSr.color = newColor;
                }
            }
        }


    }
}
