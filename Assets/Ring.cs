using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform ball;
    private GameManager _gm;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!(transform.position.y + 12.5f >= ball.position.y)) return;
        
        _gm.GameScore(25);
            
        Destroy(gameObject);
        _gm.RingCount--;

        if (_gm.RingCount != 3) return;
        
        _gm.CloneRings();
        _gm.RingCount += 6;
    }
}
