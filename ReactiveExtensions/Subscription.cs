using System;
using System.Collections.Generic;

namespace ReactiveExtensions
{
    // Opakowuje iserwatora w subskrybcje z interfejsem IDisposable
    public class Subscription<T> : IDisposable
    {
        private ICollection<Subscription<T>> _parent;
        public readonly IObserver<T> Item;

        // Konstruktor dodaje do kolekcji obserwatora
        public Subscription(ICollection<Subscription<T>> Parent, IObserver<T> Item)
        {
            _parent = Parent;
            _parent.Add(this);
            this.Item = Item;
        }

        // Dispose usuwa obserwatora z kolekcji, wywołuje jego metodę OnCompleted
        // oraz jeśli implementuje i metodę Disopse
        public void Dispose()
        {
            _parent.Remove(this);
            Item.OnCompleted();
            if (Item is IDisposable)
            {
                (Item as IDisposable).Dispose();
            }
        }
    }
}
