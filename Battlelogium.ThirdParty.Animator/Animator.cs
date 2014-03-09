//<copyright>
//All contents in namespace Battlelogium.ThirdParty.Animator
//Copyright 2013 Jawahar Suresh Babu
//Project page http://www.codeproject.com/Tips/588253/GIF-Animation-in-WPF
//Licensed under CodeProject Open License (http://www.codeproject.com/info/cpol10.aspx)
//</copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Battlelogium.ThirdParty.Animator
{
    public class Animator : Control
    {
        private Image _image;

        private DispatcherTimer _timer;

        private Canvas _border;

        private int _Hcount = 0;

        private int _Vcount = 0;

        private int _maxHpieces;

        private int _maxVpieces;

        static Animator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Animator), new FrameworkPropertyMetadata(typeof(Animator)));
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(Animator), new PropertyMetadata(null));



        public double HorizontalOffset
        {
            get { return (double)GetValue(HorizontalOffsetProperty); }
            set { SetValue(HorizontalOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HoizontalOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalOffsetProperty =
            DependencyProperty.Register("HorizontalOffset", typeof(double), typeof(Animator), new PropertyMetadata(0.0, OnUpdate));




        public double VerticalOffset
        {
            get { return (double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VerticalOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.Register("VerticalOffset", typeof(double), typeof(Animator), new PropertyMetadata(0.0, OnUpdate));



        public TimeSpan Interval
        {
            get { return (TimeSpan)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Interval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(TimeSpan), typeof(Animator), new PropertyMetadata(TimeSpan.FromSeconds(0.1), OnIntervalChanged));


        public override void OnApplyTemplate()
        {
            _image = GetTemplateChild("PART_Image") as Image;
            _border = GetTemplateChild("PART_Border") as Canvas;
            Loaded += Animator_Loaded;
        }

        void Animator_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer(Interval, DispatcherPriority.Normal, Callback, Dispatcher);
            SetRect();
            Loaded -= Animator_Loaded;
            Unloaded += Animator_Unloaded;
            _timer.Start();

        }

        private void Callback(object sender, EventArgs eventArgs)
        {
            _Hcount++;
            if (_Hcount >= _maxHpieces)
            {
                _Hcount = 0;
                _Vcount++;
                if (_Vcount >= _maxVpieces)
                {
                    _Vcount = 0;
                }
            }
            _image.RenderTransform = new TranslateTransform(-HorizontalOffset * _Hcount, -VerticalOffset * _Vcount);
        }

        void Animator_Unloaded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _timer = null;
            Unloaded -= Animator_Unloaded;
        }

        private void SetRect()
        {
            if (_image != null)
            {
                _border.Clip = new RectangleGeometry(new Rect(0, 0, HorizontalOffset, VerticalOffset));
                _border.Height = VerticalOffset;
                _border.Width = HorizontalOffset;

                if (HorizontalOffset > 0.0)
                    _maxHpieces = Convert.ToInt16(_image.ActualWidth / HorizontalOffset);

                if (VerticalOffset > 0.0)
                    _maxVpieces = Convert.ToInt16(_image.ActualHeight / VerticalOffset);
            }
        }

        private static void OnUpdate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as Animator;
            control.OnUpdate(e);
        }

        private void OnUpdate(DependencyPropertyChangedEventArgs e)
        {
            SetRect();
        }

        private static void OnIntervalChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as Animator;
            if (control != null && control._timer != null)
            {
                control._timer.Stop();
                control._timer.Interval = control.Interval;
                control._timer.Start();
            }
        }
    }
}
