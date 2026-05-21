using UnityEngine;
using TMPro;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Controla uma resposta do mini quiz SQL.
/// Cada botão pode ser configurado como resposta correta ou incorreta.
/// </summary>
public class QuizSQL : MonoBehaviour
{
    [Header("Configuração da resposta")]
    public bool respostaCorreta;

    [Header("Texto que mostra o resultado do quiz")]
    public TMP_Text textoResultado;

    [Header("Renderer deste botão")]
    public Renderer botaoRenderer;

    [Header("Cores do botão")]
    public Color corNormal = Color.gray;
    public Color corCorreta = Color.green;
    public Color corErrada = Color.red;

    [Header("Câmera usada para detectar o clique")]
    public Camera cameraClique;

    private Camera cameraPrincipal;

    void Start()
    {
        if (cameraClique != null)
        {
            cameraPrincipal = cameraClique;
        }
        else
        {
            cameraPrincipal = Camera.main;

            if (cameraPrincipal == null)
            {
                cameraPrincipal = FindFirstObjectByType<Camera>();
            }
        }

        if (botaoRenderer != null)
        {
            botaoRenderer.material.color = corNormal;
        }

        if (textoResultado != null)
        {
            textoResultado.text = "Escolha uma resposta.";
        }
    }

    void Update()
    {
        Vector2 posicaoMouse;

        if (DetectouClique(out posicaoMouse))
        {
            VerificarClique(posicaoMouse);
        }
    }

    /// <summary>
    /// Detecta clique do mouse usando Input System novo ou Input antigo.
    /// </summary>
    bool DetectouClique(out Vector2 posicaoMouse)
    {
        posicaoMouse = Vector2.zero;
        bool clicou = false;

#if ENABLE_INPUT_SYSTEM
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            posicaoMouse = Mouse.current.position.ReadValue();
            clicou = true;
        }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
        if (Input.GetMouseButtonDown(0))
        {
            posicaoMouse = Input.mousePosition;
            clicou = true;
        }
#endif

        return clicou;
    }

    /// <summary>
    /// Faz um Raycast para verificar se o clique acertou este botão.
    /// </summary>
    void VerificarClique(Vector2 posicaoMouse)
    {
        if (cameraPrincipal == null)
        {
            Debug.LogWarning("Nenhuma câmera encontrada para o QuizSQL.");
            return;
        }

        Ray raio = cameraPrincipal.ScreenPointToRay(posicaoMouse);
        RaycastHit hit;

        if (Physics.Raycast(raio, out hit, 100f))
        {
            Debug.Log("Quiz clicou em: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject == gameObject || hit.collider.transform.IsChildOf(transform))
            {
                Responder();
            }
        }
    }

    /// <summary>
    /// Mostra se a resposta escolhida está correta ou errada.
    /// </summary>
    void Responder()
    {
        if (respostaCorreta)
        {
            if (textoResultado != null)
            {
                textoResultado.text = "Resposta correta! SELECT busca dados.";
            }

            if (botaoRenderer != null)
            {
                botaoRenderer.material.color = corCorreta;
            }
        }
        else
        {
            if (textoResultado != null)
            {
                textoResultado.text = "Tente novamente!";
            }

            if (botaoRenderer != null)
            {
                botaoRenderer.material.color = corErrada;
            }
        }
    }
}