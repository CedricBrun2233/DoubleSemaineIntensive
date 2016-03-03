using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    float horizontalMovment;
    float verticalLeft;
    float horizontalLeft;
    public GameObject mapCenter;
    GameObject[] dice;
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
        dice = new GameObject[3];
       
        dice[0] = Instantiate(Resources.Load("GA/Prefabs/diceTest", typeof(GameObject))) as GameObject;
        dice[1] = Instantiate(Resources.Load("GA/Prefabs/diceTest", typeof(GameObject))) as GameObject;
        dice[2] = Instantiate(Resources.Load("GA/Prefabs/diceTest", typeof(GameObject))) as GameObject;
        for(int i = 0; i<3;i++)
        {
            dice[i].transform.parent = transform;
            dice[i].transform.localPosition = new Vector3(-1.5f+(1.5f* i),-3,5.5f);
            dice[i].transform.rotation = Random.rotation;
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
            foreach (GameObject currentDice in dice)
            {
                currentDice.transform.parent = null;
                force = Mathf.Max(force, 10f);
                Vector3 AF = transform.forward * force * 30 * multiplierForce;
                float magn = AF.magnitude;
                //magn *= Mathf.Tan(Random.Range(accuracy / 2, -accuracy / 2));
                magn *= Mathf.Tan(Random.Range(accuracy / 2, -accuracy / 2));
                currentDice.GetComponent<Rigidbody>().AddForce(AF + Vector3.right * magn / 8);
                currentDice.GetComponent<Rigidbody>().useGravity = true;
                currentPosition = POSITION.STATIC;
                Dice DR = currentDice.GetComponent<Dice>();
                StartCoroutine(DR.checkStill());
            }
            
        }

        if (Input.GetButtonDown("ButtonLB"))
        {
            accuracy -= Mathf.PI/36;
            accuracy = Mathf.Max(accuracyMax, accuracy);
            //ajuster cone
        }

        if (Input.GetButtonDown("ButtonRB"))
        {
            accuracy += Mathf.PI / 36;
            accuracy = Mathf.Min(accuracyMin, accuracy);
            //ajuster cone
        }
        if (Input.GetButtonDown("ButtonY"))
        {
            force = 0;
        }
        checkforce();

        //charger le tir
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
        Debug.Log(force);
    }

    void follow()
    {
        if (Input.GetButtonDown("ButtonX"))
        {
            currentPosition = POSITION.STATIC;
        }

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
        Vector3 look = (dice[0].transform.position + dice[1].transform.position+dice[2].transform.position)/3;
        return look;
    }
}
