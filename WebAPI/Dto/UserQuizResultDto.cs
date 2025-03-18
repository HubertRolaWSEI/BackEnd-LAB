namespace WebAPI.Dto;

public class UserQuizResultDto
{
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public int CorrectAnswersCount { get; set; }

    public UserQuizResultDto(int quizId, int userId, int correctAnswersCount)
    {
        QuizId = quizId;
        UserId = userId;
        CorrectAnswersCount = correctAnswersCount;
    }
}