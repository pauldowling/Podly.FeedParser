﻿using System;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Podly.FeedParser.Tests.Extensions;

namespace Podly.FeedParser.Tests.SyndicationFeed.Valid
{
    [Ignore("Test runner can't use approval tests")]
    [TestFixture]
    public class AtomApprovalTest
    {
        protected IFeedFactory Factory;
        protected Uri feeduri;
        protected int itemCount;

        [SetUp]
        public void SetUp()
        {
            this.Factory = new FileSystemFeedFactory();
            feeduri = new Uri(TestFileLoader.LoadValidAtomTestCases(TestFileLoader.TestFileType.FileSys).Last().Arguments[0].ToString());
            itemCount = 3;
        }

        [UseReporter(typeof(DiffReporter))]
        [Test, Description("Uses approvals to determine if the output from the feed entry parsing is correct or not.")]
        public virtual void ApproveAtomFeedItemParse()
        {
            IFeed feed = Factory.CreateFeed(feeduri);
            var strFeedItems = from feeditem in feed.Items
                               select feeditem.ToApprovalString();
            Approvals.VerifyAll(strFeedItems, "feed items");
        }

        [UseReporter(typeof(DiffReporter))]
        [Test, Description("Uses approvals to determine if the GetItems function produces the correct amount of feed entries.")]
        public virtual void ApproveAtomFeedItemExplicitCountParse()
        {
            var feed = Factory.CreateFeed(feeduri);
            var strFeedItems = from feeditem in feed.Items.Take(itemCount)
                               select feeditem.ToApprovalString();
            Approvals.VerifyAll(strFeedItems, "feed items");
        }

    }
}
