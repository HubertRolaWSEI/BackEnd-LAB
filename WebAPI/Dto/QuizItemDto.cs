using ApplicationCore.Models.QuizAggregate;

namespace WebApi.Dto;

public class QuizItemDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string> Options { get; set; }

    public QuizItemDto(int id, string question, List<string> options)
    {
        Id = id;
        Question = question;
        Options = options;
    }

    public static QuizItemDto Of(QuizItem quiz)
    {
        var options = new List<string> { quiz.CorrectAnswer };
        options.AddRange(quiz.IncorrectAnswers);
        
        var random = new Random();
        options = options.OrderBy(_ => random.Next()).ToList();
        
        return new QuizItemDto(
            id: quiz.Id,
            question: quiz.Question,
            options: options
        );
    }
}