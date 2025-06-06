using UnityEngine;

public class RandomPAPlayer : MonoBehaviour
{
    public AudioSource source;
    public float minDelay = 30f;
    public float maxDelay = 60f;
    private float timer;
    private float nextDelay;

    void Start()
    {
        SetNextDelay();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextDelay)
        {
            source.Play();
            SetNextDelay();
            timer = 0f;
        }
    }

    void SetNextDelay()
    {
        nextDelay = Random.Range(minDelay, maxDelay);
    }
}
