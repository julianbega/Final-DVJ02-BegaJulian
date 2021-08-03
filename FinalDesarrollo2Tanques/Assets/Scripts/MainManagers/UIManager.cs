
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager manager = null;
    private PlayerManager player = null;

    //---------------- HUD------------------
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;

    //---------------- Pause------------------
    public Image backgroundPanel;

    //---------------- EndGame------------------
    public Image endGamePanel;
    public TextMeshProUGUI boxesDestroyed;
    public TextMeshProUGUI distanceTraveled;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager != null)
        {
            // score.text = "Score: " + player.score.ToString();
            time.text = "Game end in: " + manager.GetTimerMin() + " : " + (float)Mathf.Round(manager.GetTimerSec());
        }

        if (manager.GetIsPaused())
        {
            backgroundPanel.gameObject.SetActive(true);
        }
        else
        {
            backgroundPanel.gameObject.SetActive(false);
        }
        if (manager.GetEndGame())
        {
            endGamePanel.gameObject.SetActive(true);
            boxesDestroyed.text = "Boxes destroyed: " + player.GetBoxesDestroyed();
            distanceTraveled.text = "Distance traveled: " + player.GetDistanceTraveled();
        }
    }
}
