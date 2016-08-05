using System;
using CoreLocation;
using MapKit;
using TrabbleCrossPlatformExperiment.iOS;
using UIKit;

namespace XamarinMapExample.iOS
{
    public partial class ViewController : UIViewController
    {

        MKMapView mapView;
        private CLLocationCoordinate2D coords;
        private const int radius = 5;
        private CLLocationManager locationManager;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            setUpView();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void setUpView()
        {
            mapView = new MKMapView(View.Bounds);
            mapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
            View.AddSubview(mapView);

            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            locationManager.StartUpdatingLocation();

            mapView.UserTrackingMode = MKUserTrackingMode.None;
            mapView.ShowsUserLocation = true;
              
            coords = new CLLocationCoordinate2D(locationManager.Location.Coordinate.Latitude,locationManager.Location.Coordinate.Longitude);
            var annotation = new BasicMapAnnotation(coords, "Current Location", null);
            mapView.AddAnnotation(annotation);


            var span = new MKCoordinateSpan(annotation.KilometresToLatitudeDegrees(radius), annotation.KilometresToLongitudeDegrees(radius, coords.Latitude));
            mapView.Region = new MKCoordinateRegion(coords, span);

        }
    }
}

