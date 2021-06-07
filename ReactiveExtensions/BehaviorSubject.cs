using ReactiveExtensions;
using System;
using System.Collections.Generic;

namespace ReactiveExtensions
{
    // Klasa reprezentuje Obserwowany obiekt.
    // Dla nowych subskrypcji zwraca ostatnią wartość 
    public class BehaviorSubject<T> : IObservable<T>
    {
        public T LastValue { get; private set; }

        private ICollection<Subscription<T>> observers;

        public BehaviorSubject(T Value)
        {
            LastValue = Value;
            observers = new List<Subscription<T>>();
        }


        public IDisposable Subscribe(IObserver<T> observer)
        {
            observer.OnNext(LastValue);
            var sub = new Subscription<T>(observers, observer);
            return sub;
        }

        public void Push(T Value)
        {
            foreach (Subscription<T> sub in observers)
            {
                sub.Item.OnNext(Value);
            }

            LastValue = Value;
        }

        public void Close()
        {
            foreach (Subscription<T> sub in observers)
            {
                sub.Item.OnCompleted();
                sub.Dispose();
            }
        }
    }
    

}
