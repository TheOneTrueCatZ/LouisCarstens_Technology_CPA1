using UnityEngine;

public class AstroidBelt : MonoBehaviour
{
    [SerializeField]public float rotationSpeed = 10f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

}
