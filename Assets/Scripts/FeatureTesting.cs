using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FeatureTesting : MonoBehaviour
{
    public float moveSpeed = 600f;
    float movement = 0f;
    #region Stamina
    private float staminaLeftValue = 100f;
    private float staminaRightValue = 100f;
    [SerializeField] private float turnCost = 25f;
    [SerializeField] private Image staminaRight;
    [SerializeField] private Image staminaLeft;
    private Coroutine rechargeLeft;
    private Coroutine rechargeRight;
    #endregion

    #region Flicker Screen
    [SerializeField] private GameObject X_iconLeft;
    [SerializeField] private GameObject X_iconRight;
    public bool isLeftDisabled = false;
    public bool isRightDisabled = false;
    #endregion

    private void FixedUpdate()
    {
        // Rotate around the center point (Vector3.zero)
        transform.RotateAround(Vector3.zero, Vector3.up, movement * Time.deltaTime * moveSpeed);
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        // Handle touch input
        if (Input.touchCount > 0 || (movement != 0f))
        {
            Touch touch = Input.GetTouch(0);

            // Check if touch is on the left side
            if (touch.position.x < Screen.width / 2 && !isLeftDisabled)
            {
                HandleLeftMovement();
            }
            // Check if touch is on the right side
            else if (touch.position.x >= Screen.width / 2 && !isRightDisabled)
            {
                HandleRightMovement();
            }
        }
    }

    private void HandleLeftMovement()
    {
        movement = -1f;
        staminaLeftValue -= turnCost * Time.deltaTime;
        if (staminaLeftValue < 0) staminaLeftValue = 0;
        staminaLeft.fillAmount = staminaLeftValue / 100;

        if (rechargeLeft != null) StopCoroutine(rechargeLeft);
        rechargeLeft = StartCoroutine(RechargeStamina(true));

        if (staminaLeftValue <= 0)
        {
            isLeftDisabled = true;
            X_iconLeft.SetActive(true);  // Show "X" icon
        }
    }

    private void HandleRightMovement()
    {
        movement = 1f;
        staminaRightValue -= turnCost * Time.deltaTime;
        if (staminaRightValue < 0) staminaRightValue = 0;
        staminaRight.fillAmount = staminaRightValue / 100;

        if (rechargeRight != null) StopCoroutine(rechargeRight);
        rechargeRight = StartCoroutine(RechargeStamina(false));

        if (staminaRightValue <= 0)
        {
            isRightDisabled = true;
            X_iconRight.SetActive(true);  // Show "X" icon
        }
    }

    private IEnumerator RechargeStamina(bool isLeft)
    {
        yield return new WaitForSeconds(1f);

        // Refill the corresponding stamina bar
        while (isLeft ? staminaLeftValue < 100 : staminaRightValue < 100)
        {
            if (isLeft)
            {
                staminaLeftValue += turnCost / 10f;
                if (staminaLeftValue > 100) staminaLeftValue = 100;
                staminaLeft.fillAmount = staminaLeftValue / 100;

                if (staminaLeftValue > 0) X_iconLeft.SetActive(false);  // Hide "X" icon when stamina is refilled
            }
            else
            {
                staminaRightValue += turnCost / 10f;
                if (staminaRightValue > 100) staminaRightValue = 100;
                staminaRight.fillAmount = staminaRightValue / 100;

                if (staminaRightValue > 0) X_iconRight.SetActive(false);  // Hide "X" icon when stamina is refilled
            }

            yield return new WaitForSeconds(0.1f);
        }

        // Re-enable movement once stamina is full
        if (isLeft) isLeftDisabled = false;
        else isRightDisabled = false;
    }
}
