using System;
using System.ComponentModel;

namespace ReactiveExtensions
{
    class NotifyProprertyChangeObserver<T> : INotifyPropertyChanged, IObserver<T>
    {
        private T _value;
        public T Value
        {
            get => _value;
            set
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
