using UnityEngine;
using UnityEngine.Rendering;

public class LookAtDirection : MonoBehaviour
{
    private const string VERTICAL_DIRECTION = "Vertical";
    private const string HORIZONTAL_DIRECTION = "Horizontal";

    [SerializeField] private float minMagnitude;

    private Vector2 direction;

    private void Update()
    {
        direction.x = Input.GetAxis(HORIZONTAL_DIRECTION);
        direction.y = Input.GetAxis(VERTICAL_DIRECTION);
        if (direction.magnitude < minMagnitude) return;

        var eulerAngles = transform.localEulerAngles;

        eulerAngles.z = Mathf.Acos(direction.x / direction.magnitude);
        eulerAngles.z *= Mathf.Rad2Deg;
        if (direction.y < 0) eulerAngles.z = 360 - eulerAngles.z;
        eulerAngles.z -= 90;
        transform.localEulerAngles = eulerAngles;
    }
}
