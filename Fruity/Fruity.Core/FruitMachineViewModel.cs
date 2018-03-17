using System;
using GorgleDevs.Wpf.Mvvm;

namespace Fruity.Core
{
	public class FruitMachineViewModel : ViewModel
	{
		private Random _rng;
		private ReelValue[] _reels;
		private int _credits;

		public FruitMachineViewModel(int startingCredits)
		{
			_reels = new ReelValue[3];
			_rng = new Random();
			_credits = startingCredits;
		}

		public ReelValue Reel1 => _reels[0];

		public ReelValue Reel2 => _reels[1];

		public ReelValue Reel3 => _reels[2];

		public int Credits => _credits;

		public bool CanPlay => _credits > 0;

		public DelegateCommand SpinCommand => new DelegateCommand(Spin);

		public void InsertCoin()
		{
			_credits++;
			RaisePropertyChanged(nameof(Credits));
			if(_credits == 1)
				RaisePropertyChanged(nameof(CanPlay));
		}
		
		public void Spin()
		{
			if (CanPlay)
			{
				_credits--;
				for (int i = 0; i < 3; i++)
				{
					_reels[i] = (ReelValue)_rng.Next(5);
				}

				RaisePropertyChanged(nameof(Reel1));
				RaisePropertyChanged(nameof(Reel2));
				RaisePropertyChanged(nameof(Reel3));
				RaisePropertyChanged(nameof(Credits));

				if (_credits == 0)
					RaisePropertyChanged(nameof(CanPlay));
			}
		}
	}
}
