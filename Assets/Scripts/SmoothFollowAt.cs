using UnityEngine;

public class SmoothFollowAt : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 smoothSpeed;

    private Transform selfTransform;

    public Vector3 Offset { get => offset; set => offset = value; }

    private void Awake()
    {
        selfTransform = transform;
    }

    private void LateUpdate()
    {
        if (character == null)
        {
            return;
        }
        selfTransform.position = new Vector3(Mathf.Lerp(selfTransform.position.x, character.position.x + Offset.x, Time.deltaTime * smoothSpeed.x),
            Mathf.Lerp(selfTransform.position.y, character.position.y + Offset.y, Time.deltaTime * smoothSpeed.y),
            Mathf.Lerp(selfTransform.position.z, character.position.z + Offset.z, Time.deltaTime * smoothSpeed.z));
    }
}
