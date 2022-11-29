using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputName;

    void Update()
    {
        if (shakeInput)
        {
            ShakeInput();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        if (inputName.text != "")
        {
            GameManager.Instance.PlayerName = inputName.text;
            SceneManager.LoadScene(1);
        }
        else if (!shakeInput)
        {
            shakeDirection = shakeSpeed;
            inputInitialX = inputName.transform.position.x;
            shakeInput = true;
        }

    }

    private bool shakeInput = false;
    private float shakeDistance = 5f;
    private float shakeSpeed = 15.0f;
    private float shakeDirection;
    private int totalShakes = 2;
    private int shakeCount = 0;
    private float inputInitialX;
    private void ShakeInput()
    {
        if (shakeCount >= totalShakes)
        {
            if (inputName.transform.position.x > inputInitialX)
            {
                inputName.transform.position = new Vector3(inputInitialX, inputName.transform.position.y, inputName.transform.position.z);
                shakeCount = 0;
                shakeInput = false;
                return;
            }
        }
        if (inputName.transform.position.x > inputInitialX + shakeDistance)
        {
            shakeDirection = -shakeSpeed;
        }
        else if (inputName.transform.position.x < inputInitialX - shakeDistance)
        {
            shakeDirection = shakeSpeed;
            shakeCount += 1;
        }
        inputName.transform.Translate(Vector3.right * shakeDirection * shakeSpeed * Time.deltaTime);
    }
}
