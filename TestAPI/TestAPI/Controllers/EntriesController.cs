using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Services;
using WebApi.Controllers;

namespace TestAPI.Controllers;

public class EntriesController : BaseController
{
    private APIContext db { get; set; }
    private IAccountService _accountService { get; set; }

    public EntriesController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    
    [Route("entries")]
    [HttpPost]
    public string Post(EntriesRequest request)
    {
        _accountService.Entries(request, "https://localhost:7283", User.Id);
        

        return "Eintrag erfolgreich";
    }
}
