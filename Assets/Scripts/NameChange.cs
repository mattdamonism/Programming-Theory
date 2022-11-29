using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameChange : MonoBehaviour
{
    public TMP_Text text;
    public TMP_InputField inputField;
    public Camera mainCamera;

    private Animal animal;

    public void Show()
    {
        animal = PlayerControl.Instance.SelectedAnimal;
        inputField.text = animal.AnimalName;
        Vector3 textPosition = mainCamera.WorldToScreenPoint(animal.transform.position + (Vector3.up * 0.5f));
        transform.position = textPosition;
        gameObject.SetActive(true);
        inputField.Select();
        inputField.ActivateInputField();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            animal.AnimalName = inputField.text;
            PlayerControl.Instance.SelectAnimal(animal);
        }
    }
}
