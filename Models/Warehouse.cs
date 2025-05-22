using System;
using ReactiveUI;

namespace DairyFarm.Models
{
    public class Warehouse : ReactiveObject
    {
        private int _currentMilk;
        private readonly int _maxCapacity; //// Максимальная вместимость

        public event Action WarehouseFull;

        public int CurrentMilk
        {
            get => _currentMilk;
            private set => this.RaiseAndSetIfChanged(ref _currentMilk, value);
        }

        public int MaxCapacity => _maxCapacity;

        public Warehouse(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        public void AddMilk(int amount)
        {
            CurrentMilk += amount;
            if (CurrentMilk >= MaxCapacity)
                WarehouseFull?.Invoke();
        }

        public void ResetMilk()
        {
            CurrentMilk = 0;
        }
    }
}
