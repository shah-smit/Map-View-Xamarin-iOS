using System;
using CoreLocation;
using MapKit;

namespace TrabbleCrossPlatformExperiment.iOS
{
    class BasicMapAnnotation : MKAnnotation
    {

        CLLocationCoordinate2D coord;
        string title, subtitle;

        public override CLLocationCoordinate2D Coordinate { get { return coord; } }
        public override void SetCoordinate(CLLocationCoordinate2D value)
        {
            coord = value;
        }
        public override string Title { get { return title; } }
        public override string Subtitle { get { return subtitle; } }
        public BasicMapAnnotation(CLLocationCoordinate2D coordinate, string title, string subtitle)
        {
            this.coord = coordinate;
            this.title = title;
            this.subtitle = subtitle;
        }

        public double KilometresToLatitudeDegrees(double kms)
        {
            double earthRadius = 6371.0; // in kms
            double radiansToDegrees = 180.0 / Math.PI;
            return (kms / earthRadius) * radiansToDegrees;
        }

        public double KilometresToLongitudeDegrees(double kms, double atLatitude)
        {
            double earthRadius = 6371.0; // in kms
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;
            // derive the earth's radius at that point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (kms / radiusAtLatitude) * radiansToDegrees;
        }
    }
}

