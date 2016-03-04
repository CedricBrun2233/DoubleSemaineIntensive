using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{

    Vector3 position;
    Rigidbody rb;
    Vector3 initialPosition;
    bool destroyable = false;
    // Use this for initialization
    void Awake()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.mass *= 100;
        //rb.Sleep();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (name != "RDC")
        {
            if (collision.gameObject.tag == "Ground" && destroyable == false)
            {
                SoundManager.Instance.PlaySound(gameObject, SoundManager.Instance.destruction[Random.Range(0, SoundManager.Instance.destruction.Length)], 0.5f, true);
                Destroy(gameObject, 5.2f);
                destroyable = true;
            }
        }


        if (collision.relativeVelocity.magnitude > 2)
        {
            //bruit de fracas
        }
    }

    public void bump()
    {
        StartCoroutine("checkStill");
    }

    public void changeWeight()
    {
        Invoke("reallyChangeWeight", 1f);
    }

    void reallyChangeWeight()
    {
        rb.mass -= 50f;
    }

    public IEnumerator checkStill()
    {
        yield return new WaitForSeconds(0.5f);
        position = Vector3.zero;
        while(rb.velocity != Vector3.zero)
        {
            yield return new WaitForSeconds(1f);
        }
        if (name == "RDC")
        {
            if (Vector3.Distance(transform.position, initialPosition) > 1)
            {
                SoundManager.Instance.PlaySound(gameObject, SoundManager.Instance.destruction[Random.Range(0, SoundManager.Instance.destruction.Length)], 0.5f, true);
                Destroy(gameObject, 5.2f);
            }
        }
    }
}
