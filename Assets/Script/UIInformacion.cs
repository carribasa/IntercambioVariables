using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;

public class UIInformacion : MonoBehaviourPunCallbacks, IPunObservable
{
    // variables
    public TMP_Text informacion;
    public int playerNum;

    void Start()
    {
        StartCoroutine("SetPlayerOrEnemy");
    }

    void Update()
    {

    }

    IEnumerator SetPlayerOrEnemy()
    {
        yield return new WaitForSeconds(3);
        
        if (photonView.IsMine)
        {
            informacion.text = "Yo soy el jugador";
        }
        if (!photonView.IsMine)
        {
            informacion.text = "Soy el enemigo";
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
