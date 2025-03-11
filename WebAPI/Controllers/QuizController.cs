using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/quizzes")]
public class QuizController : ControllerBase
{
    private readonly IQuizUserService _service;

    public QuizController(IQuizUserService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<QuizDto> FindById(int id)
    {
        var quiz = _service.FindQuizById(id);
        if (quiz == null)
        {
            return NotFound();
        }
        var quizDto = QuizDto.Of(quiz);
        return Ok(quizDto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<QuizDto>> FindAll()
    {
        var quizzes = _service.FindAllQuizzes();
        var quizDtos = quizzes.Select(QuizDto.Of).ToList();
        return Ok(quizDtos);
    }

    [HttpPost]
    [Route("{quizId}/items/{itemId}")]
    public IActionResult SaveAnswer(int quizId, int itemId, [FromBody] QuizItemAnswerDto dto)
    {
        _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);
        return NoContent();
    }

    [HttpGet]
    [Route("{quizId}/results/{userId}")]
    public ActionResult<QuizResultDto> GetQuizResult(int quizId, int userId)
    {
        var correctAnswersCount = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);
        var resultDto = QuizResultDto.Of(quizId, userId, correctAnswersCount);
        return Ok(resultDto);
    }
}