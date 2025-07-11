using UnityEngine;
using TMPro;

public class DetectObject : MonoBehaviour
{
    private string targetItem;
    public TextMeshProUGUI resultText;

    public ListRandomizerEN listRandomizer;


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

        // Add this check to prevent processing after completion
        if (listRandomizer.doneItems != null && listRandomizer.doneItems.Count >= 6)
        {
            return;
        }

        if (other.tag == "Untagged" || other.tag == "Player")
        {
            Debug.Log("Untagged or Player item. other.tag: " + other.tag + " targetItem: " + targetItem);
            return;
        }
        
        if (other.CompareTag(targetItem))
        {
            Debug.Log("Correct item placed! other.tag: " + other.tag + " targetItem: " + targetItem);
            if (resultText != null)
                resultText.text = "Correct!";
            listRandomizer.nextItem();
        }
        else
        {
            Debug.Log("Wrong item. other.tag: " + other.tag + " targetItem: " + targetItem);
            if (resultText != null)
                resultText.text = "Try Again!";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (resultText != null)
            resultText.text = "";
    }
}
