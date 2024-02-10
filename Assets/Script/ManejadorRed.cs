using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class ManejadorRed : MonoBehaviourPunCallbacks
{
    public TMP_Text informacion;
    public static ManejadorRed manejadorRed;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        informacion.text = "Conectando al servidor";
        print(informacion.text);
        Debug.Log("Conectando al servidor");
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Sala", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }
}