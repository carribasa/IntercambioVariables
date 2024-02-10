using Photon.Pun;
using TMPro;
using UnityEngine;

public class ControladorPuntos : MonoBehaviourPunCallbacks
{
    public TMP_InputField VariableLocalInput, VariableRedInput;
    public TMP_Text VariableLocalText;
    public TMP_Text VariableRedText;
    private string numeroAAdivinar, numeroAdivinado;
    public GameObject UIJuego, UIFinJuego, TextoHasAdivinado, TextoNoHasAdivinado, BotonComprobarNumero;

    // variable para modificar en red
    public string tomarDatosRival = "0";

    // cuando se introduzca un valor en inputField se sincronizan
    public void CambiarValor()
    {
        string value = VariableLocalInput.text;
        VariableLocalText.text = value; // el jugador local cambia el valor

        // avisamos al otro jugador para que lo cambie
        photonView.RPC(nameof(EnviarValorEnRed), RpcTarget.OthersBuffered, value);
    }

    [PunRPC]
    void EnviarValorEnRed(string variable)
    {
        numeroAAdivinar = variable;
    }

    public void ComprobarNumero()
    {
        UIJuego.SetActive(false);
        UIFinJuego.SetActive(true);

        if (VariableRedText.text == numeroAAdivinar)
        {
            TextoHasAdivinado.SetActive(true);
            TextoNoHasAdivinado.SetActive(false);
        }
        else
        {
            TextoNoHasAdivinado.SetActive(true);
            TextoHasAdivinado.SetActive(false);
        }
    }

    public void AlmacenarNumeroAdivinado()
    {
        string value = VariableRedInput.text;
        VariableRedText.text = value;
    }

}