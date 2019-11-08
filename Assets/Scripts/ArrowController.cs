using System.Collections;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 0.1f;

    private void Start()
    {
        StartCoroutine(DestroyB());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // ReSharper disable once InvertIf
        if (other.collider.CompareTag("Enemy"))
        {
            SingletonManager.Instance.points += 100;
            Debug.Log("Points: " + SingletonManager.Instance.points);
            BulletAddition();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void BulletAddition()
    {
        if (Random.value < .5)
        {
            SingletonManager.Instance.arrows++;
            Debug.Log("Arrows Roll successful");
        }
        else
        {
            Debug.Log("Arrows Roll failed");

        }
    }

    // Update is called once per frame
    void Update()
    {
        var transform1 = transform;
        Vector2 position = transform1.position;
        position.x += speed;
        transform1.position = position;
    }

    IEnumerator DestroyB()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}