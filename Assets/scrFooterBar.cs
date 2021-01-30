using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrFooterBar : MonoBehaviour
{
    public GameObject selector;
    public GameObject oggetto1;
    public GameObject oggetto2;
    public GameObject oggetto3;
    public GameObject oggetto4;
    public GameObject oggetto5;
    public GameObject vita1;
    public GameObject vita2;
    public GameObject vita3;
    public GameObject cibo1;
    public GameObject cibo2;
    public GameObject cibo3;
    public GameObject cibo4;
    public GameObject cibo5;
    public GameObject numero1;
    public GameObject numero2;
    public GameObject numero3;
    public GameObject numero4;
    public GameObject numero5;
    private GameObject player;

    public Sprite FULLHP;
    public Sprite HALFHP;
    public Sprite NOHP;
    public Sprite FOOD;

    [SerializeField]
    int vita;
    [SerializeField]
    int cibo;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        numero1.GetComponent<Text>().text = "";
        numero2.GetComponent<Text>().text = "";
        numero3.GetComponent<Text>().text = "";
        numero4.GetComponent<Text>().text = "";
        numero5.GetComponent<Text>().text = "";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Sincronizzazione con dati player
        SetLife((int)player.GetComponent<LifePoint>().HP);
        SetFood((int)player.GetComponent<HungerPoint>().Hunger);
        if (Input.mouseScrollDelta.y > 0) counter++;
        if (Input.mouseScrollDelta.y < 0) counter--;
        if (counter > 5) counter = 5;
        if (counter < 1) counter = 1;

        switch (counter)
        {
            case 5:
                selector.transform.position = oggetto5.transform.position;
                break;
            case 4:
                selector.transform.position = oggetto4.transform.position;
                break;
            case 3:
                selector.transform.position = oggetto3.transform.position;
                break;
            case 2:
                selector.transform.position = oggetto2.transform.position;
                break;
            case 1:
                selector.transform.position = oggetto1.transform.position;
                break;
            default:
                selector.transform.position = oggetto1.transform.position;
                break;
        }


        switch (vita)
        {
            case 6:
                vita1.GetComponent<Image>().sprite = FULLHP;
                vita2.GetComponent<Image>().sprite = FULLHP;
                vita3.GetComponent<Image>().sprite = FULLHP;
                break;
            case 5:
                vita1.GetComponent<Image>().sprite = HALFHP;
                vita2.GetComponent<Image>().sprite = FULLHP;
                vita3.GetComponent<Image>().sprite = FULLHP;
                break;
            case 4:
                vita1.GetComponent<Image>().sprite = NOHP;
                vita2.GetComponent<Image>().sprite = FULLHP;
                vita3.GetComponent<Image>().sprite = FULLHP;
                break;
            case 3:
                vita1.GetComponent<Image>().sprite = NOHP;
                vita2.GetComponent<Image>().sprite = HALFHP;
                vita3.GetComponent<Image>().sprite = FULLHP;
                break;
            case 2:
                vita1.GetComponent<Image>().sprite = NOHP;
                vita2.GetComponent<Image>().sprite = NOHP;
                vita3.GetComponent<Image>().sprite = FULLHP;
                break;
            case 1:
                vita1.GetComponent<Image>().sprite = NOHP;
                vita2.GetComponent<Image>().sprite = NOHP;
                vita3.GetComponent<Image>().sprite = HALFHP;
                break;
            case 0:
                vita1.GetComponent<Image>().sprite = NOHP;
                vita2.GetComponent<Image>().sprite = NOHP;
                vita3.GetComponent<Image>().sprite = NOHP;
                break;
            default:
                vita1.GetComponent<Image>().sprite = NOHP;
                vita2.GetComponent<Image>().sprite = NOHP;
                vita3.GetComponent<Image>().sprite = NOHP;
                break;
        }

        switch (cibo)
        {
            case 5:
                cibo1.GetComponent<Image>().sprite = FOOD;
                cibo2.GetComponent<Image>().sprite = FOOD;
                cibo3.GetComponent<Image>().sprite = FOOD;
                cibo4.GetComponent<Image>().sprite = FOOD;
                cibo5.GetComponent<Image>().sprite = FOOD;
                break;
            case 4:
                cibo1.GetComponent<Image>().sprite = NOHP;
                cibo2.GetComponent<Image>().sprite = FOOD;
                cibo3.GetComponent<Image>().sprite = FOOD;
                cibo4.GetComponent<Image>().sprite = FOOD;
                cibo5.GetComponent<Image>().sprite = FOOD;
                break;
            case 3:
                cibo1.GetComponent<Image>().sprite = NOHP;
                cibo2.GetComponent<Image>().sprite = NOHP;
                cibo3.GetComponent<Image>().sprite = FOOD;
                cibo4.GetComponent<Image>().sprite = FOOD;
                cibo5.GetComponent<Image>().sprite = FOOD;
                break;
            case 2:
                cibo1.GetComponent<Image>().sprite = NOHP;
                cibo2.GetComponent<Image>().sprite = NOHP;
                cibo3.GetComponent<Image>().sprite = NOHP;
                cibo4.GetComponent<Image>().sprite = FOOD;
                cibo5.GetComponent<Image>().sprite = FOOD;
                break;
            case 1:
                cibo1.GetComponent<Image>().sprite = NOHP;
                cibo2.GetComponent<Image>().sprite = NOHP;
                cibo3.GetComponent<Image>().sprite = NOHP;
                cibo4.GetComponent<Image>().sprite = NOHP;
                cibo5.GetComponent<Image>().sprite = FOOD;
                break;
            case 0:
                cibo1.GetComponent<Image>().sprite = NOHP;
                cibo2.GetComponent<Image>().sprite = NOHP;
                cibo3.GetComponent<Image>().sprite = NOHP;
                cibo4.GetComponent<Image>().sprite = NOHP;
                cibo5.GetComponent<Image>().sprite = NOHP;
                break;
            default:
                cibo1.GetComponent<Image>().sprite = NOHP;
                cibo2.GetComponent<Image>().sprite = NOHP;
                cibo3.GetComponent<Image>().sprite = NOHP;
                cibo4.GetComponent<Image>().sprite = NOHP;
                cibo5.GetComponent<Image>().sprite = NOHP;
                break;
        }

    }

    public int GetCounter()
    {
        return(counter);
    }

    public int GetLife()
    {
        return (vita);
    }

    public int GetFood()
    {
        return (cibo);
    }

    public void SetLife(int life)
    {
        vita = life;
    }

    public void SetFood(int food)
    {
        cibo = food;
    }

    public void SetObject(int inventoryNumber, Sprite objSprite, int numberOfObjects)
    {
        if (inventoryNumber < 1) inventoryNumber = 1;
        if (inventoryNumber < 5) inventoryNumber = 5;
        if (numberOfObjects < 0) numberOfObjects = 0;
        if (numberOfObjects > 9) numberOfObjects = 9;
        
        switch (inventoryNumber)
        {
            case 5:
                oggetto5.GetComponent<Image>().sprite = objSprite;
                numero5.GetComponent<Text>().text = "x" + numberOfObjects;
                break;
            case 4:
                oggetto4.GetComponent<Image>().sprite = objSprite;
                numero4.GetComponent<Text>().text = "x" + numberOfObjects;
                break;
            case 3:
                oggetto3.GetComponent<Image>().sprite = objSprite;
                numero3.GetComponent<Text>().text = "x" + numberOfObjects;
                break;
            case 2:
                oggetto2.GetComponent<Image>().sprite = objSprite;
                numero2.GetComponent<Text>().text = "x" + numberOfObjects;
                break;
            case 1:
                oggetto1.GetComponent<Image>().sprite = objSprite;
                numero1.GetComponent<Text>().text = "x" + numberOfObjects;
                break;
            default:
                break;
        }

    }

}
