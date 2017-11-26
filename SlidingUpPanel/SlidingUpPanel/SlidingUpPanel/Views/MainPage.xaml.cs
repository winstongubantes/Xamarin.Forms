using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlidingUpPanel.Views
{
	public partial class MainPage : ContentPage
	{
	    private static readonly CompositeDisposable EventSubscriptions = new CompositeDisposable();
	    private readonly PanGestureRecognizer _panGesture = new PanGestureRecognizer();
	    private double _transY;

        public MainPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        InitializeObservables();
	        CollapseAllMenus();
	    }

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();
	        EventSubscriptions.Clear();
        }

	    private void CollapseAllMenus()
        {
            Task.Factory.StartNew(async () =>
            {
                await Task.Delay(200);
                Device.BeginInvokeOnMainThread(() =>
                {
                    Notification.HeightRequest = this.Height - QuickMenuLayout.Height;
                    QuickMenuPullLayout.TranslationY = Notification.HeightRequest;
                });
            });
        }

        private void InitializeObservables()
        {
            //IF THERE IS OBSERVABLES
            var panGestureObservable = Observable
                .FromEventPattern<PanUpdatedEventArgs>(
                    x => _panGesture.PanUpdated += x,
                    x => _panGesture.PanUpdated -= x
                )
                //.Throttle(TimeSpan.FromMilliseconds(20), TaskPoolScheduler.Default)
                .Subscribe(x => Device.BeginInvokeOnMainThread(() => { CheckQuickMenuPullOutGesture(x); }));

            EventSubscriptions.Add(panGestureObservable);
            QuickMenuInnerLayout.GestureRecognizers.Add(_panGesture);
        }

	    private void CheckQuickMenuPullOutGesture(EventPattern<PanUpdatedEventArgs> x)
	    {
	        var e = x.EventArgs;
	        var typeOfAction = x.Sender as StackLayout;

	        switch (e.StatusType)
	        {
	            case GestureStatus.Running:
	                MethodLockedSync(() =>
	                {
	                    Device.BeginInvokeOnMainThread(() =>
	                    {
	                        QuickMenuPullLayout.TranslationY = Math.Max(0,
	                            Math.Min(Notification.HeightRequest, QuickMenuPullLayout.TranslationY + e.TotalY));
	                    });
	                }, 2);

	                break;

	            case GestureStatus.Completed:
	                // Store the translation applied during the pan
	                _transY = QuickMenuPullLayout.TranslationY;
	                break;
	            case GestureStatus.Canceled:
	                Debug.WriteLine("Canceled");
	                break;
	        }
	    }

	    private CancellationTokenSource _throttleCts = new CancellationTokenSource();
	    private void MethodLockedSync(Action method, double timeDelay = 500)
	    {
	        Interlocked.Exchange(ref _throttleCts, new CancellationTokenSource()).Cancel();
	        Task.Delay(TimeSpan.FromMilliseconds(timeDelay), _throttleCts.Token) // throttle time
	            .ContinueWith(
	                delegate { method(); },
	                CancellationToken.None,
	                TaskContinuationOptions.OnlyOnRanToCompletion,
	                TaskScheduler.FromCurrentSynchronizationContext());
	    }
    }
}