using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatMove : MonoBehaviour
{
    [SerializeField] private MainSubmarineScript mainSubmarine;
    [SerializeField] private float speed;
    private Vector2 screenBounds;

    const float extraWidthAndHeight = 2.2f;
    const float reducedWidthAndHeight = 5; 
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void Update()
    {
        if (transform.position.x > screenBounds.x * extraWidthAndHeight)
        {
            transform.position = new Vector2((-screenBounds.x) / reducedWidthAndHeight, transform.position.y);
        }
        else if (transform.position.x < (-screenBounds.x) / reducedWidthAndHeight)
        {
            transform.position = new Vector2(screenBounds.x * extraWidthAndHeight, transform.position.y);
        }
        else if (transform.position.y > screenBounds.y * extraWidthAndHeight)
        {
            transform.position = new Vector2(transform.position.x, (-screenBounds.y) / reducedWidthAndHeight);
        }
        else if (transform.position.y < (-screenBounds.y) / reducedWidthAndHeight)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y * extraWidthAndHeight);
        }

        transform.Translate(mainSubmarine.Dir * speed * Time.deltaTime, Space.World);
    }

}
