using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] public float ThrowForce = 10.0f;
    [SerializeField] public float ThrowDelay = 0.5f;
    private float Timer = 0f;
    private bool CanThrow = false;
    private scrFooterBar FooterScript;
    // Start is called before the first frame update
    private bool _AnimazioneX1Rossa = false;
    private bool _AnimazioneX2Rossa = false;
    private bool _AnimazioneX3Rossa = false;
    private bool _AnimazioneX4Rossa = false;
    private bool _AnimazioneX5Rossa = false;
    [SerializeField] public bool AnimazioneX1Rossa { get { return _AnimazioneX1Rossa; } set { _AnimazioneX1Rossa = value; GameObject.Find("X1").GetComponent<Image>().enabled = value;} }
    [SerializeField] public bool AnimazioneX2Rossa { get { return _AnimazioneX2Rossa; } set { _AnimazioneX2Rossa = value; GameObject.Find("X2").GetComponent<Image>().enabled = value; } }
    [SerializeField] public bool AnimazioneX3Rossa { get { return _AnimazioneX3Rossa; } set { _AnimazioneX3Rossa = value; GameObject.Find("X3").GetComponent<Image>().enabled = value; } }
    [SerializeField] public bool AnimazioneX4Rossa { get { return _AnimazioneX4Rossa; } set { _AnimazioneX4Rossa = value; GameObject.Find("X4").GetComponent<Image>().enabled = value; } }
    [SerializeField] public bool AnimazioneX5Rossa { get { return _AnimazioneX5Rossa; } set { _AnimazioneX5Rossa = value; GameObject.Find("X5").GetComponent<Image>().enabled = value; } }
    private float AnimazioneX1RossaTime = 2.0f;
    private float AnimazioneX1RossaTimer = 0;
    private float AnimazioneX2RossaTime = 2.0f;
    private float AnimazioneX2RossaTimer = 0;
    private float AnimazioneX3RossaTime = 2.0f;
    private float AnimazioneX3RossaTimer = 0;
    private float AnimazioneX4RossaTime = 2.0f;
    private float AnimazioneX4RossaTimer = 0;
    private float AnimazioneX5RossaTime = 2.0f;
    private float AnimazioneX5RossaTimer = 0;
    void Start()
    {

        if (GameObject.Find("UI - FooterBar") == null)
        {
            this.enabled = false;

            return;
        }
        FooterScript = GameObject.Find("UI - FooterBar").GetComponent<scrFooterBar>();

    }

    void GestisciAnimazioneX1Rossa()
	{
        if (!AnimazioneX1Rossa) return;
        AnimazioneX1RossaTimer += Time.deltaTime;
        if (AnimazioneX1RossaTimer >= AnimazioneX1RossaTime)
		{
            AnimazioneX1RossaTimer = 0;
            AnimazioneX1Rossa = false;
        }
	}
    void GestisciAnimazioneX2Rossa()
    {
        if (!AnimazioneX2Rossa) return;
        AnimazioneX2RossaTimer += Time.deltaTime;
        if (AnimazioneX2RossaTimer >= AnimazioneX2RossaTime)
        {
            AnimazioneX2RossaTimer = 0;
            AnimazioneX2Rossa = false;
        }
    }
    void GestisciAnimazioneX3Rossa()
    {
        if (!AnimazioneX3Rossa) return;
        AnimazioneX3RossaTimer += Time.deltaTime;
        if (AnimazioneX3RossaTimer >= AnimazioneX3RossaTime)
        {
            AnimazioneX3RossaTimer = 0;
            AnimazioneX3Rossa = false;
        }
    }
    void GestisciAnimazioneX4Rossa()
    {
        if (!AnimazioneX4Rossa) return;
        AnimazioneX4RossaTimer += Time.deltaTime;
        if (AnimazioneX4RossaTimer >= AnimazioneX4RossaTime)
        {
            AnimazioneX4RossaTimer = 0;
            AnimazioneX4Rossa = false;
        }
    }
    void GestisciAnimazioneX5Rossa()
    {
        if (!AnimazioneX5Rossa) return;
        AnimazioneX5RossaTimer += Time.deltaTime;
        if (AnimazioneX5RossaTimer >= AnimazioneX5RossaTime)
        {
            AnimazioneX5RossaTimer = 0;
            AnimazioneX5Rossa = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GestisciAnimazioneX1Rossa();
        GestisciAnimazioneX2Rossa();
        GestisciAnimazioneX3Rossa();
        GestisciAnimazioneX4Rossa();
        GestisciAnimazioneX5Rossa();
        int counter = FooterScript.GetCounter();
        /*
        1 = sasso
        2 = cibo
        */
        if (!CanThrow)
        {
            Timer += Time.deltaTime;
            if (Timer > ThrowDelay)
            {
                Timer = 0;
                CanThrow = true;
            }
        }
        if (Input.GetButtonDown("Throw"))
		{
            if (CanThrow && Inventory.Throwable(counter) && Inventory.GetQuantity(counter) > 0)
			{
                CanThrow = false;
                GameObject Proiettile = GameObject.Instantiate(FooterScript.GetCurrentItemPrefab(), transform.position, Quaternion.identity, transform.root.parent);
                Vector2 Velocity = new Vector2(GetComponentInParent<Rigidbody2D>().velocity.x, 0);
                Proiettile.GetComponent<Rigidbody2D>().AddForce(Velocity + GetComponentInParent<PlayerMovement>().Forward * ThrowForce, ForceMode2D.Impulse);
                if (counter > 1)
                {
                    Inventory.DecreaseQuantity(counter);
                    FooterScript.UpdateCounter(counter);
                }
            }
            else if (Inventory.GetQuantity(counter) == 0)
            {
                //Avvio animazione X rossa
                switch (counter)
                {
                    case 1:
                        AnimazioneX1Rossa = true;
                        break;
                    case 2:
                        AnimazioneX2Rossa = true;
                        break;
                    case 3:
                        AnimazioneX3Rossa = true;
                        break;
                    case 4:
                        AnimazioneX4Rossa = true;
                        break;
                    case 5:
                        AnimazioneX5Rossa = true;
                        break;
                }
            }
        }
        if (Input.GetButtonDown("Eat"))
		{
            if (Inventory.Eatable(counter) && Inventory.GetQuantity(counter) > 0)
            {
                Inventory.DecreaseQuantity(counter);
                FooterScript.UpdateCounter(counter);
                GetComponentInParent<LifePoint>().Cure(1);
                GetComponentInParent<HungerPoint>().RestoreAll();
            }
            else
            {
                //Avvio animazione X rossa
                switch (counter)
                {
                    case 1:
                        AnimazioneX1Rossa = true;
                        break;
                    case 2:
                        AnimazioneX2Rossa = true;
                        break;
                    case 3:
                        AnimazioneX3Rossa = true;
                        break;
                    case 4:
                        AnimazioneX4Rossa = true;
                        break;
                    case 5:
                        AnimazioneX5Rossa = true;
                        break;
                }
            }
        }
    }
}
