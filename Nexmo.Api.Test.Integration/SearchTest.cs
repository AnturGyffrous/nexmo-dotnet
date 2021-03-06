﻿using System.Net;
using NUnit.Framework;

namespace Nexmo.Api.Test.Integration
{
    [TestFixture]
    public class SearchTest
    {
        [Test]
        public void should_get_message()
        {
            var msg = Search.GetMessage("03000000FFFFFFFF");
            Assert.AreEqual("03000000FFFFFFFF", msg.messageId);
            Assert.AreEqual("17775551212", msg.from);
            Assert.AreEqual("2015-12-31 14:08:40", msg.dateReceived);
        }

        [Test]
        public void should_get_messages()
        {
            var msgs = Search.GetMessages(new Search.SearchRequest
            {
                date = "2015-12-31",
                to = "17775551212"
            });

            Assert.AreEqual(1, msgs.count);
        }

        [Test]
        public void should_get_rejections()
        {
            var msgs = Search.GetRejections(new Search.SearchRequest
            {
                date = "2015-12-31",
                to = "17775551212"
            });

            Assert.AreEqual(1, msgs.count);
        }
    }
}