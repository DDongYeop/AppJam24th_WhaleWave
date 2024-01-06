using UnityEngine;

public class Shrimp : MonoBehaviour
{
    [SerializeField] private float _rotation;
    private Transform visual;

    private void Awake()
    {
        visual = transform.GetChild(0);
    }

    private void Update()
    {
        visual.Rotate(Vector3.up * (_rotation * Time.deltaTime));
    }
}
