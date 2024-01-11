using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balll : MonoBehaviour
{
    public Rigidbody rb;
    
    public float jumpForce;

    private GameManager gm;

    public GameObject SplashPrefab;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(SplashPrefab, transform.position + new Vector3(0f, -0.23f, 0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        Debug.Log("Touching Ring21: " + metarialName);

        if (metarialName == "safe (Instance)")
        {
            
        }
        else if (metarialName == "unsafe (Instance)")
        {
            gm.RestartGame();
        }
        else if (metarialName == "Last Ring (Instance)")
        {
            Debug.Log("Next Level");
        }
    }
}
