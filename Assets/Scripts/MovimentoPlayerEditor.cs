using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Controla a movimentação do jogador no Unity Editor.
/// Permite andar com WASD e olhar ao redor com o mouse.
/// Isso ajuda a testar a experiência sem depender do óculos VR.
/// </summary>
public class MovimentoPlayerEditor : MonoBehaviour
{
    [Header("Configurações de movimento")]
    public float velocidade = 4f;
    public float sensibilidadeMouse = 0.1f;

    [Header("Câmera do jogador")]
    public Transform cameraJogador;

    private float rotacaoVertical = 0f;

    void Start()
    {
        if (cameraJogador == null && Camera.main != null)
        {
            cameraJogador = Camera.main.transform;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 entradaMovimento = Vector2.zero;
        Vector2 entradaMouse = Vector2.zero;
        bool usouInputSystemNovo = false;

#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) entradaMovimento.y += 1;
            if (Keyboard.current.sKey.isPressed) entradaMovimento.y -= 1;
            if (Keyboard.current.dKey.isPressed) entradaMovimento.x += 1;
            if (Keyboard.current.aKey.isPressed) entradaMovimento.x -= 1;

            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            usouInputSystemNovo = true;
        }

        if (Mouse.current != null)
        {
            entradaMouse = Mouse.current.delta.ReadValue() * sensibilidadeMouse;
        }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
        if (!usouInputSystemNovo)
        {
            entradaMovimento.x = Input.GetAxisRaw("Horizontal");
            entradaMovimento.y = Input.GetAxisRaw("Vertical");

            entradaMouse.x = Input.GetAxis("Mouse X") * sensibilidadeMouse * 10f;
            entradaMouse.y = Input.GetAxis("Mouse Y") * sensibilidadeMouse * 10f;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
#endif

        MoverJogador(entradaMovimento);
        GirarCamera(entradaMouse);
    }

    void MoverJogador(Vector2 entrada)
    {
        Vector3 direcao = transform.right * entrada.x + transform.forward * entrada.y;

        if (direcao.magnitude > 1)
        {
            direcao.Normalize();
        }

        transform.position += direcao * velocidade * Time.deltaTime;
    }

    void GirarCamera(Vector2 entradaMouse)
    {
        transform.Rotate(Vector3.up * entradaMouse.x);

        rotacaoVertical -= entradaMouse.y;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -80f, 80f);

        if (cameraJogador != null)
        {
            cameraJogador.localRotation = Quaternion.Euler(rotacaoVertical, 0f, 0f);
        }
    }
}