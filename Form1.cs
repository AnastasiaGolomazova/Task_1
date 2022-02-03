using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;



namespace Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache; 
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; 
            gMap.MinZoom = 2;
            gMap.MaxZoom = 16; 
            gMap.Zoom = 13; 
            gMap.Position = new GMap.NET.PointLatLng(56.50373683619619, 84.94823803271237);
            gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMap.CanDragMap = true; 
            gMap.DragButton = MouseButtons.Left; 
            gMap.Show(); 
            gMap.ShowTileGridLines = false; 
            gMap.Bearing = 0;
            gMap.CanDragMap = true;
            gMap.DragButton = MouseButtons.Left;
            gMap.GrayScaleMode = false;
            gMap.MarkersEnabled = true;
            gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;




        }
    }
}
