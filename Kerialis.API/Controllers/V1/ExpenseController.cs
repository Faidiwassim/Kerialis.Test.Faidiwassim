using Kerialis.Datas.DbContexts;
using Kerialis.Datas.DTO;
using Kerialis.Datas.Entities.V1;
using Kerialis.Datas.Enum;
using Kerialis.Repositories;
using Kerialis.Repositories.Factories;
using Kerialis.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;


namespace Kerialis.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IRepository<User, int, KerialisContext> _repoUser;
        private readonly IRepository<Expense, int, KerialisContext> _repoExpense;
        private readonly IExpenseService _expenseService;

        public ExpenseController(IRepositoryFactory<KerialisContext> repo, IExpenseService expenseService)
        {
            _repoUser = repo.Create<User, int>();
            _repoExpense = repo.Create<Expense, int>();
            _expenseService = expenseService;
        }


        // Get Expenses(Depenses) Action
        [HttpGet("GetExpenseUser")]
        public async Task<IActionResult> GetExpenseUser(int userId, SortEnum sort)
        {
            var result = await _expenseService.GetExpenseUser(userId, sort);
            return Ok(result);
        }

        // Post Expense(Depense) Action
        [HttpPost("PostWithDto")]
        public async Task<ActionResult> PostWithDto([FromForm] ExpensePostDTO model)
        {

            if (model.Date < DateTime.Now.AddMonths(-3))
            {
                return StatusCode(500, "Une dépense ne peut pas être datée de plus de 3 mois");
            }
            if (model.Date > DateTime.Now)
            {
                return StatusCode(500, "Une dépense ne peut pas avoir une date dans le futur");
            }

            var expenseUser = await _repoExpense.FindAsQuerableAsync(x => x.UserId == model.UserId && x.Date.Year == model.Date.Year && x.Date.Month == model.Date.Month && x.Date.Day == model.Date.Day && x.Amount == model.Amount);
            if (expenseUser.Count() > 0)
            {
                return StatusCode(500, "Un utilisateur ne peut pas déclarer deux fois la même dépense (même date et même montant)");
            }
            var user = await _repoUser.FindOneAsync(x => x.Id == model.UserId);

            if (user != null && model.CurrencyId != user.CurrencyId)
            {
                return StatusCode(500, "La devise de la dépense doit être identique à celle de l'utilisateur");
            }

            if (string.IsNullOrEmpty(model.Comment))
            {
                return StatusCode(500, "Le commentaire est obligatoire");
            }

            Expense expense = new Expense
            {
                UserId = model.UserId,
                Date = model.Date,
                Amount = model.Amount,
                CurrencyId = model.CurrencyId,
                Comment = model.Comment
            };

            if (await _repoExpense.CreateAsync(expense))
            {
                return Ok(expense);
            }
            else
            {
                return StatusCode(500, "Error create expense");
            }
        }
    }
}
