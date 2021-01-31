using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibaltamentoNemico : MonoBehaviour
{
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] public GameObject EnemyJumpPlatform;
    private Stordimento stordimento;
    private SpriteRenderer sr;
    private JumpPlatform jf;
    // Start is called before the first frame update
    void Start()
    {
        stordimento = GetComponent<Stordimento>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stordimento.IsStunned())
        {
            sr.sprite = downSprite;
        }
        else if (stordimento.IsWakingUp())
        {
            Debug.Log("BOHNONLOSO");
            sr.sprite = idleSprite;
            if (jf != null)
            {
                jf.DestroyPlatform();
            }

        }
        else
        {
            sr.sprite = idleSprite;
        }
    }

    public void Ribalta()
    {
        sr.sprite = downSprite;
        GameObject enemyJumpPlatform = GameObject.Instantiate(EnemyJumpPlatform, transform.position, Quaternion.identity, transform);
        jf = enemyJumpPlatform.GetComponent<JumpPlatform>();
    }
}
