﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace connectPython.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoController : ControllerBase
    {
        [HttpGet]
        public async Task<int> DoSomething(int x)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync($"http://127.0.0.1:5000/do?x={x}");

                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");
                    }
                    else
                    {
                        Console.Write("Failure");
                    }

                    return int.Parse(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
