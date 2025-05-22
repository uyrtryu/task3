using System.Threading.Tasks;

// Loader.cs
using ReactiveUI;
namespace DairyFarm.Models
{
    public class Loader : ReactiveObject
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            private set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        public async Task UnloadAsync(Warehouse warehouse)
        {
            IsBusy = true;
            await Task.Delay(2000);
            warehouse.ResetMilk();
            IsBusy = false;
        }
    }
}
