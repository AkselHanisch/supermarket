using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public string targetItem;
    public UnityEngine.UI.Text resultText;


    public void SetTargetItem(string itemName)
    {
        targetItem = itemName;
    }

    void OnTriggerEnter(Collider other)
    {
        if (string.IsNullOrEmpty(targetItem))
        {
            Debug.LogWarning("targetItem is null or empty! Did you forget to set it?");
            return;
        }

        if (other.CompareTag(targetItem))
        {
            Debug.Log("Correct item placed!");
            if (resultText != null)
                resultText.text = "Correct!";
        }
        else
        {
            Debug.Log("Wrong item.");
            if (resultText != null)
                resultText.text = "Try Again!";
        }
    }
}
