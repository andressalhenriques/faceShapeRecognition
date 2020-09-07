
namespace FaceTrackingBasics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;

    using System.Windows.Controls;
    using System.Windows.Media;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit.FaceTracking;
    using System.Globalization;
    using System.Linq;
    using Point = System.Windows.Point;

    public partial class FaceTrackingViewer : UserControl, IDisposable
    {
        
        public static readonly DependencyProperty KinectProperty = DependencyProperty.Register(
            "Kinect",
            typeof(KinectSensor),
            typeof(FaceTrackingViewer),
            new PropertyMetadata(
                null, (o, args) => ((FaceTrackingViewer)o).OnSensorChanged((KinectSensor)args.OldValue, (KinectSensor)args.NewValue)));

        private const uint MaxMissedFrames = 100;

        private readonly Dictionary<int, SkeletonFaceTracker> trackedSkeletons = new Dictionary<int, SkeletonFaceTracker>();

        private byte[] colorImage;

        private ColorImageFormat colorImageFormat = ColorImageFormat.Undefined;

        private short[] depthImage;

        private DepthImageFormat depthImageFormat = DepthImageFormat.Undefined;

        private bool disposed;

        private Skeleton[] skeletonData;
        public String formatoRosto;


        public FaceTrackingViewer()
        {
            this.InitializeComponent();


        }

        ~FaceTrackingViewer()
        {
            this.Dispose(false);
        }

        public KinectSensor Kinect
        {
            get
            {
                return (KinectSensor)this.GetValue(KinectProperty);
            }

            set
            {
                this.SetValue(KinectProperty, value);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.ResetFaceTracking();

                this.disposed = true;
            }
        }



        protected override void OnRender(DrawingContext drawingContext) // fazem os pontos aparecerem na tela
        {
            base.OnRender(drawingContext);
            foreach (SkeletonFaceTracker faceInformation in this.trackedSkeletons.Values)
            {
                faceInformation.DrawFaceFlat(drawingContext);
            }
        }




        private void OnAllFramesReady(object sender, AllFramesReadyEventArgs allFramesReadyEventArgs)
        {
            ColorImageFrame colorImageFrame = null;
            DepthImageFrame depthImageFrame = null;
            SkeletonFrame skeletonFrame = null;

            try
            {
                colorImageFrame = allFramesReadyEventArgs.OpenColorImageFrame();
                depthImageFrame = allFramesReadyEventArgs.OpenDepthImageFrame();
                skeletonFrame = allFramesReadyEventArgs.OpenSkeletonFrame();


                if (colorImageFrame == null || depthImageFrame == null || skeletonFrame == null)
                {
                    return;
                }

                // Verifique as mudanças no formato da imagem. O FaceTracker não  lida com isso, então precisamos reiniciar.
                if (this.depthImageFormat != depthImageFrame.Format)
                {
                    this.ResetFaceTracking();
                    this.depthImage = null;
                    this.depthImageFormat = depthImageFrame.Format;
                }

                if (this.colorImageFormat != colorImageFrame.Format)
                {
                    this.ResetFaceTracking();
                    this.colorImage = null;
                    this.colorImageFormat = colorImageFrame.Format;
                }

                // Crie quaisquer buffers para armazenar cópias dos dados com os quais trabalhamos
                if (this.depthImage == null)
                {
                    this.depthImage = new short[depthImageFrame.PixelDataLength];
                }

                if (this.colorImage == null)
                {
                    this.colorImage = new byte[colorImageFrame.PixelDataLength];
                }

                // Obter a informação do esqueleto
                if (this.skeletonData == null || this.skeletonData.Length != skeletonFrame.SkeletonArrayLength)
                {
                    this.skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];
                }

                colorImageFrame.CopyPixelDataTo(this.colorImage);
                depthImageFrame.CopyPixelDataTo(this.depthImage);
                skeletonFrame.CopySkeletonDataTo(this.skeletonData);

                // Atualize a lista de rastreadores e os rastreadores com as informações de quadro atuais
                foreach (Skeleton skeleton in this.skeletonData)
                {

                    if (skeleton.TrackingState == SkeletonTrackingState.Tracked
                        || skeleton.TrackingState == SkeletonTrackingState.PositionOnly)
                    {
                        // Queremos manter um registro de qualquer esqueleto, rastreado ou sem rastreamento.
                        if (!this.trackedSkeletons.ContainsKey(skeleton.TrackingId))
                        {
                            this.trackedSkeletons.Add(skeleton.TrackingId, new SkeletonFaceTracker());
                        }

                        //  a cada rastreador o quadro atualizado.
                        SkeletonFaceTracker skeletonFaceTracker;
                        if (this.trackedSkeletons.TryGetValue(skeleton.TrackingId, out skeletonFaceTracker))
                        {

                            skeletonFaceTracker.OnFrameReady(this.Kinect, colorImageFormat, colorImage, depthImageFormat, depthImage, skeleton);
                            skeletonFaceTracker.LastTrackedFrame = skeletonFrame.FrameNumber;

                        }
                    }


                    
                }
                this.RemoveOldTrackers(skeletonFrame.FrameNumber);

                this.InvalidateVisual();

            }

            finally
            {
                if (colorImageFrame != null)
                {
                    colorImageFrame.Dispose();
                }

                if (depthImageFrame != null)
                {
                    depthImageFrame.Dispose();
                }

                if (skeletonFrame != null)
                {
                    skeletonFrame.Dispose();
                }
            }

        }



        private void OnSensorChanged(KinectSensor oldSensor, KinectSensor newSensor)
        {
            if (oldSensor != null)
            {
                oldSensor.AllFramesReady -= this.OnAllFramesReady;
                this.ResetFaceTracking();
            }

            if (newSensor != null)
            {
                newSensor.AllFramesReady += this.OnAllFramesReady;
            }
        }

        private void RemoveOldTrackers(int currentFrameNumber)
        {
            var trackersToRemove = new List<int>();

            foreach (var tracker in this.trackedSkeletons)
            {
                uint missedFrames = (uint)currentFrameNumber - (uint)tracker.Value.LastTrackedFrame;
                if (missedFrames > MaxMissedFrames)
                {
                    // Houve muitos quadros desde a última vez que vimos este esqueleto
                    trackersToRemove.Add(tracker.Key);
                }
            }

            foreach (int trackingId in trackersToRemove)
            {
                this.RemoveTracker(trackingId);
            }
        }

        private void RemoveTracker(int trackingId)
        {
            this.trackedSkeletons[trackingId].Dispose();
            this.trackedSkeletons.Remove(trackingId);
        }

        private void ResetFaceTracking()
        {
            foreach (int trackingId in new List<int>(this.trackedSkeletons.Keys))
            {
                this.RemoveTracker(trackingId);
            }
        }




        private class SkeletonFaceTracker : IDisposable
        {
            Rosto rosto = new Rosto();
            TipoRosto tipoRosto = new TipoRosto();


            private static FaceTriangle[] faceTriangles;

            private EnumIndexableCollection<FeaturePoint, PointF> facePoints;

            private FaceTracker faceTracker;

            private bool lastFaceTrackSucceeded;

            private SkeletonTrackingState skeletonTrackingState;
            PontosDAO pontosDAO = new PontosDAO();
            Pontos crud = new Pontos();
           // MainWindow au = new MainWindow();

            public int LastTrackedFrame { get; set; }
           // private Button button1 = new Button();



            public void Dispose()
            {
                if (this.faceTracker != null)
                {
                    this.faceTracker.Dispose();
                    this.faceTracker = null;
                }
            }


            public void DrawFaceFlat(DrawingContext drawingContext)
            {
                DateTime _startFaceRecognition = DateTime.MinValue;


                if (!lastFaceTrackSucceeded || skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    _startFaceRecognition = DateTime.MinValue;

                    return;
                }

                var faceModelPts = facePoints.Select(t => new Point(t.X + 0.5f, t.Y + 0.5f)).ToList();
                var faceModelGroup = new GeometryGroup();
                var pointFilter = new List<int> { 1, 3, 9, 10, 13, 27, 30, 32, 38, 46, 63, 64, 65, 113, 117, 93, 99 };


                for (var i = 0; i < pointFilter.Count; i++) // mostra os numeros no rosto
                {
                    int x = pointFilter[i];
                    var geometryGroup = new GeometryGroup();
                    var ellipseGeometry = new EllipseGeometry(faceModelPts[x], 1, 1);

                    var formattedText = new FormattedText(x.ToString(), CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                    new Typeface("Verdana"), 12, Brushes.White);
                    geometryGroup.Children.Add(ellipseGeometry);
                    faceModelGroup.Children.Add(geometryGroup);

                }
                drawingContext.DrawGeometry(Brushes.Yellow, new Pen(Brushes.White, 1.0), faceModelGroup);


                for (var i = 0; i < pointFilter.Count; i++) // mostra os pontos no rosto
                {
                    int x = pointFilter[i];
                    var formattedText = new FormattedText(x.ToString(), CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 10, Brushes.White);
                    drawingContext.DrawText(formattedText, faceModelPts[x]);
                }

                if (_startFaceRecognition == DateTime.MinValue)
                {
                    _startFaceRecognition = DateTime.Now;
                }
                else
                {
                    if (DateTime.Now.Subtract(_startFaceRecognition).TotalSeconds > 5)
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            System.Threading.Thread.Sleep(300);
                            _startFaceRecognition = DateTime.MinValue;

                        }));
                    }
                }
            }


           // private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            internal void OnFrameReady(KinectSensor kinectSensor, ColorImageFormat colorImageFormat, byte[] colorImage, DepthImageFormat depthImageFormat, short[] depthImage, Skeleton skeletonOfInterest)
            {

                TipoRostoDAO tipoRostoDAO = new TipoRostoDAO();
                CalcularLinhadoRosto calcularLinhadoRosto = new CalcularLinhadoRosto();
                CalculoFormatoQueixo calculoFormatoQueixo = new CalculoFormatoQueixo();
                FormatoRosto formatoRosto = new FormatoRosto();

                this.skeletonTrackingState = skeletonOfInterest.TrackingState;

                if (this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    return;
                }


                if (this.faceTracker == null)
                {
                    try
                    {
                        this.faceTracker = new FaceTracker(kinectSensor);
                    }
                    catch (InvalidOperationException)
                    {
                        // During some shutdown scenarios the FaceTracker
                        // is unable to be instantiated.  Catch that exception
                        // and don't track a face.
                        Debug.WriteLine("AllFramesReady - creating a new FaceTracker threw an InvalidOperationException");
                        this.faceTracker = null;

                    }

                }
                
                if (this.faceTracker != null)
                {
                    FaceTrackFrame frame = this.faceTracker.Track(
                    colorImageFormat, colorImage, depthImageFormat, depthImage, skeletonOfInterest);

                    this.lastFaceTrackSucceeded = frame.TrackSuccessful;
                    if (this.lastFaceTrackSucceeded)
                    {
                        if (faceTriangles == null)
                        {
                            faceTriangles = frame.GetTriangles();
                        }

                        this.facePoints = frame.GetProjected3DShape();
                        Console.WriteLine(this.facePoints);

                        for (int i = 0; i < this.facePoints.Count; i++)
                        {
                            Debug.Print("X:{0}, Y:{1} - Type:{2} ", this.facePoints[i].X, facePoints[i].Y, ((FeaturePoint)i).ToString());

                            pontosDAO.PontoSupTesta = this.facePoints[1].Y; // pega o ponto do topo da  testa
                            pontosDAO.PontoInfTesta = this.facePoints[3].Y; // ponto da parte de baixo da testa
                            pontosDAO.PontoEsqTesta = this.facePoints[13].X; // ponto esquerdo da testa
                            pontosDAO.PontoDirTesta = this.facePoints[46].X; // ponto direita da testa
                            pontosDAO.PontoSupQueixo = this.facePoints[9].Y; //pega o ponto do topo da  queixo
                            pontosDAO.PontoInfQueixo = this.facePoints[10].Y; // ponto da parte de baixo da queixo
                            pontosDAO.PontoLatDir = this.facePoints[113].X; // ponto do largura 
                            pontosDAO.PontoLatEsq = this.facePoints[117].X; // ponto do largura
                            pontosDAO.PontoDirQueixo = this.facePoints[32].Y; // ponto do queixo
                            pontosDAO.PontoEsqQueixo = this.facePoints[65].Y; // ponto do queixo
                            pontosDAO.PontoLinhaMaxilarEsq = this.facePoints[30].X; // ponto do mandibula esquerda
                            pontosDAO.PontoLinhaMaxilarDir = this.facePoints[63].X; // ponto do mandibula direita                           
                            pontosDAO.PontoLinhaMaxilarEsqY = this.facePoints[30].Y; // ponto do mandibula direita
                            pontosDAO.PontolinhaBoca = this.facePoints[64].Y; // ponto do labios
                            pontosDAO.PontoMaca = this.facePoints[27].X; // ponto do maca
                            pontosDAO.PontoNariz = this.facePoints[93].X; // ponto do nariz
                            pontosDAO.PontoLinhaAuxiliar = this.facePoints[99].X; // ponto calculo da linha 
                            
                        }

                        Debug.Print("contador:" + pontosDAO.Contador);
                        pontosDAO.Contador++;

                        pontosDAO.TotalPontoSupTesta += pontosDAO.PontoSupTesta;
                        pontosDAO.TotalPontoInfTesta += pontosDAO.PontoInfTesta;
                        pontosDAO.TotalPontoMaca += pontosDAO.PontoMaca;
                        pontosDAO.TotalPontoLatDir += pontosDAO.PontoLatDir;
                        pontosDAO.TotalPontoLatEsq += pontosDAO.PontoLatEsq;
                        pontosDAO.TotalPontolinhaBoca += pontosDAO.PontolinhaBoca;
                        pontosDAO.TotalPontoLinhaMaxilarDir += pontosDAO.PontoLinhaMaxilarDir;
                        pontosDAO.TotalPontoSupQueixo += pontosDAO.PontoSupQueixo;
                        pontosDAO.TotalPontoInfQueixo += pontosDAO.PontoInfQueixo;
                        pontosDAO.TotalPontoDirQueixo += pontosDAO.PontoDirQueixo;
                        pontosDAO.TotalPontoEsqQueixo += pontosDAO.PontoEsqQueixo;
                        pontosDAO.TotalPontoLinhaMaxilarEsqY += pontosDAO.PontoLinhaMaxilarEsqY;
                        pontosDAO.TotalPontoTestEsq += pontosDAO.PontoEsqTesta;
                        pontosDAO.TotalPontoTestDir += pontosDAO.PontoDirTesta;
                        pontosDAO.TotalPontoLinhaMaxilarEsq += pontosDAO.PontoLinhaMaxilarEsq;
                        pontosDAO.TotalPontoNariz += pontosDAO.PontoNariz;
                        pontosDAO.TotalPontoLinhaAuxiliar += pontosDAO.PontoLinhaAuxiliar;
                        //Debug.Print("TotalPontoSupTesta:" + pontosDAO.TotalPontoSupTesta);
                        //Debug.Print("TotalPontoInfTesta:" + pontosDAO.TotalPontoInfTesta);
                        //Debug.Print("TotalPontoMaca:" + pontosDAO.TotalPontoMaca);
                        //Debug.Print("TotalPontoLatDir:" + pontosDAO.TotalPontoLatDir);
                        //Debug.Print("TotalPontoLatEsq:" + pontosDAO.TotalPontoLatEsq);
                        //Debug.Print("TotalPontolinhaBoca:" + pontosDAO.TotalPontolinhaBoca);
                        //Debug.Print("TotalPontoLinhaMaxilarDir:" + pontosDAO.TotalPontoLinhaMaxilarDir);
                        //Debug.Print("TotalPontoSupQueixo:" + pontosDAO.TotalPontoSupQueixo);
                        //Debug.Print("TotalPontoInfQueixo:" + pontosDAO.TotalPontoInfQueixo);
                        //Debug.Print("TotalPontoDirQueixo:" + pontosDAO.TotalPontoDirQueixo);
                        //Debug.Print("TotalPontoEsqQueixo:" + pontosDAO.TotalPontoEsqQueixo);
                        //Debug.Print("TotalPontoLinhaMaxilarEsqY:" + pontosDAO.TotalPontoLinhaMaxilarEsqY);
                        //Debug.Print("TotalPontoTestEsq:" + pontosDAO.TotalPontoTestEsq);
                        //Debug.Print("TotalPontoTestDir:" + pontosDAO.TotalPontoTestDir);
                        //Debug.Print("TotalPontoLinhaMaxilarEsq:" + pontosDAO.TotalPontoLinhaMaxilarEsq);
                        //Debug.Print("TotalPontoNariz:" + pontosDAO.TotalPontoNariz);
                        //Debug.Print("TotalPontoLinha99:" + pontosDAO.TotalPontoLinhaAuxiliar);
                    }



                    if (pontosDAO.Contador == 3)
                    {

                        pontosDAO.TotalPontoSupTesta = pontosDAO.TotalPontoSupTesta / 3;
                        pontosDAO.TotalPontoInfTesta = pontosDAO.TotalPontoInfTesta / 3;
                        pontosDAO.TotalPontoTestEsq = pontosDAO.TotalPontoTestEsq / 3;
                        pontosDAO.TotalPontoTestDir = pontosDAO.TotalPontoTestDir / 3;
                        pontosDAO.TotalPontoSupQueixo = pontosDAO.TotalPontoSupQueixo / 3;
                        pontosDAO.TotalPontoInfQueixo = pontosDAO.TotalPontoInfQueixo / 3;
                        pontosDAO.TotalPontoLatDir = pontosDAO.TotalPontoLatDir / 3;
                        pontosDAO.TotalPontoLatEsq = pontosDAO.TotalPontoLatEsq / 3;
                        pontosDAO.TotalPontoLinhaMaxilarEsq = pontosDAO.TotalPontoLinhaMaxilarEsq / 3;
                        pontosDAO.TotalPontoLinhaMaxilarDir = pontosDAO.TotalPontoLinhaMaxilarDir / 3;
                        pontosDAO.TotalPontoLinhaMaxilarEsqY = pontosDAO.TotalPontoLinhaMaxilarEsqY / 3;
                        pontosDAO.TotalPontolinhaBoca = pontosDAO.TotalPontolinhaBoca / 3;
                        pontosDAO.TotalPontoMaca = pontosDAO.TotalPontoMaca / 3;
                        pontosDAO.TotalPontoNariz = pontosDAO.TotalPontoNariz / 3;
                        pontosDAO.TotalPontoDirQueixo = pontosDAO.TotalPontoDirQueixo / 3;
                        pontosDAO.TotalPontoEsqQueixo = pontosDAO.TotalPontoEsqQueixo / 3;
                        pontosDAO.TotalPontoLinhaAuxiliar = pontosDAO.TotalPontoLinhaAuxiliar / 3;
                        Debug.Print("TotalPontoSupTesta / 3:" + pontosDAO.TotalPontoSupTesta);
                        Debug.Print("TotalPontoInfTesta / 3:" + pontosDAO.TotalPontoInfTesta);
                        Debug.Print("TotalPontoMaca / 3:" + pontosDAO.TotalPontoMaca);
                        Debug.Print("TotalPontoLatDir / 3:" + pontosDAO.TotalPontoLatDir);
                        Debug.Print("TotalPontoLatEsq / 3:" + pontosDAO.TotalPontoLatEsq);
                        Debug.Print("TotalPontolinhaBoca / 3:" + pontosDAO.TotalPontolinhaBoca);
                        Debug.Print("TotalPontoLinhaMaxilarDir / 3:" + pontosDAO.TotalPontoLinhaMaxilarDir);
                        Debug.Print("TotalPontoSupQueixo / 3:" + pontosDAO.TotalPontoSupQueixo);
                        Debug.Print("TotalPontoInfQueixo / 3:" + pontosDAO.TotalPontoInfQueixo);
                        Debug.Print("TotalPontoDirQueixo / 3:" + pontosDAO.TotalPontoDirQueixo);
                        Debug.Print("TotalPontoEsqQueixo / 3:" + pontosDAO.TotalPontoEsqQueixo);
                        Debug.Print("TotalPontoLinhaMaxilarEsqY / 3:" + pontosDAO.TotalPontoLinhaMaxilarEsqY);
                        Debug.Print("TotalPontoTestEsq / 3:" + pontosDAO.TotalPontoTestEsq);
                        Debug.Print("TotalPontoTestDir / 3:" + pontosDAO.TotalPontoTestDir);
                        Debug.Print("TotalPontoLinhaMaxilarEsq / 3:" + pontosDAO.TotalPontoLinhaMaxilarEsq);
                        Debug.Print("TotalPontoNariz / 3:" + pontosDAO.TotalPontoNariz);
                        Debug.Print("TotalPontoLinhaAuxiliar / 3:" + pontosDAO.TotalPontoLinhaAuxiliar);

                        float linha = calcularLinhadoRosto.CalcLinhaRosto(pontosDAO.TotalPontoTestEsq, pontosDAO.TotalPontoLinhaMaxilarEsq, pontosDAO.TotalPontoLinhaAuxiliar);
                        float formatoQueixo = calculoFormatoQueixo.Calculoqueixo(pontosDAO.TotalPontoLinhaMaxilarEsqY, pontosDAO.TotalPontoInfQueixo);

                        // chama a classe que ideitifica o formato do rosto
                        String formato = formatoRosto.Identificar(pontosDAO.TotalPontoSupTesta, pontosDAO.TotalPontoInfTesta, pontosDAO.TotalPontoMaca, pontosDAO.TotalPontoLatDir, pontosDAO.TotalPontoLatEsq, pontosDAO.TotalPontolinhaBoca, pontosDAO.TotalPontoLinhaMaxilarDir, 
                            pontosDAO.TotalPontoSupQueixo, pontosDAO.TotalPontoInfQueixo, pontosDAO.TotalPontoDirQueixo, pontosDAO.TotalPontoEsqQueixo, pontosDAO.TotalPontoLinhaMaxilarEsqY, pontosDAO.TotalPontoTestEsq,
                            pontosDAO.TotalPontoTestDir, pontosDAO.TotalPontoLinhaMaxilarEsq, pontosDAO.TotalPontoNariz, pontosDAO.TotalPontoLinhaAuxiliar, linha, formatoQueixo);

                        //grava no banco
                        crud.InsertPontos(pontosDAO);
                        Debug.Print("formato:" + formato);
                        tipoRosto.InsertTipoRosto(formato);
                        crud.SelectIdPontos();
                        tipoRosto.SelectIdTipoRosto();
                        rosto.InsertRosto();

                        kinectSensor.Stop();
                        var formulario = new Form1(formato);
                        formulario.Show();
         
                    }
                }
         
            }
        }   
    }
}

        
    
