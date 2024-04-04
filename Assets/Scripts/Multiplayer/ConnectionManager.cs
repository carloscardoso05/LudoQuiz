using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField nickName;
    [SerializeField] private TextMeshProUGUI message;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnClick_Connect()
    {
        message.text = "";
        if (nickName.text.Length == 0)
        {
            message.text = "Insira o nome do jogador";
            return;
        }
        PhotonNetwork.NickName = nickName.text;
        PhotonNetwork.ConnectUsingSettings();
        message.text = "Carregando...";
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("Lobby");
    }
}