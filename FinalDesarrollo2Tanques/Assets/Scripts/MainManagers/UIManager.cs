
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager manager = null;

    //---------------- HUD------------------
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager != null)
        {
           // score.text = "Score: " + manager.score.ToString();
            time.text = "Game end in: " + manager.GetTimerMin() + " : " + (float)Mathf.Round(manager.GetTimerSec());
        }
    }
}
