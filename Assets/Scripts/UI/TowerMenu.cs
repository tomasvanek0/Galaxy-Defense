using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    public GameObject ST;
    public GameObject AE;
    public GameObject SE;
    public GameObject STower;
    public GameObject TMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoGame()
    {
        Destroy(gameObject);
        GameManager.Instance.GameState = true;
        GameManager.Instance.TowerPlacementMode = false;
    }

    public void AoE()
    {
        Destroy(TMenu);
        GameManager.Instance.GameState = false;
        GameManager.Instance.TowerPlacementMode = true;
        Instantiate(AE);

    }

    public void SingleTarget()
    {
        Destroy(TMenu);
        GameManager.Instance.GameState = false;
        GameManager.Instance.TowerPlacementMode = true;
        Instantiate(ST);
    }

    public void SupportEnemy()
    {
        Destroy(TMenu);
        GameManager.Instance.GameState = false;
        GameManager.Instance.TowerPlacementMode = true;
        Instantiate(SE);
    }

    public void SupportTower()
    {
        Destroy(TMenu);
        GameManager.Instance.GameState = false;
        GameManager.Instance.TowerPlacementMode = true;
        Instantiate(STower);
    }

    public void BackToMain()
    {
        Instantiate(TMenu);
        GameManager.Instance.GameState = false;
        GameManager.Instance.TowerPlacementMode = true;
        Destroy(gameObject);
    }
}
