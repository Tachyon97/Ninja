using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public GameObject bullet;


    //Event Catcher
    private void OnEnable()
    {
        TouchBehaviour.BButton += BAttack;
        TouchBehaviour.AButton += AAttack;
    }

    private void OnDisable()
    {
        TouchBehaviour.BButton -= BAttack;
        TouchBehaviour.AButton -= AAttack;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            SingletonManager.Instance.health--;
            HealthAnnouncement();
            Destroy(other.gameObject);
        }
    }


    private void BAttack()
    {
        BulletB();
        BulletAnnouncement();
    }

    private void HealthAnnouncement()
    {
        Debug.Log("Current Health: " + SingletonManager.Instance.health);
    }

    private void BulletAnnouncement()
    {
        Debug.Log("Amount of arrows left: " + SingletonManager.Instance.arrows);
    }

    private void BulletB()
    {
        SingletonManager.Instance.arrows--;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        var position = transform.position;
        GameObject b = Instantiate(bullet, new Vector3(position.x + 2, position.y, position.z), Quaternion.identity);
        b.GetComponent<ArrowController>().speed = 0.1f;
    }

    private void BulletA()
    {
        SingletonManager.Instance.arrows--;
        Transform transform1;
        (transform1 = transform).localRotation = Quaternion.Euler(0, 180, 0);
        var position = transform1.position;
        GameObject b = Instantiate(bullet, new Vector3(position.x - 2, position.y, position.z), Quaternion.identity);
        b.GetComponent<ArrowController>().speed = -0.1f;
    }

    private void AAttack()
    {
        BulletA();
        BulletAnnouncement();
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (SingletonManager.Instance.health == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}