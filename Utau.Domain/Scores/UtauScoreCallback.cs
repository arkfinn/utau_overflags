using Utau.Elements;

namespace Utau.Domain.Scores
{
    public delegate UtauElement UtauScoreCallback(int index, UtauElement prev, UtauElement now, UtauElement next);
}