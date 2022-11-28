using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : Animal
{
    private string animalName = "Penguin";

    public override string AnimalName
    {
        get { return animalName; }
        set { animalName = value; }
    }
    protected override void Start()
    {
        movementSpeed = 1;
        jumpForce = 2;
        base.Start();
    }
}
