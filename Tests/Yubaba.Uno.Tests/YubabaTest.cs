using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Yubaba.Uno.Services;
using Yubaba.Uno.Services.Impl;

namespace Yubaba.Uno.Tests
{
    public class YubabaTest
    {
        private Mock<IRandom> MockRandom { get; }
        private Services.Impl.Yubaba Target { get; }
        public YubabaTest()
        {
            MockRandom = new Mock<IRandom>();
            Target = new Services.Impl.Yubaba(MockRandom.Object);
        }

        [Fact]
        public void InitialStatus()
        {
            Assert.Empty(Target.Messages);
        }

        [Fact]
        public async Task IntroductionMessages()
        {
            await Target.RequestIntroductionAsync();
            Assert.Collection(Target.Messages, 
                act => Assert.Equal("契約書だよ。", act.Value),
                act => Assert.Equal("そこに名前を書きな。", act.Value));
        }

        [Fact]
        public async Task CommonName()
        {
            MockRandom.Setup(x => x.Next(2)).Returns(0).Verifiable();
            await Target.RequestIntroductionAsync();
            await Target.SubmitContractAsync(new ContractPaper("一希"));
            Assert.Collection(Target.Messages,
                act => Assert.Equal("フン。", act.Value),
                act => Assert.Equal("一希というのかい。", act.Value),
                act => Assert.Equal("贅沢な名だねぇ。", act.Value),
                act => Assert.Equal("今からお前の名前は一だ。", act.Value),
                act => Assert.Equal("いいかい、一だよ。", act.Value),
                act => Assert.Equal("分かったら返事をするんだ、一!!", act.Value));
            MockRandom.VerifyAll();
        }

        [Fact]
        public async Task SurrogatePairName()
        {
            MockRandom.Setup(x => x.Next(2)).Returns(0).Verifiable();
            await Target.RequestIntroductionAsync();
            await Target.SubmitContractAsync(new ContractPaper("𠮷田"));
            Assert.Collection(Target.Messages,
                act => Assert.Equal("フン。", act.Value),
                act => Assert.Equal("𠮷田というのかい。", act.Value),
                act => Assert.Equal("贅沢な名だねぇ。", act.Value),
                act => Assert.Equal("今からお前の名前は𠮷だ。", act.Value),
                act => Assert.Equal("いいかい、𠮷だよ。", act.Value),
                act => Assert.Equal("分かったら返事をするんだ、𠮷!!", act.Value));
            MockRandom.VerifyAll();
        }

        [Fact]
        public async Task KillYubabaUsingNull()
        {
            MockRandom.Setup(x => x.Next(2)).Returns(0).Verifiable();
            await Target.RequestIntroductionAsync();
            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await Target.SubmitContractAsync(new ContractPaper(null)));
        }

        [Fact]
        public async Task KillYubabaUsingEmpty()
        {
            MockRandom.Setup(x => x.Next(2)).Returns(0).Verifiable();
            await Target.RequestIntroductionAsync();
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                async () => await Target.SubmitContractAsync(new ContractPaper("")));
        }
    }
}
