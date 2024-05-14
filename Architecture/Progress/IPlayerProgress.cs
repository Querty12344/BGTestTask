namespace Project.Scripts.Architecture.Progress
{
    public interface IPlayerProgress
    {
        public int GetActiveLevel();
        public void MoveNextLevel();
    }
}