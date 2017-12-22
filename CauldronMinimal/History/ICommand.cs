namespace CauldronMinimal.History
{
    public interface ICommand
    {
        void Perform();

        void Undo();
    }
}