using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Move
    public float moveSpeed = 10f;
    public float rotationFactor = 5f;
    public float xMin = -5f, xMax = 5f; // ���ұ߽�
    public float zMin = -5f, zMax = 5f; // ǰ��߽�

    // Fire
    public GameObject boltPrefab;
    public Transform shotPoint; // �ӵ����ɵ�
    public float fireRate = 0.5f;
    private float nextFireTime = 0.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �����鷢���ӵ�������
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
        // ʹ���ӵ����ɵ��λ�ú���ת
        Instantiate(boltPrefab, shotPoint.position, shotPoint.rotation);

        // �����´η���ʱ�䣬ȷ���ӵ�������
        nextFireTime = Time.time + fireRate;
    }
}
