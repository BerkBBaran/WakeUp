using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartRateMonitor : MonoBehaviour
{
    public TextMeshProUGUI bpmText;
    public Animator heartRateAnim;

    public float startingRate = 80;
    public float walkingLimit = 110;
    public float deathLimit = 180;

    public float walkingIncrease = 2f;  // make this non-linear?, e is better.
    public float climbingIncrease = 3f;
    public float decaySpeed = 2;    // decreases by 2 every second the player is not moving

    // i,e. if in range [110,180) and NOT climbing but walking, decrease bpm by this value every sec.
    public float decayAboveWalkingLimit = 1f;

    // public for debug purposes.
    public float currentBpm = 80;
    public bool isClimbing = false;

    private PlayerController pCont;

    bool hasDied = false;
    private void Awake()
    {
        pCont = FindObjectOfType<PlayerController>();
    }
    public void CalculateHeartRate(float moveMagnitude)
    {
        if(moveMagnitude > 0.05)
        {
            if (isClimbing)
            {
                // moving in climbing area
                // also slown down effect?
                currentBpm += climbingIncrease * Time.fixedDeltaTime;
                if (currentBpm > deathLimit)
                {
                    // if exceeds this while climbing, goal achieved, player dies.
                    Debug.Log("You killed yourself while climbing this tiny hill. Good for you.");
                    if (!hasDied)
                    {
                        Invoke("EndGameWithDelay", 2f);
                        hasDied = true;
                    }
                }
            }
            else
            {
                // moving in walking area
                if(currentBpm > walkingLimit)
                {
                    // exceeded the limit before by climbing, but stopped climbing.
                    // slowly decrease to limit even though player is walking.
                    currentBpm -= decayAboveWalkingLimit * Time.fixedDeltaTime;
                }
                else
                {
                    currentBpm += walkingIncrease * Time.fixedDeltaTime;
                    if (currentBpm > walkingLimit) currentBpm = walkingLimit;   // cant exceed this by just walking. needs to climb.
                }
            }
        }
        else
        {
            // no movement
            currentBpm -= decaySpeed * Time.fixedDeltaTime;
            if (currentBpm < startingRate) currentBpm = startingRate; // clamp to min

        }

        // Update UI
        bpmText.text = ((int)currentBpm).ToString();
    }

    private void Update()

    {
        if (currentBpm > 160)
        {
            heartRateAnim.speed = 2.5f;
        }
        if (currentBpm > 130)
        {
            heartRateAnim.speed = 1.8f;
        }
        else if(currentBpm >= 110)
        {
            heartRateAnim.speed = 1.5f;
        }
        else
        {
            heartRateAnim.speed = 1f;
        }
    }
    // needs to know whether the player is climbing or not.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClimbingArea"))
        {
            isClimbing = true;
            pCont.isClimbing = true;

            if (pCont.isDraging)
            {
                pCont.moveSpeed = pCont.climbAndDragSpeed;
            }
            else
            {
                pCont.moveSpeed = pCont.climbingSpeed;
            }
            Debug.Log("climbing now");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClimbingArea"))
        {
            isClimbing = false;

            pCont.isClimbing = false;
            Debug.Log("not climbing");
            if (pCont.isDraging)
            {
                pCont.moveSpeed = pCont.dragSpeed;
            }
            else
            {
                pCont.moveSpeed = pCont.defaultSpeed;
            }
        }
    }

    private void EndGameWithDelay()
    {
        GameManager.Instance.EndLevel();
    }
}
