using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace IntSequence
{
    class IntEnumerator : IEnumerator<int>
    {
        private int curr;

        public IntEnumerator(int start)
        {
            this.curr = start-1;
        }

        public int Current
        {
            get
            {
                return curr;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            curr++;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class IntSequence : IEnumerable<int>
    {
        private int start;
        public IntSequence(int start)
        {
            this.start = start;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new IntEnumerator(start);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


    class Program
    {
        public static IEnumerable<int> MakeIntSequence(int start)
        {
            return new IntSequence(start);
        }

        static void Main(string[] args)
        {
            IEnumerable<int> seq = MakeIntSequence(10);
            foreach(int v in seq)
            {
                Console.WriteLine(v);
                Thread.Sleep(1000);
            }
        }
    }
}
