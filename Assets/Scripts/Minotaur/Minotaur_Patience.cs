using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_Patience : MonoBehaviour
{

    private GameObject Player;
    private Animator Minotaur_ExpressionsAnimator;

    public Sprite Expression_IncreasePatience;
    public Sprite Expression_DecreasePatience;
    public Sprite Expression_Love;
    public Sprite Expression_Like;
    public Sprite Expression_Neutral;
    public Sprite Expression_Dislike;
    public Sprite Expression_Hate;
    [HideInInspector] public List<GameObject> Expression_Gameobjects;

    public float Minotaur_PatiencePoints_Actual = 150.0f;
    public float Minotaur_PatiencePoints_Max = 300.0f;
    public float Minotaur_Patience_Love_Min = 240.0f;
    public float Minotaur_Patience_Like_Min = 180.0f;
    public float Minotaur_Patience_Neutral_Min = 120.0f;
    public float Minotaur_Patience_Dislike_Min = 60.0f;

    public float Minotaur_Patience_Show_Distance = 3.0f;
    public float Minotaur_Patience_Show_Timer = 4.0f;
    public float Minotaur_Patience_Change_Timer = 0.5f;
    private float Minotaur_Patience_Timer_Actual = 4.0f;
    private bool Minotaur_Patience_Showing = false;

    public Vector3 Minotaur_Patience_Show_SpriteScale = Vector3.one;
    public Vector3 Minotaur_Patience_Change_SpriteScale = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {

        Transform expressionContainer = transform.Find("Minotaur_Expression");
        Minotaur_ExpressionsAnimator = expressionContainer.gameObject.GetComponent<Animator>();
        foreach (Transform child in expressionContainer)
        {
            Expression_Gameobjects.Add(child.gameObject);
        }

        Minotaur_PatiencePoints_Actual = Minotaur_PatiencePoints_Max / 2.0f;
        Minotaur_Patience_Timer_Actual = Minotaur_Patience_Show_Timer;

        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("f"))
        {

            float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
            if (distanceToPlayer <= Minotaur_Patience_Show_Distance)
            {

                if (!Minotaur_Patience_Showing)
                {

                    Minotaur_ExpressionsAnimator.SetBool("Expressions", true);

                    Sprite actualExpression;
                    if (Minotaur_PatiencePoints_Actual >= Minotaur_Patience_Love_Min)
                    {
                        actualExpression = Expression_Love;
                    }
                    else if (Minotaur_PatiencePoints_Actual >= Minotaur_Patience_Like_Min)
                    {
                        actualExpression = Expression_Like;
                    }
                    else if (Minotaur_PatiencePoints_Actual >= Minotaur_Patience_Neutral_Min)
                    {
                        actualExpression = Expression_Neutral;
                    }
                    else if (Minotaur_PatiencePoints_Actual >= Minotaur_Patience_Dislike_Min)
                    {
                        actualExpression = Expression_Dislike;
                    }
                    else
                    {
                        actualExpression = Expression_Hate;
                    }

                    //Expression_Gameobjects[0].transform.parent.localScale = Minotaur_Patience_Show_SpriteScale;
                    foreach (GameObject expressionSlot in Expression_Gameobjects)
                    {

                        expressionSlot.GetComponent<SpriteRenderer>().sprite = actualExpression;
                        expressionSlot.transform.localScale = Minotaur_Patience_Show_SpriteScale;

                    }

                    Minotaur_Patience_Timer_Actual = Minotaur_Patience_Show_Timer;
                    Minotaur_Patience_Showing = true;

                }

            }

        }

        if (Minotaur_Patience_Showing)
        {

            Minotaur_Patience_Timer_Actual -= Time.deltaTime;
            if (Minotaur_Patience_Timer_Actual <= 0.0f)
            {
                Minotaur_ExpressionsAnimator.SetBool("Expressions", false);

                foreach (GameObject expressionSlot in Expression_Gameobjects)
                {
                    expressionSlot.GetComponent<SpriteRenderer>().sprite = null;
                }

                Minotaur_Patience_Timer_Actual = Minotaur_Patience_Show_Timer;

                Minotaur_Patience_Showing = false;
            }

        }

    }


    public void ChangePatience(float value)
    {

        Minotaur_PatiencePoints_Actual += value;

        Sprite actualExpression;
        if (value >= 0)
        {
            actualExpression = Expression_IncreasePatience;
        }
        else
        {
            actualExpression = Expression_DecreasePatience;
        }

        Minotaur_PatiencePoints_Actual = Mathf.Clamp(Minotaur_PatiencePoints_Actual, 0.0f, Minotaur_PatiencePoints_Max);

        //Expression_Gameobjects[0].transform.parent.localScale = Minotaur_Patience_Change_SpriteScale;
        foreach (GameObject expressionSlot in Expression_Gameobjects)
        {
            expressionSlot.GetComponent<SpriteRenderer>().sprite = actualExpression;
            expressionSlot.transform.localScale = Minotaur_Patience_Change_SpriteScale;
        }

        Minotaur_Patience_Timer_Actual = Minotaur_Patience_Change_Timer;
        Minotaur_Patience_Showing = true;

        Minotaur_ExpressionsAnimator.SetBool("Expressions", true);
        Minotaur_ExpressionsAnimator.Play("Expression", -1, 0);

    }


}
