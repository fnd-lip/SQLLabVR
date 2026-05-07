using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Controla a interação do botão SELECT na sala SQL.
/// Quando o usuário clica no botão, o painel de resultado aparece,
/// o botão muda de cor e a tabela consultada fica destacada.
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

    private bool consultaAtiva = false;
    private Color corOriginalTabela;
    private Camera cameraPrincipal;

    void Start()
    {
        cameraPrincipal = Camera.main;

        if (cameraPrincipal == null)
        {
            cameraPrincipal = FindFirstObjectByType<Camera>();
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
    /// Faz um Raycast da câmera até a posição do mouse.
    /// Se o Raycast acertar este botão, a consulta é ativada.
    /// </summary>
    void VerificarCliqueNoBotao(Vector2 posicaoMouse)
    {
        if (cameraPrincipal == null)
        {
            Debug.LogWarning("Nenhuma câmera encontrada na cena.");
            return;
        }

        Ray raio = cameraPrincipal.ScreenPointToRay(posicaoMouse);
        RaycastHit hit;

        if (Physics.Raycast(raio, out hit, 100f))
        {
            Debug.Log("Clique acertou o objeto: " + hit.collider.gameObject.name);

            if (hit.collider.gameObject == gameObject)
            {
                AlternarConsulta();
            }
        }
    }

    /// <summary>
    /// Ativa ou desativa o resultado da consulta SQL.
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
    }
}