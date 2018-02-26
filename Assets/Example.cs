using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    private const float LOW_VALUE = 150;
    private const float HIGH_VALUE = 250;
    private const float TIME = 3;

    private bool trigger = false;

    private float lerpValue;
    private float moveTowardsValue;

    private float elapsed = 0;

	void Update ()
    {
        if (trigger)
        {
            // Lerping properly requires you keep track of the amount of time elapsed since the trigger event
            elapsed += Time.deltaTime;
            lerpValue = Mathf.Lerp(LOW_VALUE, HIGH_VALUE, elapsed / TIME);

            // MoveTowards does not require this, as the return value is moved by a maximum delta value
            moveTowardsValue = Mathf.MoveTowards(moveTowardsValue, HIGH_VALUE, (HIGH_VALUE - LOW_VALUE) / TIME * Time.deltaTime);
        }

        if (elapsed > TIME)
        {
            trigger = false;
            elapsed = TIME;
        }
	}

    private void ResetTrigger()
    {
        trigger = true;
        lerpValue = LOW_VALUE;
        moveTowardsValue = LOW_VALUE;
        elapsed = 0;
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Reset Trigger"))
        {
            ResetTrigger();
        }

        GUILayout.Label("Lerp: ");
        GUILayout.Label(lerpValue.ToString());
        GUILayout.Label("MoveTowards: ");
        GUILayout.Label(moveTowardsValue.ToString());

        GUILayout.Label("Elapsed Since Reset:");
        GUILayout.Label(elapsed.ToString());
    }
}
