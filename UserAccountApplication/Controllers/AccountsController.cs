using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAccountApplication.Data;
using UserAccountApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAccountApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly ApiDbContext _dbContext;

    public AccountsController(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/<AccountsController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _dbContext.Accounts.ToListAsync());
    }

    // GET api/<AccountsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _dbContext.Accounts.FindAsync(id));
    }

    // POST api/<AccountsController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Account account)
    {
        await _dbContext.Accounts.AddAsync(account);
        await _dbContext.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<AccountsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Account updatedAccount)
    {
        var account = await _dbContext.Accounts.FindAsync(id);
        if (account == null) return NotFound("No account with this id was found");

        account.Name = updatedAccount.Name;
        account.Email = updatedAccount.Email;
        await _dbContext.SaveChangesAsync();
        return Ok("Account details updated successfully");
    }

    // DELETE api/<AccountsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var account = await _dbContext.Accounts.FindAsync(id);
        if (account == null) return NotFound("No account with this if was found.");

        _dbContext.Remove(account);
        await _dbContext.SaveChangesAsync();
        return Ok("Account deleted");
    }
}
