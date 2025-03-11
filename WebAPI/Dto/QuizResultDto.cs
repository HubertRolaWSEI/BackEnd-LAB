namespace WebApi.Dto;

public class QuizResultDto
{
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public int CorrectAnswersCount { get; set; }

    public QuizResultDto(int quizId, int userId, int correctAnswersCount)
    {
        QuizId = quizId;
        UserId = userId;
        CorrectAnswersCount = correctAnswersCount;
    }

    public static QuizResultDto Of(int quizId, int userId, int correctAnswersCount)
    {
        return new QuizResultDto(quizId, userId, correctAnswersCount);
    }
}