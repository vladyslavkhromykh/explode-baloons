using UnityEngine;

public class Baloon : MonoBehaviour
{
    public void Update()
    {
        Vector3 position = transform.position;
        position.y += 3.0f * Time.deltaTime;
        transform.position = position;
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}