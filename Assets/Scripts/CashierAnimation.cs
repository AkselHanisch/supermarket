using System.Collections;
using UnityEngine;

public class CashierAnimation : MonoBehaviour
{
    [Header("Forearm Transforms")]
    public Transform leftForearm;
    public Transform rightForearm;

    [Header("Typing Animation Settings")]
    [Range(0.1f, 0.5f)] public float keyPressTime = 0.15f;
    [Range(0.1f, 0.8f)] public float timeBetweenKeys = 0.3f;
    [Range(0.05f, 0.3f)] public float randomVariation = 0.1f;

    [Header("Movement Ranges")]
    [Range(5f, 30f)] public float verticalRotation = 15f;
    [Range(2f, 15f)] public float forwardRotation = 8f;
    [Range(1f, 10f)] public float sidewaysRotation = 5f;

    private Quaternion leftRestRotation;
    private Quaternion rightRestRotation;
    private bool isTyping = false;

    private void Start()
    {
        if (!ValidateComponents())
        {
            Debug.LogError("CashierAnimation: Missing forearm transforms!");
            enabled = false;
            return;
        }

        // Store rest positions
        leftRestRotation = leftForearm.localRotation;
        rightRestRotation = rightForearm.localRotation;

        // Start typing animation
        StartCoroutine(TypingAnimation());
    }

    private bool ValidateComponents()
    {
        return leftForearm != null && rightForearm != null;
    }

    private IEnumerator TypingAnimation()
    {
        yield return new WaitForSeconds(1f); // Initial delay

        while (true)
        {
            // Randomly choose which hand types
            bool useLeftHand = Random.value > 0.5f;
            
            if (useLeftHand)
            {
                yield return StartCoroutine(TypeWithForearm(leftForearm, leftRestRotation, true));
            }
            else
            {
                yield return StartCoroutine(TypeWithForearm(rightForearm, rightRestRotation, false));
            }

            // Wait between keystrokes with some variation
            float waitTime = timeBetweenKeys + Random.Range(-randomVariation, randomVariation);
            yield return new WaitForSeconds(Mathf.Max(0.05f, waitTime));
        }
    }

    private IEnumerator TypeWithForearm(Transform forearm, Quaternion restRotation, bool isLeft)
    {
        // Calculate typing position
        Quaternion typingRotation = CalculateTypingRotation(restRotation, isLeft);

        // Move down to "press key"
        yield return StartCoroutine(RotateToPosition(forearm, restRotation, typingRotation, keyPressTime * 0.6f));
        
        // Brief hold at typing position
        yield return new WaitForSeconds(keyPressTime * 0.2f);
        
        // Return to rest position
        yield return StartCoroutine(RotateToPosition(forearm, typingRotation, restRotation, keyPressTime * 0.4f));
    }

    private Quaternion CalculateTypingRotation(Quaternion restRotation, bool isLeft)
    {
        // Create typing motion: down, slightly forward, and slight side movement
        Vector3 eulerAngles = restRotation.eulerAngles;
        
        // Vertical movement (main typing motion)
        eulerAngles.x += verticalRotation + Random.Range(-randomVariation * 10f, randomVariation * 10f);
        
        // Forward movement (reaching toward keyboard)
        eulerAngles.z += forwardRotation + Random.Range(-randomVariation * 5f, randomVariation * 5f);
        
        // Slight sideways variation for realism
        float sidewaysVariation = Random.Range(-sidewaysRotation, sidewaysRotation);
        if (isLeft)
            eulerAngles.y += sidewaysVariation;
        else
            eulerAngles.y -= sidewaysVariation;

        return Quaternion.Euler(eulerAngles);
    }

    private IEnumerator RotateToPosition(Transform target, Quaternion fromRotation, Quaternion toRotation, float duration)
    {
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            // Use ease-out for more natural movement
            t = 1f - (1f - t) * (1f - t);
            
            target.localRotation = Quaternion.Slerp(fromRotation, toRotation, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        target.localRotation = toRotation;
    }

    // Optional: Public method to start/stop typing
    public void SetTyping(bool typing)
    {
        if (typing && !isTyping)
        {
            isTyping = true;
            StartCoroutine(TypingAnimation());
        }
        else if (!typing)
        {
            isTyping = false;
            StopAllCoroutines();
            // Return to rest positions
            StartCoroutine(ReturnToRest());
        }
    }

    private IEnumerator ReturnToRest()
    {
        StartCoroutine(RotateToPosition(leftForearm, leftForearm.localRotation, leftRestRotation, 0.5f));
        yield return StartCoroutine(RotateToPosition(rightForearm, rightForearm.localRotation, rightRestRotation, 0.5f));
    }
}
