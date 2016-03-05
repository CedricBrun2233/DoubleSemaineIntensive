using UnityEngine;
using System.Collections;
using System;

public class CameraScript : MonoBehaviour
{

    float horizontalMovment;
    float verticalLeft;
    float horizontalLeft;
    public GameObject mapCenter;
    public GameObject[] dices;
    public float speedRotationArround = 20f;
    public float speedRotationVerticalScope = 20f;
    public float speedRotationHorizontalScope = 20f;
    public float forceThrow = 200f;
    public float accuracyMin = Mathf.PI / 4;
    public float accuracyMax = Mathf.PI / 12;
    float accuracy = Mathf.PI / 12;
    float force;
    Vector2 getForce;
    public float multiplierForce = 1f;

    enum POSITION
    {
        ROTATEARROUND,
        RAPIDDISPLACMENT,
        SCOPE,
        FOLLOW,
        STATIC,
    }

    POSITION currentPosition = POSITION.ROTATEARROUND;
    // Use this for initialization
    void Start()
    {
        dices = new GameObject[3];

        dices[0] = Instantiate(Resources.Load("GA/Prefabs/diceTest", typeof(GameObject))) as GameObject;
        dices[1] = Instantiate(Resources.Load("GA/Prefabs/diceTest", typeof(GameObject))) as GameObject;
        dices[2] = Instantiate(Resources.Load("GA/Prefabs/diceTest", typeof(GameObject))) as GameObject;
        for(int i = 0; i<3;i++)
        {
            dices[i].transform.parent = transform;
            dices[i].transform.localPosition = new Vector3(-2f+(2f* i),-3,5.5f);
            dices[i].transform.rotation = UnityEngine.Random.rotation;
            TurnManager.instance.currentPlayer.GODices[i] = dices[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentPosition)
        {
            case POSITION.ROTATEARROUND:
                rotateArround();
                break;
            case POSITION.RAPIDDISPLACMENT:
                rapidDisplacment();
                break;
            case POSITION.SCOPE:
                scope();
                break;
            case POSITION.FOLLOW:
                follow();
                break;
            case POSITION.STATIC:
                staticCamera();
                break;
        }

    }

    void rotateArround()
    {
        if (Input.GetButtonDown("ButtonX"))
        {
            currentPosition = POSITION.RAPIDDISPLACMENT;
        }
        if (Input.GetButtonDown("ButtonA"))
        {
            goScope();
        }
        horizontalMovment = Input.GetAxis("Horizontal");
        if (horizontalMovment != 0)
        {
            mapCenter.transform.Rotate(mapCenter.transform.up, -horizontalMovment * Time.deltaTime * speedRotationArround);
        }
    }

    void rapidDisplacment()
    {
        if (Input.GetButtonDown("ButtonX"))
        {
            currentPosition = POSITION.ROTATEARROUND;
        }
        if (Input.GetButtonDown("ButtonA"))
        {
            goScope();
        }
    }

    void goScope()
    {
        currentPosition = POSITION.SCOPE;
        //afficher cone par rapport a l'accuracy
    }

    void scope()
    {
        if (Input.GetButtonDown("ButtonB"))
        {
            currentPosition = POSITION.ROTATEARROUND;
        }
        verticalLeft = Input.GetAxis("LeftVertical");
        horizontalLeft = Input.GetAxis("LeftHorizontal");
        transform.Rotate(new Vector3(horizontalLeft * speedRotationVerticalScope, -verticalLeft * speedRotationHorizontalScope, 0) * Time.deltaTime);

        if (Input.GetAxis("Trigger") > 0.5f || Input.GetAxis("Trigger") < -0.5f)
        {
            foreach (GameObject currentDice in dices)
            {
                currentDice.transform.parent = null;
                force = Mathf.Max(force, 10f);
                Vector3 AF = transform.forward * force * 30 * multiplierForce;
                float magn = AF.magnitude;
                //magn *= Mathf.Tan(Random.Range(accuracy / 2, -accuracy / 2));
                magn *= Mathf.Tan(UnityEngine.Random.Range(accuracy / 2, -accuracy / 2));
                currentDice.GetComponent<Rigidbody>().AddForce(AF + Vector3.right * magn / 8);
                currentDice.GetComponent<Rigidbody>().useGravity = true;
                currentPosition = POSITION.STATIC;
                Dice DR = currentDice.GetComponent<Dice>();
                StartCoroutine(DR.checkStill());
            }
            
        }
        if (Input.GetButtonDown("ButtonY"))
        {
            force = 0;
        }
        checkforce();

        //charger le tir
    }

    public void changeAngle(int multiplier)
    {
        accuracy += multiplier*5;
        accuracy = Mathf.Min(accuracyMin, accuracy);
        accuracy = Mathf.Max(accuracyMax, accuracy);
        Debug.Log(accuracy);
    }

    void checkforce()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        float dist = Vector2.Distance(getForce, new Vector2(hori, verti));
        force = Mathf.Min(force + dist*2, 100f);
        getForce = new Vector2(hori, verti);
        if (dist < 0.1f)
        {
            force = Mathf.Max(0f, force - Time.deltaTime * 10);
        }
    }

    void follow()
    {
        if (Input.GetButtonDown("ButtonX"))
        {
            currentPosition = POSITION.STATIC;
        }
        SelectDices();
    }

    void staticCamera()
    {
        if (Input.GetButtonDown("ButtonX"))
        {
            currentPosition = POSITION.FOLLOW;
        }
        transform.LookAt(getMiddleOfThree());
        //reculer suivant distance entre les 2 dès les plus éloignés

    }



    Vector3 getMiddleOfThree()
    {
        /*float x = (dice[0].transform.position.x + dice[1].transform.position.x + dice[2].transform.position.x) / 3;
        float y = (dice[0].transform.position.y + dice[1].transform.position.y + dice[2].transform.position.y) / 3;
        float z = (dice[0].transform.position.z + dice[1].transform.position.z + dice[2].transform.position.z) / 3;
        Vector3 look = new Vector3(x, y, z);*/
        Vector3 look = (dices[0].transform.position + dices[1].transform.position+ dices[2].transform.position)/3;
        return look;
    }

    void SelectDices()
    {
        GameObject[] farDices = new GameObject[2];
        float[] dists = new float[3];
        dists[0] = Vector3.Distance(dices[0].transform.position, dices[1].transform.position);
        dists[1] = Vector3.Distance(dices[2].transform.position, dices[1].transform.position);
        dists[2] = Vector3.Distance(dices[2].transform.position, dices[0].transform.position);
        if (dists[0] > dists[1] && dists[0] > dists[2])
        {
            farDices[0] = dices[0];
            farDices[1] = dices[1];
        }
        else if (dists[1] > dists[2])
        {
            farDices[0] = dices[1];
            farDices[1] = dices[2];
        }
        else
        {
            farDices[0] = dices[0];
            farDices[1] = dices[2];
        }
        Debug.Log("trouvé les dés");
        GetPosition(farDices);
    }

    void GetPosition(GameObject[] farDices)
    {
        Vector3 center = (farDices[0].transform.position + farDices[1].transform.position) / 2;
        transform.position = new Vector3(center.x, transform.position.y, center.z);
        transform.LookAt(new Vector3(farDices[0].transform.position.x, transform.position.y, farDices[0].transform.position.z));
        transform.Rotate(0, 90, 0);
        transform.Translate(-transform.forward * Vector3.Distance(farDices[0].transform.position, farDices[1].transform.position));
        transform.LookAt(getMiddleOfThree());
    }
}
