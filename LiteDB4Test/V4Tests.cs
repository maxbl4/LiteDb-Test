using System;
using LiteDB;
using Xunit;

namespace LiteDB4Test
{
    public class V4Tests
    {
        [Fact]
        public void String()
        {
            using var repo = new LiteRepository(nameof(String));
            repo.Insert(new RecordString());
            Assert.Equal("Some", repo.Query<RecordString>().First().String);
        }
        
        [Fact]
        public void Int()
        {
            using var repo = new LiteRepository(nameof(Int));
            repo.Insert(new RecordInt());
            Assert.Equal(5, repo.Query<RecordInt>().First().Int);
        }
        
        [Fact]
        public void Double()
        {
            using var repo = new LiteRepository(nameof(Double));
            repo.Insert(new RecordDouble());
            Assert.Equal(5.5, repo.Query<RecordDouble>().First().Double, 1);
        }
        
        [Fact]
        public void Float()
        {
            using var repo = new LiteRepository(nameof(Float));
            repo.Insert(new RecordFloat());
            Assert.Equal(6.6f, repo.Query<RecordFloat>().First().Float, 1);
        }
        [Fact]
        public void Decimal()
        {
            using var repo = new LiteRepository(nameof(Decimal));
            repo.Insert(new RecordDecimal());
            Assert.Equal(7.7m, repo.Query<RecordDecimal>().First().Decimal);
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