namespace CauldronMinimal.History
{
    public interface IHistory
    {
        bool HistoryEnabled();
        void StartHistory();
    }
}