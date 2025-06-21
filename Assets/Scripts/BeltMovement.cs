using UnityEngine;

public class BeltMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of texture movement
    public Transform beltTransform; // Assign the Belt child object
    private Material beltMaterial;
    private float offset;

    void Start()
    {
        if (beltTransform != null)
        {
            MeshRenderer renderer = beltTransform.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                beltMaterial = renderer.material; // Get the material
            }
            else
            {
                Debug.LogWarning("No MeshRenderer on Belt!");
            }
        }
        else
        {
            Debug.LogWarning("beltTransform is not assigned!");
        }
    }

    void Update()
    {
        if (beltMaterial != null)
        {
            offset += moveSpeed * Time.deltaTime; // Increase offset
            beltMaterial.mainTextureOffset = new Vector2(offset, 0); // Scroll vertically
        }
    }
}