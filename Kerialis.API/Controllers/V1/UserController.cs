using Kerialis.Datas.DbContexts;
using Kerialis.Datas.Entities.V1;
using Kerialis.Repositories;
using Kerialis.Repositories.Factories;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;


namespace Kerialis.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User, int, KerialisContext> _repoUser;
        private readonly IRepository<Currency, int, KerialisContext> _repoCurrency;

        public UserController(IRepositoryFactory<KerialisContext> repo)
        {
            _repoUser = repo.Create<User, int>();
            _repoCurrency = repo.Create<Currency, int>();
        }
    }
}
