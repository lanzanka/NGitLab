using System;
using Xunit;

namespace NGitLab.Tests
{
    public class Sha1Tests
    {
        [Fact]
        public void WhenNull_ThenThrowException()
        {
            const string value = null;
            Assert.Throws<ArgumentNullException>(() => { new Sha1(value); });
        }

        [Fact]
        public void WhenSha1WithLowerCase_ThenParsedCorrectly()
        {
            const string value = "2695effb5807a22ff3d138d593fd856244e155e7";
            Assert.Equal(value.ToUpper(), new Sha1(value).ToString().ToUpper());
        }

        [Fact]
        public void WhenSha1WithLeadingZero_ThenParsedCorrectly()
        {
            const string value = "59529D73E3E6E2B7015F05D197E12C43B13BA033";
            Assert.Equal(value.ToUpper(), new Sha1(value).ToString().ToUpper());
        }

        [Fact]
        public void WhenSha1WithUpperCase_ThenParsedCorrectly()
        {
            const string value = "2695EFFB5807A22FF3D138D593FD856244E155E7";
            Assert.Equal(value, new Sha1(value).ToString().ToUpper());
        }

        [Fact]
        public void WhenNotEnoughtChars_ThenErrorThrown()
        {
            const string value = "2695EFFB5807A22FF3D138D593FD856244";
            Assert.Throws<ArgumentException>(() => { new Sha1(value); });
        }

        [Fact]
        public void WhenToManyChars_ThenErrorThrown()
        {
            const string value = "2695EFFB5807A22FF3D138D593FD856244234234234324";
            Assert.Throws<ArgumentException>(() => { new Sha1(value); });
        }
    }
}