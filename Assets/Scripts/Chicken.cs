using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    private string animalName = "Chicken";

    public override string AnimalName
    {
        get { return animalName; }
        set { animalName = value; }
    }

    private int jumps = 0;
    private int maxJumps = 2;

    //add doublejump
    public override void Jump()
    {
        jumps += 1;
        base.Jump();
        if (jumps < maxJumps) {
            canJump = true;
        } else
        {
            jumps = 0;
        }
    }
}
