using UnityEngine;

public class balll : MonoBehaviour
{
    public Rigidbody rb;
    
    public float jumpForce;

    private GameManager _gm;

    public GameObject SplashPrefab;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        var ballTransform = transform;
        var splash = Instantiate(SplashPrefab, ballTransform.position + new Vector3(0f, -0.23f, 0f), ballTransform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        var metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

        if (metarialName == "unsafe (Instance)")
        {
            _gm.RestartGame();
        }
    }
}
