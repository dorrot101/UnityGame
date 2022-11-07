using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    public float horizontalSpeed = 0.2f;
    public float verticalSpeed = 0.2f;
    public Sprite bgImage;
    public SpriteRenderer spriteRenderer;

    float upSpeed;
    private Renderer re;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, 0);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bgImage;
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.deltaTime;
        upSpeed += time * verticalSpeed;

        transform.position = new Vector2(0, upSpeed);
    }
}
