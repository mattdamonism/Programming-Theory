using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//INHERITANCE
public class Cat : Animal
{
    private string animalName = "Cat";

    //POLYMORPHISM
    public override string AnimalName
    {
        get { return animalName; }
        //ENCAPSULATION
        set
        {
            if (value.Length < 10)
            {
                animalName = value;
            }
        }
    }
    
    protected override void Start()
    {
        base.Start();
        movementSpeed = 5;
    }
}
