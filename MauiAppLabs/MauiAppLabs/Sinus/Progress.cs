using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppLabs.Sinus
{
    internal class Progress : IProgress<int>
    {
        public event Action<int> progress;
        public void Report(int value) => progress?.Invoke(value);
    }
}
