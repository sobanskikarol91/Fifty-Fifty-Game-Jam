using UnityEngine;

public class BackgroundWrapping : MonoBehaviour
{
    [SerializeField] float speed = 0.02f;

    private Material material;
    private new Camera camera;
    
    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        camera = Camera.main;
    }

    private void Update()
    {
        Wrap();
    }

    private void Wrap()
    {
        Vector2 offset = material.mainTextureOffset;
        offset =  (Vector2) camera.transform.localPosition * speed;
        material.mainTextureOffset = offset;
    }
}