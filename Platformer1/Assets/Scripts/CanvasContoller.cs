using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasContoller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Text playerHpText;
    [SerializeField] private GameObject deathPanel;
    private void Start()
    {
        playerHpText.gameObject.SetActive(true);
        Time.timeScale = 1;
        deathPanel.SetActive(false);
    }
    private void Update()
    {
        playerHpText.text = player.GetComponent<Health>().currentHP.ToString();
    }
    public void Death() 
    {
        playerHpText.gameObject.SetActive(false);
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
