using System;
using System.ComponentModel;

namespace ReactiveExtensions
{
    public class NotifyProprertyChangeObserver<T> : INotifyPropertyChanged, IObserver<T>
    {
        private T _value;
        public T Value
        {
            get => _value;
            private set
            {
                _value = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(T value)
        {
            Value = value;
        }
    }
}
