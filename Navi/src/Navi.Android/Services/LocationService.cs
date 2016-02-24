using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Util;
using Android.Runtime;

namespace Navi.Android.Services
{
    [Service]
    public class LocationService : Service, ILocationListener
    {
        private double _mapLocationLongitude = 4.5458347;
        private double _mapLocationLatitude = 51.8716588;
        Location _currentLocation;
        LocationManager _locationManager;
        string _locationProvider;

        static readonly string TAG = "X:" + typeof(LocationService).Name;
        static readonly int TimerWait = 4000;
        Timer _timer;
        Timer _timerTwo;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug(TAG, "OnStartCommand called at {2}, flags={0}, startid={1}", flags, startId, DateTime.UtcNow);
            _timer = new Timer(o => { Log.Debug(TAG, "Hello from LocationService. {0}", DateTime.UtcNow); },
                               null,
                               0,
                               TimerWait);

            InitializeLocationManager();

            return StartCommandResult.NotSticky;
        }

        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
            };

            _locationProvider = _locationManager.GetBestProvider(criteriaForLocationService, true);

            if (_locationProvider != null)
            {
                _locationManager.RequestLocationUpdates(_locationProvider, 2000, 1, this);
            }
            else
            {
                Log.Info(TAG, "No location providers available");
            }

            _timerTwo = new Timer(o => { Log.Debug(TAG, "Using " + _locationProvider + "."); },
                               null,
                               0,
                               TimerWait);
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public async Task<bool> MapAvailable(double longitude1, double latitude1, double longitude2, double latitude2)
        {
            if (_currentLocation != null)
            {
                if (_mapLocationLatitude != null && _mapLocationLongitude != null)
                {
                    int eathRadius = 6371;
                    double dLat = ConvertToRadians(_currentLocation.Longitude - _mapLocationLongitude);
                    double dLon = ConvertToRadians(_currentLocation.Latitude - _mapLocationLatitude);

                    double sum = Math.Sin(dLat/2)*Math.Sin(dLat/2) +
                                 Math.Cos(ConvertToRadians(_currentLocation.Latitude)) *
                                 Math.Cos(ConvertToRadians(_mapLocationLatitude)) * 
                                 Math.Sin(dLon/2)*Math.Sin(dLon/2);

                    double c = 2 * Math.Asin(Math.Sqrt(sum));
                    double d = eathRadius * c;

                    if (d < 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }

        public async void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                _timerTwo = new Timer(o => { Log.Debug(TAG, "Unable to determine your location. Try again in a short while."); },
                               null,
                               0,
                               TimerWait);
            }
            else
            {
                bool availableMap = await MapAvailable(_currentLocation.Longitude, _currentLocation.Latitude, _mapLocationLongitude, _mapLocationLatitude);

                _timerTwo = new Timer(o => { Log.Debug(TAG, $"{_currentLocation.Latitude:f6},{_currentLocation.Longitude:f6}" + "Map is available:" + availableMap); },
                               null,
                               0,
                               TimerWait);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            _timer.Dispose();
            _timer = null;

            Log.Debug(TAG, "SimpleService destroyed at {0}.", DateTime.UtcNow);
        }

        public override IBinder OnBind(Intent intent)
        {
            // This example isn't of a bound service, so we just return NULL.
            return null;
        }
    }
}