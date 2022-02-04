using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Task_1
{
    public partial class Form1 : Form
    {
        private LocationDB dataBase = new LocationDB();
        public Form1()
        {
              InitializeComponent();
        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache; 
            gMap.MapProvider = GoogleMapProvider.Instance; 
            gMap.MinZoom = 2;
            gMap.MaxZoom = 16; 
            gMap.Zoom = 13; 
            gMap.Position = new PointLatLng(56.50373683619619, 84.94823803271237);
            gMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gMap.CanDragMap = true;  
            gMap.Show(); 
            gMap.ShowTileGridLines = false; 
            gMap.Bearing = 0;
            gMap.CanDragMap = true;
            gMap.DragButton = MouseButtons.Left;
            gMap.GrayScaleMode = false;
            gMap.MarkersEnabled = true;
            gMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            mouseIsDown = false;
            IsMarkerEnter = false;
            currentMarker = null;

            dataBase.OpenBbConnection();

            if (!dataBase.IsConnectionOpen())
            {
                MessageBox.Show("Connection error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var units = dataBase.GetAll();
            var markers = CreateMarkers(units);

            gMap.Overlays.Add(markers);
        }

        private GMapOverlay CreateMarkers(List<DBUnit> units)
        {
            GMapOverlay overlay = new GMapOverlay("markers");

            foreach (var unit in units)
            {
                PointLatLng point = new PointLatLng(unit.Longitude, unit.Latitude);
                GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red)
                {
                    ToolTipText = unit.Name,
                    Tag = unit.ID
                };

                overlay.Markers.Add(marker);
            }

            return overlay;
        }

        private void GMap_OnMarkerEnter(GMapMarker marker)
        {
            if (currentMarker == null)
            {
                currentMarker = Convert.ToInt32(marker.Tag);
                IsMarkerEnter = true;
            }
        }

        private void GMap_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            mouseDownPoint = new Point(e.Location.X, e.Location.Y);
        }

        private void GMap_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            if (currentMarker != null)
            {
                var marker = GetMarkerById(currentMarker);
                int id = int.Parse($"{marker.Tag}");
                dataBase.ChangePosition(id, marker.Position.Lat, marker.Position.Lng);
                currentMarker = null;
            }
        }

        private void GMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMarkerEnter && mouseIsDown)
            {
                var marker = GetMarkerById(currentMarker);

                if (marker != null)
                {
                    var point = gMap.FromLocalToLatLng(e.Location.X, e.Location.Y);
                    marker.Position = new PointLatLng(point.Lat, point.Lng);
                }
            }
        }

        private GMapMarker GetMarkerById(int? id)
        {
            return gMap
                    .Overlays
                    .FirstOrDefault(x => x.Id == "markers")
                    .Markers
                    .FirstOrDefault(m => Convert.ToInt32(m.Tag) == id);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataBase.CloseBdConnection();
        }
    }
}
