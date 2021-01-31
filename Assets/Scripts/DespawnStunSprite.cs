using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnStunSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float framerate = 0.1f;
    private SpriteRenderer spriteRender;

    private Stordimento stun;
    // Start is called before the first frame update
    void Start()
    {
        stun = GetComponentInParent<Stordimento>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stun.IsStunned())
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= framerate)
            {
                timer -= framerate;
                currentFrame = (currentFrame + 1) % frameArray.Length;
                spriteRender.sprite = frameArray[currentFrame];
            }
        }
    }
}
