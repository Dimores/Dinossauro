using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Pegando a camera
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public Transform cameraTarget;
    public float mouseSensitivity = 1f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Trava o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Obt�m o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Aplica rota��o aos �ngulos de rota��o X e Y
        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Rotaciona o objeto vazio da c�mera com base nos �ngulos de rota��o
        cameraTarget.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        // Atualiza a posi��o da c�mera virtual para seguir o objeto vazio
        virtualCamera.transform.position = cameraTarget.position;
        virtualCamera.transform.rotation = cameraTarget.rotation;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            // Libera o cursor se a tecla Esc for pressionada
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
