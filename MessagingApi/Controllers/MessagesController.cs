using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MessagingApi.Entities;
using MessagingApi.Models;
using MessagingApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessagingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class MessagesController : ControllerBase
    {
        private ITokenService _tokenService;
        private readonly ILogger<MessagesController> _logger;
        private IMapper _mapper;
        private IUserService _userService;
        private IMessageService _messageService;
        public MessagesController(
            ITokenService tokenService,
            ILogger<MessagesController> logger,
            IMapper mapper,
            IUserService userService,
            IMessageService messageService
            )
        {
            _tokenService = tokenService;
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _messageService = messageService;
        }

        [HttpPost("send")]
        public IActionResult Send([FromBody] MessageModel messageModel)
        {
            var isAuthenticated = _tokenService.IsAuthenticated(messageModel.Token);
            if (isAuthenticated == null)
            {
                return BadRequest("Sender is not Authenticated");
            }
            var receiverUser = _userService.FindByUserName(messageModel.ReceiverUsername);
            if(receiverUser != null)
            {
                MessageSaveModel messageSaveModel = new MessageSaveModel(isAuthenticated.UserId, receiverUser.Id, messageModel.Context);
                var messageModelMapped = _mapper.Map<Message>(messageSaveModel);
                _messageService.Save(messageModelMapped);
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
            return Ok(messages);
        }
    }
}
