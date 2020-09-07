
namespace FaceTrackingBasics
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using System.Diagnostics;


    public partial class MainWindow : Window
    {
        Boolean buttonEditar = true;
        
        private static readonly int Bgr32BytesPerPixel = (PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
        private readonly KinectSensorChooser sensorChooser = new KinectSensorChooser(); // representa o kinect, conexao com o kinect

        private WriteableBitmap colorImageWritableBitmap;
        private byte[] colorImageData;
        private ColorImageFormat currentColorImageFormat = ColorImageFormat.Undefined;
        private int a;


            public MainWindow()
        {

            InitializeComponent();
            var faceTrackingViewerBinding = new System.Windows.Data.Binding("Kinect")
            {
                Source = sensorChooser

            };
            faceTrackingViewer.SetBinding(FaceTrackingViewer.KinectProperty, faceTrackingViewerBinding);


            sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
        }

        public MainWindow(int a)
        {
            this.a = a;
            InitializeComponent();
            ButtonIniciar.Visibility = Visibility.Visible;
            sensorChooser.Start();
        }

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs kinectChangedEventArgs)
        {
            KinectSensor oldSensor = kinectChangedEventArgs.OldSensor;
            KinectSensor newSensor = kinectChangedEventArgs.NewSensor;


            if (oldSensor != null)
            {
                oldSensor.AllFramesReady -= KinectSensorOnAllFramesReady;
                oldSensor.ColorStream.Disable();
                oldSensor.DepthStream.Disable();
                oldSensor.DepthStream.Range = DepthRange.Default;
                oldSensor.SkeletonStream.Disable();
                oldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                oldSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;

            }

            if (newSensor != null)
            {


                try // habilita a camera principal se tiver um sensor conectado
                {
                    newSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30); //Habilita a camera RGB
                    newSensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30); // Configura a resolução da proximidade 
                    try
                    {
                        // Configura o Kinect para trabalhar no modelo "perto" 
                        newSensor.DepthStream.Range = DepthRange.Near;
                        // Configura o tracking do esquelo para trabalhar 
                        // em um modelo "perto" onde o usuário esteja "sentado" 
                        newSensor.SkeletonStream.EnableTrackingInNearRange = true;
                        newSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    }
                    catch (InvalidOperationException)
                    {
                        newSensor.DepthStream.Range = DepthRange.Default;
                        newSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }

                    newSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    newSensor.SkeletonStream.Enable();  // habilita o rastreio o esqueleto


                    newSensor.AllFramesReady += KinectSensorOnAllFramesReady;
                    //Associo o evento ao AllFrameReady
                    //sensorChooser.Stop(); - NÃO DEU CERTO AQUI


                }

                catch (InvalidOperationException)
                {

                }

            }




        }

        public void WindowClosed(object sender, EventArgs e) // veja o sensor se estiver aberto sem uso
        {
            sensorChooser.Stop();
            faceTrackingViewer.Dispose();


        }



        //A cada vez que o kinect detectar uma imagem ele passará aqui
        private void KinectSensorOnAllFramesReady(object sender, AllFramesReadyEventArgs allFramesReadyEventArgs)
        {

            // Pega o frame de cor
            using (var colorImageFrame = allFramesReadyEventArgs.OpenColorImageFrame())
            {
                // Se não vier nada então sai do metodo
                if (colorImageFrame == null)
                {
                    return;
                }
                // Faça uma cópia do quadro de cores para exibição.
                var haveNewFormat = this.currentColorImageFormat != colorImageFrame.Format;
                if (haveNewFormat)
                {
                    this.currentColorImageFormat = colorImageFrame.Format;
                    this.colorImageData = new byte[colorImageFrame.PixelDataLength]; //  bytes com o tamanho do frame
                    this.colorImageWritableBitmap = new WriteableBitmap(
                    colorImageFrame.Width, colorImageFrame.Height, 96, 96, PixelFormats.Bgr32, null); // cor do fundo da imagem
                    ColorImage.Source = this.colorImageWritableBitmap;
                }

                // Copia os bytes para o this.colorImageData
                colorImageFrame.CopyPixelDataTo(this.colorImageData); // pega o conjunto bytes e transforma em imagem
                this.colorImageWritableBitmap.WritePixels(

                    new Int32Rect(0, 0, colorImageFrame.Width, colorImageFrame.Height),
                    this.colorImageData,
                    colorImageFrame.Width * Bgr32BytesPerPixel,
                    0);

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // inicia quando apaertar o botão iniciar
        {
            sensorChooser.Start();  
            ButtonIniciar.Visibility = Visibility.Hidden;
            ButtonListar.Visibility = Visibility.Hidden;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Form2 form2 = new Form2(buttonEditar);
            form2.Show();


        }
    }



}
