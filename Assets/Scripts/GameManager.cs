using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float startTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString();
    }
}
