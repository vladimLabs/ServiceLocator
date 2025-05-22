using Core;

namespace ScoreSystem
{
    public class Score : IService
    {
        private readonly IScoreView _scoreView;

        public int CurrentScore { get; private set; }
        
        public Score(IScoreView scoreView)
        {
            _scoreView = scoreView;
        }

        public void AddScore()
        {
            CurrentScore++;
            _scoreView.SetScore(CurrentScore);
        }

        public void SetScore(int score)
        {
            CurrentScore = score;
        }
    }
}
