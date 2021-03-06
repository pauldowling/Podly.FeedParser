﻿using NUnit.Framework;

namespace Podly.FeedParser.Tests.FeedFactory.Valid.FileSys
{
    [TestFixture, Description("Tests all of the BaseFeedFactory super class' functionality with RSS feeds by way of a FileFeedFactory instance.")]
    public class FileFeedFactoryTestsRss : BaseFeedFactoryTests<Rss20Feed>
    {

        public FileFeedFactoryTestsRss()
            : base(new FileSystemFeedFactory(), FeedType.Rss20, TestFileLoader.LoadValidRssTestCases(TestFileLoader.TestFileType.FileSys))
        {
        }
    }
}
