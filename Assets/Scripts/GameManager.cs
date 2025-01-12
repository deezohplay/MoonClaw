using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    PlayerController playerController;
    private float startTime;
    public TextMeshProUGUI timerText;
    private bool finished = false;

    private void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished)
            return;
            if(playerController.startGame == true){
                float t = Time.time - startTime;
                string minutes = ((int) t / 60).ToString();
                string seconds = (t % 60).ToString("f2");
                timerText.text = minutes + ":" + seconds;
            }
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}
