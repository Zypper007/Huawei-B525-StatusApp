using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace ReactiveExtensions
{
    public class ConsoleLogObserver<T> : IObserver<T> 
    {
        private string id;
        public ConsoleLogObserver()
        {
            var byteHash = BitConverter.GetBytes(GetHashCode());
            id = BitConverter.ToString(byteHash);
        }
        public void OnCompleted()
        {
            var byteHash = BitConverter.GetBytes(GetHashCode());
            Console.WriteLine("OnCompleted " + id);
        }
        public void OnError(Exception error)
        {
            Console.WriteLine("OnError " + id);
            Console.WriteLine(error.Message);

        }

            public void OnNext(T value)
        {
            Console.WriteLine("OnNext " + id);
            Console.WriteLine(value.ToString());
        }
    }
}
