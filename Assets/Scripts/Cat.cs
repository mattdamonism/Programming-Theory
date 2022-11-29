using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    private string animalName = "Cat";

    public override string AnimalName
    {
        get { return animalName; }
        set { animalName = value; }
    }
    protected override void Start()
    {
        base.Start();
        movementSpeed = 5;
    }
}
