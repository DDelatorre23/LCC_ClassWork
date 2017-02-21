using System;
using System.Collections.Generic;
using System.Linq;
using CommunityWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebSite.Repository {
    public class MessageRepository : IMessage {

        public ApplicationDbContext context;
        public MessageRepository (ApplicationDbContext ctx){

            context = ctx;
        }

        public IEnumerable<Message> GetAllMessages() {

            return context.Messages.Include(m => m.Sender);
        }

        public List<Message> GetMessagesByDateRange(DateTime start, DateTime end) {
            var list = context.Messages.Include(m => m.Sender)
                .Where(d => d.Date >= start && d.Date <= end).ToList();
            return list;
        }

        public List<Message> GetMessagesByMember(int memberID) {
            var list = context.Messages.Include(m => m.Sender)
                .Where(m => m.Sender.MemberID == memberID).Include(m => m.Sender).ToList();

            return list;
        }

        public List<Message> GetMessagesByTopic(string topic) {
            var list = context.Messages.Include(m => m.Sender)
                .Where(m => m.Topic == topic).ToList();

            return list;
        }
    }
}
