using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehaviour
{
    public float speed = 3f;
    public float runMultiplier = 1.4f;
    public bool running;

    void Update()
    {
        running = false;

        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var run = inputState.GetButtonValue(inputButtons[2]);

        float tmpSpeed = 0;

        if(right || left)
        {
            tmpSpeed = speed;

            if(run && runMultiplier > 0)
            {
                tmpSpeed *= runMultiplier;
                running = true;
            }

            var velx = tmpSpeed * (float)inputState.directions;
            body2d.velocity = new Vector2(velx, body2d.velocity.y);
        }
    }
}
