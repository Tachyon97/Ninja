using System;
using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float speed = .01f;

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    void Update()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > 1f)
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(15f);
        speed += .01f;
    }
}