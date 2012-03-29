using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Infrastructure;
using NHibernate;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class VisitorRepositoryTester
    {
        [SetUp]
        public void Setup()
        {
            new DatabaseTester().CreateDatabaseSchema();
            DataConfig.EnsureStartup();
        }

        [Test]
        public void When_saving_should_write_to_database()
        {
            var visitor = new Visitor
                {
                    Browser = "1",
                    IpAddress = "2",
                    LoginName = "3",
                    PathAndQuerystring = "4",
                    VisitDate =
                        new DateTime(2000, 1, 1)
                };

            var repository = new VisitorRepository();
            repository.Save(visitor);

            Visitor loadedVisitor;
            using (ISession session = DataConfig.GetSession())
            {
                loadedVisitor = session.Load<Visitor>(
                    visitor.Id);
            }

            Assert.That(loadedVisitor, Is.Not.Null);
            Assert.That(loadedVisitor.Browser, 
                Is.EqualTo("1"));
            Assert.That(loadedVisitor.IpAddress, 
                Is.EqualTo("2"));
            Assert.That(loadedVisitor.LoginName, 
                Is.EqualTo("3"));
            Assert.That(loadedVisitor.PathAndQuerystring,
                Is.EqualTo("4"));
            Assert.That(loadedVisitor.VisitDate,
                Is.EqualTo(new DateTime(2000, 1, 1)));
        }

        [Test]
        public void Should_get_two_most_recent_visitors()
        {
            Visitor visitor1 =
                CreateVisitor(new DateTime(2000, 1, 1));
            Visitor visitor2 =
                CreateVisitor(new DateTime(2000, 1, 2));
            Visitor visitor3 =
                CreateVisitor(new DateTime(2000, 1, 3));
            using (ISession session1 = DataConfig.GetSession())
            {
                session1.BeginTransaction();
                session1.SaveOrUpdate(visitor1);
                session1.SaveOrUpdate(visitor2);
                session1.SaveOrUpdate(visitor3);
                session1.Transaction.Commit();
            }

            var repository = new VisitorRepository();
            Visitor[] recentVisitors =
                repository.GetRecentVisitors(2);

            Assert.That(recentVisitors.Length, 
                Is.EqualTo(2));
            IEnumerable<Guid> idList =
                recentVisitors.Select(x => x.Id);
            Assert.That(idList.Contains(visitor3.Id), 
                Is.True);
            Assert.That(idList.Contains(visitor2.Id), 
                Is.True);
            Assert.That(idList.Contains(visitor1.Id), 
                Is.False);
        }

        private Visitor CreateVisitor(DateTime visitDate)
        {
            return new Visitor
                       {
                           Browser = "1",
                           IpAddress = "2",
                           LoginName = "3",
                           PathAndQuerystring = "4",
                           VisitDate = visitDate
                       };
        }
    }
}