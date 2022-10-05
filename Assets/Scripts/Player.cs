using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 2f;

    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float padTop;
    [SerializeField] float padRight;
    [SerializeField] float padBottom;
    [SerializeField] float padLeft;

    void Start() {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds() {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }

    void Move() {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + padLeft, maxBounds.x - padRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + padBottom, maxBounds.y - padTop);
        transform.position = newPos;
    }
}
