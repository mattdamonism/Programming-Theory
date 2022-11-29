using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    public GameObject rename;

    private Animal selectedAnimal;
    private bool canMove = true;

    public Animal SelectedAnimal { get { return selectedAnimal; } }


    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (selectedAnimal != null && canMove)
        {
            selectedAnimal.Move();
        }
    }

    public void SelectAnimal(Animal animal)
    {
        selectedAnimal = animal;
        rename.SetActive(false);
        canMove = true;
    }

    public void RenameAnimal(Animal animal)
    {
        canMove = false;
        if (selectedAnimal != null)
        {
            selectedAnimal.Stop();  
        }
        selectedAnimal = animal;
        rename.GetComponent<NameChange>().Show();
    }
}
