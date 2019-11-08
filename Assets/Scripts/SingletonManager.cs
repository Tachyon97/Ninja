using System;
using UnityEngine;
using UnityEngine.UI;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Instance = null;
    public int health = 3;
    public int points = 0;
    public int arrows = 10;
    [SerializeField] public Text healthText;
    [SerializeField] public Text pointsText;
    [SerializeField] public Text arrowsText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        setText(healthText, "Lives", health);
        setText(pointsText, "Points", points);
        setText(arrowsText, "Arrows", arrows);
    }

    private void setText(Text text, String content, int counter)
    {
        text.text = content + " :" + " " + counter;
    }
}