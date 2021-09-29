namespace Utau.Domain.Scores
{
    public interface IScoreWriter
    {
        void Write(string body);
    }
}