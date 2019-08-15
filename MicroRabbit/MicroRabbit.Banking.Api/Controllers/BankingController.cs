using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET api/banking
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }
        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            //stopwatch.Start();
            _accountService.Transfer(accountTransfer);
            //for (int i = 0; i < 1000000; i++)
            //{
            //    _accountService.Transfer(accountTransfer);
            //    if (i == 1000000)
            //    {
            //        accountTransfer.IsEndPublish = true;
            //    }
            //}
            //stopwatch.Stop();

            // Write result.
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            return Ok(accountTransfer);
        }

    }
}
