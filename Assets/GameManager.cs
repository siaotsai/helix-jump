using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _score;
    public Text ScoreText;

    public GameObject cylinderPrefab;

    public Transform ball;

    public int RingCount { get; set; } = 6;

    private int _copyCount;
    
    public void GameScore(int ringScore)
    {
        _score += ringScore;
        ScoreText.text = _score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloneRings()
    {
        _copyCount += 1;

        var newCylinder = Instantiate(cylinderPrefab, new Vector3(0f, _copyCount * -27f, 0f), Quaternion.identity);

        int[] rings = new int[6];
        for (var i = 0; i < 6; i++)
        {
            rings[i] = Random.Range(1, 7);
        }

        for (var i = 0; i < 6; i++)
        {
            var newRing = Instantiate(Resources.Load("ring " + rings[i]),
                newCylinder.transform.position + new Vector3(0f, i * -4.5f, 0f), Quaternion.identity,
                newCylinder.transform);

            newRing.GetComponent<Ring>().ball = ball;
        }
    }
}
