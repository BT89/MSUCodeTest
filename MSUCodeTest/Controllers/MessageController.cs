using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSUCodeTest.Data;
using MSUCodeTest.Models;
using MSUCodeTest.Models.Entities;
using System.Linq;

namespace MSUCodeTest.Controllers
{
    public class MessageController : Controller
    {
        public ApplicationDBContext DbContext { get; }

        public MessageController(ApplicationDBContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageViewModel viewModel)
        {
            if (viewModel == null || string.IsNullOrEmpty(viewModel.MessageContent)) { return View(); }
            Message message = new Message { MessageContent= viewModel.MessageContent, MessageDateTime = DateTime.Now };
            await DbContext.messages.AddAsync(message);
            await DbContext.SaveChangesAsync();

            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public async Task<IActionResult> MessageList()
        {
            var messages = await DbContext.messages.ToListAsync<Message>();

            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> ViewMessage(Guid Id)
        {
            var message = await DbContext.messages.FindAsync(Id);

            return View(message);
        }
    }
}
