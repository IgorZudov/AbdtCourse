using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfPractice.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfPractice.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AppDbContext context;

        public AccountsController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet("sql")]
        public async Task<ActionResult<List<Account>>> GetFromSql()
        { 
            var accounts = await context.Accounts
                .FromSqlRaw(@"select * from ""Accounts"" where ""Number"" ='string'")
                .ToListAsync();
            return Ok(accounts);
        }
        
        [HttpGet("query")]
        public async Task<ActionResult> GetLinq()
        { 
            var query = context
                    .Accounts
                    .Where(x => x.Number != "")
                    .Select(x => new
                    {
                        x.Currency,
                        x.Number
                    });
                
            var accounts = await query.ToListAsync();
            return Ok(accounts);
        }
        
        [HttpGet("function")]
        public async Task<ActionResult> GetFunction()
        { 
            var query = context
                .Accounts
                .Where(x => !string.IsNullOrEmpty(x.Number))
                //.Where(x => x.Currency.ToLower().StartsWith("ru"))
                .Where(x => EF.Functions.Like(x.Currency.ToLower(), "ru%"))
                .Select(x => new
                {
                    x.Currency,
                    x.Number
                });
                
            var accounts = await query.ToListAsync();
            return Ok(accounts);
        }
    }
}