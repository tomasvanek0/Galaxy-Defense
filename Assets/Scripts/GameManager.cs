using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private RadiusController radiusController;
    public static GameManager Instance { get; private set; }
    public bool GameState;
    public bool TowerPlacementMode;
    public int PlayerHealth;
    public int PlayerMoney;
    public GameObject TowerMenu;    
    private bool lastPlacementModeState; // Hlídá změnu stavu

    public List<GameObject> TowersRadius = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }        
    }

    void Start()
    {
        radiusController = FindAnyObjectByType<RadiusController>();
        TowersRadius.AddRange(GameObject.FindGameObjectsWithTag("Radius"));
        GameState = true;
        TowerPlacementMode = true;
        PlayerHealth = 30;
        PlayerMoney = 100;
        lastPlacementModeState = !TowerPlacementMode;
        
    }

    void Update()
    {
        // Přepínání módu klávesou B přes nový Input System
        if (Keyboard.current != null && Keyboard.current.bKey.wasPressedThisFrame)
        {
            TowerPlacementMode = !TowerPlacementMode;
        }

        if (PlayerHealth <= 0)
        {
            GameState = false;
            Debug.Log("Game Over");
        }

        if (!GameState)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        // Pokud ještě nemáme referenci na RadiusController, pokusíme se ji načíst
        if (radiusController == null)
        {
            radiusController = FindAnyObjectByType<RadiusController>();
        }

        // Zavolá se pouze v momentě, kdy se hodnota TowerPlacementMode skutečně změní
        if (radiusController != null && TowerPlacementMode != lastPlacementModeState)
        {
            if (TowerPlacementMode)
            {
                radiusController.ShowRadius();
                Instantiate(TowerMenu);
                GameState = false;
            }
            else
            {
                radiusController.HideRadius();
                Destroy(GameObject.FindWithTag("TowerMenui"));
                GameState = true;
            }

            lastPlacementModeState = TowerPlacementMode;
        }
    }
}
