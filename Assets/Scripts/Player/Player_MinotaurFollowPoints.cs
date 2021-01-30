using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MinotaurFollowPoints : MonoBehaviour
{

    public float Player_FollowPointCreation_Timer = 0.1f;
    private float Player_FollowPointCreation_Timer_Actual = 0.1f;

    public float Player_FollowPointCreation_DistanceFromLastPointForNewCreation = 0.5f;

    private GameObject Player_FollowPoints_Container;
    private GameObject Player_FollowPoints_LastInstancedPoint;
    private Vector3 Player_FollowPoints_LastInstancedPoint_Position;
    [HideInInspector] public float Player_FollowPoints_PathLength = 0.0f;
    public GameObject Player_FollowPoint_Prefab;

    private GameObject Minotaur;
    private Minotaur_FollowPlayer Minotaur_FollowPlayerScript;

    // Start is called before the first frame update
    void Start()
    {

        Player_FollowPointCreation_Timer_Actual = Player_FollowPointCreation_Timer;

        Player_FollowPoints_Container = new GameObject()
        {
            name = "FollowPointsContainer"
        };
        Player_FollowPoints_Container.transform.position = Vector3.zero;

        Minotaur = GameObject.Find("Minotaur");
        if (Minotaur == null)
        {
            Debug.LogWarning("ATTENZIONE: non c'è il minotauro nella scena");
            this.enabled = false;
        }
        else
        {
            Minotaur_FollowPlayerScript = Minotaur.GetComponent<Minotaur_FollowPlayer>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        float newX = transform.position.x;
        if (Input.GetKey("d"))
        {
            newX = Mathf.MoveTowards(newX, newX + (Time.deltaTime * 5.0f), 100.0f);
        }
        else if (Input.GetKey("a"))
        {
            newX = Mathf.MoveTowards(newX, newX - (Time.deltaTime * 5.0f), 100.0f);
        }
        float newY = transform.position.y;
        if (Input.GetKey("w"))
        {
            newY = Mathf.MoveTowards(newY, newY + (Time.deltaTime * 5.0f), 100.0f);
        }
        else if (Input.GetKey("s"))
        {
            newY = Mathf.MoveTowards(newY, newY - (Time.deltaTime * 5.0f), 100.0f);
        }
        transform.parent.position = new Vector3(newX, newY, transform.parent.position.z);

        if (Player_FollowPointCreation_Timer_Actual <= 0.0f)
        {

            if (Player_FollowPoints_LastInstancedPoint == null)
            {

                if (Player_FollowPoints_LastInstancedPoint_Position != null)
                {

                    float distanceToLastPoint = Vector3.Distance(transform.position, Player_FollowPoints_LastInstancedPoint_Position);
                    if (distanceToLastPoint > Player_FollowPointCreation_DistanceFromLastPointForNewCreation)
                    {

                        Player_FollowPoints_PathLength = distanceToLastPoint;

                        Player_FollowPoints_LastInstancedPoint = Instantiate(Player_FollowPoint_Prefab, transform.position, Quaternion.Euler(Vector3.zero));
                        Minotaur_FollowPlayerScript.Minotaur_FoPl_PointToReach = Player_FollowPoints_LastInstancedPoint;
                        Minotaur_FollowPlayerScript.Minotaur_FoPl_LerpStartPosition = Minotaur.transform.position;

                        Player_FollowPoints_LastInstancedPoint_Position = Player_FollowPoints_LastInstancedPoint.transform.position;

                        Player_FollowPoints_LastInstancedPoint.transform.parent = Player_FollowPoints_Container.transform;

                        Player_FollowPointCreation_Timer_Actual = Player_FollowPointCreation_Timer;

                    }

                }
                else
                {

                    Player_FollowPoints_LastInstancedPoint = Instantiate(Player_FollowPoint_Prefab, transform.position, Quaternion.Euler(Vector3.zero));
                    Minotaur_FollowPlayerScript.Minotaur_FoPl_PointToReach = Player_FollowPoints_LastInstancedPoint;
                    Minotaur_FollowPlayerScript.Minotaur_FoPl_LerpStartPosition = Minotaur.transform.position;

                    Player_FollowPoints_LastInstancedPoint_Position = Player_FollowPoints_LastInstancedPoint.transform.position;

                    Player_FollowPoints_LastInstancedPoint.transform.parent = Player_FollowPoints_Container.transform;

                    Player_FollowPointCreation_Timer_Actual = Player_FollowPointCreation_Timer;

                }

            }
            else
            {

                float distanceToLastPoint = Vector3.Distance(transform.position, Player_FollowPoints_LastInstancedPoint_Position);
                if (distanceToLastPoint > Player_FollowPointCreation_DistanceFromLastPointForNewCreation)
                {

                    Player_FollowPoints_PathLength += distanceToLastPoint;

                    GameObject newInstancedPoint = Instantiate(Player_FollowPoint_Prefab, transform.position, Quaternion.Euler(Vector3.zero));
                    Player_FollowPoints_LastInstancedPoint.GetComponent<Minotaur_FollowPoint>().FollowPoint_Next = newInstancedPoint;

                    Player_FollowPoints_LastInstancedPoint = newInstancedPoint;
                    if (Minotaur_FollowPlayerScript.Minotaur_FoPl_PointToReach == null)
                    {
                        Minotaur_FollowPlayerScript.Minotaur_FoPl_PointToReach = Player_FollowPoints_LastInstancedPoint;
                        Minotaur_FollowPlayerScript.Minotaur_FoPl_LerpStartPosition = Minotaur.transform.position;
                    }
                    Player_FollowPoints_LastInstancedPoint_Position = Player_FollowPoints_LastInstancedPoint.transform.position;

                    Player_FollowPoints_LastInstancedPoint.transform.parent = Player_FollowPoints_Container.transform;

                    Player_FollowPointCreation_Timer_Actual = Player_FollowPointCreation_Timer;

                }

            }

        }
        else
        {

            Player_FollowPointCreation_Timer_Actual -= Time.deltaTime;

        }

    }

}
