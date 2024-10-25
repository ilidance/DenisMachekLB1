using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private static List<Message> messages = new List<Message>();

    // Отримати всі повідомлення 
    [HttpGet]
    public IEnumerable<Message> Get()
    {
        return messages;
    }

    // Отримати нове повідомлення
    [HttpPost]
    public IActionResult Post([FromBody] Message message)
    {
        message.Id = messages.Count + 1;
        message.Timestamp = DateTime.Now;
        messages.Add(message);
        return Ok(message);
    }

    // Отримання повідомлень для конкретного користувача
    [HttpGet("{receiver}")]
    public IEnumerable<Message> GetMessagesForUser(string receiver)
    {
        return messages.Where(m => m.Receiver == receiver);
    }
}
