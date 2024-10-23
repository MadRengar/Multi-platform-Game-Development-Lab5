using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public InputActionAsset controls;

    public InputAction moveAction;
    public InputAction fireAction;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        moveAction = controls.FindAction("Move");
        fireAction = controls.FindAction("Fire");
    }
}
