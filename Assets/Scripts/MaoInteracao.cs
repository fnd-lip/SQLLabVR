using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

// Faz uma pequena animação na mão visual quando o usuário clica.
public class MaoInteracao : MonoBehaviour
{
    public float distanciaClique = 0.15f;
    public float velocidade = 12f;

    private Vector3 posicaoInicial;
    private Vector3 posicaoClique;
    private bool clicando = false;

    void Start()
    {
        posicaoInicial = transform.localPosition;
        posicaoClique = posicaoInicial + new Vector3(0, 0, distanciaClique);
    }

    void Update()
    {
        if (DetectouClique())
        {
            clicando = true;
        }

        Vector3 destino = clicando ? posicaoClique : posicaoInicial;

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            destino,
            Time.deltaTime * velocidade
        );

        if (clicando && Vector3.Distance(transform.localPosition, posicaoClique) < 0.02f)
        {
            clicando = false;
        }
    }

    bool DetectouClique()
    {
#if ENABLE_INPUT_SYSTEM
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            return true;
        }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
#endif

        return false;
    }
}