using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private const string VERTICAL_DIRECTION = "Vertical";
    private const string HORIZONTAL_DIRECTION = "Horizontal";
    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float dashSpeed = 1.5f;
    [SerializeField] private float dashTime = 1f;

    private Vector2 direction;
    private Rigidbody2D _rigidbody2D;
    private float doDash = 0;
    private bool isDash = false;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction.x = Input.GetAxis(HORIZONTAL_DIRECTION);
        direction.y = Input.GetAxis(VERTICAL_DIRECTION);
        if (Input.GetKeyDown(KeyCode.Space) == true && isDash == false)
        {
            isDash = true;
            doDash = 1f;
            StartCoroutine(DashTimeCoroutine());
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = direction * (playerSpeed + dashSpeed * doDash) * Time.fixedDeltaTime;
    }

    private IEnumerator DashTimeCoroutine()
    {
        var time = 0f;

        while (time < dashTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        isDash = false;
        doDash = 0;
    }
}
