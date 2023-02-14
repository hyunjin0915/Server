using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class MemoryBarrierEx
    {
        int _answer;
        bool _complete;

        void A()
        {
            //연속적으로 store -> 둘다 memorybarrier를 해줘야 확실하게 해줄 수 있음
            _answer = 123;
            Thread.MemoryBarrier(); // Barrier 1
            _complete = true;
            Thread.MemoryBarrier();// Barrier 2
        }

        void B()
        {
            Thread.MemoryBarrier();// Barrier 3
            if (_complete)
            {
                Thread.MemoryBarrier();// Barrier 4
                Console.WriteLine(_answer);
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
