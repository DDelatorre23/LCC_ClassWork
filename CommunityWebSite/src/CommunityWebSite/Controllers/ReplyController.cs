﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebSite.Models.ViewModels;
using CommunityWebSite.Models;
using CommunityWebSite.Repository;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityWebSite.Controllers
{
    public class ReplyController : Controller
    {
        IMessage repository;
        
        public ReplyController (IMessage repo) {
            repository = repo;
        }   


        [HttpGet]
        public IActionResult ReplyForm(string subject, int id)
        {
            var replyVM = new ReplyViewModel();
            replyVM.MessageID = id;
            replyVM.Subject = subject;
            replyVM.MessageReply = new Models.Reply();

            return View(replyVM);
        }

        [HttpPost]
        public IActionResult ReplyForm(int id, string body) {

            Message message = repository.GetAllMessages().Where(m =>
            m.MessageID == id).FirstOrDefault();

            message.MessageReplies.Add(new Reply { Body = body, DateCreated = DateTime.Today });

            repository.Update(message);

            return RedirectToAction("Index", "Message");
        }
    }

}