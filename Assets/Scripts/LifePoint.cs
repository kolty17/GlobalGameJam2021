using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifePoint : MonoBehaviour
{
    [SerializeField] public float HP;
    [SerializeField] public float HPMax = 300f;
    // Start is called before the first frame update
    void Start()
    {
        HP = HPMax;
    }

    public void Cure(float Amount)
    {
        //TODO: Aggiungere Effetto
        HP += Amount;
        if (HP >= HPMax)
        {
            HP = HPMax;

        }
    }
    public void Damage(float Damage)
	{
        //TODO: Aggiungere Effetto
        HP -= Damage;
        if (HP <= 0)
		{
            HP = 0;
            //Morte
            if (CompareTag("Enemy"))
			{
                Destroy(this.gameObject);
			}
            else if (CompareTag("Player"))
			{
                SceneManager.LoadScene("LVGameOver");
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
