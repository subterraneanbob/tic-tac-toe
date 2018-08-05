using System;
using UnbeatableTicTacToe.Common.Utils;
using Xunit;

namespace UnbeatableTicTacToe.Tests
{
    public class RequireTests
    {
        [Fact]
        public void NotEmptyTest()
        {
            Require.NotEmpty("TEST");

            Assert.Throws<ArgumentException>(() => Require.NotEmpty(null));
            Assert.Throws<ArgumentException>(() => Require.NotEmpty(""));
        }

        [Fact]
        public void EqualTest()
        {
            Require.Equal(1, 1);

            Assert.Throws<ArgumentException>(() => Require.Equal(1, 2));

            var obj1 = new object();
            var obj2 = new object();
            Assert.Throws<ArgumentException>(() => Require.Equal(obj1, obj2));
        }

        [Fact]
        public void NotEqualTest()
        {
            Require.NotEqual(1, 2);

            Assert.Throws<ArgumentException>(() => Require.NotEqual(1, 1));

            var obj = new object();
            Assert.Throws<ArgumentException>(() => Require.NotEqual(obj, obj));
        }

        [Fact]
        public void InRangeTest()
        {
            Require.InRange(1, 0, 2);

            Assert.ThrowsAny<ArgumentException>(() => Require.InRange(0, 1, 2));
            Assert.ThrowsAny<ArgumentException>(() => Require.InRange(3, 1, 2));
        }
    }
}
