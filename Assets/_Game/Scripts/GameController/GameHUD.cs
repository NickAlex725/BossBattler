using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentStateText;
    [SerializeField] private GameObject _playerHUD;

    private GameObject _currentActiveHUD;
    
    public void EnableHUD(GameObject HUDToEnable)
    {
        HUDToEnable.SetActive(true);
        _currentActiveHUD = HUDToEnable;
    }

    public void ClearHUD()
    {
        _currentActiveHUD.SetActive(false);
        _currentActiveHUD = null;
    }

    public void UpdateStateText(State newState)
    {
        _currentStateText.text = newState.ToString();
    }

    public void DisplayHUD(GameHUD HUD)
    {
        HUD.gameObject.SetActive(true);
    }

    public void HideHUD(GameHUD HUD)
    {
        HUD.gameObject.SetActive(false);
    }
}
