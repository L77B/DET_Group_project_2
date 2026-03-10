using UnityEngine;

public class MaterialWater : MonoBehaviour
{

    private Material myMaterial;

    public float offsetX;
    public float offsetY;
    public Vector2 newOffset;

    public float scrollSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            myMaterial = renderer.material;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myMaterial != null)
        {
            newOffset = new Vector2(offsetX * Time.time * scrollSpeed, offsetY * Time.time * scrollSpeed);
            myMaterial.mainTextureOffset = newOffset;
        }
    }
}
