using ApplicationCore.Models.QuizAggregate;
 
namespace WebAPI.Dto;
 
public class QuizItemDto 
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string> Options { get; set; }
 
    /*public static QuizItemDto of(QuizItem quizItem)
    {
        var allOptions = new List<string>(quizItem.IncorrectAnswers)
        {
            quizItem.CorrectAnswer
        };

        return new QuizItemDto
        {
            Id = quizItem.Id,
            Question = quizItem.Question,
            Options = allOptions.OrderBy(option => option).ToList()
        };
    }*/
     
    public static QuizItemDto of(QuizItem quiz)
    {
        return new QuizItemDto
        {
            Id = quiz.Id,
            Question = quiz.Question,
            Options = quiz.IncorrectAnswers
                .Concat(new[] { quiz.CorrectAnswer })
                .OrderBy(option => option)
                .ToList()
        };
    }
}