using System;
using System.Collections.Generic;
using System.Text;

namespace Yubaba.Uno.Services.Impl
{
    public interface IRandom
    {
        int Next(int max);
    }

    public class DefaultRandom : IRandom
    {
        private Random Random { get; } = new Random();
        public int Next(int max) => Random.Next(max);
    }
}
