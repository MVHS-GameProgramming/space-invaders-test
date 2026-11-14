using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    [Tooltip("Speed of the background scroll")]
    public float scrollSpeed = 0.5f;

    [Tooltip("Direction and axis to scroll (e.g., X or Y)")]
    public Vector2 scrollDirection = new Vector2(1f, 0f);

    private Renderer quadRenderer;

    void Start()
    {
        quadRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = scrollDirection.normalized * Time.time * scrollSpeed;
        quadRenderer.material.mainTextureOffset = offset;
    }
}