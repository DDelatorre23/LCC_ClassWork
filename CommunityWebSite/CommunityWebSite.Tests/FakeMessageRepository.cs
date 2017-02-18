using System;
using System.Collections.Generic;
using System.Linq;
using CommunityWebSite.Models;
using CommunityWebSite.Repository;

namespace CommunityWebSite.Tests {
    public class FakeMessageRepository : IMessage {

        List<Message> messages;
        public FakeMessageRepository() {

            messages = new List<Message>() {
            new Message {Subject = "Test Subject omicron", Body = "blah blah blah", Date = new DateTime(2017, 1, 1),
            Sender = new Member {FirstName = "John", LastName = "Doe", Email = "doej@gmail.com" },
            Topic = "Topic A"
            },
            new Message {Subject = "Test Subject alpha", Body = "blah blah blah", Date = new DateTime(2017, 1, 31),
            Sender = new Member {FirstName = "George", LastName = "Lucas", Email = "starwarsfan@gmail.com"},
            Topic = "Topic B"

            },
            new Message {Subject = "Test Subject beta", Body = "blah blah blah", Date = new DateTime(2017, 2, 10),
            Sender = new Member {FirstName = "Jane", LastName = "Dee", Email = "deej@gmail.com" },
            Topic = "Topic C"
            },
            new Message {Subject = "Test Subject omega", Body = "blah blah blah", Date = new DateTime(2016, 6, 5),
            Sender = new Member {FirstName = "John", LastName = "Doe", Email = "doej@gmail.com" },
            Topic = "Topic A"
            },
            new Message {Subject = "Test Subject sigma", Body = "blah blah blah", Date = new DateTime(2016, 4, 1),
            Sender = new Member {FirstName = "Jane", LastName = "Dee", Email = "deej@gmail.com" },
            Topic = "Topic B"
            },
            new Message {Subject = "Test Subject delta", Body = "blah blah blah", Date = new DateTime(2016, 12, 1),
            Sender = new Member {FirstName = "George", LastName = "Lucas", Email = "starwarsfan@gmail.com"},
            Topic = "Topic C"
            },
        };

        }

        public IEnumerable<Message> GetAllMessages()    {
            return messages;
        }

        public List<Message> GetMessagesByDateRange(DateTime start, DateTime end) {
            var list = messages.Where(d => d.Date >= start && d.Date <= end).ToList();
            return list;
        }

        public List<Message> GetMessagesByMember(Member member) {
            var list = messages.Where(m => m.Sender.LastName == member.LastName &&
                                            m.Sender.FirstName == member.FirstName).ToList();

            return list;
        }

        public List<Message> GetMessagesByTopic(string topic) {
            var list = messages.Where(m => m.Topic == topic).ToList();

            return list;
        }
    }
}
