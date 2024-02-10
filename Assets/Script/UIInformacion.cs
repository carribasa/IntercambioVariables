using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInformacion : MonoBehaviourPunCallbacks, IPunObservable
{
    // variables
    public TMP_Text informacion;
    public int playerNum;
    public GameObject InsertaNumeroAAdivinar, VariableLocalInput, QueNumeroEs, VariableRedInput, BotonComprobarNumero, UIJuego, UIFinJuego, TextHasAdivinado, TextNoHasAdivinado, VariableLocal, VariableLocalText;

    void Start()
    {
        StartCoroutine("SetPlayerOrEnemy");
    }

    IEnumerator SetPlayerOrEnemy()
    {
        yield return new WaitForSeconds(3);

        if (photonView.IsMine)
        {
            informacion.text = "Yo soy el jugador que pone numero";
            QueNumeroEs.SetActive(false);
            VariableRedInput.SetActive(false);
            InsertaNumeroAAdivinar.SetActive(true);
            VariableLocalInput.SetActive(true);
            BotonComprobarNumero.SetActive(false);
        }
        if (!photonView.IsMine)
        {
            informacion.text = "Soy el jugador que adivina numero";
            InsertaNumeroAAdivinar.SetActive(false);
            VariableLocalInput.SetActive(false);
            QueNumeroEs.SetActive(true);
            VariableRedInput.SetActive(true);
            VariableLocal.SetActive(false);
            VariableLocalText.SetActive(false);
            
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}