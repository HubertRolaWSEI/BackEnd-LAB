using ApplicationCore.Models.QuizAggregate;
using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controller;

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
    public async Task<ActionResult<QuizDto>> FindById(int id)
    {
        var quiz = _service.FindQuizById(id);
        if (quiz is null)
        {
            return NotFound();
        }

        var quizDto = QuizDto.of(quiz);
        return Ok(quizDto);
    }
    
    [HttpGet]
    public IEnumerable<QuizDto> FindAll()
    {
        return  _service.FindAllQuizzes().Select(u=>QuizDto.of(u));
    }
    
    [HttpPost]
    [Route("{quizId}/items/{itemId}")]
    public IActionResult SaveAnswer([FromBody] QuizItemAnswerDto dto, [FromRoute] int quizId, [FromRoute] int itemId)
    {
        _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);

        return NoContent(); // zwraca status HTTP 204, czyli poprawnie zapisano bez treści
    }

    [HttpGet]
    [Route("{quizId}/users/{userId}/result")]
    public ActionResult<UserQuizResultDto> GetQuizResultForUser(int quizId, int userId)
    {
        int correctAnswers = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);

        var resultDto = new UserQuizResultDto(quizId, userId, correctAnswers);

        return Ok(resultDto);
    }


}