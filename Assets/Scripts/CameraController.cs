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
        // Obtém o movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Aplica rotação aos ângulos de rotação X e Y
        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Rotaciona o objeto vazio da câmera com base nos ângulos de rotação
        cameraTarget.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        // Atualiza a posição da câmera virtual para seguir o objeto vazio
        virtualCamera.transform.position = cameraTarget.position;
        virtualCamera.transform.rotation = cameraTarget.rotation;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            // Libera o cursor se a tecla Esc for pressionada
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
