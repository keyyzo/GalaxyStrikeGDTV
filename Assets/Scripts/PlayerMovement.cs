using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Ship Movement Variables")]

    [SerializeField] float baseMovementSpeed = 5.0f;

    [SerializeField] float xClampRange = 5.0f;
    [SerializeField] float yMinClampRange = -5.0f;
    [SerializeField] float yMaxClampRange = 5.0f;

    [Space(10)]

    [Header("Ship Rotation Variables")]

    [SerializeField] float generalRotationSpeed = 5.0f;

    [Space(5)]

    [Header("Roll")]

    [SerializeField] float controlRollFactor = 20.0f;

    [Space(5)]

    [Header("Pitch")]

    [SerializeField] float controlPitchFactor = 20.0f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        ProcessShipTranslation();
        ProcessShipRotation();
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void ProcessShipTranslation()
    {
        float xOffset = movement.x * baseMovementSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * baseMovementSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yMinClampRange, yMaxClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessShipRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, generalRotationSpeed * Time.deltaTime);
    }
}
