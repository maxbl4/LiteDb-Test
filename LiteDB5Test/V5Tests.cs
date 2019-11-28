using System;
using System.IO;
using LiteDB;
using Xunit;

namespace LiteDB5Test
{
    public class V5Tests
    {
        [Fact]
        public void String()
        {
            using var repo = new LiteRepository(nameof(String));
            repo.Insert(new RecordString());
            Assert.Equal("Some", repo.Query<RecordString>().OrderByDescending(x => x.Id).First().String);
        }
        
        [Fact]
        public void Int()
        {
            using var repo = new LiteRepository(nameof(Int));
            repo.Insert(new RecordInt());
            Assert.Equal(5, repo.Query<RecordInt>().OrderByDescending(x => x.Id).First().Int);
        }
        
        [Fact]
        public void Double()
        {
            var r = new Random();
            using var repo = new LiteRepository(nameof(Double));
            repo.Insert(new RecordDouble());
            Assert.Equal(5.5d, repo.Query<RecordDouble>().OrderByDescending(x => x.Id).First().Double);
        }
        
        [Fact]
        public void Float()
        {
            using var repo = new LiteRepository(nameof(Float));
            repo.Insert(new RecordFloat());
            Assert.Equal(6.6f, repo.Query<RecordFloat>().OrderByDescending(x => x.Id).First().Float, 1);
        }
        [Fact]
        public void Decimal()
        {
            using var repo = new LiteRepository(nameof(Decimal));
            repo.Insert(new RecordDecimal());
            Assert.Equal(7.7m, repo.Query<RecordDecimal>().OrderByDescending(x => x.Id).First().Decimal);
        }
    }

    public class RecordString
    {
        public long Id { get; set; }
        public string String { get; set; } = "Some";
    }
    
    public class RecordInt
    {
        public long Id { get; set; }
        public int Int { get; set; } = 5;
    }
    
    public class RecordDouble
    {
        public long Id { get; set; }
        public double Double { get; set; } = 5.5;
    }
    
    public class RecordFloat
    {
        public long Id { get; set; }
        public float Float { get; set; } = 6.6f;
    }
    
    public class RecordDecimal
    {
        public long Id { get; set; }
        public decimal Decimal { get; set; } = 7.7m;
    }
}