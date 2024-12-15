using TMPro;
using Unity.UI;
public class AlertTextCommand : ICommand
{
    private TMP_Text _board;
    private string _text;
    public AlertTextCommand(TMP_Text board, string message)
    {
        _board = board;
        _text = message;
    }
    public void Execute()
    {
        _board.text = _text;
    }
}
