   M S B A M L   `   `   `  ����Q  MFaceTrackingBasics-WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FaceTrackingBasicsFaceTrackingBasics  5   	   #    FaceTrackingBasics.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FaceTrackingBasics     5   	   -   5          �Name$  borde��5   	   $��671.678��5	   	   $��771.424��6    � WindowStartupLocation$ Manual=�6*    � 	Resources 5         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush��%�   &	        &	 #     &	 F     �� 5   
   $ 	#ff6e6e6e��62   �� 5   
   $ 	#ff52318f��64   �� 5   
   $ 	#ff00BCF2��62   5      .��5      � -   5        $��
layoutGrid��5      $��
10 0 10 10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��0,0,-11,20.2q�6!   $
��Left=�67   $	��754��6R   .+�5      �� $
��Left=�6   $��Images\Logo.png��6*   $
��Fill=�6C   $��32��6R   $��81��6^   $��	0,0,0,5.2q�6i   $��Bottom=�6|   �� 5      $��1��6   $��Images\Status.png��6$   $
��None=�6?   $��Center=�6N   $��	280 0 0 5q�6k   $��RightToLeft=�6~   �� 5      -   5        $��Right=�5      $��40��6,   $��60��69   
������ 
������ $��0q�6w    � Cursor$
 Hand��6�   $��	290 0 0 5q�6�   .��5      �� 5      5      (� 5   
   $��1��6    (� Stretch$ Uniform=�6   $��Center=�61   .��5       � -   5        $��MainGrid��5       $	��640��6#   $	��480��6/   .+�5!      �� -   5        $��
ColorImage��5!      +   %FaceTrackingBasics.FaceTrackingViewer  5"      -   5          Name$ faceTrackingViewer��5"   +   5#      5$      �� 5&   
   -   5        $��ButtonListar��5&      $��Edição��6&   $
��Left=�67   $��38��6R   $��445,523.8,0,-48.2q�6^   $��1��6z   $	��Top=�6�   $	��123��6�   ���	#FFFAF9F9$��Center=�6�   $��1q�6�   ���	#FF63C6EB4  .System.Windows.Automation.AutomationProperties   Name$ 	btnListar��6)  	 � BindingGroup	 5'      &   System.Windows.Data.BindingGroup  5(      5*      �� 5,   
   -   5        $��ButtonIniciar��5,      $��Capturar��6'   $
��Left=�6:   $��38��6U   $��601,523.8,0,-48.2q�6a   $��1��6|   $	��Top=�6�   ���	#FFFAF9F9$��Center=�6�   $��1q�6�   ���	#FF63C6EB$ 
btnIniciar��6  $	��123��6F  	 5-        5.      50      54      55      