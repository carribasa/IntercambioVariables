using Photon.Pun;
using TMPro;

public class ControladorPuntos : MonoBehaviourPunCallbacks
{
    public TMP_InputField VariableLocalInput;
    public TMP_Text VariableLocalText;
    public TMP_Text VariableRedText;

    // variable para modificar en red
    public string tomarDatosRival = "0";

    // cuando se introduzca un valor en inputField se sincronizan
    public void CambiarValor()
    {
        string value = VariableLocalInput.text;
        VariableLocalText.text = value; // el jugador local cambia el valor

        // avisamos al otro jugador para que lo cambie
        photonView.RPC(nameof(CambiarValorEnRed), RpcTarget.OthersBuffered, value);
    }

    [PunRPC]
    void CambiarValorEnRed(string variable)
    {
        VariableRedText.text = variable;
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
