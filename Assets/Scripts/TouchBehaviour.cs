using UnityEngine;

public class TouchBehaviour : MonoBehaviour
{
    public delegate void TouchPressed();

    public static event TouchPressed AButton;
    public static event TouchPressed BButton;
    public static event TouchPressed Restart;
#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D ray = Physics2D.Raycast(position, Vector2.zero);
            if (AButton != null && ray.collider != null && ray.collider.CompareTag("AButton"))
                AButton();
            else if (BButton != null && ray.collider != null && ray.collider.CompareTag("BButton"))
                BButton();
            else if (Restart != null && ray.collider != null && ray.collider.CompareTag("Restart"))
                Restart();
        }
    }

#elif (UNITY_IOS || UNITY_ANDROID)
    void Update() {
    foreach(Touch t in Input.touches) {
    Vector3 position = Camera.main.ScreenToWorldPoint(t.position);
    RaycastHit2D ray = Physics2D.Raycast(position, Vector2.zero);
            if (AButton != null && ray.collider != null && ray.collider.CompareTag("AButton"))
                AButton();
            else if (BButton != null && ray.collider != null && ray.collider.CompareTag("BButton"))
                BButton();
            else if (Restart != null && ray.collider != null && ray.collider.CompareTag("Restart"))
                Restart();
        }
}
    }
#endif
}