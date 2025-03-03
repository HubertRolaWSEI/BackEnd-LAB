using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            
            //TODO Utwórz trzy pytania typu QuizItem
            //TODO Dodaj je do quizItemRepo
            //TODO Utwórz obiekt klasy Quiz z kolekcją pytań dodanych do quizItemRepo
            //TODO Dodaj Quiz do quizRepo
            
            List<QuizItem> quizItems = new List<QuizItem>();
            
            quizItems.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "7", question: "5 + 2",
                incorrectAnswers: new List<string>() {"2", "3", "4"})));

            quizItems.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "8", question: "4 * 2",
                incorrectAnswers: new List<string>() {"2", "3", "7"})));
            
            quizItems.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "0", question: "3 - 3",
                incorrectAnswers: new List<string>() {"2", "3", "6"})));

            quizRepo.Add(new Quiz(id: 1, items: quizItems, title: "Matematyka"));
            
            
            
            List<QuizItem> quizItems2 = new List<QuizItem>();
            
            quizRepo.Add(new Quiz(id: 2, items: quizItems2, title: "Piłka Nożna"));
            
            quizItems2.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "Real Madryt", question: "Najlepszy klub w historii piłki nożnej",
                incorrectAnswers: new List<string>() {"Termalica Brukbet Nieciecza", "Bayern Monachium", "Manchester City"})));

            quizItems2.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "15", question: "Jaka jest największa liczba zdobytych lig mistrzów przez jeden klub?",
                incorrectAnswers: new List<string>() {"2", "3", "7"})));
            
            quizItems2.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "11", question: "Ilu piłkarzy znajduje się na boisku w wyjściowej jedenastce?",
                incorrectAnswers: new List<string>() {"9", "10", "12"})));
            
            
            
            List<QuizItem> quizItems3 = new List<QuizItem>();
            
            quizRepo.Add(new Quiz(id: 3, items: quizItems3, title: "Sejm"));
            
            quizItems3.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "Andrzej Duda", question: "Kto jest prezydentem Polski?",
                incorrectAnswers: new List<string>() {"Sławomir Mentzen", "Donald Tusk", "Karol Nawrocki"})));

            quizItems3.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "460", question: "Ile jest osób w sejmie?",
                incorrectAnswers: new List<string>() {"452", "443", "447"})));
            
            quizItems3.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "Donald Tusk", question: "Kto jest premierem Polski?",
                incorrectAnswers: new List<string>() {"Andrzej Duda", "Rafał Trzaskowski", "Sławomir Mentzen"})));
            
            
            
        }
    }
}