using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerPoint : MonoBehaviour
{
    [SerializeField] public float Hunger;
    [SerializeField] public float HungerMax = 300f;
    [SerializeField] public float StarvationDamage = 20f;
    [SerializeField] public float DepletionTime = 1f;
    [SerializeField] public float StarvationDamageTime = 1f;
    private float Timer;
    private bool IsStarving = false;
    // Start is called before the first frame update
    void Start()
    {
        Hunger = HungerMax;
        Timer = 0;
    }
    public void Cure(float Amount)
    {
        //TODO: Aggiungere Effetto
        Hunger += Amount;
        if (Hunger >= HungerMax)
        {
            Hunger = HungerMax;

        }
        IsStarving = false;
    }
    
    public void RestoreAll()
	{
        Hunger = HungerMax;
        IsStarving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsStarving)
		{
            Timer += Time.fixedDeltaTime;
            if (Timer >= DepletionTime)
            {
                Timer = 0;
                Hunger--;
                if (Hunger <= 0)
                {
                    Hunger = 0;
                    IsStarving = true;
                }
            }
        }
        else
		{
            Timer += Time.fixedDeltaTime;
            if (Timer >= StarvationDamageTime)
			{
                Timer = 0;
                GetComponent<LifePoint>().Damage(StarvationDamage);
			}
        }
    }
}
