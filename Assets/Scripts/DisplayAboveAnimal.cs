using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayAboveAnimal : MonoBehaviour
{
    public TMP_Text text;
    public TMP_InputField inputField;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Animal animal = GameManager.Instance.SelectedAnimal;
        inputField.text = animal.AnimalName;
        Vector3 textPosition = mainCamera.WorldToScreenPoint(animal.transform.position + (Vector3.up * 0.5f));
        transform.position = textPosition;
    }
}
