using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject display;

    private DisplayAboveAnimal displayScript;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Animal animal = hit.collider.GetComponentInParent<Animal>();
                if (animal != null)
                {
                    GameManager.Instance.SelectedAnimal = animal;
                    display.SetActive(true);
                }
            }
        }
        if (GameManager.Instance.SelectedAnimal != null)
        {
            GameManager.Instance.SelectedAnimal.Move();
        }
    }
}
