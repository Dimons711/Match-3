using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledPiece : MonoBehaviour
{
    public bool falling;

    float speed = 16f;
    float gravity = 32f;

    Vector2 moveDir;
    RectTransform rect;
    Image img;
    

    public void Initialize(Sprite piece, Vector2 start)
    {
        falling = true;

        moveDir = Vector2.up;
        moveDir.x = Random.Range(-1f, 1f);
        moveDir *= speed / 2;

        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        img.sprite = piece;
        rect.anchoredPosition = start;

    }

    void Update()
    {
        if (!falling) return;
        {
            moveDir.y -= Time.deltaTime * gravity;
            moveDir.x = Mathf.Lerp(moveDir.x, 0, Time.deltaTime);
            rect.anchoredPosition += moveDir * Time.deltaTime * speed;
            if (rect.position.x < -32f || rect.position.x > Screen.width + 32f || rect.position.y < -32f || rect.position.y > Screen.height + 32f)
            {
                falling = false;
            }
        }
    }
}
