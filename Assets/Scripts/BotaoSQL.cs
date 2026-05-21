using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Controla a interação do botão SELECT na sala SQL.
/// Quando o usuário clica no botão, o painel de resultado aparece,
/// o botão muda de cor, a tabela consultada fica destacada
/// e a luz do servidor acende para simular o processamento da consulta.
/// </summary>
public class BotaoSQL : MonoBehaviour
{
    [Header("Painel com o resultado da consulta")]
    public GameObject painelResultado;

    [Header("Objeto que representa a tabela consultada")]
    public Renderer tabelaUsuarios;

    [Header("Renderer do botão")]
    public Renderer botaoRenderer;

    [Header("Cores da interação")]
    public Color corBotaoNormal = Color.red;
    public Color corBotaoAtivo = Color.green;
    public Color corTabelaAtiva = Color.cyan;

    [Header("Luz de status do servidor")]
    public Renderer luzServidorRenderer;
    public Material materialLuzDesligada;
    public Material materialLuzAtiva;
    public Light luzServidorPoint;

    [Header("Câmera usada para detectar o clique")]
    public Camera cameraClique;

    [Header("Configuração do clique")]
    public bool usarCentroDaTela = false;
    public float distanciaClique = 100f;

    private bool consultaAtiva = false;
    private Color corOriginalTabela;
    private Camera cameraPrincipal;

    void Start()
    {
        // Usa a câmera definida manualmente no Inspector.
        // Se não tiver câmera definida, tenta encontrar uma câmera automaticamente.
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

        if (painelResultado != null)
        {
            painelResultado.SetActive(false);
        }

        if (botaoRenderer != null)
        {
            botaoRenderer.material.color = corBotaoNormal;
        }

        if (tabelaUsuarios != null)
        {
            corOriginalTabela = tabelaUsuarios.material.color;
        }

        // Garante que a luz do servidor começa desligada.
        AtualizarLuzServidor(false);
    }

    void Update()
    {
        Vector2 posicaoMouse;

        if (DetectouClique(out posicaoMouse))
        {
            VerificarCliqueNoBotao(posicaoMouse);
        }
    }

    /// <summary>
    /// Detecta clique do mouse usando tanto o Input System novo quanto o Input antigo.
    /// Isso deixa o script mais compatível com diferentes configurações do Unity.
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
    /// Faz um Raycast para detectar se o usuário clicou no botão SELECT.
    /// No modo VR, usar o centro da tela costuma funcionar melhor do que usar a posição exata do mouse.
    /// </summary>
    void VerificarCliqueNoBotao(Vector2 posicaoMouse)
    {
        if (cameraPrincipal == null)
        {
            Debug.LogWarning("Nenhuma câmera encontrada na cena.");
            return;
        }

        Ray raio;

        if (usarCentroDaTela)
        {
            // Raycast saindo do centro da câmera, como se o usuário estivesse olhando para o botão.
            raio = new Ray(cameraPrincipal.transform.position, cameraPrincipal.transform.forward);
        }
        else
        {
            // Raycast tradicional usando a posição do mouse.
            raio = cameraPrincipal.ScreenPointToRay(posicaoMouse);
        }

        RaycastHit hit;

        if (Physics.Raycast(raio, out hit, distanciaClique))
        {
            Debug.Log("Clique acertou o objeto: " + hit.collider.gameObject.name);

            // Aceita clique no próprio botão ou em algum objeto filho dele.
            if (hit.collider.gameObject == gameObject || hit.collider.transform.IsChildOf(transform))
            {
                AlternarConsulta();
            }
        }
    }

    /// <summary>
    /// Ativa ou desativa o resultado da consulta SQL.
    /// Também altera o botão, a tabela consultada e a luz do servidor.
    /// </summary>
    void AlternarConsulta()
    {
        consultaAtiva = !consultaAtiva;

        if (painelResultado != null)
        {
            painelResultado.SetActive(consultaAtiva);
        }

        if (botaoRenderer != null)
        {
            botaoRenderer.material.color = consultaAtiva ? corBotaoAtivo : corBotaoNormal;
        }

        if (tabelaUsuarios != null)
        {
            tabelaUsuarios.material.color = consultaAtiva ? corTabelaAtiva : corOriginalTabela;
        }

        // Acende ou apaga a luz do servidor conforme o estado da consulta.
        AtualizarLuzServidor(consultaAtiva);
    }

    /// <summary>
    /// Controla a luz visual do servidor.
    /// Quando a consulta é executada, a luz fica verde e a Point Light acende.
    /// Quando a consulta é desativada, a luz volta para o material desligado.
    /// </summary>
    void AtualizarLuzServidor(bool ativa)
    {
        if (luzServidorRenderer != null)
        {
            if (ativa && materialLuzAtiva != null)
            {
                luzServidorRenderer.material = materialLuzAtiva;
            }
            else if (!ativa && materialLuzDesligada != null)
            {
                luzServidorRenderer.material = materialLuzDesligada;
            }
        }

        if (luzServidorPoint != null)
        {
            luzServidorPoint.gameObject.SetActive(ativa);
        }
    }
}