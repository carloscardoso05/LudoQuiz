using UnityEngine;

public enum GameState { SelectPlayersNumber, RollingDice, SelectPiece, End };
public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public Dice dice;
    public GameState state = GameState.SelectPlayersNumber;
    private GameColor[] colors;
    public GameColor? currentColor;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject piecePrefab;

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        SetMenuVisibility(true);
    }

    private void GeneratePlayersPieces()
    {
        var players = new GameObject("Players");
        foreach (GameColor color in colors)
        {
            if (color == GameColor.White) continue;
            var colorGO = new GameObject(color.ToString());
            colorGO.transform.parent = players.transform;
            for (int i = 0; i < 4; i++)
            {
                var piece = Instantiate(piecePrefab).GetComponent<Piece>();
                piece.name = "Piece" + i.ToString();
                piece.transform.parent = colorGO.transform;
                Vector2 homePosition = Board.I.GetHome(color).transform.position;
                Vector2 offset = Board.I.GetHomeOffset(i);
                piece.HomePosition = homePosition + offset;
                piece.color = color;
                piece.spriteResolver.SetCategoryAndLabel("Body", color.ToString());
            }
        }
    }

    public void InitGame(int playersQuantity)
    {
        colors = Colors.GetColorsByPlayersQty(playersQuantity);
        GeneratePlayersPieces();
        SetMenuVisibility(false);
        UpdateColor();
    }

    public void UpdateColor()
    {
        currentColor = Colors.GetNextColor(currentColor, colors);
    }

    private void SetMenuVisibility(bool isInMenu)
    {
        MainMenu.SetActive(isInMenu);
        UI.SetActive(!isInMenu);
        dice.gameObject.SetActive(!isInMenu);
        Board.I.gameObject.SetActive(!isInMenu);
    }
}