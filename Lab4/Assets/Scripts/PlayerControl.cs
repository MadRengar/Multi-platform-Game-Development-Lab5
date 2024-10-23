using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Move
    public float moveSpeed = 10f;
    public float rotationFactor = 5f;
    public float xMin = -5f, xMax = 5f; // 左右边界
    public float zMin = -5f, zMax = 5f; // 前后边界

    // Fire
    public GameObject boltPrefab;
    public Transform shotPoint; // 子弹生成点
    public float fireRate = 0.5f;
    private float nextFireTime = 0.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 这里检查发射子弹的输入
        if (InputManager.Instance.fireAction.triggered && Time.time >= nextFireTime)
        {
            Fire();
        }
    }

    void FixedUpdate()
    {
        /* Move */
        Vector2 moveInput = InputManager.Instance.moveAction.ReadValue<Vector2>();

        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.fixedDeltaTime;

        float clampedX = Mathf.Clamp(rb.position.x, xMin, xMax);
        float clampedZ = Mathf.Clamp(rb.position.z, zMin, zMax);

        rb.position = new Vector3(clampedX, rb.position.y, clampedZ);

        Vector3 newPosition = rb.position + movement;
        rb.MovePosition(newPosition);

        float tilt = -moveInput.x * rotationFactor;
        Quaternion playerRotation = Quaternion.Euler(0, 0, tilt);
        rb.MoveRotation(playerRotation);
    }

    void Fire()
    {
        // 使用子弹生成点的位置和旋转
        Instantiate(boltPrefab, shotPoint.position, shotPoint.rotation);

        // 更新下次发射时间，确保子弹发射间隔
        nextFireTime = Time.time + fireRate;
    }
}
