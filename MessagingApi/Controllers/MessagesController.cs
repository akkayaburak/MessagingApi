using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MessagingApi.Entities;
using MessagingApi.Models;
using MessagingApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessagingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private IMapper _mapper;
        private IUserService _userService;
        private IMessageService _messageService;
        private IBlockService _blockService;
   
        public MessagesController(
            ILogger<MessagesController> logger,
            IMapper mapper,
            IUserService userService,
            IMessageService messageService,
            IBlockService blockService
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _messageService = messageService;
            _blockService = blockService;
        }

        [HttpPost("send")]
        public IActionResult Send([FromBody] MessageModel messageModel)
        {
            var senderUser = _userService.FindByUserName(messageModel.Username);
            var receiverUser = _userService.FindByUserName(messageModel.ReceiverUsername);
            if(receiverUser != null)
            {
                if (_blockService.IsBlocked(receiverUser.Id, senderUser.Id))
                {
                    _logger.LogInformation($"Sender user {0} is blocked by {1}", senderUser.Id, receiverUser.Id);
                    return BadRequest("Sender user is blocked.");
                }
                MessageSaveModel messageSaveModel = new MessageSaveModel(senderUser.Id, receiverUser.Id, messageModel.Context);
                var messageModelMapped = _mapper.Map<Message>(messageSaveModel);
                _messageService.Save(messageModelMapped);
            }
            else
            {
                _logger.LogError("Receiver user could not be found.");
                return BadRequest("Receiver user could not be found.");
            }
            
            return Ok(new
            {
                messageSent = messageModel.Context,
                from = messageModel.Username,
                to = messageModel.ReceiverUsername
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var messages = _messageService.GetMessagesBySenderId(id);
            _logger.LogInformation($"User : {0} message information requested.", messages.First().Sender.Username);
            List<MessageShowModel> msgs = new List<MessageShowModel>();
            foreach(var msg in messages)
            {
                msgs.Add(new MessageShowModel(msg.Context, msg.Sender.Username, msg.ReceiverId));
            }
            return Ok(msgs);
        }   
    }
}
